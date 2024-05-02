using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion.AdaptadoresDeElaboracion
{
    public interface IAdaptadorIngredientes
    {
        Task<Ingrediente> Adaptar(IngredienteAdaptado recibido);
    }
}
