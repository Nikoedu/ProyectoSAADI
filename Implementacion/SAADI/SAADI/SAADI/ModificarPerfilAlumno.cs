using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SAADI
{
    public partial class ModificarPerfilAlumno : Form
    {
        public ModificarPerfilAlumno()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
            comboBox1.Visible = false;
        }

        public void llenarComboBox(int IdPer)
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD; 
            String query = "SELECT P.NombrePerfil from Perfil AS P where P.IDPerfil <> " + IdPer;
             OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
            OleDbCommand exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            OleDbDataReader aReader = exec.ExecuteReader();
            comboBox1.Items.Clear();
            while (aReader.Read())
            {
                comboBox1.Items.Add(aReader.GetValue(0).ToString());
            }
            exec.Connection.Close();
        }

        public Boolean existeUsuarioEncEducacional(String nombreUs){
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD; 
            Boolean existe = false;
            int contador = 0;
            String query = "SELECT COUNT(*) from EncargadoEducacional where NombreUsuario = '" + nombreUs + "'";
            OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
            OleDbCommand exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            OleDbDataReader aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                contador = (int)aReader.GetValue(0);
            }
            if (contador == 1)
            {
                existe = true;
            }
            return existe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD; 
            if(textBox1.Text.Equals("")){
                MessageBox.Show("Debe Indicar el Nombre de Usuario del Alumno");
            }
            else
            {
                String nombreUs = textBox1.Text;
                if (existeUsuarioEncEducacional(nombreUs) == false)
                {
                    int idPerfil = 0;
                    String nombrePerfil = "";
                    String query = "SELECT A.IdPerfil, P.NombrePerfil from Alumno AS A, Perfil AS P where A.IDPerfil = P.IDPerfil AND A.NombreUsuario = '" + nombreUs + "'";
                    OleDbConnection conexion = new OleDbConnection(cadena);
                    OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                    OleDbCommand exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    OleDbDataReader aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        idPerfil = (int)aReader.GetValue(0);
                        nombrePerfil = aReader.GetValue(1).ToString();
                    }
                    if (nombrePerfil == "")
                    {
                        MessageBox.Show("No existe ningun usuario");
                        label2.Visible = false;
                        label3.Visible = false;
                        comboBox1.Visible = false;
                        textBox2.Visible = false;
                        button2.Visible = false;
                    }
                    else
                    {
                        textBox1.Enabled = false;
                        exec.Connection.Close();
                        label2.Visible = true;
                        label3.Visible = true;
                        comboBox1.Visible = true;
                        textBox2.Visible = true;
                        button2.Visible = true;
                        textBox2.Text = nombrePerfil;
                        llenarComboBox(idPerfil);
                    }
                }
                else
                {
                    label2.Visible = false;
                    label3.Visible = false;
                    comboBox1.Visible = false;
                    textBox2.Visible = false;
                    button2.Visible = false;
                    MessageBox.Show("No se puede modificar el perfil ya que el usuario no posee actividades para desarrollar");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(""))
            {
                String nombreUs = textBox1.Text;
                Profesor profe = new Profesor();
                profe.modificarPerfilAlumno(nombreUs, comboBox1);
            }
            else
            {
                MessageBox.Show("Seleccione perfil a cambiar");
            }
        }
    }
}
