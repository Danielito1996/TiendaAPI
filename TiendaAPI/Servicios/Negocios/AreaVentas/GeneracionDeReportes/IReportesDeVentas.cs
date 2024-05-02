using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.GeneracionDeReportes
{
    public interface IReportesDeVentas
    {
        Task GenerarReporte(List<ProductoVendido> vendidos);
    }
}
