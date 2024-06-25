using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class Ofertas:IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public virtual List<Categorias>? CategoriasDeProductos { get; set; } = new List<Categorias>();
    }
}
