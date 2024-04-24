using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class StockDeProductos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
