using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.Xml;

namespace SAADI
{
    public partial class PantallaInicioAlumno : Form
    {
        public static String us;
        public static int idActividad;
        public static String idActTitulo;
        public static String txt_termino;
        public PantallaInicioAlumno(String usuario, int idAct)
        {
            InitializeComponent();
            us = usuario;
            idActividad = idAct;
        }
        public PantallaInicioAlumno(String usuario)
        {
            InitializeComponent();
            us = usuario;
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
            SeleccionarActividad selAc = new SeleccionarActividad(us, idActividad, axShockwaveFlash1, axShockwaveFlash2);
            selAc.ShowDialog();            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void guardarAvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            GuardarActividad ga = new GuardarActividad();
            ga.ShowDialog();            
        }
        private void PantallaInicioAlumno_Load(object sender, EventArgs e)
        {
            if (SAADI.AutentificarUsuario.Bienvenida == false)
            {
                Alumno al = new Alumno();
                al.leerActividad(us, axShockwaveFlash1, axShockwaveFlash2);
            }
        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void axShockwaveFlash2_Enter(object sender, EventArgs e)
        {

        }

        private void axShockwaveFlash1_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
        {
              
        }
    }
}
