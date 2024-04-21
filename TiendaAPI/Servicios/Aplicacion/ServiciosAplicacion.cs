using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;

namespace TiendaAPI.Servicios.Aplicacion
{
    public class ServiciosAplicacion:IServiciosAplicacion
    {
        private IGenericFactory _genericFactory;
        private IPorSQLite _porSQLite;
        private IServiciosLogs _serviciosLogs;
        public ServiciosAplicacion(IGenericFactory genericFactory,IPorSQLite porSQLite,IServiciosLogs serviciosLogs)
        {
            _genericFactory = genericFactory;
            _porSQLite = porSQLite;
            _serviciosLogs=serviciosLogs;
        }
        public IGenericFactory ObtenerConstructor()
        {
            return _genericFactory;
        }
        public IPorSQLite ObtenerAccesoBD()
        {
            return _porSQLite;
        }
        public IServiciosLogs ObtenerServiciosLogs() 
        { 
            return _serviciosLogs;
        }
    }
}
