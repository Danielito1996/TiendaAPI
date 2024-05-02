using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class Venta : IEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public List<ProductoVendido> Productos { get; set; }

        public double ActualizarMonto()
        {
            var monto = Productos.Sum(u => u.producto.Precio);
            return monto;
        }

    }
}
