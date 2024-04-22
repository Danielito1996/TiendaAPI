using TiendaAPI.Modelos.AreaFinanzas;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras
{
    public interface IServiciosCompras
    {
        Task GenerarNuevaAdquisicion(List<Compras> Compras);
        Task GenerarNuevaAdquisicion(Compras compra);
    }
}
