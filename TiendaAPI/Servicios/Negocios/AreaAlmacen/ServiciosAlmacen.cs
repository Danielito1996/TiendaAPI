using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.Almacen;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales.Adaptadores;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public class ServiciosAlmacen : IServiciosAlmacen
    {
        private IAlmacen _almacen;
        private ITraduccion _traductor;
        private IServiciosCompras _serviciosCompras;
        private IGenericFactory _factory;
        public ServiciosAlmacen(IServiciosCompras serviciosCompras, IGenericFactory factory, ITraduccion traduccion, IAlmacen almacen)
        {
            _almacen = almacen;
            _traductor = traduccion;
            _serviciosCompras = serviciosCompras;
            _factory = factory;
        }
        public async Task<List<MateriaPrima>> MostrarMateriasPrimas()
        {
            return await _almacen.ObtenerMateriasPrimas();
        }
        public async Task ModificarDatosDeMateriaPrima(MateriaPrima materiaPrima)
        {
            await _almacen.ModificarMateriasPrimas(materiaPrima);
        }
        public async Task RecepcionarMateriaPrima(MateriaPrima materiaPrima)
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
        public async Task RealizarCompra(List<Compras> compras)
        {
            List<MateriaPrima> listaMateriasPrimas = await ArmarListaDeMatriasPrimas(compras);
            if (compras.Count > 1)
            {
                await _serviciosCompras.GenerarNuevaAdquisicion(compras);

                foreach (var item in listaMateriasPrimas)
                {
                    await _almacen.AnadirMateriaPrima(item);
                }
            }
            else
            {
                await _serviciosCompras.GenerarNuevaAdquisicion(compras[0]);
                await _almacen.AnadirMateriaPrima(listaMateriasPrimas[0]);
            }
            /*foreach(var item in compras)
            {
                await _almacen.InsertarCompras(item.MateriaPrima);
            }*/

        }
        public IServiciosCompras ObtenerServiciosCompras()
        {
            return _serviciosCompras;
        }
        async Task<List<MateriaPrima>> ArmarListaDeMatriasPrimas(List<Compras> compras)
        {
            List<MateriaPrima> materiaPrimas = new List<MateriaPrima>();
            foreach (Compras compra in compras)
            {
                var materiaPrima = await _factory.ConstruirElemento<MateriaPrima>();
                materiaPrima.Descripcion = compra.MateriaPrima;
                materiaPrima.Costo = compra.PrecioDeCompra;
                materiaPrima.Cantidad = compra.Cantidad;
                materiaPrima.UnidadMedida = compra.UnidadDeMedida;
                materiaPrimas.Add(materiaPrima);
            }
            return materiaPrimas;
        }
    }
}
