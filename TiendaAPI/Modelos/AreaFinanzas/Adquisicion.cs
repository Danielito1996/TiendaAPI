using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaFinanzas
{
    public class Adquisicion:IEntity,IFinanzasModel
    {
        public int Id { get; set; }
        public List<Compras> Compras { get; set; }

    }
}
