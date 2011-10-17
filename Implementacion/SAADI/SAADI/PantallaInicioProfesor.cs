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
    public partial class PantallaInicioProfesor : Form
    {
        public PantallaInicioProfesor()
        {
            InitializeComponent();
        }

        private void buscarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarUsuario busUs = new BuscarUsuario();
            busUs.Show();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUsuario agreUs = new AgregarUsuario();
            agreUs.Show();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuario modUs = new ModificarUsuario();
            modUs.Show();
        }

        private void inhabilitarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InhabilitarUsuario inhUs = new InhabilitarUsuario();
            inhUs.Show();
        }

        private void listarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarUsuarios lisUs = new ListarUsuarios();
            lisUs.Show();
        }

        private void crearPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPerfil crePe = new CrearPerfil();
            crePe.Show();
        }

        private void modificarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarPerfil modPe = new ModificarPerfil();
            modPe.Show();
        }

        private void modificarPerfilAAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarPerfilAlumno modPeAl = new ModificarPerfilAlumno();
            modPeAl.Show();
        }

        private void buscarPerfilDeAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarPerfil busPe = new BuscarPerfil();
            busPe.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generarReporteActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObtenerReporte obtRe = new ObtenerReporte();
            obtRe.Show();
        }
    }
}
