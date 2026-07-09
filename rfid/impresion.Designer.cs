namespace rfid
{
    partial class impresion
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_buscar = new System.Windows.Forms.TextBox();
            this.btBuscar_t020 = new System.Windows.Forms.Button();
            this.dgv_t020_t003 = new System.Windows.Forms.DataGridView();
            this.lbl_log = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.cbFormatos_t012 = new System.Windows.Forms.ComboBox();
            this.cbImpresoras_t010 = new System.Windows.Forms.ComboBox();
            this.btnImprimir_t003 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_t020_t003)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(28, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Formato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Impresora:";
            // 
            // tb_buscar
            // 
            this.tb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_buscar.ForeColor = System.Drawing.Color.Gray;
            this.tb_buscar.Location = new System.Drawing.Point(12, 159);
            this.tb_buscar.Name = "tb_buscar";
            this.tb_buscar.Size = new System.Drawing.Size(454, 26);
            this.tb_buscar.TabIndex = 24;
            this.tb_buscar.Text = "Buscar";
            this.tb_buscar.Enter += new System.EventHandler(this.tb_buscar_Enter);
            this.tb_buscar.Leave += new System.EventHandler(this.tb_buscar_Leave);
            // 
            // btBuscar_t020
            // 
            this.btBuscar_t020.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscar_t020.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar_t020.Location = new System.Drawing.Point(472, 155);
            this.btBuscar_t020.Name = "btBuscar_t020";
            this.btBuscar_t020.Size = new System.Drawing.Size(100, 32);
            this.btBuscar_t020.TabIndex = 23;
            this.btBuscar_t020.Text = "...";
            this.btBuscar_t020.UseVisualStyleBackColor = true;
            // 
            // dgv_t020_t003
            // 
            this.dgv_t020_t003.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_t020_t003.Location = new System.Drawing.Point(12, 201);
            this.dgv_t020_t003.Name = "dgv_t020_t003";
            this.dgv_t020_t003.Size = new System.Drawing.Size(560, 332);
            this.dgv_t020_t003.TabIndex = 22;
            // 
            // lbl_log
            // 
            this.lbl_log.AutoSize = true;
            this.lbl_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_log.ForeColor = System.Drawing.Color.Blue;
            this.lbl_log.Location = new System.Drawing.Point(109, 569);
            this.lbl_log.Name = "lbl_log";
            this.lbl_log.Size = new System.Drawing.Size(44, 13);
            this.lbl_log.TabIndex = 26;
            this.lbl_log.Text = "Ver Log";
            this.lbl_log.Visible = false;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.Location = new System.Drawing.Point(13, 569);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(52, 13);
            this.lbl_info.TabIndex = 25;
            this.lbl_info.Text = "Lbl_info";
            this.lbl_info.Visible = false;
            // 
            // cbFormatos_t012
            // 
            this.cbFormatos_t012.FormattingEnabled = true;
            this.cbFormatos_t012.Location = new System.Drawing.Point(141, 24);
            this.cbFormatos_t012.Name = "cbFormatos_t012";
            this.cbFormatos_t012.Size = new System.Drawing.Size(175, 21);
            this.cbFormatos_t012.TabIndex = 27;
            // 
            // cbImpresoras_t010
            // 
            this.cbImpresoras_t010.FormattingEnabled = true;
            this.cbImpresoras_t010.Location = new System.Drawing.Point(141, 58);
            this.cbImpresoras_t010.Name = "cbImpresoras_t010";
            this.cbImpresoras_t010.Size = new System.Drawing.Size(175, 21);
            this.cbImpresoras_t010.TabIndex = 28;
            // 
            // btnImprimir_t003
            // 
            this.btnImprimir_t003.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir_t003.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir_t003.Location = new System.Drawing.Point(472, 539);
            this.btnImprimir_t003.Name = "btnImprimir_t003";
            this.btnImprimir_t003.Size = new System.Drawing.Size(100, 40);
            this.btnImprimir_t003.TabIndex = 29;
            this.btnImprimir_t003.Text = "Imprimir";
            this.btnImprimir_t003.UseVisualStyleBackColor = true;
            // 
            // impresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 591);
            this.Controls.Add(this.btnImprimir_t003);
            this.Controls.Add(this.cbImpresoras_t010);
            this.Controls.Add(this.cbFormatos_t012);
            this.Controls.Add(this.lbl_log);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.tb_buscar);
            this.Controls.Add(this.btBuscar_t020);
            this.Controls.Add(this.dgv_t020_t003);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.MaximumSize = new System.Drawing.Size(600, 630);
            this.MinimumSize = new System.Drawing.Size(600, 630);
            this.Name = "impresion";
            this.Text = "impresion";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_t020_t003)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_buscar;
        private System.Windows.Forms.Button btBuscar_t020;
        private System.Windows.Forms.DataGridView dgv_t020_t003;
        private System.Windows.Forms.Label lbl_log;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.ComboBox cbFormatos_t012;
        private System.Windows.Forms.ComboBox cbImpresoras_t010;
        private System.Windows.Forms.Button btnImprimir_t003;
    }
}