using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace SAADI
{
    public class Profesor : Usuario
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
            if (existeUsuario(username) == false)
            {
                if (tipoUsuario.Equals("Alumno"))
                {
                    int perfilDefecto = 1;
                    int estadoDefecto = 1;
                    String motivoDefecto = "Usuario Habilitado";
                    String query = "INSERT INTO Alumno VALUES('" + username + "'," + perfilDefecto + ",'" + password + "','" + nombre + "','" + apellido + "','" + fechaNacimiento + "','" + nivelDiscapacidad + "'," + estadoDefecto + ",'" + motivoDefecto + "')";
                    MessageBox.Show(query);
                    String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    MessageBox.Show(path);
                    String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    OleDbConnection conexion = new OleDbConnection(cadena);
                    OleDbCommand exec = new OleDbCommand();
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    exec.CommandText = query;
                    exec.ExecuteNonQuery();
                }
                else if (tipoUsuario.Equals("Ayudante Tecnico"))
                {
                    int estadoDefecto = 1;
                    String motivoDefecto = "Usuario Habilitado";
                    String query = "INSERT INTO EncargadoEducacional VALUES('" + username + "','" + password + "','" + nombre + "','" + apellido + "','" + fechaNacimiento + "'," + estadoDefecto + ",'" + motivoDefecto + "','" + tipoUsuario + "')";
                    MessageBox.Show(query);
                    String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    MessageBox.Show(path);
                    String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    OleDbConnection conexion = new OleDbConnection(cadena);
                    OleDbCommand exec = new OleDbCommand();
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    exec.CommandText = query;
                    exec.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("El Usuario Ya Existe, Elija Otro Nombre De Usuario");
            }
        }

        public void buscarUsuario(String param, String tipoBus, DataGridView dataGridView1)
        {
            if (tipoBus.Equals("NombreUsuario"))
            {
                String query = "SELECT EE.NombreUsuario, EE.Nombre, EE.Apellido from EncargadoEducacional AS EE WHERE NombreUsuario = '"+param+"' UNION SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE NombreUsuario = '"+param+"'";
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection con = new OleDbConnection(cadena);
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(query, con);
                    oledbAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();                 
            }
            if (tipoBus.Equals("NombreAlumno"))
            {
                String query = "SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE A.Nombre = '" + param + "'";
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection con = new OleDbConnection(cadena);
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(query, con);
                    oledbAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();  
            }
            if (tipoBus.Equals("FechaDeNacimiento"))
            {
                DateTime fechaNac = DateTime.Parse(param);
                param = String.Format("{0:d}", fechaNac);
                String query = "SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE FechadeNacimiento = '" + param+ "'";
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection con = new OleDbConnection(cadena);
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(query, con);
                    oledbAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();  
            }
            if (tipoBus.Equals("NivelDiscapacidad"))
            {
                String query = "SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE NiveldeDiscapacidad = '" + param + "'";
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection con = new OleDbConnection(cadena);
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(query, con);
                    oledbAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();  
            }
        }

        public void buscarPerfil(String param)
        {
            
        }

        public void crearPerfilAlumno(String nombre, String[] actividad)
        {

        }

        public void inhabilitarUsuario(String nombreUs, String motivoInh)
        {
            if (existeUsuario(nombreUs) == true)
            {
                String query = "UPDATE Alumno SET Estado =" + 0 + ", Motivo_Inhabilitacion = '" + motivoInh + "' where NombreUsuario = '" + nombreUs + "'";
                MessageBox.Show(query);
                String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection conexion = new OleDbConnection(cadena);
                OleDbCommand exec = new OleDbCommand();
                exec.Connection = conexion;
                exec.Connection.Open();
                exec.CommandText = query;
                exec.ExecuteNonQuery();
                conexion.Close();
                //Si es ayudante Tecnico 
                query = "UPDATE EncargadoEducacional SET Estado =" + 0 + ", Motivo_Inhabilitacion = '" + motivoInh + "' where NombreUsuario = '" + nombreUs + "'";
                MessageBox.Show(query);
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                exec = new OleDbCommand();
                exec.Connection = conexion;
                exec.Connection.Open();
                exec.CommandText = query;
                exec.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("El Usuario no existe. Ingrese uno valido");
            }
        }

        public void listarUsuarios(DataGridView dataGridView1)
        {
            String query = "SELECT EE.NombreUsuario, EE.TipoEncargadoEducacional , EE.Estado, EE.Motivo_Inhabilitacion from EncargadoEducacional AS EE UNION SELECT A.NombreUsuario, 'Alumno', A.Estado, A.Motivo_Inhabilitacion from Alumno AS A ";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection con = new OleDbConnection(cadena);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(query, con);
                oledbAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();  
        }

        public void modificarPerfilAlumno(String nombre, String[] actividades)
        {

        }

        public void modificarUsuario(Boolean pedirDatos, String nombreUs, Panel pan, ComboBox com1, TextBox txt_n, TextBox txt_a, TextBox txt_c, MonthCalendar mcal1, ComboBox com2)
        {
            if (pedirDatos == true)
            {
                if (existeUsuario(nombreUs) == true)
                {
                    String query = "SELECT Nombre, Apellido, Contraseña, FechadeNacimiento, NiveldeDiscapacidad from Alumno AS A WHERE NombreUsuario = '" + nombreUs + "'";
                    String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    OleDbConnection conexion = new OleDbConnection(cadena);
                    OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                    OleDbCommand exec = new OleDbCommand(query, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    OleDbDataReader aReader = exec.ExecuteReader();
                    while (aReader.Read())
                    {//ejecutalo
                        com1.SelectedIndex = 0;
                        txt_n.Text = aReader.GetValue(0).ToString();
                        txt_a.Text = aReader.GetValue(1).ToString();
                        txt_c.Text = aReader.GetValue(2).ToString();
                        mcal1.SelectionStart = DateTime.Parse(aReader.GetValue(3).ToString());
                        if (aReader.GetValue(4).ToString() == "Bajo")
                        {
                            com2.SelectedIndex = 0;
                        }
                        if (aReader.GetValue(4).ToString() == "Medio")
                        {
                            com2.SelectedIndex = 1;
                        }
                        if (aReader.GetValue(4).ToString() == "Alto")
                        {
                            com2.SelectedIndex = 2;
                        }
                    }
                    exec.Connection.Close();
                    //Ahora para el Encargado Educacional
                    String query2 = "SELECT Nombre, Apellido, Contraseña, FechadeNacimiento from EncargadoEducacional AS A WHERE NombreUsuario = '" + nombreUs + "'";
                    conexion = new OleDbConnection(cadena);
                    adap = new OleDbDataAdapter(query2, conexion);
                    exec = new OleDbCommand(query2, conexion);
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    aReader = exec.ExecuteReader();
                    Boolean ayud = false;
                    while (aReader.Read())
                    {
                        com1.SelectedIndex = 1;
                        txt_n.Text = aReader.GetValue(0).ToString();
                        txt_a.Text = aReader.GetValue(1).ToString();
                        txt_c.Text = aReader.GetValue(2).ToString();
                        mcal1.SelectionStart = DateTime.Parse(aReader.GetValue(3).ToString());
                        ayud = true;
                        
                    }
                    exec.Connection.Close();                    
                    pan.Visible = true;
                    if (ayud == true)
                    {
                        com2.Enabled = false;
                    }
                }
            }
                
     
            if (pedirDatos == false){
                    pan.Visible = true;
                    if (com1.SelectedItem.ToString() == "Alumno")
                    {
                        String query = "UPDATE Alumno SET nombre ='" + txt_n.Text + "', apellido = '" + txt_a.Text + "', contraseña = '" + txt_c.Text + "', FechadeNacimiento = '" + mcal1.SelectionStart.ToString() + "', NiveldeDiscapacidad = '" + com2.SelectedItem.ToString() + "' where NombreUsuario = '" + nombreUs + "'";
                        MessageBox.Show(query);
                        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                        OleDbConnection conexion = new OleDbConnection(cadena);
                        OleDbCommand exec = new OleDbCommand();
                        exec.Connection = conexion;
                        exec.Connection.Open();
                        exec.CommandText = query;
                        exec.ExecuteNonQuery();
                    }
                    else if (com1.SelectedItem.ToString() == "Ayudante Tecnico")
                    {
                        com2.Enabled = false;
                        String query = "UPDATE EncargadoEducacional SET nombre ='" + txt_n.Text + "', apellido = '" + txt_a.Text + "', contraseña = '" + txt_c.Text + "', FechadeNacimiento = '" + mcal1.SelectionStart.ToString() + "'  where NombreUsuario = '" + nombreUs + "'";
                        MessageBox.Show(query);
                        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                        OleDbConnection conexion = new OleDbConnection(cadena);
                        OleDbCommand exec = new OleDbCommand();
                        exec.Connection = conexion;
                        exec.Connection.Open();
                        exec.CommandText = query;
                        exec.ExecuteNonQuery();
                    }                
            }
            
        }

        public void obtenerReporteActividadesRealizadas(String nombreUs, DataGridView dataGridView1)
        {
            int contador = 0;
            String query = "SELECT COUNT(*) from Alumno where NombreUsuario = '" + nombreUs + "'";
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
            if (contador == 1)
            {
                query = "SELECT A.NombreUsuario, A.IDActividad, Ac.NombreActividad  from Avance AS A, Actividad AS Ac WHERE A.IDActividad = Ac.IDActividad AND NombreUsuario = '"+nombreUs+"'";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection con = new OleDbConnection(cadena);
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(query, con);
                    oledbAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();  
            }
            else
            {
                MessageBox.Show("El usuario no existe o no es un alumno");
            }
            
        }
        public void seleccionarActividad(String nombre)
        {

        }

    }//end Profesor
}


