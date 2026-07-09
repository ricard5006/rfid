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

namespace rfid
{
    public partial class configuracion : Form
    {
        private BaseApiService<t002_usuarios> t002_usuario_service;
        private BaseApiService<t010_impresora> t010_impresora_service;
        private BaseApiService<t011_reader> t011_reader_service;
        private BaseApiService<t012_formatos> t012_formatos_service;
        
        //private BaseApiService<t002_perfil> t0021_perfiles_service;
        //private BaseApiService<t002_t003> t002_t003_service;
        public configuracion()
        {
            InitializeComponent();

            this.Location = new Point(170, 0);
            this.Size = new Size(630, 600);

            t002_usuario_service = new BaseApiService<t002_usuarios>($"{config.ApiBaseUrl}usuario.php");
            t010_impresora_service = new BaseApiService<t010_impresora>($"{config.ApiBaseUrl}impresora.php");
            t011_reader_service = new BaseApiService<t011_reader>($"{config.ApiBaseUrl}reader.php");
            t012_formatos_service = new BaseApiService<t012_formatos>($"{config.ApiBaseUrl}formatos.php");

            //t002_perfiles_service = new BaseApiService<t002_perfil>($"{config.ApiBaseUrl}perfiles.php");
            //t002_t003_service = new BaseApiService<t002_t003>($"{config.ApiBaseUrl}perfiles.php");

            btnGuardar_f012.Click += btnGuardar_f012_Click;
            dgv_formatos.CellClick += dgv_formatos_CellClick;

            list_t002_usuarios();
            list_t010_impresora();
            list_t011_reader();
            list_t012_formatos();
            //list_t002_perfiles();
        }

        #region usuarios
        private void btnGuardar_t002_usuarios_Click(object sender, EventArgs e)
        {
            

            if (Tbf001_nombre.Text.ToString() != ""
                //&& Tbf001_email.Text.ToString() != "" 
                && Tbf001_pass.Text.ToString() != ""                 
                //&& Cbf001_perfil.Text.ToString() != ""
                )
            {

                var usuario = new t002_usuarios
                {
                    f002_id = string.IsNullOrWhiteSpace(Tbf001_idUsuario.Text) ? 1 : Convert.ToInt32(Tbf001_idUsuario.Text),                    
                    f002_usuario = Tbf001_nombre.Text.ToString(),
                    //f001_email = Tbf001_email.Text.ToString(),
                    f002_contrasena = Tbf001_pass.Text.ToString(),
                    //f001_perfil = Cbf001_perfil.Text.ToString(),
                    f002_habilitado = ChkHabilitadoUser.Checked ? 1 : 0,
                    f002_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    f002_actualizacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                };

                if (Tbf001_idUsuario.Text.ToString() != "")
                {
                    //var id = Convert.ToInt32(Tbf001_idUsuario.Text.ToString());
                    update_t002_usuario( usuario);

                }
                else
                {
                    new_t002_usuario(usuario);
                }
                

            }
            else
            {

                MessageBox.Show("Campos obligatorios, por favor revisar!");

            }
        }

        private async void list_t002_usuarios()
        {
            var lista = await t002_usuario_service.GetAllAsync();
            DatagvUsuarios.DataSource = lista;
        }

        private async void new_t002_usuario(t002_usuarios usuario)
        {

            await t002_usuario_service.CreateAsync(usuario);

            list_t002_usuarios();
        }

        private async void update_t002_usuario(t002_usuarios usuario) {

            await t002_usuario_service.UpdateAsync(usuario);

            list_t002_usuarios();
        }

        private void DatagvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DatagvUsuarios.Rows[e.RowIndex];

