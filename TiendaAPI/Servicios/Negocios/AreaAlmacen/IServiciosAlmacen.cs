using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public interface IServiciosAlmacen
    {
        Task RecepcionarMateriaPrima(MateriaPrimaAdapter materiaPrima);
        Task PasarMateriasPrimasAProcesamiento(PlanGeneral planGeneral);
        Task EliminarMateriaPrima(MateriaPrima materiaPrima);
        Task<List<MateriaPrima>> MostrarMateriasPrimas();
        Task ModificarDatosDeMateriaPrima(MateriaPrima materiaPrima);
        Task<MateriaPrima> InformaciondeMateriaPrima(int id);
    }
}
