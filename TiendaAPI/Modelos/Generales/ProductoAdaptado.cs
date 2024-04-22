using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaVenta;

namespace TiendaAPI.Modelos.Generales
{
    public class ProductoAdaptado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
    }
}
