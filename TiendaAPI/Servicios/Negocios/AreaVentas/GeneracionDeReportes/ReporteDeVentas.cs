using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.GeneracionDeReportes
{
    public class ReporteDeVentas : IReportesDeVentas
    {
        private IPorSQLite _bd;
        private IGenericFactory _factory;
        public ReporteDeVentas(IPorSQLite bd, IGenericFactory factory)
        {
            _bd = bd;
            _factory = factory;
        }
        public async Task GenerarReporte(List<ProductoVendido> vendidos)
        {
            double precioCosto = 0, precioVenta = 0;
            var cartasTecnicas = await _bd.ObtenerListaDeElementos<NormasTecnicas>();
            var reporte = await _factory.ConstruirElemento<ReporteVentasGenerales>();
            foreach (var v in vendidos)
            {
                double valor = cartasTecnicas.FirstOrDefault(u => u.Producto.Descripcion == v.producto.Descripcion).PrecioDeCosto ?? 0.0;
                precioCosto += valor * v.Cantidad;
            }
        }
        public async Task<Venta> ObtenerVenta(int id)
        {
            return await _bd.ObtenerElemento<Venta>(id);
        }

    }
}
