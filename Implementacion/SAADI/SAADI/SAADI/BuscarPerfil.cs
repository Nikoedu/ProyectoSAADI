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

        public Boolean validarNumActividad(String num)
        {
            Boolean valor = false;
            for (int i = 1; i <= 35; i++)
            {
                if (num == ""+i)
                {
                    valor = true;
                }
            }
            return valor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("Debe completar el campo pedido. Compruebe que no sean espacios en blanco");
            }
            else if(validarNumActividad(textBox1.Text.Trim()) ==  false) {
                MessageBox.Show("No es un ID de Actividad valido. Valor debe estar comprendido entre 1 y 35");
            }
            else
            {
                Profesor profe = new Profesor();
                profe.buscarPerfil(textBox1.Text, dataGridView1);
            }
        }
    }
}
