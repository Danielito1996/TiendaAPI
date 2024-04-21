using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaElaboracion
{
    public class Ingrediente : IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? ProductoId { get; set; }
        public double Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public int MateriaPrimaId {  get; set; }
        public int? NormasTecnicasId { get; set; }
        public virtual NormasTecnicas NormasTecnicas { get; set; }
        public int? StockDeIngredientesId { get; set; }
        public virtual StockDeIngredientes StockDeIngredientes { get; set; }
    }
}
