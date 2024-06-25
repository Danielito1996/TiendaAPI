using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeProdcutosVendidos
{
    public class ProductosVendidos : IProductosVendidos
    {
        private IPorSQLite _bd;
        private IGenericFactory _factory;
        public StockDeProductos Stock { get; set; }
        public ProductosVendidos(IPorSQLite bd, IGenericFactory factory)
        {
            _bd = bd;
            _factory = factory;
        }
        async Task InicializarStock()
        {

            Stock = (await _bd.ObtenerListaDeElementos<StockDeProductos>()).FirstOrDefault(i => i.Codigo == "inicial");
            if (Stock == null)
            {
                var stock = await _factory.ConstruirElemento<StockDeProductos>();

                stock.Codigo = "inicial";
                await _bd.GuardarElemento(stock);
            }
        }
        async Task ActualizarStock()
        {
            Stock = (await _bd.ObtenerListaDeElementos<StockDeProductos>()).FirstOrDefault(i => i.Codigo == "inicial");
        }
        async Task StockConCambios()
        {
            await _bd.ModificarElemento(Stock);
            await ActualizarStock();
        }
        public async Task AnadirProducto(ProductoVendido producto)
        {
            if (Stock == null)
            {
                await InicializarStock();
            }
            await ActualizarStock();
            var encontrada = Stock.Productos.FirstOrDefault(u => u.producto.Nombre == producto.producto.Nombre);
            if (encontrada == null)
            {
                Stock.Productos.Add(producto);
            }
            else
            {
                //encontrada. .Cantidad += ingredientes.Cantidad;
                await _bd.ModificarElemento(encontrada);
            }
            await StockConCambios();
        }
    }
}
