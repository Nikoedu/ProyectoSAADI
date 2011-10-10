
using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Windows.Forms;
public class Perfil {

	private String Nombre;
	// public Perfil_Actividad m_Perfil_Actividad;

	public Perfil(){

	}

    public Boolean tienenPerfil(String actividades)
    {
        int cantPerfiles = 0;
        String query = "SELECT COUNT(*) from Perfil";
        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
        OleDbConnection conexion = new OleDbConnection(cadena);
        OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
        OleDbCommand exec = new OleDbCommand(query, conexion);
        exec.Connection = conexion;
        exec.Connection.Open();
        OleDbDataReader aReader = exec.ExecuteReader();
        while (aReader.Read())
        {
            cantPerfiles = (int) aReader.GetValue(0);
        }
       
        conexion.Close();
        List<String> lista = new List<String>();
     
        for (int i = 1; i <= cantPerfiles; i++)
        {
            query = "SELECT IDActividad from Actividad_Perfil WHERE IDPerfil = " + i ;
            cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            conexion = new OleDbConnection(cadena);
            adap = new OleDbDataAdapter(query, conexion);
            exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            aReader = exec.ExecuteReader();
            int cont = 0;
            String formar_lista = "";
            while (aReader.Read())
            {
                if(cont != 0){
                    formar_lista = formar_lista + " - " + aReader.GetValue(0);
                }
                else{
                    formar_lista = formar_lista + aReader.GetValue(0);
                    cont++;
                }
            }
            lista.Add(formar_lista);
            MessageBox.Show(formar_lista);
        }
        Boolean existe = false;
        if (lista.Contains(actividades))
        {
            MessageBox.Show("Las actividades ya estan asociadas a un perfil");
            existe = true;
        }
        return existe;
    }

    public String getNombre()
    {
        return Nombre;
	}

	public void setNombre(String nombre){
        this.Nombre = nombre;
	}

}//end Perfil