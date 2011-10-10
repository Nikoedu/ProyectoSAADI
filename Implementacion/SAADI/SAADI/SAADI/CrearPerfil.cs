using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace SAADI
{
    public partial class CrearPerfil : Form
    {
        public CrearPerfil()
        {
            InitializeComponent();
            llenarLista();
        }

        public void llenarLista()
        {
            String query = "SELECT Ac.IDActividad, TA.NombreTipoActividad, Ac.NombreActividad from Actividad AS Ac, TipoActividad AS TA WHERE Ac.IDTipoActividad = TA.IDTipoActividad";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
            OleDbCommand exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            OleDbDataReader aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                listBox1.Items.Add(aReader.GetValue(0).ToString() + ".- " + aReader.GetValue(1).ToString() + " - " + aReader.GetValue(2).ToString());
            }
            conexion.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Profesor profe = new Profesor();
            profe.crearPerfilAlumno(textBox1.Text, listBox1, textBox2);
        }

        ArrayList selecc = new ArrayList();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i))
                {
                    if (!selecc.Contains(i + 1))
                    {
                        selecc.Add(i + 1);
                    }
                }
                else
                {
                    if (selecc.Contains(i + 1))
                    {
                        selecc.Remove(i + 1);
                    }
                }
            }
            textBox2.Text = "";
            int primero = 0;
            foreach (int i in selecc)
            {                
                if (primero != 0)
                {
                    textBox2.Text = textBox2.Text + " - " + i;
                }
                else
                {
                    textBox2.Text = textBox2.Text + i;
                    primero++;
                }
            }         
            
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
    }
}
