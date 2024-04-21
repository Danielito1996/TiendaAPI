using TiendaAPI.Modelos.AreaAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public interface IAdaptadorMateriasPrimas
    {
        Task<MateriaPrima> Adaptar(MateriaPrimaAdapter recibido);
    }
}
