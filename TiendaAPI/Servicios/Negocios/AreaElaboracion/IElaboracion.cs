using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public interface IElaboracion
    {
        Task AnadirMateriaPrima(IngredienteAdaptado ingredientePrimaRecibida);
    }
}
