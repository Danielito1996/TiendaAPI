using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaFinanzas
{
    public class Compras : IEntity
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public MateriaPrimaAdapter MateriaPrima { get; set; }
        public double PrecioDeCompra { get; set; }
    }
}
