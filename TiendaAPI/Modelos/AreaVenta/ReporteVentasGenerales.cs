using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class ReporteVentasGenerales:IEntity
    {
        public int Id { get; set; }
        public List<Producto> ProductosVendidos { get; set; }
        public List<MateriaPrima> MateriaPrimaGastada { get; set; }
        public double TotalPrecioDeVentas { get; set; }
        public double TotalPrecioDeCosto { get; set; }
    }
}
