using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios.Aplicacion;
using TiendaAPI.Servicios.Negocios;

namespace TiendaAPI.Servicios
{
    public class Servicios : IServicios
    {
        ApplicationBuilder _appBuilder;
        public Inventario Almacen { get; set; }
        private IServiciosNegocios _serviciosNegocios;
        private IServiciosAplicacion _serviciosAplicacion;
        public Servicios(IServiciosNegocios serviciosNegocios, IServiciosAplicacion serviciosAplicacion)
        { 
            _serviciosNegocios = serviciosNegocios;
            _serviciosAplicacion = serviciosAplicacion;
            InicializarAlmacen();
        }
        async void InicializarAlmacen()
        {
            Almacen = await _serviciosAplicacion.ObtenerAccesoBD().ObtenerElemento<Inventario>(0);
        }
        public IServiciosAplicacion ObtenerServiciosDeAplicacion()
        {
            return _serviciosAplicacion;
        }
        public IServiciosNegocios ObtenerServiciosDeNegocios()
        {
            return _serviciosNegocios;
        }
    }
}
