using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAADI
{
    public class Profesor //: Usuario
    {

        //public Avance m_Avance;

        public Profesor()
        {

        }

        ~Profesor()
        {

        }

        //public override void Dispose()
        //{

        //}

        public void agregarUsuario()
        {
           // String query = "INSERT INTO ALUMNO VALUES()";
            //String nombre;

            System.Data.OleDb.OleDbConnection conexion = new System.Data.OleDb.OleDbConnection();
            conexion.ConnectionString = @"PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documentacion\base.mdb";
            conexion.Open();
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


