using TiendaAPI.Servicios.Negocios.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;
using TiendaAPI.Servicios.Negocios.AreaVentas;

namespace TiendaAPI.Servicios.Negocios
{
    public interface IServiciosNegocios
    {
        IServiciosAlmacen ObtenerServiciosDeAlmacen();
        IServiciosElaboracion ObtenerServiciosDeElaboracion();
        IServiciosVentas ObtenerServiciosDeVentas();
    }
}
