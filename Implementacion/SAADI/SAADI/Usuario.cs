using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace SAADI{

    public class Usuario {

	protected String apellido;
    protected DateTime fechaNacimiento;
    protected String nombre;
    protected String nombreUsuario;
    protected String password;
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
            OleDbCommand exec = new OleDbCommand( query, conexion);
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
                        MessageBox.Show("El usuario esta deshabilitado, Motivo: " + aReader.GetValue(1).ToString());
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
            if (tipoUs == "Alumno" && contador != 1)
            {
                MessageBox.Show("Contraseña no valida");
            }
            if (tipoUs == "Ayudante Tecnico" && contador2 != 1)
            {
                MessageBox.Show("Contraseña no valida");
            }
            if (tipoUs == "Profesor" && contador2 != 1)
            {
                MessageBox.Show("Contraseña no valida");
            }
            if (tipoUs == "Alumno" && pasoEstado == true)
            {
                PantallaInicioAlumno pantIA = new PantallaInicioAlumno(usuario);
                pantIA.Show();
            }
            if (tipoUs == "Ayudante Tecnico" && pasoEstado2 == true)
            {
                MessageBox.Show("El usuario es un ayudante tecnico, por lo que no tiene panel");
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
		return apellido;
	}

	public DateTime getFechaNacimiento(){
        return fechaNacimiento;
	}

	public String getNombre(){
        return nombre;
	}

	public String getNombreUsuario(){
		return nombreUsuario;
	}

	public String getPassword(){
		return password;
	}

	public void setApellido(String apell){
        this.apellido = apell;
	}

	public void setFechaNacimiento(DateTime fec){
        this.fechaNacimiento = fec;
	}

	public void setNombre(String nom){
        this.nombre = nom;
	}

	public void setNombreUsuario(String nombreU){
        this.nombreUsuario = nombreU;
	}

	public void setPassword(String pass){
        this.password = pass;
	}
    }
}