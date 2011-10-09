using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace SAADI{

    public class Usuario {

	private String apellido;
	private DateTime fechaNacimiento;
	private String nombre;
	private String nombreUsuario;
	private String password;
	public GuiaVirtual m_GuiaVirtual;

	public Usuario(){

	}

	~Usuario(){

	}

	public virtual void Dispose(){

	}

	public void autentificarUsuario(String usuario, String password){
        if (existeUsuario(usuario) == true)
        {
            int contador = 0;
            int contador2 = 0;
            Boolean pasoEstado = false;
            Boolean pasoEstado2 = false;
            String tipoUs = "";
            String query = "SELECT COUNT(*) from Alumno where NombreUsuario = '" + usuario + "' and Contraseña = '"+password+"'";
            String query2 = "SELECT COUNT(*) from EncargadoEducacional where NombreUsuario = '" + usuario + "' and Contraseña = '" + password + "'";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
            OleDbCommand exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            OleDbDataReader aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                contador = (int)aReader.GetValue(0);
            }
            exec.Connection.Close();
            exec = new OleDbCommand(query2, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                contador2 = (int)aReader.GetValue(0);
            }
            if (contador == 1)
            {
                tipoUs = "Alumno";
                query = "SELECT Estado, Motivo_Inhabilitacion FROM Alumno where NombreUsuario = '" + usuario + "'";
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
                        pasoEstado = true;
                    }
                    else
                    {
                        MessageBox.Show("El usuario esta deshabilitado, Motivo: "+aReader.GetValue(1).ToString());
                    }
                }
                
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
                query = "SELECT TipoEncargadoEducacional FROM EncargadoEducacional where NombreUsuario = '"+usuario+"' and contraseña = '"+password+"'";
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
            if (tipoUs == "Alumno" && pasoEstado == true)
            {
                PantallaInicioAlumno pantIA = new PantallaInicioAlumno();
                pantIA.Show();
            }
            if (tipoUs == "Ayudante Tecnico" && pasoEstado2 == true)
            {
                PantallaInicioAyTecnico pantIAT = new PantallaInicioAyTecnico();
                pantIAT.Show();
            }
            if (tipoUs == "Profesor" && pasoEstado2 == true)
            {
                PantallaInicioProfesor pantIP = new PantallaInicioProfesor();
                pantIP.Show();
            }
        }
        else
        {
            MessageBox.Show("El usuario no existe. Ingrese uno valido");
        }

	}

	public Boolean existeUsuario(String nombreus){
        Boolean existe;
        int contador = 0;
        int contador2 = 0;
        String query = "SELECT COUNT(*) from Alumno where NombreUsuario = '" + nombreus+"'";
        String query2 = "SELECT COUNT(*) from EncargadoEducacional where NombreUsuario = '" + nombreus+"'";
        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
        OleDbConnection conexion = new OleDbConnection(cadena);
        OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);        
        OleDbCommand exec = new OleDbCommand(query, conexion);
        exec.Connection = conexion;
        exec.Connection.Open();
        OleDbDataReader aReader = exec.ExecuteReader();
         while(aReader.Read())
        {
            contador = (int) aReader.GetValue(0);
        }
         exec.Connection.Close();
         exec = new OleDbCommand(query2, conexion);
         exec.Connection = conexion;
         exec.Connection.Open();
         aReader = exec.ExecuteReader();
         while (aReader.Read())
         {
             contador2 = (int) aReader.GetValue(0);
         }
         if (contador == 1 || contador2 == 1)
         {
             existe = true;
         }
         else
         {
             existe = false;
         }
         return existe;
	}

	public String getApellido(){
		return "";
	}

	public DateTime getFechaNacimiento(){
        return DateTime.Today; //Cambiar
	}

	public String getNombre(){

		return "";
	}

	public String getNombreUsuario(){

		return "";
	}

	public String getPassword(){

		return "";
	}

	/// 
	/// <param name="apellido"></param>
	public void setApellido(String apellido){

	}

	/// 
	/// <param name="fecha"></param>
	public void setFechaNacimiento(DateTime fecha){

	}

	/// 
	/// <param name="nombre"></param>
	public void setNombre(String nombre){

	}

	/// 
	/// <param name="nombreUsuario"></param>
	public void setNombreUsuario(String nombreUsuario){

	}

	/// 
	/// <param name="password"></param>
	public void setPassword(String password){

	}
    }
}//end Usuario