using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;
using TiendaAPI.Servicios.Negocios.AreaVentas;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales;

namespace TiendaAPI.Servicios.Negocios
{
    public class ServiciosNegocios:IServiciosNegocios
    {
        private IServiciosAlmacen _serviciosAlmacen;
        private IServiciosElaboracion _serviciosElaboracion;
        private IServiciosVentas _serviciosVentas;
        private IServiciosGenerales _serviciosGenerales;
        public ServiciosNegocios(IServiciosGenerales serviciosGenerales,IServiciosAlmacen serviciosAlmacen, IServiciosElaboracion serviciosElaboracion, IServiciosVentas serviciosVentas)
        {
            _serviciosAlmacen = serviciosAlmacen;
            _serviciosElaboracion = serviciosElaboracion;
            _serviciosVentas = serviciosVentas;
            _serviciosGenerales=serviciosGenerales;
        }
        public IServiciosAlmacen ObtenerServiciosDeAlmacen()
        {
            return _serviciosAlmacen;
        }
        public IServiciosElaboracion ObtenerServiciosDeElaboracion()
        {
            return _serviciosElaboracion;
        }
        public IServiciosVentas ObtenerServiciosDeVentas()
        {
            return _serviciosVentas;
        }
        public IServiciosGenerales ObtenerServiciosGenerales()
        {
            return _serviciosGenerales;
        }
    }
}
