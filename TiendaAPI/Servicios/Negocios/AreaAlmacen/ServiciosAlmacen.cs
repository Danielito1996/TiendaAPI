using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public class ServiciosAlmacen:IServiciosAlmacen
    {
        private IAlmacen _almacen;
        private ITraduccion _traductor;
        private IElaboracion _elaboracion;
        private IAdaptadorMateriasPrimas _adaptadorMateriasPrimas;
        public ServiciosAlmacen(IElaboracion elaboracion, ITraduccion traduccion,IAdaptadorMateriasPrimas adaptador,IAlmacen almacen)
        {
            _almacen = almacen;
            _elaboracion=elaboracion;
            _traductor = traduccion;
            _adaptadorMateriasPrimas = adaptador;
        }
        public async Task<List<MateriaPrima>> MostrarMateriasPrimas()
        {
            return await _almacen.ObtenerMateriasPrimas();
        }
        public async Task ModificarDatosDeMateriaPrima(MateriaPrima materiaPrima)
        {
            await _almacen.ModificarMateriasPrimas(materiaPrima);
        }
        public async Task RecepcionarMateriaPrima(MateriaPrimaAdapter materiaPrima)
        {
            await _almacen.AnadirMateriaPrima(materiaPrima);
        }
        public async Task PasarMateriasPrimasAProcesamiento(PlanGeneral planGeneral)
        {
            var listaIngredientes = await _traductor.TraducirPlanGeneralAIngredientes(planGeneral);
            var listaMateriasPrimas = await _traductor.TraducirIngredientesMateriasPrimas(listaIngredientes);
            await _almacen.RebajarMateriasPrimas(listaMateriasPrimas);
        }
        public async Task EliminarMateriaPrima(MateriaPrima materiaPrima)
        {
            await _almacen.QuitarMateriasPrimas(materiaPrima);
        }
        public async Task<MateriaPrima> InformaciondeMateriaPrima(int id)
        {
            return await _almacen.ObtenerDatosDeMateriasPrimas(id);
        }
    }
}
