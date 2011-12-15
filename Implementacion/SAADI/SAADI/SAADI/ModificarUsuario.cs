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
    public partial class ModificarUsuario : Form
    {
        String[] nvl = { "Bajo", "Medio", "Alto" };
        String[] tipo = { "Alumno", "Ayudante Tecnico" };
        public void llenarCombo(String[] datos, ComboBox combo)
        {

            for (int i = 0; i < datos.Length; i++)
            {
                combo.Items.Add(datos[i]);
            }
        }
        public ModificarUsuario()
        {
            InitializeComponent();
            panel1.Visible = false;
            llenarCombo(tipo, comboBox1);
            llenarCombo(nvl, comboBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.SelectionStart.Date >= DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor o igual a la actual");
            }
                 if (textBox1.Text.Equals("") || comboBox1.Text.Equals("") || txt_nombre.Text.Equals("") || txt_contrasena.Equals(""))
                {
                    MessageBox.Show("Todos los campos deben estar completos");
                }
                else
                {
                    Profesor profe = new Profesor();
                    profe.modificarUsuario(false, textBox1.Text, panel1, comboBox1, txt_nombre, txt_apellido, txt_contrasena, monthCalendar1, comboBox2);
                }
            }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {      
            panel1.Visible = false;
            Profesor profe = new Profesor();
            profe.modificarUsuario(true, textBox1.Text, panel1, comboBox1, txt_nombre, txt_apellido, txt_contrasena, monthCalendar1, comboBox2 );
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
