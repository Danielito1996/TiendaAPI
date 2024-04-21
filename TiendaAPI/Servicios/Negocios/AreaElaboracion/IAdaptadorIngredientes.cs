using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public interface IAdaptadorIngredientes
    {
        Task<Ingrediente> Adaptar(IngredienteAdaptado recibido);
    }
}
