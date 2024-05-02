using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class ReporteVentasGenerales : IEntity
    {
        public int Id { get; set; }
        public List<ProductoVendido> ProductosVendidos { get; set; }
        public double TotalPrecioDeVentas { get; set; }
        public double TotalPrecioDeCosto { get; set; }
    }
}
