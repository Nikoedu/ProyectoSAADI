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
    public partial class SeleccionarActividad : Form
    {
        private String nomAlumno;
        public SeleccionarActividad(String usuario)
        {
            InitializeComponent();
            groupBox2.Visible = false;
            nomAlumno = usuario;
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
            int[] arregloAct = new int[10];
            String query = "SELECT DISTINCT Ac.IDActividad, Ac.NombreActividad FROM Actividad AS Ac, Avance AS av WHERE Ac.IDActividad <> Av.IDActividad AND Ac.IDTipoActividad = "+comboBox1.SelectedIndex + 1 +" AND NombreUsuario = '"+nomAlumno+"' AND NOT EXISTS (SELECT IDActividad FROM Avance AS Av WHERE Av.IDActividad = Ac.IDActividad)";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
            OleDbCommand exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            OleDbDataReader aReader = exec.ExecuteReader();
            int pos = 0;
            while (aReader.Read())
            {
                arregloAct[pos] = (int) aReader.GetValue(0);
                comboBox2.Items.Add(aReader.GetValue(0) + ".- " + aReader.GetValue(1));
                pos++;
            }
            return arregloAct;            
        }
       
        public void autentificarEncargadoEduc(String usuario, String password)
        {
            Usuario us = new Usuario();
            if (us.existeUsuario(usuario) == true)
            {
                int contador2 = 0;
                Boolean pasoEstado2 = false;
                String tipoUs = "";
                String query = "SELECT COUNT(*) from EncargadoEducacional where NombreUsuario = '" + usuario + "' and Contraseña = '" + password + "'";
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
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
                    groupBox2.Visible = true;
                    llenarComboTipoAct();
                }
                if (tipoUs == "Profesor" && pasoEstado2 == true)
                {
                    comboBox1.Items.Clear();
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
        int idAct = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (idAct == 0)
            {
                MessageBox.Show("Debe Seleccionar la actividad a mostrar");
            }
            else if (textBox1.Text.Equals("") || textBox1.Text.Equals(""))
            {
                MessageBox.Show("Indique el nombre de usuario o la contraseña para autorizar la accion");
            }
            else
            {
                Profesor profe = new Profesor();
                profe.seleccionarActividad(idAct);
            }

            
        }
        int[] arreglo;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            arreglo = llenarComboAct();            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAct  = arreglo[comboBox2.SelectedIndex];
        }
    }
}
