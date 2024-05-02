using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class Factura : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
