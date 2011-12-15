using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using AxShockwaveFlashObjects;

namespace SAADI
{
    public partial class SeleccionarActividad : Form
    {
        private String nomAlumno;
        public static int idAct = 0;
        public AxShockwaveFlash axShockwaveFlash1;
        public AxShockwaveFlash axShockwaveFlash2;
        public SeleccionarActividad(String usuario, int idActi, AxShockwaveFlash axFlash1, AxShockwaveFlash axFlash2)
        {
            InitializeComponent();
            groupBox2.Visible = false;
            nomAlumno = usuario;
            idAct = idActi;
            axShockwaveFlash1 = axFlash1;
            axShockwaveFlash2 = axFlash2;
        }
        public SeleccionarActividad()
        {

        }
        String[] tipoAct = { "Memoria", "Atención", "Percepción", "Discriminación Visual", "Discriminación Auditiva" };
        public void llenarComboTipoAct()
        {
            for(int i = 0; i < tipoAct.Length ; i++){
                comboBox1.Items.Add(tipoAct[i]);
            }
        }

        public int[] llenarComboAct()
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD; 
            int[] arregloAct = new int[10];
            int busq = comboBox1.SelectedIndex + 1;
            String query = "SELECT DISTINCT Ac.IDActividad, Ac.NombreActividad FROM Actividad AS Ac, Avance AS av WHERE Ac.IDActividad <> Av.IDActividad AND Ac.IDTipoActividad = "+ busq +" AND NOT EXISTS (SELECT IDActividad FROM Avance AS Av WHERE Av.IDActividad = Ac.IDActividad" + " AND NombreUsuario = '"+nomAlumno+"')";
            try
            {
                OleDbConnection conexion = new OleDbConnection(cadena);
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                OleDbCommand exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                int pos = 0;
                while (aReader.Read())
                {
                    arregloAct[pos] = (int)aReader.GetValue(0);
                    comboBox2.Items.Add(aReader.GetValue(0) + ".- " + aReader.GetValue(1));
                    pos++;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("No se puede continuar");
            }
            return arregloAct;            
        }
       
        public void autentificarEncargadoEduc(String usuario, String password)
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD; 
            Usuario us = new Usuario();
            if (us.existeUsuario(usuario) == true)
            {
                int contador2 = 0;
                Boolean pasoEstado2 = false;
                String tipoUs = "";
                String query = "SELECT COUNT(*) from EncargadoEducacional where NombreUsuario = '" + usuario + "' and Contraseña = '" + password + "'";
                OleDbConnection conexion = new OleDbConnection(cadena);
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                OleDbCommand exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                while (aReader.Read())
                {
                    contador2 = (int)aReader.GetValue(0);
                }

                if (contador2 == 1)
                {
                    query = "SELECT Estado, Motivo_Inhabilitacion FROM EncargadoEducacional where NombreUsuario = '" + usuario + "'";
                    conexion = new OleDbConnection(cadena);
                    adap = new OleDbDataAdapter(query, conexion);
                    exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        if ((int)aReader.GetValue(0) == 1)
                        {
                            pasoEstado2 = true;
                        }
                        else
                        {

                            MessageBox.Show("El usuario esta deshabilitado, Motivo: " + aReader.GetValue(1).ToString());
                        }
                    }
                    query = "SELECT TipoEncargadoEducacional FROM EncargadoEducacional where NombreUsuario = '" + usuario + "' and contraseña = '" + password + "'";
                    conexion = new OleDbConnection(cadena);
                    adap = new OleDbDataAdapter(query, conexion);
                    exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        tipoUs = aReader.GetValue(0).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no esta autorizado para Seleccionar Actividad");
                }
                if (tipoUs == "Ayudante Tecnico" && pasoEstado2 == true)
                {
                    comboBox1.Items.Clear();
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    llenarComboTipoAct();
                }
                if (tipoUs == "Profesor" && pasoEstado2 == true)
                {
                    comboBox1.Items.Clear();
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    llenarComboTipoAct();
                }
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña no es valida");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            autentificarEncargadoEduc(textBox1.Text, textBox2.Text);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Debe Seleccionar la actividad a mostrar");
            }
            else if (textBox1.Text.Equals("") || textBox1.Text.Equals(""))
            {
                MessageBox.Show("Indique el nombre de usuario o la contraseña para autorizar la accion");
            }
            else            
            {
                try
                {
                    Profesor profe = new Profesor();
                    profe.seleccionarActividad(idAct, axShockwaveFlash1, axShockwaveFlash2);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error: No se puede continuar");
                }
            }
            
        }
        int[] arreglo;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            arreglo = llenarComboAct();
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Enabled = true;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAct  = arreglo[comboBox2.SelectedIndex];
        }
    }
}
