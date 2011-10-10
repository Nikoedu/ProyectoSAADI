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

	/// 
	/// <param name="usuario"></param>
	/// <param name="password"></param>
	public void autentificarUsuario(String usuario, String password){

	}

	/// 
	/// <param name="String"></param>
	public void existeUsuario(String nombreus){
        int contador = 0;
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
            MessageBox.Show(aReader.GetValue(0).ToString());

        }
         exec.Connection.Close();


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