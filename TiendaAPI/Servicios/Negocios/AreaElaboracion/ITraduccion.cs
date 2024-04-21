using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public interface ITraduccion
    {
        Task<List<Ingrediente>> TraducirPlanGeneralAIngredientes(PlanGeneral planGeneral);
        Task<List<MateriaPrima>> TraducirIngredientesMateriasPrimas(List<Ingrediente> ingredientes);
        Task<MateriaPrima> TraducirIngredientesMateriasPrimas(Ingrediente ingredientes);
    }
}
