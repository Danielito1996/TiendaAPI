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
            var aguardar = await _factory.ConstruirElemento<Producto>();
            if ((aInsertar == null)||(aInsertar.Descripcion != "")||(aInsertar.Precio != 0))
            {
                throw new ArgumentNullException(nameof(aInsertar));
            }
            aguardar.Descripcion= aInsertar.Descripcion;
            aguardar.Precio= aInsertar.Precio;
            
            await _bd.GuardarElemento<Producto>(aguardar);
        }
    }
}
