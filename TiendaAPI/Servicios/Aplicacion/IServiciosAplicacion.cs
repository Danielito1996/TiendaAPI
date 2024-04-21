using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;

namespace TiendaAPI.Servicios.Aplicacion
{
    public interface IServiciosAplicacion
    {
        IGenericFactory ObtenerConstructor();
        IPorSQLite ObtenerAccesoBD();
        IServiciosLogs ObtenerServiciosLogs();
    }
}
