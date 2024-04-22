

using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaVenta;
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
