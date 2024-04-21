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
        private IPorSQLite _bd;
        private IServiciosLogs _logs;
        private IGenericFactory _factory;
        private IAlmacen _almacen;
        private ITraduccion _traductor;
        private IAdaptadorMateriasPrimas _adaptadorMateriasPrimas;
        public ServiciosAlmacen(IPorSQLite bd, ITraduccion traduccion,IAdaptadorMateriasPrimas adaptador,IAlmacen almacen, IServiciosLogs logs, IGenericFactory factory)
        {
            _bd = bd;
            _logs = logs;
            _factory = factory;
            _almacen = almacen;
            _traductor = traduccion;
            _adaptadorMateriasPrimas = adaptador;
        }

        public async Task<bool> RecepcionarMateriaPrima(MateriaPrimaAdapter materiaPrima)
        {
           try
           {
                await _almacen.AnadirMateriaPrima(materiaPrima);
           }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<bool> PasarMateriasPrimasAProcesamiento(PlanGeneral planGeneral)
        {
            try
            {
                var listaIngredientes = await _traductor.TraducirPlanGeneralAIngredientes(planGeneral);
                var listaMateriasPrimas = await _traductor.TraducirIngredientesMateriasPrimas(listaIngredientes);
                await _almacen.RebajarMateriasPrimas(listaMateriasPrimas);
            }
            catch { return false; }
            return true;
            
        }
       /* public async Task<bool> RecepcionarMateriaPrima(MateriaPrima materiaPrima)
        {
            var encontrada = (await _bd.ObtenerListaDeElementos<MateriaPrima>())
                                     .Where(u => u.Descripcion == materiaPrima.Descripcion).FirstOrDefault();
            if(encontrada is null)
            {
                await _bd.GuardarElemento<MateriaPrima>(materiaPrima);
                //Falta Guardar en Almacen
            }

        }*/
        /* public async Task<bool> PasarMateriasPrimasAProcesamiento(PlanGeneral planGeneral,Inventario inventario)
         {
             var planesIndividuales=planGeneral.PlanesIndividuales;
             foreach(var item in planesIndividuales)
             {
                 var encontrado = inventario.MateriaPrima
                                            .Where(u => u.Descripcion == item.Producto.Descripcion).FirstOrDefault();
                 encontrado.Cantidad-=item.Cantidad;
                 //Actualizar El producto en almacen
             }
         }*/
    }
}
