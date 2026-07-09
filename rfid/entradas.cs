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

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using rfid.utils;
using System.IO;
using System.Diagnostics;

namespace rfid
{
    public partial class entradas : Form
    {
        private BaseApiService<t0011_barras> t0011_barras_service;
        private BaseApiService<t004_ubicaciones> t004_ubicaciones_Service;
        private BaseApiService<t005_zonas> t005_zonas_service;
        private BaseApiService<t020_documentos> t020_documentos_service;
        private BaseApiService<t003_epc> t003_epc_service;
        public entradas()
        {
            InitializeComponent();

            t0011_barras_service = new BaseApiService<t0011_barras>($"{config.ApiBaseUrl}barras.php");
            t004_ubicaciones_Service = new BaseApiService<t004_ubicaciones>($"{config.ApiBaseUrl}ubicaciones.php");
            t005_zonas_service = new BaseApiService<t005_zonas>($"{config.ApiBaseUrl}zonas.php");
            t020_documentos_service = new BaseApiService<t020_documentos>($"{config.ApiBaseUrl}documentos.php");
            t003_epc_service = new BaseApiService<t003_epc>($"{config.ApiBaseUrl}epc.php");

            this.Location = new Point(170, 0);
            this.Size = new Size(630, 600);

            btsBuscar_t020.Click += btsBuscar_t020_Click;
            dgv_t020.CellDoubleClick += dgv_t020_CellDoubleClick;
            dgv_t020.CellClick += dgv_t020_CellClick;
            this.Shown += entradas_Shown;
        }

        private async void btnGuardar_t020_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t020.Enabled = false;

                await procesarExcel_t020_documentos(op.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnGuardar_t020.Enabled = true;
            }
        }

