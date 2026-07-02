using rfid.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace rfid
{
    public partial class rfid_Form : Form
    {
        
        public rfid_Form()
        {
            InitializeComponent();

            
            p_contenedor.Location = new Point(170,0);
            p_contenedor.Size = new Size(630,600);

            
        }

        private void salirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void abrir_modulo(Form frm)
        {

            if (this.p_contenedor.Controls.Count > 0)
            {
                this.p_contenedor.Controls.RemoveAt(0);
            }

            frm.TopLevel = false; // Importante para que no sea una ventana independiente
            frm.FormBorderStyle = FormBorderStyle.None; // Opcional: Sin bordes
            frm.Dock = DockStyle.Fill; // Rellena el panel
            this.p_contenedor.Controls.Add(frm);
            frm.Show();
        }

        private void DashBoardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dashboard frm = new dashboard();
            abrir_modulo(frm);

        }               

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuracion frm = new configuracion();
            abrir_modulo(frm);
        }
        

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data frm = new data();
            abrir_modulo(frm);
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data frm = new data();

            abrir_modulo(frm);
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entradas frm = new entradas();
            abrir_modulo(frm);
        }
    }
}
