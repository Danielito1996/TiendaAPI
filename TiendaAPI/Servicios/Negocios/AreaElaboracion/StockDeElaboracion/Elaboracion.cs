using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Negocios.AreaElaboracion.AdaptadoresDeElaboracion;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales.Adaptadores;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion.StockDeElaboracion
{
    public class Elaboracion : IElaboracion
    {
        StockDeIngredientes Stock { get; set; }

        private IPorSQLite _bd;
        private IGenericFactory _factory;
        private IAdaptadorIngredientes _adaptador;
        private ITraduccion _traductor;
        public Elaboracion(IPorSQLite bd, IGenericFactory factory, ITraduccion traductor, IAdaptadorIngredientes adaptador)
        {
            _bd = bd;
            _factory = factory;
            _adaptador = adaptador;
            _traductor = traductor;
        }
        async Task InicializarStock()
        {

            Stock = (await _bd.ObtenerListaDeElementos<StockDeIngredientes>(Stock)).Where(i => i.Codigo == "inicial").FirstOrDefault();
            if (Stock == null)
            {
                var stock = await _factory.ConstruirElemento<StockDeIngredientes>();

                stock.Codigo = "inicial";
                await _bd.GuardarElemento(stock);
            }
        }
        async Task ActualizarStock()
        {
            Stock = (await _bd.ObtenerListaDeElementos<StockDeIngredientes>()).Where(i => i.Codigo == "inicial").FirstOrDefault();
        }
        async Task StockConCambios()
        {
            await _bd.ModificarElemento(Stock);
            await ActualizarStock();
        }
        public async Task AnadirIngredientes(Ingrediente ingredientes)
        {
            if (Stock == null)
            {
                await InicializarStock();
            }
            await ActualizarStock();
            var encontrada = Stock.Ingredientes.FirstOrDefault(u => u.Descripcion == ingredientes.Descripcion);
            if (encontrada == null)
            {
                Stock.Ingredientes.Add(ingredientes);
            }
            else
            {
                encontrada.Cantidad += ingredientes.Cantidad;
                await _bd.ModificarElemento(encontrada);
            }
            await StockConCambios();
        }
        public async Task AnadirIngredientes(List<Ingrediente> ingredientesPrimaRecibida)
        {
            if (Stock == null)
            {
                await InicializarStock();
            }
            foreach (var item in ingredientesPrimaRecibida)
            {
                var encontrada = Stock.Ingredientes.FirstOrDefault(u => u.Descripcion == item.Descripcion);
                if (encontrada == null)
                {
                    Stock.Ingredientes.Add(item);
                }
                else
                {
                    encontrada.Cantidad += item.Cantidad;
                    await _bd.ModificarElemento(encontrada);
                }
                await StockConCambios();
            }
        }
        public async Task ReducirIngredientes(List<Ingrediente> ingredientes)
        {
            if (Stock == null)
            {
                await InicializarStock();
            }
            foreach (var ingrediente in ingredientes)
            {
                var ingredienteEncontrado = Stock.Ingredientes.FirstOrDefault(m => m.Descripcion == ingrediente.Descripcion);

                if (ingredienteEncontrado != null)
                {
                    if (ingredienteEncontrado.Cantidad - ingrediente.Cantidad < 0)
                    {
                        // Si la cantidad resultante es negativa, lanza una excepción con el nombre del ingrediente.
                        throw new Exception($"No se aprueba el plan general, la materia prima '{ingrediente.Descripcion}' esta en indiponibilidad, ya que la cantidad demandada para su cumplimiento sobrepasa lo que se tiene en almacen");
                    }
                    else
                    {
                        // Si la cantidad resultante es positiva o cero, realiza la rebaja.
                        ingredienteEncontrado.Cantidad -= ingrediente.Cantidad;
                    }
                }
                else
                {
                    // Si la materia prima no existe en el inventario, lanza una excepción con el nombre del ingrediente.
                    throw new Exception($"La materia prima '{ingrediente.Descripcion}' no existe en el inventario.");
                }
            }
            // Si todas las rebajas se realizaron correctamente, confirma la rebaja en la base de datos y devuelve true.
            await _bd.ModificarElemento<StockDeIngredientes>(Stock);
            await StockConCambios();
        }
    }
}
