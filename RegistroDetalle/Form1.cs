using RegistroDetalle.UI.Consulta;
using RegistroDetalle.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroDetalle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisPersona P = new RegisPersona();

            P.Show();        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            RegisPersona P = new RegisPersona();
            
            P.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisArticulos A = new RegisArticulos();
            
            A.Show();
        }

        private void Articulos_Click(object sender, EventArgs e)
        {
            RegisArticulos A = new RegisArticulos();
            
            A.Show();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisCotizaciones C = new RegisCotizaciones();
          
            C.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            RegisCotizaciones C = new RegisCotizaciones();
            
            C.Show();
        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsulPersona A = new ConsulPersona();
            
            A.Show();

        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsulArticulos A = new ConsulArticulos();
            
            A.Show();

        }
    }
}

