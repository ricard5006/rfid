namespace rfid
{
    partial class rfid_Form
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
        /// 


        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DashBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impresoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.aplicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.p_contenedor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 100);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DashBoardToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(170, 600);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DashBoardToolStripMenuItem
            // 
            this.DashBoardToolStripMenuItem.AutoSize = false;
            this.DashBoardToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DashBoardToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashBoardToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DashBoardToolStripMenuItem.Name = "DashBoardToolStripMenuItem";
            this.DashBoardToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.DashBoardToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DashBoardToolStripMenuItem.Size = new System.Drawing.Size(170, 50);
            this.DashBoardToolStripMenuItem.Text = "DashBoard";
            this.DashBoardToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DashBoardToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.DashBoardToolStripMenuItem.Click += new System.EventHandler(this.DashBoardToolStripMenuItem1_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.dataToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.dataToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(166, 32);
            this.dataToolStripMenuItem.Text = "Data";
            this.dataToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.importarToolStripMenuItem.Text = "Importar";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(166, 30);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventariosToolStripMenuItem,
            this.entradasToolStripMenuItem,
            this.salidasToolStripMenuItem,
            this.transferenciasToolStripMenuItem});
            this.operacionesToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(166, 32);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            this.operacionesToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inventariosToolStripMenuItem
            // 
            this.inventariosToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.inventariosToolStripMenuItem.Name = "inventariosToolStripMenuItem";
            this.inventariosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.inventariosToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.inventariosToolStripMenuItem.Text = "Inventarios";
            // 
            // entradasToolStripMenuItem
            // 
            this.entradasToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
            this.entradasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.entradasToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.entradasToolStripMenuItem.Text = "Entradas";
            // 
            // salidasToolStripMenuItem
            // 
            this.salidasToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
            this.salidasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.salidasToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.salidasToolStripMenuItem.Text = "Salidas";
            // 
            // transferenciasToolStripMenuItem
            // 
            this.transferenciasToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.transferenciasToolStripMenuItem.Name = "transferenciasToolStripMenuItem";
            this.transferenciasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.transferenciasToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.transferenciasToolStripMenuItem.Text = "Transferencias";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.AutoSize = false;
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.perfilesToolStripMenuItem,
            this.impresoraToolStripMenuItem,
            this.toolStripMenuItem5,
            this.aplicacionToolStripMenuItem});
            this.configuracionToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(170, 50);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.AutoSize = false;
            this.usuarioToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(150, 30);
            this.usuarioToolStripMenuItem.Text = "Usuarios";
            // 
            // perfilesToolStripMenuItem
            // 
            this.perfilesToolStripMenuItem.AutoSize = false;
            this.perfilesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            this.perfilesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.perfilesToolStripMenuItem.Size = new System.Drawing.Size(150, 30);
            this.perfilesToolStripMenuItem.Text = "Perfiles";
            // 
            // impresoraToolStripMenuItem
            // 
            this.impresoraToolStripMenuItem.AutoSize = false;
            this.impresoraToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.impresoraToolStripMenuItem.Name = "impresoraToolStripMenuItem";
            this.impresoraToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.impresoraToolStripMenuItem.Size = new System.Drawing.Size(150, 30);
            this.impresoraToolStripMenuItem.Text = "Impresora";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.AutoSize = false;
            this.toolStripMenuItem5.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripMenuItem5.Size = new System.Drawing.Size(150, 30);
            this.toolStripMenuItem5.Text = "RFID";
            // 
            // aplicacionToolStripMenuItem
            // 
            this.aplicacionToolStripMenuItem.AutoSize = false;
            this.aplicacionToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.aplicacionToolStripMenuItem.Name = "aplicacionToolStripMenuItem";
            this.aplicacionToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.aplicacionToolStripMenuItem.Size = new System.Drawing.Size(150, 30);
            this.aplicacionToolStripMenuItem.Text = "Aplicacion";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.AutoSize = false;
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 578);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "RFID LA v1.0";
            // 
            // p_contenedor
            // 
            this.p_contenedor.Location = new System.Drawing.Point(170, 0);
            this.p_contenedor.Name = "p_contenedor";
            this.p_contenedor.Size = new System.Drawing.Size(630, 34);
            this.p_contenedor.TabIndex = 4;
            // 
            // rfid_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.p_contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "rfid_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rfid v1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impresoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aplicacionToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem DashBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;


        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.Text = "rfid_Form";
        //}

        #endregion
        private System.Windows.Forms.Panel p_contenedor;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciasToolStripMenuItem;
    }
}