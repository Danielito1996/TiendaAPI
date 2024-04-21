using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public class Traduccion:ITraduccion
    {
        private IPorSQLite _bd;
        private IGenericFactory _factory;
        public Traduccion(IPorSQLite bd, IGenericFactory genericFactory)
        {
            _bd = bd;
            _factory = genericFactory;
        }
        public async Task<List<Ingrediente>> TraducirPlanGeneralAIngredientes(PlanGeneral planGeneral)
        {
            var planesIndividuales = planGeneral.PlanesIndividuales;
            List<List<Ingrediente>> ProductosDesglozados = new List<List<Ingrediente>>();
            foreach (var plane in planesIndividuales)
            {
                ProductosDesglozados.Add(await TraducirPlanIndividualAIngredientes(plane));
            }
            List<Ingrediente> listaGeneral = await ProductosDesglozadosAListaGeneral(ProductosDesglozados);
            return listaGeneral;
        }
        public async Task<List<Ingrediente>> TraducirPlanIndividualAIngredientes(PlanIndividual planIndividual)
        {
            var NormasTecnicas = (await _bd.ObtenerListaDeElementos<NormasTecnicas>())
                                        .FirstOrDefault(u => u.Producto == planIndividual.Producto);
            if (NormasTecnicas == null)
            {
                throw new NullReferenceException();
            }
            var listaIngredientes = NormasTecnicas.Ingredientes;
            foreach (var item in listaIngredientes)
            {
                item.Cantidad *= planIndividual.Cantidad;
            }
            return listaIngredientes;
        }
        public async Task<List<Ingrediente>> ProductosDesglozadosAListaGeneral(List<List<Ingrediente>> productosDesglozados)
        {
            Dictionary<string, Ingrediente> diccionarioIngredientes = new Dictionary<string, Ingrediente>();

            foreach (var listaIngredientes in productosDesglozados)
            {
                foreach (var ingrediente in listaIngredientes)
                {
                    if (diccionarioIngredientes.ContainsKey(ingrediente.Descripcion))
                    {
                        diccionarioIngredientes[ingrediente.Descripcion].Cantidad += ingrediente.Cantidad;
                    }
                    else
                    {
                        diccionarioIngredientes.Add(ingrediente.Descripcion, ingrediente);
                    }
                }
            }

            return diccionarioIngredientes.Values.ToList();
        }
        public async Task<List<MateriaPrima>> TraducirIngredientesMateriasPrimas(List<Ingrediente> ingredientes)
        {
            List<MateriaPrima> materiasPrimas = new List<MateriaPrima>();

            foreach (var ingrediente in ingredientes)
            {
                // Busca la MateriaPrima correspondiente en la base de datos.
                MateriaPrima materiaPrima = await _bd.ObtenerElemento<MateriaPrima>(ingrediente.MateriaPrimaId);

                if (materiaPrima != null)
                {
                    // Actualiza las propiedades de la MateriaPrima
                    materiaPrima.Cantidad = ingrediente.Cantidad;
                    materiaPrima.UnidadMedida = ingrediente.UnidadMedida;

                    materiasPrimas.Add(materiaPrima);
                }
                else
                {
                    throw new Exception($"No se encontró la Materia Prima con ID {ingrediente.MateriaPrimaId} en la base de datos.");
                }
            }

            return materiasPrimas;
        }
        public async Task<MateriaPrima> TraducirIngredientesMateriasPrimas(Ingrediente ingredientes)
        {
            // Busca la MateriaPrima correspondiente en la base de datos.
            MateriaPrima materiaPrima = await _bd.ObtenerElemento<MateriaPrima>(ingredientes.MateriaPrimaId);

            if (materiaPrima != null)
            {
                // Actualiza las propiedades de la MateriaPrima
                materiaPrima.Descripcion = ingredientes.Descripcion;
                materiaPrima.Cantidad = ingredientes.Cantidad;
                materiaPrima.UnidadMedida = ingredientes.UnidadMedida;
            }
            else
            {
                throw new Exception($"No se encontró la Materia Prima con ID {ingredientes.MateriaPrimaId} en la base de datos.");
            }
            return materiaPrima;
        }
        /*public async Task<List<MateriaPrimaAdapter>> ArmarMateriasPrimasDeCompras(Adquisicion adquisicion)
        {
            List<MateriaPrimaAdapter> materiasPrimasAdaptadas = new List<MateriaPrimaAdapter>();

            foreach (var compra in adquisicion.Compras)
            {
                // Asume que tienes un método para convertir una MateriaPrima en un MateriaPrimaAdapter.
                MateriaPrimaAdapter materiaPrimaAdaptada = ConvertirAMateriaPrimaAdapter(compra.Materia);

                materiasPrimasAdaptadas.Add(materiaPrimaAdaptada);
            }

            return materiasPrimasAdaptadas;
        }*/
    }
}
