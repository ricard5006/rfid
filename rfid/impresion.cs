using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rfid.entidades;
using rfid.utils;

namespace rfid
{
    public partial class impresion : Form
    {
        private BaseApiService<t020_documentos_resumen> t020_documentos_service;
        private BaseApiService<t012_formatos> t012_formatos_service;
        private BaseApiService<t010_impresora> t010_impresora_service;
        private BaseApiService<t003_epc> t003_epc_service;

        public impresion()
        {
            InitializeComponent();

            this.Location = new Point(170, 0);
            this.Size = new Size(630, 600);

            t020_documentos_service = new BaseApiService<t020_documentos_resumen>($"{config.ApiBaseUrl}documentos.php");
            t012_formatos_service = new BaseApiService<t012_formatos>($"{config.ApiBaseUrl}formatos.php");
            t010_impresora_service = new BaseApiService<t010_impresora>($"{config.ApiBaseUrl}impresora.php");
            t003_epc_service = new BaseApiService<t003_epc>($"{config.ApiBaseUrl}epc.php");

            btBuscar_t020.Click += btsBuscar_t020_Click;
            btnImprimir_t003.Click += btnImprimir_t003_Click;
            this.Shown += impresion_Shown;
        }

        private async void impresion_Shown(object sender, EventArgs e)
        {
            await CargarCombos();
            await BuscarDocumentosAsync();
        }

