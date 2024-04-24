using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen
{
    public interface IServiciosAlmacen
    {
        Task RecepcionarMateriaPrima(MateriaPrima materiaPrima);
        Task PasarMateriasPrimasAProcesamiento(PlanGeneral planGeneral);
        Task EliminarMateriaPrima(MateriaPrima materiaPrima);
        Task<List<MateriaPrima>> MostrarMateriasPrimas();
        Task ModificarDatosDeMateriaPrima(MateriaPrima materiaPrima);
        Task<MateriaPrima> InformaciondeMateriaPrima(int id);
        IServiciosCompras ObtenerServiciosCompras();
        Task RealizarCompra(List<Compras> compras);
    }
}
