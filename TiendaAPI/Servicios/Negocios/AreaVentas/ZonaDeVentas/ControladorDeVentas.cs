using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeProdcutosVendidos;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeVentas
{
    public class ControladorDeVentas : IControladorDeVentas
    {
        private IProductosVendidos _productosVendidos;
        private IPorSQLite _bd;
        public ControladorDeVentas(IPorSQLite bd, IProductosVendidos productosVendidos)
        {
            _productosVendidos = productosVendidos;
            _bd = bd;
        }
        public async Task RealizarVentas(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException("Venta enviada nula");
            await _bd.GuardarElemento<Venta>(venta);
        }
        public async Task<Venta> ObtenerVentas(int id)
        {
            return await _bd.ObtenerElemento<Venta>(id);
        }
        public async Task<List<Venta>> ObtenerVentas()
        {
            return await _bd.ObtenerListaDeElementos<Venta>();
        }
    }
}
