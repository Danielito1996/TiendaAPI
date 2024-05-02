using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public class ServiciosElaboracion : IServiciosElaboracion
    {
        private IPorSQLite _porSQLite;
        private IServiciosLogs _serviciosLogs;
        private IGenericFactory _genericFactory;
        public ServiciosElaboracion(IPorSQLite porSQLite, IServiciosLogs serviciosLogs, IGenericFactory genericFactory)
        {
            _porSQLite = porSQLite;
            _serviciosLogs = serviciosLogs;
            _genericFactory = genericFactory;
        }

        public async Task<bool> ConstruirFichasDeCosto(List<Ingrediente> ingredientes, Producto producto)
        {
            try
            {
                var ficha = await _genericFactory.ConstruirElemento<NormasTecnicas>();
                ficha.Producto = producto;
                ficha.Ingredientes = ingredientes;
                await _porSQLite.GuardarElemento<NormasTecnicas>(ficha);
            }
            catch (Exception ex)
            {
                await _serviciosLogs.Log($"Error al crear la Cartas de Normas Tecnicas: {ex.Message}");
                return false;
            }
            return true;
        }
        public async Task<PlanIndividual> ConstruirPlanIndividual(Producto producto, double cantidad)
        {
            var individual = await _genericFactory.ConstruirElemento<PlanIndividual>();
            individual.Producto = producto;
            individual.Cantidad = cantidad;
            return individual;
        }
        public async Task<PlanGeneral> ConstruirPlanGeneral(List<PlanIndividual> planesIndividuales)
        {
            var planeGeneral = await _genericFactory.ConstruirElemento<PlanGeneral>();
            try
            {
                planeGeneral.PlanesIndividuales = planesIndividuales;
                await _porSQLite.GuardarElemento<PlanGeneral>(planeGeneral);
            }
            catch (Exception ex)
            {
                await _serviciosLogs.Log($"Error al crear el plan general del dia: {ex.Message}");
                return null;
            }
            return planeGeneral;
        }
    }
}
