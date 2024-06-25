using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Aplicacion.BaseDatos
{
    public interface IPorSQLite
    {
        //ObtenerListas Con sus Sobrecargas
        Task<List<T>> ObtenerListaDeElementos<T>() where T : class, new();
        Task<List<T>> ObtenerListaDeElementos<T>(Inventario inventario) where T : class, new();
        Task<List<T>> ObtenerListaDeElementos<T>(StockDeIngredientes stock) where T : class, new();
        public Task<List<T>> ObtenerListaDeElementos<T>(Ofertas ofertas) where T : class, new();
        public  Task<List<T>> ObtenerListaDeElementos<T>(List<Categorias> categorias) where T : class, new();
        public Task<bool> GuardarListaDeElementos<T>(List<T> list) where T : class, IEntity, new();
        Task<T> ObtenerElemento<T>(int id) where T : class, IEntity, new();
        Task<bool> GuardarElemento<T>(T item) where T : class, new();
        Task<bool> ModificarElemento<T>(T item) where T : class, IEntity, new();
        Task<bool> EliminarElemento<T>(int id) where T : class, IEntity, new();
    }
}
