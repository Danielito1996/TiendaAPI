using TiendaAPI.Modelos.AreaVenta;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeOfertas
{
    public interface IRectorDeCategorias
    {
        public Task<List<Categorias>> ObtenerCategoriasDeVentas();
        public Task InsertarCategoria(Categorias categorias);
        public  Task EliminarCategoria(List<Categorias> lista);
        public Task<Categorias> ObtenerCategoriaPorID(int id);
        public Task ModificarCategoria(Categorias modificacion);
    }
}
