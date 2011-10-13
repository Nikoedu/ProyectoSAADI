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
        public static String us;
        public static int idAct;
        public PantallaInicioAlumno(String usuario)
        {
            InitializeComponent();
            us = usuario;
        }
        public PantallaInicioAlumno()
        {
            InitializeComponent();
        }

        public void mostrarActividad(int idAc)
        {
            idAct = idAc;
            String ruta = "C:\\Documents and Settings\\Administrador\\Escritorio\\Rama Software\\Implementacion\\Actividades";
            MessageBox.Show(ruta + "\\" + idAct);
            axShockwaveFlash1.LoadMovie(0, ruta + "\\" + idAct);            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seleccionarActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SeleccionarActividad selAc = new SeleccionarActividad(us);
            selAc.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarAvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarActividad ga = new GuardarActividad();
            ga.Show();
        }
    }
}
