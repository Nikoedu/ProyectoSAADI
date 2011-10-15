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
    public partial class PantallaInicioAlumno : Form
    {
        public static String us;
        public static int idAct;
        public PantallaInicioAlumno(String usuario)
        {
            InitializeComponent();
            us = usuario;
        }
        public PantallaInicioAlumno()
        {
            InitializeComponent();
        }

        public void mostrarActividad(int idAc)
        {
            idAct = idAc;
            String ruta = "C:\\Documents and Settings\\Administrador\\Escritorio\\Copia de Rama Software\\Implementacion\\Actividades";
            MessageBox.Show(ruta + "\\" + idAct);
            axShockwaveFlash1.LoadMovie(0, ruta + "\\" + idAct);            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seleccionarActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SeleccionarActividad selAc = new SeleccionarActividad(us);
            selAc.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarAvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarActividad ga = new GuardarActividad();
            ga.Show();
        }

        public void mostrarActividadAlumno(){
            ArrayList ordenSecuencia = new ArrayList();
            int idPerfil = 0;
            String query = "SELECT IdPerfil FROM Alumno WHERE NombreUsuario = '" + us + "'";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            try
            {
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                OleDbCommand exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                while (aReader.Read())
                {
                    idPerfil = (int) aReader.GetValue(0);
                }
                exec.Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: No se puede continuar");
            }
            if (idPerfil == 0)
            {
                MessageBox.Show("El usuario no tiene perfil");
            }           

            else if (idPerfil == 1)
            {                
                query = "SELECT IDActividad FROM Secuencia ORDER BY PosicionSecuencia";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                try
                {
                    OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                    OleDbCommand exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    OleDbDataReader aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        ordenSecuencia.Add((int)aReader.GetValue(0));
                    }
                    exec.Connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR: No se puede continuar");
                }
                query = "SELECT IDActividad FROM Avance WHERE NombreUsuario = '"+us+"'";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                try
                {
                    OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                    OleDbCommand exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    OleDbDataReader aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        if(ordenSecuencia.Contains(aReader.GetValue(0))){
                            ordenSecuencia.Remove(aReader.GetValue(0));
                        }
                    }
                    exec.Connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR: No se puede continuar");
                }
                if (ordenSecuencia.Count != 0)
                {
                    mostrarActividad((int) ordenSecuencia[0]);
                }
                else
                {
                    MessageBox.Show("Usted ha completado todas las actividades");
                }                

            }
            else
            {
                ArrayList actividadesPerfil = new ArrayList();
                query = "SELECT IDActividad from Actividad_Perfil where IDPerfil = " + idPerfil;
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                OleDbCommand exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                while (aReader.Read())
                {
                    actividadesPerfil.Add((int)aReader.GetValue(0));
                }
                conexion.Close();
                query = "SELECT IDActividad FROM Secuencia ORDER BY PosicionSecuencia";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                try
                {
                    adap = new OleDbDataAdapter(query, conexion);
                    exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        ordenSecuencia.Add((int)aReader.GetValue(0));
                    }
                    exec.Connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR: No se puede continuar");
                }
                ArrayList actividadesResueltas = new ArrayList();
                query = "SELECT IDActividad FROM Avance WHERE NombreUsuario = '"+us+"'";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                try
                {
                    adap = new OleDbDataAdapter(query, conexion);
                    exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        actividadesResueltas.Add((int) aReader.GetValue(0));
                    }
                    exec.Connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR: No se puede continuar");
                }
                for(int i = 0; i < ordenSecuencia.Count; i++)
                {
                    if(actividadesResueltas.Contains(i))
                    {
                         actividadesPerfil.Remove(i); 
                    }
                }
                Boolean paso = false;
                for(int i = 0; i < ordenSecuencia.Count; i++)
                {
                    if(actividadesPerfil.Contains(ordenSecuencia[i]))
                    {
                        mostrarActividad((int) ordenSecuencia[i]);
                        i = ordenSecuencia.Count;
                        paso = true;
                    }
                }
                if (paso == false)
                {
                    MessageBox.Show("Felicitaciones se han desarrollado todas las actividades de su perfil");
                }
            }

        }
        private void PantallaInicioAlumno_Load(object sender, EventArgs e)
        {
            mostrarActividadAlumno();
        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {

        }
    }
}
