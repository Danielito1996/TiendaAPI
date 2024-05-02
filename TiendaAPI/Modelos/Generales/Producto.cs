using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.Generales
{
    public class Producto : IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
