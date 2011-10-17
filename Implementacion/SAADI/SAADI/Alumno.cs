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

        public void leerActividad(String us, AxShockwaveFlash axFlash1)
        {
            ArrayList ordenSecuencia = new ArrayList();
            int idPerfil = 0;
            // Obtiene el perfil del alumno
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
                //Obtiene las actividades que ha desarrollado el alumno y lo guarda en un arraylist (Avance)
                query = "SELECT IDActividad FROM Avance WHERE NombreUsuario = '" + us + "'";
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
                    act.mostrarActividad(((int)ordenSecuencia[0]), axFlash1);
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
                query = "SELECT IDActividad FROM Avance WHERE NombreUsuario = '" + us + "'";
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
                        act.mostrarActividad((int)ordenSecuencia[i], axFlash1);
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