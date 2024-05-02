using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.Generales;

namespace TiendaAPI.Servicios.Negocios.ServiciosGenerales.Adaptadores
{
    public interface ITraduccion
    {
        Task<List<Ingrediente>> TraducirPlanGeneralAIngredientes(PlanGeneral planGeneral);
        Task<List<MateriaPrima>> TraducirIngredientesMateriasPrimas(List<Ingrediente> ingredientes);
        Task<MateriaPrima> TraducirIngredientesMateriasPrimas(Ingrediente ingredientes);
        Task<List<Ingrediente>> TraducirProductosAIngredientes(ProductoVendido vendidos);
        Task<List<Ingrediente>> ProductosDesglozadosAListaGeneral(List<List<Ingrediente>> productosDesglozados);
    }
}
