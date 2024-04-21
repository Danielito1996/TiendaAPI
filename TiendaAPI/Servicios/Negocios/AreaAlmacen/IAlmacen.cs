using TiendaAPI.Modelos.AreaAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public interface IAlmacen
    {
        Inventario Inventario { get;}
        Task AnadirMateriaPrima(MateriaPrimaAdapter materiaPrimaRecibida);
        Task<bool> RebajarMateriasPrimas(List<MateriaPrima> lista);
    }
}
