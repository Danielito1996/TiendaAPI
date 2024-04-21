using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public interface IServiciosElaboracion
    {
        Task<bool> ConstruirFichasDeCosto(List<Ingrediente> ingredientes, Producto producto);
        Task<PlanIndividual> ConstruirPlanIndividual(Producto producto, double cantidad);
        Task<PlanGeneral> ConstruirPlanGeneral(List<PlanIndividual> planesIndividuales);
    }
}
