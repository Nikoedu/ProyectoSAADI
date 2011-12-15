
using AxShockwaveFlashObjects;
namespace SAADI{
    public class AyudanteTecnico : Usuario {
        
	    public AyudanteTecnico(){

	    }

        public void seleccionarActividad(int idActividad, AxShockwaveFlash axFlash1, AxShockwaveFlash axFlash2)
        {
            Actividad act = new Actividad();
            act.mostrarActividad(idActividad, axFlash1, axFlash2);
        }

    }
}