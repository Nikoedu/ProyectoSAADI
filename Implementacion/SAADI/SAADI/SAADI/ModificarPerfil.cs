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
    public partial class ModificarPerfil : Form
    {
        public ModificarPerfil()
        {
            InitializeComponent();
            llenarLista();
            checkedListBox1.Visible = false;
        }
        public void cargarPerfilActividad(String nombrePerfil)
        {
             //Consultar por IDPerfil ingresado
                int IdPerfil = 0;
                String query = "SELECT IDPerfil from Perfil where NombrePerfil = '" + nombrePerfil + "'";
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection conexion = new OleDbConnection(cadena);
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                OleDbCommand exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                while (aReader.Read())
                {
                    IdPerfil = (int)aReader.GetValue(0);
                }

                conexion.Close();
            //Actividades del perfil
            query = "SELECT IDActividad from Actividad_Perfil WHERE IDPerfil = "+IdPerfil;
            cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            conexion = new OleDbConnection(cadena);
            adap = new OleDbDataAdapter(query, conexion);
            exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                
            }
            conexion.Close();
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
                checkedListBox1.Items.Add(aReader.GetValue(0).ToString() + ".- " + aReader.GetValue(1).ToString() + " - " + aReader.GetValue(2).ToString());
            }
            conexion.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible =true;
        }
    }
}
