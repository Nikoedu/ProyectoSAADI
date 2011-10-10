using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAADI
{
    public partial class PantallaInicioAlumno : Form
    {
        public PantallaInicioAlumno()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seleccionarActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionarActividad selAc = new SeleccionarActividad();
            selAc.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
