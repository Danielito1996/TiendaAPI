using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Servicios.Negocios.ServiciosGenerales
{
    public interface IServiciosGenerales
    {
        Task AgregarProductos(ProductoAdaptado aInsertar);
    }
}
