using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeProdcutosVendidos
{
    public interface IProductosVendidos
    {
        Task AnadirProducto(ProductoVendido producto);
    }
}