        public async Task procesarExcel_t020_documentos(string ruta)
        {
            List<t0011_barras> barras = await t0011_barras_service.GetAllAsync();
            List<t004_ubicaciones> ubicaciones = await t004_ubicaciones_Service.GetAllAsync();
            List<t005_zonas> zonas = await t005_zonas_service.GetAllAsync();

            Dictionary<string, int> barrasPorCodigo = barras
                .Where(barra => !string.IsNullOrWhiteSpace(barra.f0011_barra))
                .GroupBy(barra => barra.f0011_barra.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f0011_id, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int> ubicacionesPorCodigo = ubicaciones
                .Where(ubicacion => !string.IsNullOrWhiteSpace(ubicacion.f004_codigo_ubicacion))
                .GroupBy(ubicacion => ubicacion.f004_codigo_ubicacion.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f004_id, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int> zonasPorCodigo = zonas
                .Where(zona => !string.IsNullOrWhiteSpace(zona.f005_id_ubicacion) && !string.IsNullOrWhiteSpace(zona.f005_codigo_zona))
                .GroupBy(zona => CrearLlaveZona(zona.f005_id_ubicacion, zona.f005_codigo_zona), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f005_id, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, DocumentoEntradaCarga> documentosPorLlave = new Dictionary<string, DocumentoEntradaCarga>(StringComparer.OrdinalIgnoreCase);
            int filasOmitidas = 0;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(ruta, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                SharedStringTablePart sharedStringPart = workbookPart.SharedStringTablePart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                bool primeraFila = true;

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    List<string> valores = ObtenerValoresFila(row, sharedStringPart, 8);

                    string tipoDocumento = valores[0];
                    string numeroDocumento = valores[1];
                    string fechaDocumento = NormalizarFechaDocumento(valores[2]);
                    string origen = valores[3];
                    string codigoBarra = valores[4];
                    string codigoUbicacion = valores[5];
                    string codigoZona = valores[6];
                    string valorCantidad = valores[7];

                    if (string.IsNullOrWhiteSpace(tipoDocumento) ||
                        string.IsNullOrWhiteSpace(numeroDocumento) ||
                        string.IsNullOrWhiteSpace(codigoBarra) ||
                        string.IsNullOrWhiteSpace(codigoUbicacion) ||
                        string.IsNullOrWhiteSpace(codigoZona) ||
                        string.IsNullOrWhiteSpace(valorCantidad))
                    {
                        filasOmitidas++;
                        continue;
                    }

                    int idBarra;
                    int idUbicacion;
                    int idZona;
                    int cantidad;

                    if (!barrasPorCodigo.TryGetValue(codigoBarra.Trim(), out idBarra)
                        || !ubicacionesPorCodigo.TryGetValue(codigoUbicacion.Trim(), out idUbicacion)
                        || !zonasPorCodigo.TryGetValue(CrearLlaveZona(idUbicacion.ToString(), codigoZona), out idZona)
                        || !TryParseCantidad(valorCantidad, out cantidad)
                        )
                    {
                        filasOmitidas++;
                        continue;
                    }

                    string llaveDocumento = CrearLlaveDocumento(tipoDocumento, numeroDocumento, fechaDocumento, origen);
                    DocumentoEntradaCarga documentoCarga;

                    if (!documentosPorLlave.TryGetValue(llaveDocumento, out documentoCarga))
                    {
                        documentoCarga = new DocumentoEntradaCarga
                        {
                            documento = new t020_documentos
                            {
                                f020_tipo_documento = tipoDocumento.Trim(),
                                f020_numero_documento = numeroDocumento.Trim(),
                                f020_fecha_documento = fechaDocumento,
                                f020_origen = origen.Trim(),
                                f020_estado = "PENDIENTE",
                                f020_habilitado = 1,
                                f020_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            },
                            detalles = new List<t021_documentos_detalle>()
                        };

                        documentosPorLlave.Add(llaveDocumento, documentoCarga);
                    }

                    documentoCarga.detalles.Add(new t021_documentos_detalle
                    {
                        f021_id_documento = 0,
                        f021_id_barra = idBarra,
                        f021_id_ubicacion = idUbicacion,
                        f021_id_zona = idZona,
                        f021_cantidad = cantidad,
                        f021_cantidad_epc_generada = 0,
                        f021_cantidad_impresa = 0,
                        f021_estado = "PENDIENTE",
                        f021_habilitado = 1,
                        f021_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }

            if (documentosPorLlave.Count > 0)
            {
                await EnviarBatch_t020_documentos(documentosPorLlave.Values.ToList());
            }

            if (filasOmitidas > 0)
            {
                MessageBox.Show($"Cargue terminado. Filas omitidas: {filasOmitidas}. Revise documento, barra, ubicacion, zona y cantidad.");
            }
        }

        private async Task EnviarBatch_t020_documentos(List<DocumentoEntradaCarga> documentos)
        {
            var request = new
            {
                documentos = documentos
            };

            var response = await t020_documentos_service.CreateAsync(request);

            ApiResponse_lblInfo(response);
        }

        private string CrearLlaveDocumento(string tipoDocumento, string numeroDocumento, string fechaDocumento, string origen)
        {
            return $"{tipoDocumento.Trim()}|{numeroDocumento.Trim()}|{fechaDocumento.Trim()}|{origen.Trim()}";
        }

        private string CrearLlaveZona(string codigoUbicacion, string codigoZona)
        {
            return $"{codigoUbicacion.Trim()}|{codigoZona.Trim()}";
        }

        private string NormalizarFechaDocumento(string valorFecha)
        {
            if (string.IsNullOrWhiteSpace(valorFecha))
                return "";

            double fechaOa;
            DateTime fecha;

            if (double.TryParse(valorFecha, out fechaOa) && fechaOa > 0)
            {
                return DateTime.FromOADate(fechaOa).ToString("yyyy-MM-dd");
            }

            if (DateTime.TryParse(valorFecha, out fecha))
            {
                return fecha.ToString("yyyy-MM-dd");
            }

            return valorFecha.Trim();
        }

        private bool TryParseCantidad(string valorCantidad, out int cantidad)
        {
            cantidad = 0;
            decimal cantidadDecimal;

            if (!decimal.TryParse(valorCantidad, out cantidadDecimal))
                return false;

            if (cantidadDecimal <= 0 || cantidadDecimal != Math.Truncate(cantidadDecimal))
                return false;

            cantidad = Convert.ToInt32(cantidadDecimal);
            return true;
        }

        private void ApiResponse_lblInfo(ApiResponse response)
        {
            lbl_info.Text = "";
            lbl_log.Visible = false;
            lbl_info.Visible = false;

            if (response.StatusCode == 200)
            {
                lbl_info.Visible = true;
                lbl_info.Text = "Procesado.";

                string rutaArchivo = "log.txt";
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] -[Success]: " + response.Success.ToString() + " [StatusCode]: " + response.StatusCode.ToString() + " [Content]: " + response.Content.ToString();

                File.AppendAllText(rutaArchivo, mensajeLog + Environment.NewLine);
            }
            else if (response.StatusCode == 500)
            {
                lbl_info.Visible = true;
                lbl_info.Text = "No procesado.";

                string rutaArchivo = "log.txt";
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] -[Success]: " + response.Success.ToString() + " [StatusCode]: " + response.StatusCode.ToString() + " [Content]: " + response.Content.ToString();

                File.AppendAllText(rutaArchivo, mensajeLog + Environment.NewLine);

                lbl_log.Visible = true;

            }
            else
            {

                lbl_log.Visible = true;
                string rutaArchivo = "log.txt";
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] -[Success]: " + response.Success.ToString() + " [StatusCode]: " + response.StatusCode.ToString() + " [Content]: " + response.Content.ToString();

                File.AppendAllText(rutaArchivo, mensajeLog + Environment.NewLine);

            }

        }


        private List<string> ObtenerValoresFila(Row row, SharedStringTablePart sharedStringPart, int totalColumnas)
        {
            List<string> valores = Enumerable.Repeat("", totalColumnas).ToList();

            foreach (Cell cell in row.Elements<Cell>())
            {
                int indice = ObtenerIndiceColumna(cell.CellReference == null ? "" : cell.CellReference.Value);

                if (indice >= 0 && indice < totalColumnas)
                {
                    valores[indice] = ObtenerValorCelda(cell, sharedStringPart).Trim();
                }
            }

            return valores;
        }

        private string ObtenerValorCelda(Cell cell, SharedStringTablePart sharedStringPart)
        {
            if (cell.CellValue == null)
                return "";

            string value = cell.CellValue.InnerText;

            if (cell.DataType != null &&
                cell.DataType == CellValues.SharedString)
            {
                return sharedStringPart
                    .SharedStringTable
                    .ElementAt(int.Parse(value))
                    .InnerText;
            }

            return value;
        }
        private int ObtenerIndiceColumna(string referenciaCelda)
        {
            int indice = 0;

            foreach (char caracter in referenciaCelda)
            {
                if (!char.IsLetter(caracter))
                    break;

                indice = (indice * 26) + (char.ToUpper(caracter) - 'A' + 1);
            }

            return indice - 1;
        }
        private class DocumentoEntradaCarga
        {
            public t020_documentos documento { get; set; }
            public List<t021_documentos_detalle> detalles { get; set; }
        }


        private async void entradas_Shown(object sender, EventArgs e)
        {
            await BuscarDocumentosAsync();
        }

        private async void btsBuscar_t020_Click(object sender, EventArgs e)
        {
            await BuscarDocumentosAsync();
        }

        private async void dgv_t020_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_t020.Tag == null || dgv_t020.Tag.ToString() != "documentos")
                return;

            DataGridViewRow fila = dgv_t020.Rows[e.RowIndex];

            if (fila.Cells["f020_id"].Value == null)
                return;

            int idDocumento = Convert.ToInt32(fila.Cells["f020_id"].Value);
            await VerDetalleDocumentoAsync(idDocumento);
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

                dgv_t020.Tag = "documentos";
                dgv_t020.DataSource = documentos;
                AjustarGridDocumentos();
                lbl_info.Visible = true;
                lbl_info.Text = $"Documentos: {documentos.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task VerDetalleDocumentoAsync(int idDocumento)
        {
            try
            {
                string url = $"{config.ApiBaseUrl}documentos.php?id={idDocumento}&detalle=1";
                BaseApiService<t021_documentos_detalle_consulta> service = new BaseApiService<t021_documentos_detalle_consulta>(url);
                List<t021_documentos_detalle_consulta> detalles = await service.GetAllAsync();

                dgv_t020.Tag = "detalle";
                dgv_t020.DataSource = detalles;
                AjustarGridDetalle();
                lbl_info.Visible = true;
                lbl_info.Text = $"Detalle documento {idDocumento}: {detalles.Count} lineas";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string ObtenerTextoBusqueda()
        {
            if (tb_buscar.Text == null || tb_buscar.Text.Trim().Equals("Buscar", StringComparison.OrdinalIgnoreCase))
                return "";

            return tb_buscar.Text.Trim();
        }

        private void AjustarGridDocumentos()
        {
            dgv_t020.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_t020.ReadOnly = true;
            dgv_t020.AllowUserToAddRows = false;
            dgv_t020.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CambiarHeader("f020_id", "Id");
            CambiarHeader("f020_tipo_documento", "Tipo");
            CambiarHeader("f020_numero_documento", "Documento");
            CambiarHeader("f020_fecha_documento", "Fecha");
            CambiarHeader("f020_origen", "Origen");
            CambiarHeader("f020_estado", "Estado");
            CambiarHeader("cantidad_total", "Cant.");
            CambiarHeader("cantidad_epc_generada", "EPC gen.");
            CambiarHeader("cantidad_impresa", "Impresa");
            CambiarHeader("cantidad_pendiente_epc", "Pend. EPC");
            CambiarHeader("cantidad_pendiente_impresion", "Pend. impr.");
        }

        private void AjustarGridDetalle()
        {
            dgv_t020.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_t020.ReadOnly = true;
            dgv_t020.AllowUserToAddRows = false;
            dgv_t020.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CambiarHeader("f001_codigo_item", "Item");
            CambiarHeader("f001_descripcion", "Descripcion");
            CambiarHeader("f0011_barra", "Barra");
            CambiarHeader("f004_codigo_ubicacion", "Ubicacion");
            CambiarHeader("f005_codigo_zona", "Zona");
            CambiarHeader("f021_cantidad", "Cant.");
            CambiarHeader("f021_cantidad_epc_generada", "EPC gen.");
            CambiarHeader("f021_cantidad_impresa", "Impresa");
            CambiarHeader("cantidad_pendiente_epc", "Pend. EPC");
            CambiarHeader("cantidad_pendiente_impresion", "Pend. impr.");
            CambiarHeader("f021_estado", "Estado");
        }

        private void CambiarHeader(string columna, string texto)
        {
            if (dgv_t020.Columns.Contains(columna))
            {
                dgv_t020.Columns[columna].HeaderText = texto;
            }
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

        private async void btnGenerar_t003_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_t020.Tag == null || dgv_t020.Tag.ToString() != "documentos")
                    return;

                if (dgv_t020.SelectedRows.Count == 0)
                    return;

                DataGridViewRow fila = dgv_t020.SelectedRows[0];

                if (fila.Cells["f020_id"].Value == null)
                    return;

                int idDocumento = Convert.ToInt32(fila.Cells["f020_id"].Value);
                btnGenerar_t003.Enabled = false;

                string url = $"{config.ApiBaseUrl}documentos.php?id={idDocumento}&detalle=1";
                BaseApiService<t021_documentos_detalle_consulta> service = new BaseApiService<t021_documentos_detalle_consulta>(url);
                List<t021_documentos_detalle_consulta> detalles = await service.GetAllAsync();

                var detallesPendientes = detalles.Where(d => d.cantidad_pendiente_epc > 0).ToList();

                if (detallesPendientes.Count == 0)
                {
                    MessageBox.Show("No hay EPCs pendientes por generar para este documento.", "Generar EPC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int totalPendientes = detallesPendientes.Sum(d => d.cantidad_pendiente_epc);

                DialogResult dr = MessageBox.Show(
                    $"Se generaran {totalPendientes} EPC(s) para el documento {idDocumento}. Continuar?",
                    "Generar EPC",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr != DialogResult.Yes)
                    return;

                int ultimoId = await ObtenerUltimoIdEpc();
                List<t003_epc> epcs = new List<t003_epc>();
                List<object> detallesActualizar = new List<object>();
                int contador = 0;
                string creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string actualizacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string epcPrefijo = "30342F01A84D";

                foreach (var detalle in detallesPendientes)
                {
                    int generados = 0;

                    for (int i = 0; i < detalle.cantidad_pendiente_epc; i++)
                    {
                        contador++;
                        long serial = ultimoId + contador;
                        string epcCompleto = epcPrefijo + serial.ToString("X12");

                        epcs.Add(new t003_epc
                        {
                            f003_id_barra = detalle.f021_id_barra,
                            f003_id_documento_detalle = detalle.f021_id,
                            f003_epc = epcCompleto,
                            f003_impreso = 0,
                            f003_habilitado = 1,
                            f003_creacion = creacion
                        });

                        generados++;
                    }

                    detallesActualizar.Add(new
                    {
                        f021_id = detalle.f021_id,
                        cantidad = generados,
                        actualizacion = actualizacion
                    });
                }

                var request = new { epcs = epcs, detalles = detallesActualizar };

                var response = await t003_epc_service.CreateAsync(request);

                if (response.StatusCode == 200)
                {
                    MessageBox.Show($"EPCs generados exitosamente: {totalPendientes}", "Generar EPC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await BuscarDocumentosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al generar EPCs: {response.Content}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar EPCs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerar_t003.Enabled = true;
            }
        }

        private async Task<int> ObtenerUltimoIdEpc()
        {
            try
            {
                string url = $"{config.ApiBaseUrl}epc.php?max=1";
                BaseApiService<t003_epc> service = new BaseApiService<t003_epc>(url);
                List<t003_epc> resultado = await service.GetAllAsync();

                if (resultado != null && resultado.Count > 0)
                {
                    return resultado[0].f003_id;
                }
            }
            catch { }

            return 0;
        }

        private void dgv_t020_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_t020.Tag == null)
            {
                btnGenerar_t003.Enabled = false;
                return;
            }

            if (dgv_t020.Tag.ToString() != "documentos")
            {
                btnGenerar_t003.Enabled = false;
                return;
            }

            DataGridViewRow fila = dgv_t020.Rows[e.RowIndex];

            if (fila.Cells["cantidad_pendiente_epc"].Value == null)
            {
                btnGenerar_t003.Enabled = false;
                return;
            }

            int pendientes = Convert.ToInt32(fila.Cells["cantidad_pendiente_epc"].Value);
            btnGenerar_t003.Enabled = pendientes > 0;
        }
    }
}
