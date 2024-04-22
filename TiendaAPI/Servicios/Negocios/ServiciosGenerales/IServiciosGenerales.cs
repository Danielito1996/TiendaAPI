using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Servicios.Negocios.ServiciosGenerales
{
    public interface IServiciosGenerales
    {
        Task AgregarProductos(ProductoAdaptado aInsertar);
        Task<List<Producto>> ObtenerInformacionProductos();
        Task<Producto> ObtenerInformacionProductos(int id);
        Task ModificarProducto(Producto producto);
        Task EliminarProductos(int id);
    }
}
