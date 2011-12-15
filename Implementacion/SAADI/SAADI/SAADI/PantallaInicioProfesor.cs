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
            busUs.ShowDialog();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUsuario agreUs = new AgregarUsuario();
            agreUs.ShowDialog();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuario modUs = new ModificarUsuario();
            modUs.ShowDialog();
        }

        private void inhabilitarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InhabilitarUsuario inhUs = new InhabilitarUsuario();
            inhUs.ShowDialog();
        }

        private void listarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarUsuarios lisUs = new ListarUsuarios();
            lisUs.ShowDialog();
        }

        private void crearPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPerfil crePe = new CrearPerfil();
            crePe.ShowDialog();
        }

        private void modificarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarPerfil modPe = new ModificarPerfil();
            modPe.ShowDialog();
        }

        private void modificarPerfilAAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarPerfilAlumno modPeAl = new ModificarPerfilAlumno();
            modPeAl.ShowDialog();
        }

        private void buscarPerfilDeAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarPerfil busPe = new BuscarPerfil();
            busPe.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generarReporteActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObtenerReporte obtRe = new ObtenerReporte();
            obtRe.ShowDialog();
        }

        private void PantallaInicioProfesor_Load(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
