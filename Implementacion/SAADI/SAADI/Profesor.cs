using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using AxShockwaveFlashObjects;
using System.Collections;

namespace SAADI
{
    public class Profesor : Usuario{
    
        public Profesor()
        {
            
        }

        public void agregarUsuario(String TipoUs, String nom, String ape, String nomUs, String pass, DateTime fechadeNac, String nvl)
        {
            String tipoUsuario = TipoUs;
            setNombre(nom);
            setApellido(ape);
            setNombreUsuario(nomUs);
            setPassword(pass);
            setFechaNacimiento(fechadeNac);
            String nivelDiscapacidad = nvl;
            
            if (existeUsuario(getNombreUsuario()) == false)
            {
                if (tipoUsuario.Equals("Alumno"))
                {
                    int perfilDefecto = 1;
                    int estadoDefecto = 1;
                    String motivoDefecto = "Usuario Habilitado";
                    String query = "INSERT INTO Alumno VALUES('" + getNombreUsuario() + "'," + perfilDefecto + ",'" + getPassword() + "','" + getNombre() + "','" + getApellido() + "','" + getFechaNacimiento() + "','" + nivelDiscapacidad + "'," + estadoDefecto + ",'" + motivoDefecto + "')";
                    String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    OleDbConnection conexion = new OleDbConnection(cadena);
                    OleDbCommand exec = new OleDbCommand();
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    exec.CommandText = query;
                    exec.ExecuteNonQuery();
                    MessageBox.Show("El alumno fue registrado correctamente");
                }
                else if (tipoUsuario.Equals("Ayudante Tecnico"))
                {
                    int estadoDefecto = 1;
                    String motivoDefecto = "Usuario Habilitado";
                    String query = "INSERT INTO EncargadoEducacional VALUES('" + getNombreUsuario() + "','" + getPassword() + "','" + getNombre() + "','" + getApellido() + "','" + getFechaNacimiento() + "'," + estadoDefecto + ",'" + motivoDefecto + "','" + tipoUsuario + "')";
                    String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    OleDbConnection conexion = new OleDbConnection(cadena);
                    OleDbCommand exec = new OleDbCommand();
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    exec.CommandText = query;
                    exec.ExecuteNonQuery();
                    MessageBox.Show("El ayudante técnico fue registrado correctamente");
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
                String query = "SELECT EE.NombreUsuario, EE.Nombre, EE.Apellido from EncargadoEducacional AS EE WHERE EE.NombreUsuario LIKE '%" + param + "%' UNION SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE NombreUsuario LIKE '%" + param + "%'";
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
                String query = "SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE A.Nombre LIKE '%" + param + "%'";
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
                String query = "SELECT A.NombreUsuario, A.Nombre, A.Apellido from Alumno AS A WHERE A.FechadeNacimiento = DATEVALUE('" + param + "')";
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

        public void buscarPerfil(String param, DataGridView dataGridView1)
        {
            int contador = 0;
            String query = "SELECT COUNT(*) from Perfil";
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
            int[] IdsPerfil = new int[contador];
            int avanza = 0;
            query = "SELECT DISTINCT IDPerfil from Actividad_Perfil where IDActividad = " + param;
            cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            conexion = new OleDbConnection(cadena);
            adap = new OleDbDataAdapter(query, conexion);
            exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                IdsPerfil[avanza] = (int) aReader.GetValue(0);
                avanza++;
            }
            conexion.Close();
            DataSet ds = new DataSet();
            for (int i = 0; i < IdsPerfil.Length; i++)
            {
                query = "SELECT IDPerfil, NombrePerfil from Perfil WHERE IDPerfil = " + IdsPerfil[i] + "";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection con = new OleDbConnection(cadena);
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

        public void crearPerfilAlumno(String nombre, ListBox listb1, TextBox txt_ord)
        {
            Perfil per = new Perfil();
            per.setNombre(nombre);
            String actsinespacio = txt_ord.Text.Replace(" ", "");
            String[] actisinguion = actsinespacio.Split('-');
            if (per.tienenPerfil(actisinguion) == false)
            {                
                String query = "INSERT INTO Perfil(IDPerfil, NombrePerfil) VALUES (7,'" + per.getNombre() + "')";
                String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                OleDbConnection conexion = new OleDbConnection(cadena);
                OleDbCommand exec = new OleDbCommand();
                exec.Connection = conexion;
                exec.Connection.Open();
                exec.CommandText = query;
                exec.ExecuteNonQuery();
                conexion.Close();
                //Consultar por IDPerfil ingresado
                int IdPerfil = 0;
                query = "SELECT IDPerfil from Perfil where NombrePerfil = '" + per.getNombre() + "'";
                cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                conexion = new OleDbConnection(cadena);
                OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
                exec = new OleDbCommand(query, conexion);
                exec.Connection = conexion;
                exec.Connection.Open();
                OleDbDataReader aReader = exec.ExecuteReader();
                while (aReader.Read())
                {
                    IdPerfil = (int)aReader.GetValue(0);
                }

                conexion.Close();
                //Insertar actividades
                for (int i = 0; i < actisinguion.Length; i++)
                {
                    query = "INSERT INTO Actividad_Perfil(IDPerfil, IDActividad) VALUES (" + IdPerfil + "," + actisinguion[i]+")";
                    path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    conexion = new OleDbConnection(cadena);
                    exec = new OleDbCommand();
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    exec.CommandText = query;
                    exec.ExecuteNonQuery();
                }
                MessageBox.Show("El perfil fue creado correctamente");                
            }
            
            
        }

        public void inhabilitarUsuario(String nombreUs, String motivoInh)
        {
            if (existeUsuario(nombreUs) == true)
            {
                switch (MessageBox.Show("¿Esta seguro de realizar la accion?","Advertencia",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question))
                {
                        case DialogResult.Yes:
                        String query = "UPDATE Alumno SET Estado =" + 0 + ", Motivo_Inhabilitacion = '" + motivoInh + "' where NombreUsuario = '" + nombreUs + "'";
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
                        MessageBox.Show("Usuario inhabilitado correctamente");
                        break;
                }
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

        public void modificarPerfil(int IdPerfil, String nomPerfil, CheckedListBox checkedListBox1)
        {
            String query = "DELETE * FROM Actividad_perfil WHERE IDPERFIL = " + IdPerfil;
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbCommand exec = new OleDbCommand();
            exec.Connection = conexion;
            exec.Connection.Open();
            exec.CommandText = query;
            exec.ExecuteNonQuery();
            conexion.Close();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i) == true){
                    int idAct = i + 1;
                    query = "INSERT INTO ACTIVIDAD_PERFIL VALUES(" + IdPerfil + ","+ idAct +")";
                    path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                    conexion = new OleDbConnection(cadena);
                    exec = new OleDbCommand();
                    exec.Connection = conexion;
                    exec.Connection.Open();
                    exec.CommandText = query;
                    exec.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }

        public void modificarPerfilAlumno(String nombreUs, ComboBox com1)
        {
            Perfil perf = new Perfil();
            perf.setNombre(com1.SelectedItem.ToString());
            //Consultar por IDPerfil ingresado
            int IdPerfil = 0;
            String query = "SELECT IDPerfil from Perfil where NombrePerfil = '" + perf.getNombre() + "'";
            String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            OleDbConnection conexion = new OleDbConnection(cadena);
            OleDbDataAdapter adap = new OleDbDataAdapter(query, conexion);
            OleDbCommand exec = new OleDbCommand(query, conexion);
            exec.Connection = conexion;
            exec.Connection.Open();
            OleDbDataReader aReader = exec.ExecuteReader();
            while (aReader.Read())
            {
                IdPerfil = (int)aReader.GetValue(0);
            }

            conexion.Close();
            //Actualizar Alumno
            query = "UPDATE Alumno SET IDPerfil = " + IdPerfil + " where NombreUsuario = '" + nombreUs + "'";
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
            conexion = new OleDbConnection(cadena);
            try
            {
                exec = new OleDbCommand();
                exec.Connection = conexion;
                exec.Connection.Open();
                exec.CommandText = query;
                exec.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Cambio de Perfil Satisfactorio");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar: " + ex);
            }
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
                    {
                        com1.SelectedIndex = 0;
                        txt_n.Text = aReader.GetValue(0).ToString();
                        txt_a.Text = aReader.GetValue(1).ToString();
                        txt_c.Text = aReader.GetValue(2).ToString();
                        mcal1.SetDate(DateTime.Parse(aReader.GetValue(3).ToString()));
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
                        mcal1.SetDate(DateTime.Parse(aReader.GetValue(3).ToString()));
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
                        String query = "UPDATE Alumno SET nombre ='" + txt_n.Text + "', apellido = '" + txt_a.Text + "', contraseña = '" + txt_c.Text + "', FechadeNacimiento = DATEVALUE('" + mcal1.SelectionStart.ToString() + "'), NiveldeDiscapacidad = '" + com2.SelectedItem.ToString() + "' where NombreUsuario = '" + nombreUs + "'";
                        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                        OleDbConnection conexion = new OleDbConnection(cadena);
                        OleDbCommand exec = new OleDbCommand();
                        exec.Connection = conexion;
                        exec.Connection.Open();
                        exec.CommandText = query;
                        exec.ExecuteNonQuery();
                        MessageBox.Show("Alumno Modificado Correctamente");
                    }
                    else if (com1.SelectedItem.ToString() == "Ayudante Tecnico")
                    {
                        com2.Enabled = false;
                        String query = "UPDATE EncargadoEducacional SET nombre ='" + txt_n.Text + "', apellido = '" + txt_a.Text + "', contraseña = '" + txt_c.Text + "', FechadeNacimiento = '" + mcal1.SelectionStart.ToString() + "'  where NombreUsuario = '" + nombreUs + "'";
                        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                        String cadena = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\BDLeni_be.accdb"; // no toma el archivo..probemos directamente con C:
                        OleDbConnection conexion = new OleDbConnection(cadena);
                        OleDbCommand exec = new OleDbCommand();
                        exec.Connection = conexion;
                        exec.Connection.Open();
                        exec.CommandText = query;
                        exec.ExecuteNonQuery();
                        MessageBox.Show("Ayudante Tecnico Modificado Correctamente");
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
                DataSet ds = new DataSet();
                dataGridView1.DataSource = ds;
            }
            
        }
        public void seleccionarActividad(int idActividad, AxShockwaveFlash axFlash1)
        {
            Actividad act = new Actividad();
            act.mostrarActividad(idActividad, axFlash1);
        }
    }
}


