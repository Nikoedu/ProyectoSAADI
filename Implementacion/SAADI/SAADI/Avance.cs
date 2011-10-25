using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace SAADI
{
    public class Avance
    {

        public Avance()
        {

        }
        
        public void guardarAvance(String nomUsAl, String usuario, String password, int idAct)
        {
            Usuario usu = new Usuario(); 
            if (usu.existeUsuario(usuario) == true)
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
                if ((tipoUs == "Ayudante Tecnico" || tipoUs == "Profesor") && pasoEstado2 == true)
                {
                    //Consultar si la actividad ya se guardo
                    int contador = 0;
                    query = "SELECT COUNT(*) from Avance where NombreUsuario = '"+nomUsAl+"' and IDActividad = "+idAct;
                    MessageBox.Show(""+idAct);
                    MessageBox.Show(nomUsAl);
                    cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    conexion = new OleDbConnection(cadena);
                    adap = new OleDbDataAdapter(query, conexion);
                    exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {
                        contador = (int)aReader.GetValue(0);
                    }
                    exec.Connection.Close();
                    //Insertar la actividad en la tabla avance
                    if (contador == 1)
                    {
                        MessageBox.Show("El usuario ya tiene guardada la actividad");
                    }
                    else
                    {
                        query = "INSERT INTO Avance(NombreUsuario,IDActividad) VALUES('" + nomUsAl + "'," + idAct + ")";
                        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                        cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb";
                        conexion = new OleDbConnection(cadena);
                        exec = new OleDbCommand();
                        try
                        {
                            exec.Connection = conexion;
                            exec.Connection.Open();
                            exec.CommandText = query;
                            exec.ExecuteNonQuery();
                            MessageBox.Show("Actividad Guardada Correctamente");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("No se pudo guardar la actividad");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña no es valida");
            }

        }

      
    }
}