                Tbf001_idUsuario.Text = fila.Cells["f002_id"].Value.ToString();                
                Tbf001_nombre.Text = fila.Cells["f002_usuario"].Value.ToString();
                //Tbf001_email.Text = fila.Cells["f001_email"].Value.ToString();
                ChkHabilitadoUser.Checked = Convert.ToInt32(fila.Cells["f002_habilitado"].Value) == 1;                

            }
        }

        #endregion
        
        #region impresora
        private async void list_t010_impresora() {
            var lista = await t010_impresora_service.GetAllAsync();
            DatagvImpresoras.DataSource = lista;

        }

        private void btnGuardar_t010_impresora_Click(object sender, EventArgs e)
        {
            if(Tbf010_impresora.Text.ToString()!=""
                && Tbf010_direccion.Text.ToString()!=""
                ){

                var impresora = new t010_impresora{
                    f010_id = string.IsNullOrWhiteSpace(Tbf010_id.Text) ? 1 : Convert.ToInt32(Tbf010_id.Text),                     
                    f010_impresora = Tbf010_impresora.Text.ToString(),
                    f010_direccion = Tbf010_direccion.Text.ToString(),
                    f010_habilitado = Chkf010_habilitado.Checked ? 1 : 0,
                    f010_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    f010_actualizacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

               

                if (Tbf010_id.Text.ToString() != "")
                {

                    update_t010_impresora(impresora);

                }
                else
                {
                    new_t010_impresora(impresora);
                }


            }
            else
            {

                MessageBox.Show("Campos obligatorios, por favor revisar!");

            }
        

        }

        private async void update_t010_impresora(t010_impresora impresora)
        {
            await t010_impresora_service.UpdateAsync(impresora);

            list_t010_impresora();
        }

        private async void new_t010_impresora(t010_impresora impresora)
        {

            await t010_impresora_service.CreateAsync(impresora);

            list_t010_impresora();
        }

        private void DatagvImpresoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DatagvImpresoras.Rows[e.RowIndex];
                Tbf010_id.Text = fila.Cells["f010_id"].Value.ToString();
                Tbf010_impresora.Text = fila.Cells["f010_impresora"].Value.ToString();
                Tbf010_direccion.Text = fila.Cells["f010_direccion"].Value.ToString();
                Chkf010_habilitado.Checked = Convert.ToInt32(fila.Cells["f010_habilitado"].Value) == 1;


            }
        }


        #endregion

        #region RFID
        private void btnGuardar_t011_reader_Click(object sender, EventArgs e)
        {
            if (Tbf011_reader.Text.ToString() != ""
              && Tbf011_direccion.Text.ToString() != ""
              && Tbf011_usuario.Text.ToString() != ""
              && Tbf011_contrasena.Text.ToString() != ""
              )
            {

                var reader = new t011_reader
                {
                    f011_id = string.IsNullOrWhiteSpace(Tbf011_id.Text)? 1: Convert.ToInt32(Tbf011_id.Text),
                    f011_reader = Tbf011_reader.Text.ToString(),
                    f011_direccion = Tbf011_direccion.Text.ToString(),
                    f011_usuario = Tbf011_usuario.Text.ToString(),
                    f011_contrasena = Tbf011_contrasena.Text.ToString(),
                    f011_habilitado = Chkf011_habilitado.Checked ? 1 : 0,
                    f011_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    f011_actualizacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };



                if (Tbf011_id.Text.ToString() != "")
                {

                    update_t011_reader(reader);

                }
                else
                {
                    new_t011_reader(reader);
                }


            }
            else
            {

                MessageBox.Show("Campos obligatorios, por favor revisar!");

            }
        }

        private async void list_t011_reader()
        {
            var lista = await t011_reader_service.GetAllAsync();
            DatagvReader.DataSource = lista;

        }
        private async void update_t011_reader(t011_reader reader) {
            await t011_reader_service.UpdateAsync(reader);

            list_t011_reader();
        }
        private async void new_t011_reader(t011_reader reader) {
            await t011_reader_service.CreateAsync(reader);

            list_t011_reader();
        }

        private void DatagvReader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DatagvReader.Rows[e.RowIndex];
                Tbf011_id.Text = fila.Cells["f011_id"].Value.ToString();
                Tbf011_reader.Text = fila.Cells["f011_reader"].Value.ToString();
                Tbf011_direccion.Text = fila.Cells["f011_direccion"].Value.ToString();
                Tbf011_usuario.Text = fila.Cells["f011_usuario"].Value.ToString();
                Tbf011_contrasena.Text = fila.Cells["f011_contrasena"].Value.ToString();
                Chkf011_habilitado.Checked = Convert.ToInt32(fila.Cells["f011_habilitado"].Value) == 1;


            }
        }

        #endregion

        #region perfiles
        //private async void list_t002_perfiles()
        //{
        //    var lista = await t002_perfiles_service.GetAllAsync();
        //    cbf002_Perfil.DataSource = lista;
        //    cbf002_Perfil.ValueMember = "f002_id";
        //    cbf002_Perfil.DisplayMember = "f002_descripcion";

        //    Cbf001_perfil.DataSource = lista;
        //    Cbf001_perfil.ValueMember = "f002_id";
        //    Cbf001_perfil.DisplayMember = "f002_descripcion";

        //}

        //private async void find_t004_perfil_modulos(int id_t002)
        //{

        //    var lista = await t002_t003_service.GetByIdAsync(id_t002);


        //    //        var perfiles = lista
        //    //    .GroupBy(p => new { p.Id_Perfil, p.Nombre_Perfil, p.t004_habilitado })
        //    //    .Select(g => new t002_perfil
        //    //        {
        //    //    f002_id = g.Key.Id_Perfil,
        //    //    f002_descripcion = g.Key.Nombre_Perfil,
        //    //    t003_modulos = g.Select(m => new t003_modulos
        //    //    {
        //    //        f003_id = m.Id_Modulo,
        //    //        f003_descripcion = m.Nombre_Modulo

        //    //    }).ToList()


        //    //}).ToList();

        //    chk_mod_inventario.Checked = false;
        //    chk_mod_impresion.Checked = false;
        //    chk_mod_informes.Checked = false;
        //    chk_mod_configuracion.Checked = false;

        //    foreach (var m in lista)
        //    {
        //        if (cbf002_Perfil.Text == m.Nombre_Perfil)
        //        {

        //            switch (m.Nombre_Modulo)
        //            {

        //                case "Inventario":
        //                    if (m.t004_habilitado == "True")
        //                        chk_mod_inventario.Checked = true;
        //                    break;

        //                case "Impresion":
        //                    if (m.t004_habilitado == "True")
        //                        chk_mod_impresion.Checked = true;
        //                    break;

        //                case "Informes":
        //                    if (m.t004_habilitado == "True")
        //                        chk_mod_informes.Checked = true;
        //                    break;

        //                case "Configuracion":
        //                    if (m.t004_habilitado == "True")
        //                        chk_mod_configuracion.Checked = true;
        //                    break;

        //            }
        //        }
        //    }




        //}

        //private async void new_t002_perfil(t002_perfil perfil)
        //{
        //    await t002_perfiles_service.CreateAsync(perfil);

        //    list_t002_perfiles();
        //}

        //private async void update_t002_perfil()
        //{

        //}

        //private void btnGuardar_t002_perfiles_Click(object sender, EventArgs e)
        //{
        //    if (cbf002_Perfil.Text.ToString() != "")
        //    {
        //        var perfil = new t002_perfil
        //        {
        //            f002_descripcion = cbf002_Perfil.Text.ToString(),
        //            f002_fecha_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        //        };
        //        new_t002_perfil(perfil);
        //    }
        //}

        //private void cbf002_Perfil_TextChanged(object sender, EventArgs e)
        //{
        //    chk_mod_inventario.Enabled = true;
        //    chk_mod_impresion.Enabled = true;
        //    chk_mod_informes.Enabled = true;
        //    chk_mod_configuracion.Enabled = true;

        //}

        //private void cbf002_Perfil_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    var b = Convert.ToInt32(cbf002_Perfil.SelectedValue);
        //    find_t004_perfil_modulos(b);
        //}

        #endregion

        #region formatos
        private void btnGuardar_f012_Click(object sender, EventArgs e)
        {
            if (tbf012_descripcion.Text.ToString() != ""
                && tbf012_formato.Text.ToString() != ""
                )
            {
                var formato = new t012_formatos
                {
                    f012_id = string.IsNullOrWhiteSpace(tbf012_id.Text) ? 1 : Convert.ToInt32(tbf012_id.Text),
                    f012_descripcion = tbf012_descripcion.Text.ToString(),
                    f012_formato = tbf012_formato.Text.ToString(),
                    f012_habilitado = chkf012_habilitado.Checked ? 1 : 0,
                    f012_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    f012_actualizacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

                if (tbf012_id.Text.ToString() != "")
                {
                    update_t012_formatos(formato);
                }
                else
                {
                    new_t012_formatos(formato);
                }
            }
            else
            {
                MessageBox.Show("Campos obligatorios, por favor revisar!");
            }
        }

        private async void list_t012_formatos()
        {
            var lista = await t012_formatos_service.GetAllAsync();
            dgv_formatos.DataSource = lista;
        }

        private async void new_t012_formatos(t012_formatos formato)
        {
            await t012_formatos_service.CreateAsync(formato);
            list_t012_formatos();
        }

        private async void update_t012_formatos(t012_formatos formato)
        {
            await t012_formatos_service.UpdateAsync(formato);
            list_t012_formatos();
        }

        private void dgv_formatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv_formatos.Rows[e.RowIndex];
                tbf012_id.Text = fila.Cells["f012_id"].Value.ToString();
                tbf012_descripcion.Text = fila.Cells["f012_descripcion"].Value.ToString();
                tbf012_formato.Text = fila.Cells["f012_formato"].Value.ToString();
                chkf012_habilitado.Checked = Convert.ToInt32(fila.Cells["f012_habilitado"].Value) == 1;
            }
        }
        #endregion

        private void configuracion_Load(object sender, EventArgs e)
        {

        }

        
    }
}
