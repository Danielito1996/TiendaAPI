using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class StockDeProductos : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public List<ProductoVendido> Productos { get; set; }
    }
}
