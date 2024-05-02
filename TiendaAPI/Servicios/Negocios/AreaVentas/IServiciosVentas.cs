using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Servicios.Negocios.AreaVentas
{
    public interface IServiciosVentas
    {
        Task GenerarReporteDeVentas(List<ProductoVendido> vendidos);
        Task VenderProducto(Venta venta);
        Task<Venta> ObtenerVentas(int id);
        Task<List<Venta>> ObtenerVentas();
    }
}
