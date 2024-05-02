using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.ServicioDeTraduccion.Traductores
{
    public class AdaptadorVentas : IAdaptadorVentas
    {
        private IGenericFactory _factory;
        public AdaptadorVentas(IGenericFactory factory)
        {
            _factory = factory;
        }
        public async Task<ProductoVendido> TraducirProductoAProductoVendido(Producto producto, double Cantidad)
        {
            var productoVendido = await _factory.ConstruirElemento<ProductoVendido>();
            productoVendido.producto = producto;
            productoVendido.Cantidad = Cantidad;
            return productoVendido;
        }
    }
}
