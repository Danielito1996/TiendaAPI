using TiendaAPI.Modelos.AreaAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen.AdaptadoresDeAlmacen
{
    public interface IAdaptadorMateriasPrimas
    {
        Task<MateriaPrima> Adaptar(MateriaPrimaAdapter recibido);
    }
}
