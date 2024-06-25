using Microsoft.EntityFrameworkCore;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Modelos.AreaVenta;
using TiendaAPI.Modelos.Generales;
namespace TiendaAPI.Data
{
    public class TiendaDbContext : DbContext
    {
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<NormasTecnicas> CartasDeNormasTecnicas { get; set; }
        public DbSet<PlanGeneral> PlanesGenerales { get; set; }
        public DbSet<PlanIndividual> PlanesIndividuales { get; set; }
        public DbSet<StockDeIngredientes> StocksDeIngredientes { get; set; }
        public DbSet<ProductosListosParaVentas> ProductosListosParaVentas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Adquisicion> Adquisiciones { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ReporteVentasGenerales> ReportesDeVentas { get; set; }
        public DbSet<ProductoVendido> ProductosVendidos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Ofertas> Ofertas { get; set; }
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {

        }
    }
}
