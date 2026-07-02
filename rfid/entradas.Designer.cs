namespace rfid
{
    partial class entradas
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar_t020 = new System.Windows.Forms.Button();
            this.lbl_log = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.dgv_t020 = new System.Windows.Forms.DataGridView();
            this.btsBuscar_t020 = new System.Windows.Forms.Button();
            this.tb_buscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_t020)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(60, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(323, 38);
            this.label6.TabIndex = 16;
            this.label6.Text = "DOCUMENTO ENTRADA\r\n[Tipo - numero - fecha - origen- Cant.]";
            // 
            // btnGuardar_t020
            // 
            this.btnGuardar_t020.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_t020.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_t020.Location = new System.Drawing.Point(428, 60);
            this.btnGuardar_t020.Name = "btnGuardar_t020";
            this.btnGuardar_t020.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar_t020.TabIndex = 15;
            this.btnGuardar_t020.Text = "...";
            this.btnGuardar_t020.UseVisualStyleBackColor = true;
            this.btnGuardar_t020.Click += new System.EventHandler(this.btnGuardar_t020_Click);
            // 
            // lbl_log
            // 
            this.lbl_log.AutoSize = true;
            this.lbl_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_log.ForeColor = System.Drawing.Color.Blue;
            this.lbl_log.Location = new System.Drawing.Point(108, 569);
            this.lbl_log.Name = "lbl_log";
            this.lbl_log.Size = new System.Drawing.Size(44, 13);
            this.lbl_log.TabIndex = 18;
            this.lbl_log.Text = "Ver Log";
            this.lbl_log.Visible = false;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.Location = new System.Drawing.Point(12, 569);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(52, 13);
            this.lbl_info.TabIndex = 17;
            this.lbl_info.Text = "Lbl_info";
            this.lbl_info.Visible = false;
            // 
            // dgv_t020
            // 
            this.dgv_t020.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_t020.Location = new System.Drawing.Point(12, 210);
            this.dgv_t020.Name = "dgv_t020";
            this.dgv_t020.Size = new System.Drawing.Size(560, 345);
            this.dgv_t020.TabIndex = 19;
            // 
            // btsBuscar_t020
            // 
            this.btsBuscar_t020.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btsBuscar_t020.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsBuscar_t020.Location = new System.Drawing.Point(472, 164);
            this.btsBuscar_t020.Name = "btsBuscar_t020";
            this.btsBuscar_t020.Size = new System.Drawing.Size(100, 32);
            this.btsBuscar_t020.TabIndex = 20;
            this.btsBuscar_t020.Text = "...";
            this.btsBuscar_t020.UseVisualStyleBackColor = true;
            // 
            // tb_buscar
            // 
            this.tb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_buscar.ForeColor = System.Drawing.Color.Gray;
            this.tb_buscar.Location = new System.Drawing.Point(12, 168);
            this.tb_buscar.Name = "tb_buscar";
            this.tb_buscar.Size = new System.Drawing.Size(454, 26);
            this.tb_buscar.TabIndex = 21;
            this.tb_buscar.Text = "Buscar";
            this.tb_buscar.Enter += new System.EventHandler(this.tb_buscar_Enter);
            this.tb_buscar.Leave += new System.EventHandler(this.tb_buscar_Leave);
            // 
            // entradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 591);
            this.Controls.Add(this.tb_buscar);
            this.Controls.Add(this.btsBuscar_t020);
            this.Controls.Add(this.dgv_t020);
            this.Controls.Add(this.lbl_log);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGuardar_t020);
            this.MaximumSize = new System.Drawing.Size(600, 630);
            this.MinimumSize = new System.Drawing.Size(600, 630);
            this.Name = "entradas";
            this.Text = "entradas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_t020)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar_t020;
        private System.Windows.Forms.Label lbl_log;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.DataGridView dgv_t020;
        private System.Windows.Forms.Button btsBuscar_t020;
        private System.Windows.Forms.TextBox tb_buscar;
    }
}