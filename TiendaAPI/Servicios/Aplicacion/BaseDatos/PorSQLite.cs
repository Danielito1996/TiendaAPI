using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Aplicacion.BaseDatos
{
    public class PorSQLite : IPorSQLite
    {
        private readonly TiendaDbContext _context;
        public PorSQLite(TiendaDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> ObtenerListaDeElementos<T>() where T : class, new()
        {

            return await _context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> ObtenerListaDeElementos<T>(Inventario inventario) where T : class, new()
        {
            return await _context.Set<T>()
                .Include(i => ((Inventario)(object)i).MateriaPrima)
                .ToListAsync() as List<T>;
        }
        public async Task<List<T>> ObtenerListaDeElementos<T>(StockDeIngredientes stock) where T : class, new()
        {
            return await _context.Set<T>()
                .Include(i => ((StockDeIngredientes)(object)i).Ingredientes)
                .ToListAsync() as List<T>;
        }
        public async Task<List<T>> ObtenerListaDeElementos<T>(PlanGeneral stock) where T : class, new()
        {
            return await _context.Set<T>()
                .Include(i => ((PlanGeneral)(object)i).PlanesIndividuales)
                .ToListAsync() as List<T>;
        }

        //Obtiene un elementoo por su ID
        public async Task<T> ObtenerElemento<T>(int id) where T : class, IEntity, new()
        {
            var elemento = _context.Set<T>().FirstOrDefault(c => c.Id == id);
            if (elemento == null)
            {
                return null;
            }
            return await Task.FromResult(elemento);
        }

        //Guarda un elemento en la tabla
        public async Task<bool> GuardarElemento<T>(T item) where T : class, new()
        {
            try
            {
                _context.Set<T>().Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        //Modifica el elemento
        public async Task<bool> ModificarElemento<T>(T item) where T : class, IEntity, new()
        {
            var elementoExistente = _context.Set<T>().FirstOrDefault(c => c.Id == item.Id);
            if (elementoExistente == null)
            {
                return false;
            }
            elementoExistente = item;
            await _context.SaveChangesAsync();
            return true;
        }
        //Eliminar elemento
        public async Task<bool> EliminarElemento<T>(int id) where T : class, IEntity, new()
        {
            var elemento = _context.Set<T>().FirstOrDefault(c => c.Id == id);
            if (elemento == null)
            {
                return false;
            }
            _context.Set<T>().Remove(elemento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
