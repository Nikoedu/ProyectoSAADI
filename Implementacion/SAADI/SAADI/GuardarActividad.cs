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
    public partial class GuardarActividad : Form
    {
        public GuardarActividad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String nomUsuarioAl = SAADI.PantallaInicioAlumno.us;
            int idActividad = SAADI.SeleccionarActividad.idAct;
            Avance av = new Avance();
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                av.guardarAvance(nomUsuarioAl, textBox1.Text, textBox2.Text, idActividad);
            }
            
        }
    }
}
