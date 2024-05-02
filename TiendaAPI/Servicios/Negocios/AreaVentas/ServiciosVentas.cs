using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Negocios.AreaElaboracion.StockDeElaboracion;
using TiendaAPI.Servicios.Negocios.AreaVentas.GeneracionDeReportes;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeProdcutosVendidos;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeVentas;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales.Adaptadores;

namespace TiendaAPI.Servicios.Negocios.AreaVentas
{
    public class ServiciosVentas : IServiciosVentas
    {
        private IControladorDeVentas _controladorVentas;
        private ITraduccion _traductor;
        private IGenericFactory _factory;
        private IProductosVendidos _productosVendidos;
        private IReportesDeVentas _reportesDeVentas;
        private IElaboracion _areaElaboracion;
        public ServiciosVentas(IControladorDeVentas controladorDeVentas, ITraduccion traductor, IReportesDeVentas reportesDeVentas, IGenericFactory factory, IProductosVendidos productosVendidos)
        {
            _controladorVentas = controladorDeVentas;
            _traductor = traductor;
            _factory = factory;
            _productosVendidos = productosVendidos;
            _reportesDeVentas = reportesDeVentas;
        }
        public async Task VenderProducto(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException("Lista de Productos vacias");
            await _controladorVentas.RealizarVentas(venta);

            var listaIngredientes = new List<List<Ingrediente>>();
            foreach (var item in venta.Productos)
            {
                await _productosVendidos.AnadirProducto(item);
                var ingredientes = await _traductor.TraducirProductosAIngredientes(item);
                listaIngredientes.Add(ingredientes);
            }
            List<Ingrediente> lista = await _traductor.ProductosDesglozadosAListaGeneral(listaIngredientes);
            await _areaElaboracion.ReducirIngredientes(lista);
        }
        public async Task GenerarReporteDeVentas(List<ProductoVendido> vendidos)
        {
            await _reportesDeVentas.GenerarReporte(vendidos);
        }
        public async Task<Venta> ObtenerVentas(int id)
        {
            return await _controladorVentas.ObtenerVentas(id);
        }
        public async Task<List<Venta>> ObtenerVentas()
        {
            return await _controladorVentas.ObtenerVentas();
        }
    }
}

