using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Data;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using SQLitePCL;
using TiendaAPI.Modelos.AreaElaboracion;
using System.Reflection.Metadata.Ecma335;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AdaptadoresDeAlmacen;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen.Almacen
{
    public class Almacen : IAlmacen
    {
        private IPorSQLite _bd;
        private IGenericFactory _factory;
        private IAdaptadorMateriasPrimas _materiaPrimaAdapter;
        public Inventario Inventario { get; internal set; }
        public Almacen(IPorSQLite porSQLite, IGenericFactory genericFactory, IAdaptadorMateriasPrimas materiaPrimaAdapter)
        {
            _factory = genericFactory;
            _bd = porSQLite;
            _materiaPrimaAdapter = materiaPrimaAdapter;

        }
        #region Inicializacion,Actualizacion de Inventario
        async Task InicializarAlmacen()
        {

            Inventario = (await _bd.ObtenerListaDeElementos<Inventario>(Inventario)).Where(i => i.Codigo == "inicial").FirstOrDefault();
            if (Inventario == null)
            {
                var inicializacion = await _factory.ConstruirElemento<MateriaPrima>();
                inicializacion.UnidadMedida = "UnidadDePrueba";
                inicializacion.Cantidad = 9;
                inicializacion.Descripcion = "Producto de Prueba";
                inicializacion.Costo = 64;
                var inventacioInicial = await _factory.ConstruirElemento<Inventario>();
                inventacioInicial.MateriaPrima.Add(inicializacion);
                inventacioInicial.Codigo = "inicial";
                await _bd.GuardarElemento(inventacioInicial);
            }
        }
        async Task ActualizarInventario()
        {
            Inventario = (await _bd.ObtenerListaDeElementos<Inventario>()).Where(i => i.Codigo == "inicial").FirstOrDefault();
        }
        async Task InventarioConCambios()
        {
            await _bd.ModificarElemento(Inventario);
            await ActualizarInventario();
        }
        #endregion
        public async Task AnadirMateriaPrima(MateriaPrima adaptada)
        {
            if (Inventario == null)
                await InicializarAlmacen();
            var encontrada = Inventario.MateriaPrima.Where(u => u.Descripcion == adaptada.Descripcion).FirstOrDefault();
            if (encontrada == null)
            {
                Inventario.MateriaPrima.Add(adaptada);
            }
            else
            {
                encontrada.Costo = await CalcularCostoPromedio(adaptada.Costo, encontrada.Descripcion);
                encontrada.Cantidad += adaptada.Cantidad;
                await _bd.ModificarElemento(encontrada);
            }
            await InventarioConCambios();
        }
        public async Task InsertarCompras(List<MateriaPrima> materiaPrima)
        {
            if (Inventario == null)
                await InicializarAlmacen();
            foreach (var item in materiaPrima)
            {
                var materiaEnInventario = Inventario.MateriaPrima.FirstOrDefault(m => m.Descripcion == item.Descripcion);
                if (materiaEnInventario != null)
                {
                    materiaEnInventario.Costo = await CalcularCostoPromedio(item.Costo, materiaEnInventario.Descripcion);
                    materiaEnInventario.Cantidad += item.Cantidad;
                }
            }
            await _bd.ModificarElemento<Inventario>(Inventario);
            await InventarioConCambios();
        }
        public async Task<bool> RebajarMateriasPrimas(List<MateriaPrima> lista)
        {
            if (Inventario == null)
                await InicializarAlmacen();

            foreach (var materiaPrima in lista)
            {
                var materiaEnInventario = Inventario.MateriaPrima.FirstOrDefault(m => m.Descripcion == materiaPrima.Descripcion);

                if (materiaEnInventario != null)
                {
                    if (materiaEnInventario.Cantidad - materiaPrima.Cantidad < 0)
                    {
                        // Si la cantidad resultante es negativa, lanza una excepción con el nombre del ingrediente.
                        throw new Exception($"No se aprueba el plan general, la materia prima '{materiaPrima.Descripcion}' esta en indiponibilidad, ya que la cantidad demandada para su cumplimiento sobrepasa lo que se tiene en almacen");
                    }
                    else
                    {
                        // Si la cantidad resultante es positiva o cero, realiza la rebaja.
                        materiaEnInventario.Cantidad -= materiaPrima.Cantidad;
                    }
                }
                else
                {
                    // Si la materia prima no existe en el inventario, lanza una excepción con el nombre del ingrediente.
                    throw new Exception($"La materia prima '{materiaPrima.Descripcion}' no existe en el inventario.");
                }
            }
            // Si todas las rebajas se realizaron correctamente, confirma la rebaja en la base de datos y devuelve true.
            await _bd.ModificarElemento<Inventario>(Inventario);
            await InventarioConCambios();
            return true;
        }
        public async Task QuitarMateriasPrimas(MateriaPrima materiaPrima)
        {
            if (Inventario == null)
                await InicializarAlmacen();
            var encontrada = Inventario.MateriaPrima.Where(u => u.Descripcion == materiaPrima.Descripcion).FirstOrDefault();
            if (encontrada == null)
            {
                Inventario.MateriaPrima.Remove(encontrada);
            }
            else
            {
                encontrada.Cantidad += materiaPrima.Cantidad;
                await _bd.EliminarElemento<MateriaPrima>(encontrada.Id);
            }
            await InventarioConCambios();
        }
        public async Task<List<MateriaPrima>> ObtenerMateriasPrimas()
        {
            if (Inventario == null)
                await InicializarAlmacen();
            return Inventario.MateriaPrima;
        }
        public async Task ModificarMateriasPrimas(MateriaPrima materiaPrima)
        {
            if (Inventario == null)
                await InicializarAlmacen();
            await _bd.ModificarElemento(materiaPrima);
            await InventarioConCambios();
        }
        public async Task<MateriaPrima> ObtenerDatosDeMateriasPrimas(int Id)
        {
            if (Inventario == null)
                await InicializarAlmacen();
            var encontrado = Inventario.MateriaPrima.FirstOrDefault(u => u.Id == Id);
            if (encontrado == null)
                throw new Exception();
            return encontrado;
        }
        async Task<double> CalcularCostoPromedio(double NuevoPrecio,string Descripcion)
        {
            List<Compras>compras=(await _bd.ObtenerListaDeElementos<Compras>()).Where(u=>u.MateriaPrima==Descripcion).ToList();
            if (compras.Count == 0)
                return NuevoPrecio;
            double sumaPrecios = compras.Sum(u => u.PrecioDeCompra) + NuevoPrecio;
            int CantiDadDeCompras = compras.Count+1;
            return sumaPrecios / CantiDadDeCompras;
        }
    }
}
