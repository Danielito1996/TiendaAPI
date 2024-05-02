using TiendaAPI.Modelos.AreaVenta;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeVentas
{
    public interface IControladorDeVentas
    {
        Task RealizarVentas(Venta venta);
        Task<Venta> ObtenerVentas(int Id);
        Task<List<Venta>> ObtenerVentas();
    }
}
