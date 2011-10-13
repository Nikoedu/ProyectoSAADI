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
        public AutentificarUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                Usuario us = new Usuario();
                us.autentificarUsuario(textBox1.Text, textBox2.Text);
            }
                 
        }
    }
}
