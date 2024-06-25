using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class Categorias:IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
