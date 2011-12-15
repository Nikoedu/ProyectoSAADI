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
    public partial class AutentificarUsuario : Form
    {
        public static int contador;
        public static Boolean Bienvenida;
        public AutentificarUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals("") || textBox2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe completar todos los campos. Compruebe que no sean espacios en blanco");
            }
            else
            {
                Usuario us = new Usuario();
                us.autentificarUsuario(textBox1.Text, textBox2.Text);
            }
                 
        }
    }
}
