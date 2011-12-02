
using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
public class Perfil {

	private String Nombre;

	public Perfil(){

	}

    public Boolean tienenPerfil(String[] actSinGuion)
    {
        ArrayList acti = new ArrayList();
        for (int i = 0; i < actSinGuion.Length; i++)
        {
            acti.Add(actSinGuion[i]);
        }        
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
        Boolean existe = false;
        int existePerf = 0;
        int contador = 0;
        for (int i = 1; i <= cantPerfiles; i++)
        {
            existePerf = 0;
            query = "SELECT IDActividad from Actividad_Perfil WHERE IDPerfil = " + i;
            cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            conexion = new OleDbConnection(cadena);
            adap = new OleDbDataAdapter(query, conexion);
            exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                contador++;
                if (acti.Contains(aReader.GetValue(0).ToString()))
                {                              
                    existePerf++;
                }
                else
                {
                    contador = 0;
                    existePerf = 0;
                }                
            }
            if (existePerf == actSinGuion.Length && contador == actSinGuion.Length)
            {
                MessageBox.Show("Las actividades ya estan asociadas a un perfil");
                existe = true;
                i = cantPerfiles + 1;
            }
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

}