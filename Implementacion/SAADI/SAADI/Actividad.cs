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
            String ruta = "C:\\Documents and Settings\\Administrador\\Escritorio\\Copia de Rama Software\\Implementacion\\Actividades";
            MessageBox.Show(ruta + "\\" + idAc);
            axFlash1.LoadMovie(0, ruta + "\\" + idAc);
        }
    }
}