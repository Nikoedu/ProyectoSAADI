using System;
using System.Windows.Forms;
using AxShockwaveFlashObjects;
using System.Data.OleDb;
namespace SAADI
{
    public class Actividad
    {
        
        private String nombre;
        private String tipo;

        public Actividad()
        {

        }

        public String getNombre()
        {
            return nombre;
        }

        public String getTipo()
        {
            return tipo;
        }

        public void setNombre(String nom)
        {
            nombre = nom;
        }

        public void setTipo(String tip)
        {
            tipo = tip;
        }

        public void mostrarActividad(int idAc, AxShockwaveFlash axFlash1, AxShockwaveFlash axFlash2)
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6, path.Length - 6);
            String path2 = path + "\\Actividad\\Instrucciones\\Leni.swf";
            String path3 = path + "\\Actividad\\Instrucciones\\";            
            String query = "SELECT NombreActividad,RutaActividad FROM Actividad WHERE IDActividad ="+idAc;
            String BD = "\\BDLeni_be.accdb";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+BD; 
            OleDbConnection conexion = new OleDbConnection(cadena);
            GuiaVirtual gv = new GuiaVirtual();
            String rutaInstrucciones = gv.entregarInstrucciones(idAc);
            try
            {
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                OleDbCommand exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                while (aReader.Read())
                {
                    String nomAct = aReader.GetValue(0).ToString();
                    if (SAADI.AutentificarUsuario.Bienvenida == true)
                    {                        
                        PantallaInicioAlumno pIA = new PantallaInicioAlumno(SAADI.PantallaInicioAlumno.us);
                        pIA.Text = pIA.Text + " - Nombre Actividad: " + nomAct;
                        pIA.ShowDialog();
                        String rutaAct = aReader.GetValue(1).ToString();
                        path = path + rutaAct;
                        pIA.axShockwaveFlash2.FlashVars = "var1=" + rutaInstrucciones + "&var2=x";
                        pIA.axShockwaveFlash2.LoadMovie(0, path2);   
                        pIA.axShockwaveFlash1.LoadMovie(0, path);                                             
                    }
                    else
                    {
                        SAADI.AutentificarUsuario.Bienvenida = true;
                        SAADI.PantallaInicioAlumno.idActTitulo = " Nombre Actividad: " + nomAct;
                        String rutaAct = aReader.GetValue(1).ToString();
                        String paso = path3 + "Bienvenida.mp3";
                        path = path + rutaAct;
                        axFlash2.FlashVars = "var1=" + rutaInstrucciones + "&var2=" + paso;
                        axFlash2.LoadMovie(0, path2); 
                        axFlash1.LoadMovie(0, path);           
                    }
                    
                }
                exec.Connection.Close();
            }
            catch (Exception e)
            {
               MessageBox.Show(e.ToString());
            }
        }
    }
}