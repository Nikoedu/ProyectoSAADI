using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using AxShockwaveFlashObjects;

namespace SAADI
{
    public class Alumno : Usuario
    {
        protected String nivelDiscapacidad;
        public Alumno()
        {

        }

        public void leerActividad(String us, AxShockwaveFlash axFlash1, AxShockwaveFlash axFlash2)
        {
            ArrayList ordenSecuencia = new ArrayList();
            int idPerfil = 0;
            // Obtiene el perfil del alumno
            String query = "SELECT IdPerfil FROM Alumno WHERE NombreUsuario = '" + us + "'";
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD; 
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
                    idPerfil = (int)aReader.GetValue(0);
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
                //Obtiene la secuencia preestablecida y la guarda en un arraylist (Secuencia)
                query = "SELECT IDActividad FROM Secuencia ORDER BY PosicionSecuencia";
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
                //Obtiene las actividades que ha desarrollado el alumno y lo guarda en un arraylist (Avance)
                query = "SELECT IDActividad FROM Avance WHERE NombreUsuario = '" + us + "'";
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
                        if (ordenSecuencia.Contains(aReader.GetValue(0)))
                        {
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
                    Actividad act = new Actividad();
                    SAADI.SeleccionarActividad.idAct = (int) ordenSecuencia[0];
                    act.mostrarActividad(((int)ordenSecuencia[0]), axFlash1,axFlash2);
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
                query = "SELECT IDActividad FROM Avance WHERE NombreUsuario = '" + us + "'";
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
                        actividadesResueltas.Add((int)aReader.GetValue(0));
                    }
                    exec.Connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR: No se puede continuar");
                }
                for (int i = 0; i < ordenSecuencia.Count; i++)
                {
                    if (actividadesResueltas.Contains(i))
                    {
                        actividadesPerfil.Remove(i);
                    }
                }
                Boolean paso = false;
                for (int i = 0; i < ordenSecuencia.Count; i++)
                {
                    if (actividadesPerfil.Contains(ordenSecuencia[i]))
                    {
                        Actividad act = new Actividad();
                        SAADI.SeleccionarActividad.idAct = (int)ordenSecuencia[i];
                        act.mostrarActividad((int)ordenSecuencia[i], axFlash1, axFlash2);
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

         
        public String getNivelDiscapacidad()
        {
            return nivelDiscapacidad;
        }

        public void setNivelDiscapacidad(String nivel)
        {
            nivelDiscapacidad = nivel;
        }

    }
}