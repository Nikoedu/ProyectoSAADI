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
    public partial class BuscarPerfil : Form
    {
        public BuscarPerfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe completar el campo pedido. Compruebe que no sean espacios en blanco");
            }
            else
            {
                Profesor profe = new Profesor();
                profe.buscarPerfil(textBox1.Text, dataGridView1);
            }
        }
    }
}
