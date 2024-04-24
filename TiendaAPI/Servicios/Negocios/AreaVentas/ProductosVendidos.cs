using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;

namespace TiendaAPI.Servicios.Negocios.AreaVentas
{
    public class ProductosVendidos
    {
        private IPorSQLite _bd;
        public StockDeProductos Stock { get; set; }
        public ProductosVendidos(IPorSQLite bd)
        {
            _bd = bd;
        }


    }
}
