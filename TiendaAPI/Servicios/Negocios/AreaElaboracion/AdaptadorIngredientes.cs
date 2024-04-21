using TiendaAPI.Modelos.AreaAlmacen;
using TiendaAPI.Modelos.AreaElaboracion;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.AreaElaboracion
{
    public class AdaptadorIngredientes:IAdaptadorIngredientes
    {
        private IGenericFactory _genericFactory;
        public AdaptadorIngredientes(IGenericFactory genericFactory)
        {
            _genericFactory = genericFactory;
        }
        public async Task<Ingrediente> Adaptar(IngredienteAdaptado recibido)
        {
            var entregar = await _genericFactory.ConstruirElemento<Ingrediente>();
            entregar.Descripcion = recibido.Descripcion;
            entregar.MateriaPrimaId = recibido.MateriaPrimaId;
            entregar.UnidadMedida = recibido.UnidadMedida;
            entregar.Cantidad=recibido.Cantidad;
            return entregar;
        }
    }
}
