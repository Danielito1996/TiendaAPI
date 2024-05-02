using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.ServicioDeTraduccion.AdaptadoresDeAlmacen
{
    public class AdaptadorMateriasPrimas : IAdaptadorMateriasPrimas
    {
        private IGenericFactory _genericFactory;
        public AdaptadorMateriasPrimas(IGenericFactory genericFactory)
        {
            _genericFactory = genericFactory;
        }
        public async Task<MateriaPrima> Adaptar(MateriaPrimaAdapter recibido)
        {
            var entregar = await _genericFactory.ConstruirElemento<MateriaPrima>();
            entregar.Descripcion = recibido.Descripcion;
            entregar.Cantidad = recibido.Cantidad;
            entregar.Costo = recibido.Costo;
            entregar.UnidadMedida = recibido.UnidadMedida;
            return entregar;
        }
    }
}
