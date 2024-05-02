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
        public int MateriaPrimaId { get; set; }
    }
}
