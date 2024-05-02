using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion.StockDeElaboracion
{
    public interface IElaboracion
    {
        Task AnadirIngredientes(Ingrediente ingredientes);
        Task AnadirIngredientes(List<Ingrediente> ingredientesPrimaRecibida);
        Task ReducirIngredientes(List<Ingrediente> ingredientes);
    }
}
