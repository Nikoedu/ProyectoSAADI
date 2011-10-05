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

    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            llenarCombo(tipo, comboBox1);
            llenarCombo(nvl, comboBox2);

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
            String nombre = txt_nombre.Text;
            String apellido = txt_apellido.Text;
            String nombreUsuario = txt_username.Text;
            String password = txt_password.Text;
            String tipoUsuario = comboBox1.Text;
            DateTime fechadeNace = monthCalendar1.SelectionStart.Date;
            String nivelDiscapacidad = comboBox2.Text;
            MessageBox.Show(""+fechadeNace);
            Profesor profe = new Profesor(tipoUsuario, nombre, apellido, nombreUsuario, password, fechadeNace, nivelDiscapacidad);
            profe.agregarUsuario();
        }

       
    }
}
