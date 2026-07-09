namespace rfid
{
    partial class configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TcContenedor = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.ChkHabilitadoUser = new System.Windows.Forms.CheckBox();
            this.DatagvUsuarios = new System.Windows.Forms.DataGridView();
            this.Cbf001_perfil = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Tbf001_pass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tbf001_email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Tbf001_nombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Tbf001_idUsuario = new System.Windows.Forms.TextBox();
            this.btnGuardar_t002_usuarios = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPerfiles = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chk_mod_configuracion = new System.Windows.Forms.CheckBox();
            this.chk_mod_informes = new System.Windows.Forms.CheckBox();
            this.chk_mod_impresion = new System.Windows.Forms.CheckBox();
            this.chk_mod_inventario = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardar_t002_perfiles = new System.Windows.Forms.Button();
            this.tabImpresora = new System.Windows.Forms.TabPage();
            this.Tbf010_id = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DatagvImpresoras = new System.Windows.Forms.DataGridView();
            this.Chkf010_habilitado = new System.Windows.Forms.CheckBox();
            this.Tbf010_direccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tbf010_impresora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar_t010_impresora = new System.Windows.Forms.Button();
            this.tabRFID = new System.Windows.Forms.TabPage();
            this.Tbf011_id = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DatagvReader = new System.Windows.Forms.DataGridView();
            this.Tbf011_contrasena = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tbf011_usuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Chkf011_habilitado = new System.Windows.Forms.CheckBox();
            this.Tbf011_direccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tbf011_reader = new System.Windows.Forms.TextBox();
            this.btnGuardar_t011_reader = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAplicacion = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.tabFormatos = new System.Windows.Forms.TabPage();
            this.btnGuardar_f012 = new System.Windows.Forms.Button();
            this.tbf012_id = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkf012_habilitado = new System.Windows.Forms.CheckBox();
            this.tbf012_descripcion = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbf012_formato = new System.Windows.Forms.TextBox();
            this.dgv_formatos = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.TcContenedor.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagvUsuarios)).BeginInit();
            this.tabPerfiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabImpresora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagvImpresoras)).BeginInit();
            this.tabRFID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagvReader)).BeginInit();
            this.tabAplicacion.SuspendLayout();
            this.tabFormatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_formatos)).BeginInit();
            this.SuspendLayout();
            // 
            // TcContenedor
            // 
            this.TcContenedor.Controls.Add(this.tabUsers);
            this.TcContenedor.Controls.Add(this.tabPerfiles);
            this.TcContenedor.Controls.Add(this.tabImpresora);
            this.TcContenedor.Controls.Add(this.tabRFID);
            this.TcContenedor.Controls.Add(this.tabAplicacion);
            this.TcContenedor.Controls.Add(this.tabFormatos);
            this.TcContenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TcContenedor.ItemSize = new System.Drawing.Size(1, 20);
            this.TcContenedor.Location = new System.Drawing.Point(0, 0);
            this.TcContenedor.Name = "TcContenedor";
            this.TcContenedor.SelectedIndex = 0;
            this.TcContenedor.Size = new System.Drawing.Size(584, 592);
            this.TcContenedor.TabIndex = 4;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.ChkHabilitadoUser);
            this.tabUsers.Controls.Add(this.DatagvUsuarios);
            this.tabUsers.Controls.Add(this.Cbf001_perfil);
            this.tabUsers.Controls.Add(this.label11);
            this.tabUsers.Controls.Add(this.Tbf001_pass);
            this.tabUsers.Controls.Add(this.label10);
            this.tabUsers.Controls.Add(this.Tbf001_email);
            this.tabUsers.Controls.Add(this.label9);
            this.tabUsers.Controls.Add(this.Tbf001_nombre);
            this.tabUsers.Controls.Add(this.label8);
            this.tabUsers.Controls.Add(this.Tbf001_idUsuario);
            this.tabUsers.Controls.Add(this.btnGuardar_t002_usuarios);
            this.tabUsers.Controls.Add(this.label7);
            this.tabUsers.Location = new System.Drawing.Point(4, 24);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(576, 564);
            this.tabUsers.TabIndex = 4;
            this.tabUsers.Text = "Usuarios";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // ChkHabilitadoUser
            // 
            this.ChkHabilitadoUser.AutoSize = true;
            this.ChkHabilitadoUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkHabilitadoUser.Location = new System.Drawing.Point(244, 42);
            this.ChkHabilitadoUser.Name = "ChkHabilitadoUser";
            this.ChkHabilitadoUser.Size = new System.Drawing.Size(112, 23);
            this.ChkHabilitadoUser.TabIndex = 13;
            this.ChkHabilitadoUser.Text = "Habilitado";
            this.ChkHabilitadoUser.UseVisualStyleBackColor = true;
            // 
            // DatagvUsuarios
            // 
            this.DatagvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatagvUsuarios.Location = new System.Drawing.Point(8, 300);
            this.DatagvUsuarios.Name = "DatagvUsuarios";
            this.DatagvUsuarios.Size = new System.Drawing.Size(560, 199);
            this.DatagvUsuarios.TabIndex = 12;
            this.DatagvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagvUsuarios_CellClick);
            // 
            // Cbf001_perfil
            // 
            this.Cbf001_perfil.Enabled = false;
            this.Cbf001_perfil.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbf001_perfil.FormattingEnabled = true;
            this.Cbf001_perfil.Location = new System.Drawing.Point(244, 246);
            this.Cbf001_perfil.Name = "Cbf001_perfil";
            this.Cbf001_perfil.Size = new System.Drawing.Size(300, 27);
            this.Cbf001_perfil.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(139, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "*Perfil:";
            // 
            // Tbf001_pass
            // 
            this.Tbf001_pass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf001_pass.Location = new System.Drawing.Point(244, 199);
            this.Tbf001_pass.Name = "Tbf001_pass";
            this.Tbf001_pass.PasswordChar = '*';
            this.Tbf001_pass.Size = new System.Drawing.Size(300, 27);
            this.Tbf001_pass.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(90, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "*Contrasena:";
            // 
            // Tbf001_email
            // 
            this.Tbf001_email.Enabled = false;
            this.Tbf001_email.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf001_email.Location = new System.Drawing.Point(244, 154);
            this.Tbf001_email.Name = "Tbf001_email";
            this.Tbf001_email.Size = new System.Drawing.Size(300, 27);
            this.Tbf001_email.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(141, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 19);
            this.label9.TabIndex = 6;
            this.label9.Text = "E-Mail:";
            // 
            // Tbf001_nombre
            // 
            this.Tbf001_nombre.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf001_nombre.Location = new System.Drawing.Point(244, 111);
            this.Tbf001_nombre.Name = "Tbf001_nombre";
            this.Tbf001_nombre.Size = new System.Drawing.Size(300, 27);
            this.Tbf001_nombre.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "*Nombre Usuario:";
            // 
            // Tbf001_idUsuario
            // 
            this.Tbf001_idUsuario.Enabled = false;
            this.Tbf001_idUsuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf001_idUsuario.Location = new System.Drawing.Point(244, 71);
            this.Tbf001_idUsuario.Name = "Tbf001_idUsuario";
            this.Tbf001_idUsuario.Size = new System.Drawing.Size(300, 27);
            this.Tbf001_idUsuario.TabIndex = 2;
            // 
            // btnGuardar_t002_usuarios
            // 
            this.btnGuardar_t002_usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_t002_usuarios.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_t002_usuarios.Location = new System.Drawing.Point(468, 515);
            this.btnGuardar_t002_usuarios.Name = "btnGuardar_t002_usuarios";
            this.btnGuardar_t002_usuarios.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar_t002_usuarios.TabIndex = 1;
            this.btnGuardar_t002_usuarios.Text = "Guardar";
            this.btnGuardar_t002_usuarios.UseVisualStyleBackColor = true;
            this.btnGuardar_t002_usuarios.Click += new System.EventHandler(this.btnGuardar_t002_usuarios_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(165, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "*Id:";
            // 
            // tabPerfiles
            // 
            this.tabPerfiles.Controls.Add(this.checkBox1);
            this.tabPerfiles.Controls.Add(this.dataGridView1);
            this.tabPerfiles.Controls.Add(this.textBox1);
            this.tabPerfiles.Controls.Add(this.textBox2);
            this.tabPerfiles.Controls.Add(this.label17);
            this.tabPerfiles.Controls.Add(this.label14);
            this.tabPerfiles.Controls.Add(this.chk_mod_configuracion);
            this.tabPerfiles.Controls.Add(this.chk_mod_informes);
            this.tabPerfiles.Controls.Add(this.chk_mod_impresion);
            this.tabPerfiles.Controls.Add(this.chk_mod_inventario);
            this.tabPerfiles.Controls.Add(this.label13);
            this.tabPerfiles.Controls.Add(this.btnGuardar_t002_perfiles);
            this.tabPerfiles.Location = new System.Drawing.Point(4, 24);
            this.tabPerfiles.Name = "tabPerfiles";
            this.tabPerfiles.Size = new System.Drawing.Size(576, 564);
            this.tabPerfiles.TabIndex = 5;
            this.tabPerfiles.Text = "Perfiles";
            this.tabPerfiles.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(235, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 23);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Habilitado";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 199);
            this.dataGridView1.TabIndex = 29;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(235, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 27);
            this.textBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(235, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 27);
            this.textBox2.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(156, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 19);
            this.label17.TabIndex = 19;
            this.label17.Text = "*Id:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(68, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 19);
            this.label14.TabIndex = 18;
            this.label14.Text = "Visibilidad de modulos:";
            // 
            // chk_mod_configuracion
            // 
            this.chk_mod_configuracion.AutoSize = true;
            this.chk_mod_configuracion.Enabled = false;
            this.chk_mod_configuracion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mod_configuracion.Location = new System.Drawing.Point(72, 255);
            this.chk_mod_configuracion.Name = "chk_mod_configuracion";
            this.chk_mod_configuracion.Size = new System.Drawing.Size(140, 23);
            this.chk_mod_configuracion.TabIndex = 17;
            this.chk_mod_configuracion.Text = "Configuracion";
            this.chk_mod_configuracion.UseVisualStyleBackColor = true;
            // 
            // chk_mod_informes
            // 
            this.chk_mod_informes.AutoSize = true;
            this.chk_mod_informes.Enabled = false;
            this.chk_mod_informes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mod_informes.Location = new System.Drawing.Point(365, 211);
            this.chk_mod_informes.Name = "chk_mod_informes";
            this.chk_mod_informes.Size = new System.Drawing.Size(101, 23);
            this.chk_mod_informes.TabIndex = 16;
            this.chk_mod_informes.Text = "Informes";
            this.chk_mod_informes.UseVisualStyleBackColor = true;
            // 
            // chk_mod_impresion
            // 
            this.chk_mod_impresion.AutoSize = true;
            this.chk_mod_impresion.Enabled = false;
            this.chk_mod_impresion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mod_impresion.Location = new System.Drawing.Point(211, 211);
            this.chk_mod_impresion.Name = "chk_mod_impresion";
            this.chk_mod_impresion.Size = new System.Drawing.Size(110, 23);
            this.chk_mod_impresion.TabIndex = 15;
            this.chk_mod_impresion.Text = "Impresion";
            this.chk_mod_impresion.UseVisualStyleBackColor = true;
            // 
            // chk_mod_inventario
            // 
            this.chk_mod_inventario.AutoSize = true;
            this.chk_mod_inventario.Enabled = false;
            this.chk_mod_inventario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mod_inventario.Location = new System.Drawing.Point(72, 211);
            this.chk_mod_inventario.Name = "chk_mod_inventario";
            this.chk_mod_inventario.Size = new System.Drawing.Size(113, 23);
            this.chk_mod_inventario.TabIndex = 14;
            this.chk_mod_inventario.Text = "Inventario";
            this.chk_mod_inventario.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(139, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 19);
            this.label13.TabIndex = 12;
            this.label13.Text = "Perfil:";
            // 
            // btnGuardar_t002_perfiles
            // 
            this.btnGuardar_t002_perfiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_t002_perfiles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_t002_perfiles.Location = new System.Drawing.Point(468, 515);
            this.btnGuardar_t002_perfiles.Name = "btnGuardar_t002_perfiles";
            this.btnGuardar_t002_perfiles.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar_t002_perfiles.TabIndex = 5;
            this.btnGuardar_t002_perfiles.Text = "Guardar";
            this.btnGuardar_t002_perfiles.UseVisualStyleBackColor = true;
            // 
            // tabImpresora
            // 
            this.tabImpresora.Controls.Add(this.Tbf010_id);
            this.tabImpresora.Controls.Add(this.label12);
            this.tabImpresora.Controls.Add(this.DatagvImpresoras);
            this.tabImpresora.Controls.Add(this.Chkf010_habilitado);
            this.tabImpresora.Controls.Add(this.Tbf010_direccion);
            this.tabImpresora.Controls.Add(this.label5);
            this.tabImpresora.Controls.Add(this.Tbf010_impresora);
            this.tabImpresora.Controls.Add(this.label6);
            this.tabImpresora.Controls.Add(this.btnGuardar_t010_impresora);
            this.tabImpresora.Location = new System.Drawing.Point(4, 24);
            this.tabImpresora.Name = "tabImpresora";
            this.tabImpresora.Size = new System.Drawing.Size(576, 564);
            this.tabImpresora.TabIndex = 6;
            this.tabImpresora.Text = "Impresora";
            this.tabImpresora.UseVisualStyleBackColor = true;
            // 
            // Tbf010_id
            // 
            this.Tbf010_id.Enabled = false;
            this.Tbf010_id.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf010_id.Location = new System.Drawing.Point(244, 76);
            this.Tbf010_id.Name = "Tbf010_id";
            this.Tbf010_id.Size = new System.Drawing.Size(300, 27);
            this.Tbf010_id.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(171, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 19);
            this.label12.TabIndex = 29;
            this.label12.Text = "*Id:";
            // 
            // DatagvImpresoras
            // 
            this.DatagvImpresoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatagvImpresoras.Location = new System.Drawing.Point(8, 299);
            this.DatagvImpresoras.Name = "DatagvImpresoras";
            this.DatagvImpresoras.Size = new System.Drawing.Size(560, 199);
            this.DatagvImpresoras.TabIndex = 28;
            this.DatagvImpresoras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagvImpresoras_CellClick);
            // 
            // Chkf010_habilitado
            // 
            this.Chkf010_habilitado.AutoSize = true;
            this.Chkf010_habilitado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkf010_habilitado.Location = new System.Drawing.Point(244, 47);
            this.Chkf010_habilitado.Name = "Chkf010_habilitado";
            this.Chkf010_habilitado.Size = new System.Drawing.Size(112, 23);
            this.Chkf010_habilitado.TabIndex = 27;
            this.Chkf010_habilitado.Text = "Habilitado";
            this.Chkf010_habilitado.UseVisualStyleBackColor = true;
            // 
            // Tbf010_direccion
            // 
            this.Tbf010_direccion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf010_direccion.Location = new System.Drawing.Point(244, 153);
            this.Tbf010_direccion.Name = "Tbf010_direccion";
            this.Tbf010_direccion.Size = new System.Drawing.Size(300, 27);
            this.Tbf010_direccion.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(170, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "*IP:";
            // 
            // Tbf010_impresora
            // 
            this.Tbf010_impresora.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf010_impresora.Location = new System.Drawing.Point(244, 115);
            this.Tbf010_impresora.Name = "Tbf010_impresora";
            this.Tbf010_impresora.Size = new System.Drawing.Size(300, 27);
            this.Tbf010_impresora.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(99, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "*Dispositivo:";
            // 
            // btnGuardar_t010_impresora
            // 
            this.btnGuardar_t010_impresora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_t010_impresora.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_t010_impresora.Location = new System.Drawing.Point(468, 515);
            this.btnGuardar_t010_impresora.Name = "btnGuardar_t010_impresora";
            this.btnGuardar_t010_impresora.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar_t010_impresora.TabIndex = 21;
            this.btnGuardar_t010_impresora.Text = "Guardar";
            this.btnGuardar_t010_impresora.UseVisualStyleBackColor = true;
            this.btnGuardar_t010_impresora.Click += new System.EventHandler(this.btnGuardar_t010_impresora_Click);
            // 
            // tabRFID
            // 
            this.tabRFID.Controls.Add(this.Tbf011_id);
            this.tabRFID.Controls.Add(this.label15);
            this.tabRFID.Controls.Add(this.DatagvReader);
            this.tabRFID.Controls.Add(this.Tbf011_contrasena);
            this.tabRFID.Controls.Add(this.label4);
            this.tabRFID.Controls.Add(this.Tbf011_usuario);
            this.tabRFID.Controls.Add(this.label3);
            this.tabRFID.Controls.Add(this.Chkf011_habilitado);
            this.tabRFID.Controls.Add(this.Tbf011_direccion);
            this.tabRFID.Controls.Add(this.label1);
            this.tabRFID.Controls.Add(this.Tbf011_reader);
            this.tabRFID.Controls.Add(this.btnGuardar_t011_reader);
            this.tabRFID.Controls.Add(this.label2);
            this.tabRFID.Location = new System.Drawing.Point(4, 24);
            this.tabRFID.Name = "tabRFID";
            this.tabRFID.Size = new System.Drawing.Size(576, 564);
            this.tabRFID.TabIndex = 7;
            this.tabRFID.Text = "RFID";
            this.tabRFID.UseVisualStyleBackColor = true;
            // 
            // Tbf011_id
            // 
            this.Tbf011_id.Enabled = false;
            this.Tbf011_id.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf011_id.Location = new System.Drawing.Point(233, 75);
            this.Tbf011_id.Name = "Tbf011_id";
            this.Tbf011_id.Size = new System.Drawing.Size(300, 27);
            this.Tbf011_id.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(160, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 19);
            this.label15.TabIndex = 32;
            this.label15.Text = "*Id:";
            // 
            // DatagvReader
            // 
            this.DatagvReader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatagvReader.Location = new System.Drawing.Point(8, 310);
            this.DatagvReader.Name = "DatagvReader";
            this.DatagvReader.Size = new System.Drawing.Size(560, 199);
            this.DatagvReader.TabIndex = 25;
            this.DatagvReader.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagvReader_CellClick);
            // 
            // Tbf011_contrasena
            // 
            this.Tbf011_contrasena.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf011_contrasena.Location = new System.Drawing.Point(233, 213);
            this.Tbf011_contrasena.Name = "Tbf011_contrasena";
            this.Tbf011_contrasena.Size = new System.Drawing.Size(300, 27);
            this.Tbf011_contrasena.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "*Contraseña:";
            // 
            // Tbf011_usuario
            // 
            this.Tbf011_usuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf011_usuario.Location = new System.Drawing.Point(233, 180);
            this.Tbf011_usuario.Name = "Tbf011_usuario";
            this.Tbf011_usuario.Size = new System.Drawing.Size(300, 27);
            this.Tbf011_usuario.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "*Usuario:";
            // 
            // Chkf011_habilitado
            // 
            this.Chkf011_habilitado.AutoSize = true;
            this.Chkf011_habilitado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkf011_habilitado.Location = new System.Drawing.Point(233, 35);
            this.Chkf011_habilitado.Name = "Chkf011_habilitado";
            this.Chkf011_habilitado.Size = new System.Drawing.Size(112, 23);
            this.Chkf011_habilitado.TabIndex = 20;
            this.Chkf011_habilitado.Text = "Habilitado";
            this.Chkf011_habilitado.UseVisualStyleBackColor = true;
            // 
            // Tbf011_direccion
            // 
            this.Tbf011_direccion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf011_direccion.Location = new System.Drawing.Point(233, 147);
            this.Tbf011_direccion.Name = "Tbf011_direccion";
            this.Tbf011_direccion.Size = new System.Drawing.Size(300, 27);
            this.Tbf011_direccion.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "*IP:";
            // 
            // Tbf011_reader
            // 
            this.Tbf011_reader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbf011_reader.Location = new System.Drawing.Point(233, 112);
            this.Tbf011_reader.Name = "Tbf011_reader";
            this.Tbf011_reader.Size = new System.Drawing.Size(300, 27);
            this.Tbf011_reader.TabIndex = 16;
            // 
            // btnGuardar_t011_reader
            // 
            this.btnGuardar_t011_reader.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_t011_reader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_t011_reader.Location = new System.Drawing.Point(468, 515);
            this.btnGuardar_t011_reader.Name = "btnGuardar_t011_reader";
            this.btnGuardar_t011_reader.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar_t011_reader.TabIndex = 15;
            this.btnGuardar_t011_reader.Text = "Guardar";
            this.btnGuardar_t011_reader.UseVisualStyleBackColor = true;
            this.btnGuardar_t011_reader.Click += new System.EventHandler(this.btnGuardar_t011_reader_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "*Dispositivo:";
            // 
            // tabAplicacion
            // 
            this.tabAplicacion.Controls.Add(this.button7);
            this.tabAplicacion.Location = new System.Drawing.Point(4, 24);
            this.tabAplicacion.Name = "tabAplicacion";
            this.tabAplicacion.Size = new System.Drawing.Size(576, 564);
            this.tabAplicacion.TabIndex = 8;
            this.tabAplicacion.Text = "Aplicacion";
            this.tabAplicacion.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(468, 515);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 40);
            this.button7.TabIndex = 18;
            this.button7.Text = "Guardar";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // tabFormatos
            // 
            this.tabFormatos.Controls.Add(this.label19);
            this.tabFormatos.Controls.Add(this.dgv_formatos);
            this.tabFormatos.Controls.Add(this.tbf012_formato);
            this.tabFormatos.Controls.Add(this.tbf012_id);
            this.tabFormatos.Controls.Add(this.label16);
            this.tabFormatos.Controls.Add(this.chkf012_habilitado);
            this.tabFormatos.Controls.Add(this.tbf012_descripcion);
            this.tabFormatos.Controls.Add(this.label18);
            this.tabFormatos.Controls.Add(this.btnGuardar_f012);
            this.tabFormatos.Location = new System.Drawing.Point(4, 24);
            this.tabFormatos.Name = "tabFormatos";
            this.tabFormatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabFormatos.Size = new System.Drawing.Size(576, 564);
            this.tabFormatos.TabIndex = 9;
            this.tabFormatos.Text = "Formatos";
            this.tabFormatos.UseVisualStyleBackColor = true;
            // 
            // btnGuardar_f012
            // 
            this.btnGuardar_f012.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_f012.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_f012.Location = new System.Drawing.Point(468, 515);
            this.btnGuardar_f012.Name = "btnGuardar_f012";
            this.btnGuardar_f012.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar_f012.TabIndex = 19;
            this.btnGuardar_f012.Text = "Guardar";
            this.btnGuardar_f012.UseVisualStyleBackColor = true;
            // 
            // tbf012_id
            // 
            this.tbf012_id.Enabled = false;
            this.tbf012_id.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbf012_id.Location = new System.Drawing.Point(225, 72);
            this.tbf012_id.Name = "tbf012_id";
            this.tbf012_id.Size = new System.Drawing.Size(300, 27);
            this.tbf012_id.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(152, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 19);
            this.label16.TabIndex = 37;
            this.label16.Text = "*Id:";
            // 
            // chkf012_habilitado
            // 
            this.chkf012_habilitado.AutoSize = true;
            this.chkf012_habilitado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkf012_habilitado.Location = new System.Drawing.Point(225, 32);
            this.chkf012_habilitado.Name = "chkf012_habilitado";
            this.chkf012_habilitado.Size = new System.Drawing.Size(112, 23);
            this.chkf012_habilitado.TabIndex = 36;
            this.chkf012_habilitado.Text = "Habilitado";
            this.chkf012_habilitado.UseVisualStyleBackColor = true;
            // 
            // tbf012_descripcion
            // 
            this.tbf012_descripcion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbf012_descripcion.Location = new System.Drawing.Point(225, 109);
            this.tbf012_descripcion.Name = "tbf012_descripcion";
            this.tbf012_descripcion.Size = new System.Drawing.Size(300, 27);
            this.tbf012_descripcion.TabIndex = 35;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(80, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 19);
            this.label18.TabIndex = 34;
            this.label18.Text = "*Descripcion:";
            // 
            // tbf012_formato
            // 
            this.tbf012_formato.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbf012_formato.Location = new System.Drawing.Point(225, 142);
            this.tbf012_formato.Multiline = true;
            this.tbf012_formato.Name = "tbf012_formato";
            this.tbf012_formato.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbf012_formato.Size = new System.Drawing.Size(300, 148);
            this.tbf012_formato.TabIndex = 39;
            // 
            // dgv_formatos
            // 
            this.dgv_formatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_formatos.Location = new System.Drawing.Point(8, 296);
            this.dgv_formatos.Name = "dgv_formatos";
            this.dgv_formatos.Size = new System.Drawing.Size(560, 199);
            this.dgv_formatos.TabIndex = 40;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(51, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(147, 19);
            this.label19.TabIndex = 41;
            this.label19.Text = "*Formato (PRN):";
            // 
            // configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 591);
            this.Controls.Add(this.TcContenedor);
            this.MaximumSize = new System.Drawing.Size(600, 630);
            this.MinimumSize = new System.Drawing.Size(600, 630);
            this.Name = "configuracion";
            this.Text = "configuracion";
            this.Load += new System.EventHandler(this.configuracion_Load);
            this.TcContenedor.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagvUsuarios)).EndInit();
            this.tabPerfiles.ResumeLayout(false);
            this.tabPerfiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabImpresora.ResumeLayout(false);
            this.tabImpresora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagvImpresoras)).EndInit();
            this.tabRFID.ResumeLayout(false);
            this.tabRFID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagvReader)).EndInit();
            this.tabAplicacion.ResumeLayout(false);
            this.tabFormatos.ResumeLayout(false);
            this.tabFormatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_formatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TcContenedor;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.CheckBox ChkHabilitadoUser;
        private System.Windows.Forms.DataGridView DatagvUsuarios;
        private System.Windows.Forms.ComboBox Cbf001_perfil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tbf001_pass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tbf001_email;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tbf001_nombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tbf001_idUsuario;
        private System.Windows.Forms.Button btnGuardar_t002_usuarios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPerfiles;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chk_mod_configuracion;
        private System.Windows.Forms.CheckBox chk_mod_informes;
        private System.Windows.Forms.CheckBox chk_mod_impresion;
        private System.Windows.Forms.CheckBox chk_mod_inventario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGuardar_t002_perfiles;
        private System.Windows.Forms.TabPage tabImpresora;
        private System.Windows.Forms.TabPage tabRFID;
        private System.Windows.Forms.CheckBox Chkf011_habilitado;
        private System.Windows.Forms.TextBox Tbf011_direccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tbf011_reader;
        private System.Windows.Forms.Button btnGuardar_t011_reader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabAplicacion;
        private System.Windows.Forms.TextBox Tbf011_contrasena;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tbf011_usuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar_t010_impresora;
        private System.Windows.Forms.DataGridView DatagvImpresoras;
        private System.Windows.Forms.CheckBox Chkf010_habilitado;
        private System.Windows.Forms.TextBox Tbf010_direccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tbf010_impresora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DatagvReader;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox Tbf010_id;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Tbf011_id;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabFormatos;
        private System.Windows.Forms.TextBox tbf012_id;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkf012_habilitado;
        private System.Windows.Forms.TextBox tbf012_descripcion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnGuardar_f012;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgv_formatos;
        private System.Windows.Forms.TextBox tbf012_formato;
    }
}