using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
namespace TiendaAPI.Modelos.AreaAlmacen
{
    public class Inventario:IEntity
    {
        public int Id { get; set; }
        public string Codigo {  get; set; } 
        public virtual List<MateriaPrima>? MateriaPrima { get; set; } = new List<MateriaPrima>();
    }
}
