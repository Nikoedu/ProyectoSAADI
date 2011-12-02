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

    public partial class AgregarUsuario : Form
    {
        String[] nvl = {"Bajo","Medio","Alto"};
        String[] tipo = { "Alumno", "Ayudante Tecnico" };
        public void llenarCombo(String[] datos, ComboBox combo)
        {
            
            for (int i = 0; i < datos.Length; i++)
            {
                combo.Items.Add(datos[i]);
            }
        }
        public AgregarUsuario()
        {
            InitializeComponent();
            llenarCombo(nvl, comboBox2);
            llenarCombo(tipo, comboBox1);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ayudante Tecnico")
            {
                comboBox2.Visible = false;
                label7.Visible = false;
            }
            else
            {
                comboBox2.Visible = true;
                label7.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechadeNac = monthCalendar1.SelectionStart.Date;
            if (fechadeNac >= DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor o igual a la actual");
            }
            else
            {
                String nombre = txt_nombre.Text.Trim();
                String apellido = txt_apellido.Text.Trim();
                String nombreUsuario = txt_username.Text.Trim();
                String password = txt_password.Text.Trim();
                String tipoUsuario = comboBox1.Text.Trim();

                String nivelDiscapacidad = comboBox2.Text;
                if (nombre.Equals("") || apellido.Equals("") || nombreUsuario.Equals("") || password.Equals("") || tipoUsuario.Equals("") || nivelDiscapacidad.Equals(""))
                {
                    MessageBox.Show("Debe completar todos los campos. Compruebe que no sean espacios en blanco");
                }

                else
                {
                    Profesor profe = new Profesor();
                    profe.agregarUsuario(tipoUsuario, nombre, apellido, nombreUsuario, password, fechadeNac, nivelDiscapacidad);
                }
            }
        }

       
    }
}
