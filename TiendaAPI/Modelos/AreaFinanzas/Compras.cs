using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaFinanzas
{
    public class Compras : IEntity,IFinanzasModel
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public string MateriaPrima { get; set; }
        public double PrecioDeCompra { get; set; }
        public double Cantidad { get; set; }
        public string UnidadDeMedida { get; set; }
    }
}
