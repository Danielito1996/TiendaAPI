using TiendaAPI.Modelos.AreaAlmacen;

namespace TiendaAPI.Servicios.Negocios.ServicioDeTraduccion.AdaptadoresDeAlmacen
{
    public interface IAdaptadorMateriasPrimas
    {
        Task<MateriaPrima> Adaptar(MateriaPrimaAdapter recibido);
    }
}