        private async Task CargarCombos()
        {
            try
            {
                var formatos = await t012_formatos_service.GetAllAsync();
                var activos = formatos.Where(f => f.f012_habilitado == 1).ToList();
                cbFormatos_t012.DisplayMember = "f012_descripcion";
                cbFormatos_t012.ValueMember = "f012_id";
                cbFormatos_t012.DataSource = activos;

                var impresoras = await t010_impresora_service.GetAllAsync();
                var activas = impresoras.Where(i => i.f010_habilitado == 1).ToList();
                cbImpresoras_t010.DisplayMember = "f010_impresora";
                cbImpresoras_t010.ValueMember = "f010_id";
                cbImpresoras_t010.DataSource = activas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btsBuscar_t020_Click(object sender, EventArgs e)
        {
            await BuscarDocumentosAsync();
        }

        private async Task BuscarDocumentosAsync()
        {
            try
            {
                string filtro = ObtenerTextoBusqueda();
                string url = $"{config.ApiBaseUrl}documentos.php";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    url += $"?buscar={Uri.EscapeDataString(filtro)}";
                }

                BaseApiService<t020_documentos_resumen> service = new BaseApiService<t020_documentos_resumen>(url);
                List<t020_documentos_resumen> documentos = await service.GetAllAsync();

                var pendientes = documentos
                    .Where(d => d.cantidad_pendiente_impresion > 0)
                    .ToList();

                dgv_t020_t003.Tag = "documentos";
                dgv_t020_t003.DataSource = pendientes;
                AjustarGrid();
                lbl_info.Visible = true;
                lbl_info.Text = $"Documentos con EPCs pendientes: {pendientes.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnImprimir_t003_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbFormatos_t012.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un formato.", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbImpresoras_t010.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una impresora.", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgv_t020_t003.Tag == null || dgv_t020_t003.Tag.ToString() != "documentos" || dgv_t020_t003.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un documento.", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow fila = dgv_t020_t003.SelectedRows[0];

                if (fila.Cells["f020_id"].Value == null)
                    return;

                int idDocumento = Convert.ToInt32(fila.Cells["f020_id"].Value);
                int pendientes = Convert.ToInt32(fila.Cells["cantidad_pendiente_impresion"].Value);
                int epc_generados = Convert.ToInt32(fila.Cells["cantidad_epc_generada"].Value);

                if (epc_generados == 0)
                {
                    MessageBox.Show("No existen EPCs para imprimir, debe generarlos para este documento.", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (pendientes == 0)
                {
                    MessageBox.Show("No hay EPCs pendientes de imprimir.", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult dr = MessageBox.Show(
                    $"Se imprimiran {pendientes} EPC(s) para el documento {idDocumento}. Continuar?",
                    "Impresion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                btnImprimir_t003.Enabled = false;

                var formato = (t012_formatos)cbFormatos_t012.SelectedItem;
                var impresora = (t010_impresora)cbImpresoras_t010.SelectedItem;

                string url = $"{config.ApiBaseUrl}epc.php?id_documento={idDocumento}&pendientes=1";
                BaseApiService<t003_epc> service = new BaseApiService<t003_epc>(url);
                List<t003_epc> epcsPendientes = await service.GetAllAsync();

                var epcsPorDetalle = epcsPendientes
                    .GroupBy(x => x.f003_id_documento_detalle)
                    .ToDictionary(g => g.Key, g => g.ToList());

                int impresos = 0;
                List<object> epcsActualizar = new List<object>();
                List<object> detallesActualizar = new List<object>();
                string actualizacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                foreach (var grupo in epcsPorDetalle)
                {
                    int contados = 0;

                    foreach (var epc in grupo.Value)
                    {
                        string zpl = formato.f012_formato.Replace("{EPC}", epc.f003_epc);
                        RawPrinterHelper.SendStringToPrinter(impresora.f010_direccion, zpl);

                        epcsActualizar.Add(new
                        {
                            f003_id = epc.f003_id,
                            f003_impreso = 1,
                            f003_actualizacion = actualizacion
                        });

                        contados++;
                        impresos++;
                    }

                    detallesActualizar.Add(new
                    {
                        f021_id = grupo.Key,
                        cantidad = contados,
                        actualizacion = actualizacion
                    });
                }

                if (epcsActualizar.Count > 0)
                {
                    var request = new
                    {
                        epcs = epcsActualizar,
                        detalles = detallesActualizar
                    };

                    var response = await t003_epc_service.UpdateAsync(request);
                }

                MessageBox.Show($"Impresion completada: {impresos} EPC(s).", "Impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await BuscarDocumentosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnImprimir_t003.Enabled = true;
            }
        }

        private string ObtenerTextoBusqueda()
        {
            if (tb_buscar.Text == null || tb_buscar.Text.Trim().Equals("Buscar", StringComparison.OrdinalIgnoreCase))
                return "";

            return tb_buscar.Text.Trim();
        }

        private void AjustarGrid()
        {
            dgv_t020_t003.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_t020_t003.ReadOnly = true;
            dgv_t020_t003.AllowUserToAddRows = false;
            dgv_t020_t003.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgv_t020_t003.Columns.Contains("f020_id"))
                dgv_t020_t003.Columns["f020_id"].HeaderText = "Id";
            if (dgv_t020_t003.Columns.Contains("f020_tipo_documento"))
                dgv_t020_t003.Columns["f020_tipo_documento"].HeaderText = "Tipo";
            if (dgv_t020_t003.Columns.Contains("f020_numero_documento"))
                dgv_t020_t003.Columns["f020_numero_documento"].HeaderText = "Documento";
            if (dgv_t020_t003.Columns.Contains("f020_fecha_documento"))
                dgv_t020_t003.Columns["f020_fecha_documento"].HeaderText = "Fecha";
            if (dgv_t020_t003.Columns.Contains("f020_origen"))
                dgv_t020_t003.Columns["f020_origen"].HeaderText = "Origen";
            if (dgv_t020_t003.Columns.Contains("f020_estado"))
                dgv_t020_t003.Columns["f020_estado"].HeaderText = "Estado";
            if (dgv_t020_t003.Columns.Contains("cantidad_total"))
                dgv_t020_t003.Columns["cantidad_total"].HeaderText = "Cant.";
            if (dgv_t020_t003.Columns.Contains("cantidad_epc_generada"))
                dgv_t020_t003.Columns["cantidad_epc_generada"].HeaderText = "EPC gen.";
            if (dgv_t020_t003.Columns.Contains("cantidad_pendiente_impresion"))
                dgv_t020_t003.Columns["cantidad_pendiente_impresion"].HeaderText = "Pend. impr.";
            if (dgv_t020_t003.Columns.Contains("f020_habilitado"))
                dgv_t020_t003.Columns["f020_habilitado"].Visible = false;
        }

        private void tb_buscar_Enter(object sender, EventArgs e)
        {
            if (tb_buscar.Text == "Buscar")
            {
                tb_buscar.Text = "";
                tb_buscar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void tb_buscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_buscar.Text))
            {
                tb_buscar.Text = "Buscar";
                tb_buscar.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
