using System;
using System.Data.OleDb;
using System.Windows.Forms;


public class GuiaVirtual {

	public GuiaVirtual(){

	}


	public String entregarInstrucciones(int idAc){
        String rutaInstrucciones = "";
        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        path = path.Substring(6, path.Length - 6);
        String BD = "\\BDLeni_be.accdb";
        String query = "SELECT RutaInstruccionesActividad FROM Actividad WHERE IDActividad =" + idAc;            
        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + BD;
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
                rutaInstrucciones = aReader.GetValue(0).ToString();
            }
            rutaInstrucciones = path + rutaInstrucciones;

        }
        catch (Exception e)
        {
            MessageBox.Show("ERROR: No se puede continuar");
        }
        return rutaInstrucciones;
	}
}