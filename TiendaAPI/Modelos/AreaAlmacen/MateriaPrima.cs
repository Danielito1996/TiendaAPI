using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaAlmacen
{
    public class MateriaPrima : IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        public string UnidadMedida { get; set; }
    }
}
