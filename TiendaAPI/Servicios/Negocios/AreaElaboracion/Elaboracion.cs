using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public class Elaboracion:IElaboracion
    {
        StockDeIngredientes Stock { get; set; }

        private IPorSQLite _bd;
        private IGenericFactory _factory;
        private IAdaptadorIngredientes _adaptador;
        private ITraduccion _traductor;
        public Elaboracion(IPorSQLite bd,IGenericFactory factory,ITraduccion traductor,IAdaptadorIngredientes adaptador) 
        { 
            _bd = bd;
            _factory = factory;
            _adaptador = adaptador;
            _traductor= traductor;
        }
        async Task InicializarStock()
        {

            Stock = (await _bd.ObtenerListaDeElementos<StockDeIngredientes>(Stock)).Where(i => i.Codigo == "inicial").FirstOrDefault();
            if (Stock == null)
            { 
                var stock = await _factory.ConstruirElemento<StockDeIngredientes>();
               
                stock.Codigo = "inicial";
                await _bd.GuardarElemento<StockDeIngredientes>(stock);
            }
        }
        async Task ActualizarStock()
        {
             Stock = (await _bd.ObtenerListaDeElementos<StockDeIngredientes>()).Where(i => i.Codigo == "inicial").FirstOrDefault();
        }
        async Task StockConCambios()
        {
            await _bd.ModificarElemento<StockDeIngredientes>(Stock);
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
                await _bd.ModificarElemento<Ingrediente>(encontrada);
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
                await ActualizarStock();
                var encontrada = Stock.Ingredientes.FirstOrDefault(u => u.Descripcion == item.Descripcion);
                if (encontrada == null)
                {
                    Stock.Ingredientes.Add(item);
                }
                else
                {
                    encontrada.Cantidad += item.Cantidad;
                    await _bd.ModificarElemento<Ingrediente>(encontrada);
                }
                await StockConCambios();
            }
        }
    }
}
