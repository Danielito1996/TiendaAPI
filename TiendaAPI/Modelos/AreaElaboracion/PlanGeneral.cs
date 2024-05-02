using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaElaboracion
{
    public class PlanGeneral : IEntity
    {
        public int Id { get; set; }
        public List<PlanIndividual> PlanesIndividuales { get; set; } = new List<PlanIndividual>();
    }
}
