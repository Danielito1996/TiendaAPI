using TiendaAPI.Servicios.Aplicacion;
using TiendaAPI.Servicios.Negocios;

namespace TiendaAPI.Servicios
{
    public interface IServicios
    {
        IServiciosAplicacion ObtenerServiciosDeAplicacion();
        IServiciosNegocios ObtenerServiciosDeNegocios();
    }
}
