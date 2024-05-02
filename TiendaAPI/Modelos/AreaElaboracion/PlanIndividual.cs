using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaElaboracion
{
    public class PlanIndividual : IEntity
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }
        public int PlanGeneralId { get; set; }
        public virtual PlanGeneral PlanGeneral { get; set; }

    }
}
