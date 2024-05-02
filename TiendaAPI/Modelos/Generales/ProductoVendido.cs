using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.Generales
{
    public class ProductoVendido : IEntity
    {
        public int Id { get; set; }
        public Producto producto { get; set; }
        public double Cantidad { get; set; }
    }
}
