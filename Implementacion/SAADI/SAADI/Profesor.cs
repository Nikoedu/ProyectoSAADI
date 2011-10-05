using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SAADI
{
    public class Profesor //: Usuario
    {
        System.Data.OleDb.OleDbConnection conexion = new System.Data.OleDb.OleDbConnection();

        //public Avance m_Avance;
        String tipoUsuario;
        String nombre;
        String apellido;
        String username;
        String password;
        DateTime fechaNacimiento;
        String nivelDiscapacidad;

        public Profesor()
        {

        }

        public Profesor(String TipoUs, String nom, String ape, String nomUs, String pass, DateTime fechadeNac, String nvl)
        {
            this.tipoUsuario = TipoUs;
            this.nombre = nom;
            this.apellido = ape;
            this.username = nomUs;
            this.password = pass;
            this.fechaNacimiento = fechadeNac;
            this.nivelDiscapacidad = nvl;
        }

        //public override void Dispose()
        //{

        //}

        public void agregarUsuario()
        {
            if(tipoUsuario == "Alumno"){
            int perfilDefecto = 1;
            int estadoDefecto = 1;
            String motivoDefecto = "Usuario Habilitado";
            String query = "INSERT INTO Alumno VALUES('"+username+"',"+perfilDefecto+",'"+password+"','"+nombre+"','"+apellido+"','"+fechaNacimiento+"','"+nivelDiscapacidad+"',"+estadoDefecto+",'"+motivoDefecto+"')";
            MessageBox.Show(query);            
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            MessageBox.Show(path);
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            //conexion.Open();
            OleDbCommand exec = new OleDbCommand();
            exec.Connection = conexion;
            exec.Connection.Open();
            exec.CommandText = query;
            exec.ExecuteNonQuery();
            } 
            else if(tipoUsuario == "Ayudante Tecnico"){

            }
        }

        public void buscarPerfil(String param)
        {

        }

        public void crearPerfilAlumno(String nombre, String[] actividad)
        {

        }

        public void inhabilitarUsuario()
        {

        }

        public void listarUsuarios()
        {

        }

        public void modificarPerfilAlumno(String nombre, String[] actividades)
        {

        }

        public void modificarUsuario()
        {

        }

        public void obtenerReporteActividadesRealizadas()
        {

        }
        public void seleccionarActividad(String nombre)
        {

        }

    }//end Profesor
}


