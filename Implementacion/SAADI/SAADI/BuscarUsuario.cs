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

    
    public partial class BuscarUsuario : Form
    {
        String[] nvl = { "Bajo", "Medio", "Alto" };
        public void llenarCombo(String[] datos, ComboBox combo)
        {
            for (int i = 0; i < datos.Length; i++)
            {
                combo.Items.Add(datos[i]);
            }
        }
        public BuscarUsuario()
        {
            InitializeComponent();
            label2.Visible = false;
            textBox1.Visible = false;
            monthCalendar1.Visible = false;
            button1.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
            llenarCombo(nvl, comboBox1);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            monthCalendar1.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            monthCalendar1.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox1.Visible = true;
            monthCalendar1.Visible = true;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            button1.Visible = true;
            comboBox1.Visible = true;
            monthCalendar1.Visible = false;
            textBox1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Debe seleccionar el parametro de busqueda");
                }
                else
                {
                    String tipoBusq = "NombreUsuario";
                    Profesor profe = new Profesor();
                    profe.buscarUsuario(textBox1.Text, tipoBusq, dataGridView1);
                }                               
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Debe seleccionar el parametro de busqueda");
                }
                else
                {
                    String tipoBusq = "NombreAlumno";
                    Profesor profe = new Profesor();
                    profe.buscarUsuario(textBox1.Text, tipoBusq, dataGridView1);
                }
            }
            else if (radioButton3.Checked == true)
            {
                if (monthCalendar1.SelectionStart.Date >= DateTime.Today)
                {
                    MessageBox.Show("La fecha de nacimiento no puede ser mayor o igual a la actual");
                }
                else
                {
                    String tipoBusq = "FechaDeNacimiento";
                    Profesor profe = new Profesor();
                    profe.buscarUsuario(monthCalendar1.SelectionStart.Date.ToString(), tipoBusq, dataGridView1);
                }
            }
            else if (radioButton4.Checked == true)
            {
                if (comboBox1.Text.Equals(""))
                {
                    MessageBox.Show("Debe seleccionar el parametro de busqueda");
                }
                else
                {
                    String tipoBusq = "NivelDiscapacidad";
                    Profesor profe = new Profesor();
                    profe.buscarUsuario(comboBox1.Text, tipoBusq, dataGridView1);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de busqueda");
            }
        }



       
    }
}
