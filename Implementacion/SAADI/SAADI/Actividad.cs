using System;
using System.Windows.Forms;
using AxShockwaveFlashObjects;
namespace SAADI
{
    public class Actividad
    {

        private String nombre;
        private String tipo;

        public Actividad()
        {

        }

        public String getNombre()
        {
            return nombre;
        }

        public String getTipo()
        {
            return tipo;
        }

        public void setNombre(String nom)
        {
            nombre = nom;
        }

        public void setTipo(String tip)
        {
            tipo = tip;
        }

        public void mostrarActividad(int idAc, AxShockwaveFlash axFlash1)
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(0, 12);
            MessageBox.Show(path);
            String ruta = "\\Actividades";
            MessageBox.Show(ruta + "\\" + idAc);
            axFlash1.LoadMovie(0, ruta + "\\" + idAc);
        }
    }
}