

using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaElaboracion
{
    public class StockDeIngredientes : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
