using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.ServiciosGenerales
{
    public class ServicioGeneral : IServiciosGenerales
    {
        private IPorSQLite _bd;
        private IGenericFactory _factory;
        public ServicioGeneral(IPorSQLite porSQLite, IGenericFactory factory)
        {
            _bd = porSQLite;
            _factory = factory;
        }
        public async Task AgregarProductos(ProductoAdaptado aInsertar)
        {
            if (aInsertar == null || string.IsNullOrEmpty(aInsertar.Descripcion) || aInsertar.Precio <= 0)
            {
                throw new ArgumentNullException(nameof(aInsertar));
            }

            var aguardar = await _factory.ConstruirElemento<Producto>();
            aguardar.Descripcion = aInsertar.Descripcion;
            aguardar.Precio = aInsertar.Precio;
            aguardar.Nombre = aInsertar.Nombre;

            await _bd.GuardarElemento<Producto>(aguardar);
        }
        public async Task<List<Producto>> ObtenerInformacionProductos()
        {
            return await _bd.ObtenerListaDeElementos<Producto>();
        }
        public async Task<Producto> ObtenerInformacionProductos(int id)
        {
            return await _bd.ObtenerElemento<Producto>(id);
        }
        public async Task ModificarProducto(Producto producto)
        {
            var encontrado= await _bd.ObtenerElemento<Producto>(producto.Id);
            if (encontrado == null)
                throw new Exception("Producto no encontrado");
            encontrado.Descripcion=producto.Descripcion;
            encontrado.Precio=producto.Precio;
            encontrado.Nombre=producto.Nombre;
            await _bd.ModificarElemento<Producto>(encontrado);
        }
        public async Task EliminarProductos(int id)
        {
            await _bd.EliminarElemento<Producto>(id);
        }
    }
}
