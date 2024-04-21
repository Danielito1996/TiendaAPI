using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public interface IElaboracion
    {
        Task AnadirIngredientes(Ingrediente ingredientes);
        Task AnadirIngredientes(List<Ingrediente> ingredientesPrimaRecibida);
    }
}
