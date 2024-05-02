using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;
namespace TiendaAPI.Modelos.AreaVenta
{
    public class ProductosListosParaVentas : IEntity
    {
        public int Id { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
