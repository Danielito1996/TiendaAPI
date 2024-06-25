using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Negocios.ServicioDeTraduccion.AdaptadoresDeAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeOfertas
{
    public class RectorDeOfertas:IRectorDeCategorias
    {
        public Ofertas Ofertas { get; internal set; }

        private IPorSQLite _bd;
        private IGenericFactory _factory;
        public RectorDeOfertas(IPorSQLite bd, IGenericFactory factory)
        {
            _bd = bd;
            _factory = factory;
        }

        async Task InicializarOfertas()
        {

            Ofertas = (await _bd.ObtenerListaDeElementos<Ofertas>(Ofertas)).Where(i => i.Codigo == "inicial").FirstOrDefault();
            if (Ofertas == null)
            {
                var inicializacion = await _factory.ConstruirElemento<Categorias>();
                inicializacion.Descripcion = "CategoriaDePrueba";
                var ofertaInicial = await _factory.ConstruirElemento<Ofertas>();
                ofertaInicial.CategoriasDeProductos.Add(inicializacion);
                ofertaInicial.Codigo = "inicial";
                await _bd.GuardarElemento<Ofertas>(ofertaInicial);
                await ActualizarOfertas();
                
            }
            await ActualizarCategoriasInternas();
        }
        async Task ActualizarCategoriasInternas()
        {
            var listaActualizada = await _bd.ObtenerListaDeElementos<Categorias>(Ofertas.CategoriasDeProductos);
        }

        async Task ActualizarOfertas()
        {
            Ofertas = (await _bd.ObtenerListaDeElementos<Ofertas>()).Where(i => i.Codigo == "inicial").FirstOrDefault();
        }

        async Task OfertasConCambios()
        {
            await _bd.ModificarElemento(Ofertas);
            await ActualizarOfertas();
        }

        public async Task<List<Categorias>> ObtenerCategoriasDeVentas()
        {
            if (Ofertas == null)
                await InicializarOfertas();
            return Ofertas.CategoriasDeProductos;
        }

        public async Task InsertarCategoria(Categorias adaptada)
        {
            if (Ofertas == null)
                await InicializarOfertas();
            var encontrada = Ofertas.CategoriasDeProductos.Where(u => u.Descripcion == adaptada.Descripcion).FirstOrDefault();
            if (encontrada == null)
            {
                Ofertas.CategoriasDeProductos.Add(adaptada);
            }
            else
            {
                await _bd.ModificarElemento(encontrada);
            }
            await OfertasConCambios();
        }
        public async Task InsertarCompras(List<Categorias> categorias)
        {
            if (Ofertas == null)
                await InicializarOfertas();
            foreach (var item in categorias)
            {
                var categoriaEncontrada =Ofertas.CategoriasDeProductos.FirstOrDefault(m => m.Descripcion == item.Descripcion);
                if (categoriaEncontrada != null)
                {
                    categoriaEncontrada.Productos = item.Productos;
                }
            }
            await _bd.ModificarElemento<Ofertas>(Ofertas);
            await OfertasConCambios();
        }

        public async Task EliminarCategoria(List<Categorias> lista)
        {
            if (Ofertas == null)
                await InicializarOfertas();

            foreach (var categoria in lista)
            {
                var categoriaEnOferta = Ofertas.CategoriasDeProductos.FirstOrDefault(m => m.Descripcion == categoria.Descripcion);

                if (categoriaEnOferta != null)
                {
                    Ofertas.CategoriasDeProductos.Remove(categoriaEnOferta);
                    await _bd.EliminarElemento<Categorias>(categoriaEnOferta.Id);
                }
                else
                {
                    // Si la materia prima no existe en el inventario, lanza una excepción con el nombre del ingrediente.
                    throw new Exception($"La materia prima '{categoriaEnOferta.Descripcion}' no existe en el inventario.");
                }
            }
            // Si todas las rebajas se realizaron correctamente, confirma la rebaja en la base de datos y devuelve true.
            await _bd.ModificarElemento<Ofertas>(Ofertas);
            await OfertasConCambios();
        }

        public async Task<Categorias> ObtenerCategoriaPorID(int id)
        {
           return await _bd.ObtenerElemento<Categorias>(id);
        }
        public async Task ModificarCategoria(Categorias modificacion)
        {
            var aModificar =await _bd.ObtenerElemento<Categorias>(modificacion.Id);
            aModificar = modificacion;
            await _bd.ModificarElemento(aModificar);
        }
    }
}
