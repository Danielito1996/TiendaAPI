using TiendaAPI.Modelos.AreaAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen.Almacen
{
    public interface IAlmacen
    {
        Inventario Inventario { get; }
        Task InsertarCompras(List<MateriaPrima> materiaPrima);
        Task AnadirMateriaPrima(MateriaPrima materiaPrimaRecibida);
        Task<bool> RebajarMateriasPrimas(List<MateriaPrima> lista);
        Task QuitarMateriasPrimas(MateriaPrima materiaPrimaAdapter);
        Task<List<MateriaPrima>> ObtenerMateriasPrimas();
        Task ModificarMateriasPrimas(MateriaPrima materiaPrima);
        Task<MateriaPrima> ObtenerDatosDeMateriasPrimas(int Id);
    }
}
