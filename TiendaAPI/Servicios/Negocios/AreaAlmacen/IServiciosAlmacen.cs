using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public interface IServiciosAlmacen
    {
        Task<bool> RecepcionarMateriaPrima(MateriaPrimaAdapter materiaPrima);
        Task<bool> PasarMateriasPrimasAProcesamiento(PlanGeneral planGeneral);
    }
}
