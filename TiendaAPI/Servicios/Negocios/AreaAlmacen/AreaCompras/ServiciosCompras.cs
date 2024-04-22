using System.Runtime.InteropServices;
using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras
{
    public class ServiciosCompras : IServiciosCompras
    {
        private IGenericFactory _factory;
        private IPorSQLite _bd;

        public ServiciosCompras(IGenericFactory factory,IPorSQLite bd)
        {
            _factory = factory;
            _bd = bd;
        }
        public async Task GenerarNuevaAdquisicion(List<Compras> Compras)
        {
            if(Compras.Count == 0)
            {
                throw new Exception("Lista de compras de la adquisicion vacias");
            }
            var adquisicion = await _factory.ConstruirElemento<Adquisicion>();
            adquisicion.Compras = Compras;
            await _bd.GuardarElemento<Adquisicion>(adquisicion);    
        }
        public async Task GenerarNuevaAdquisicion(Compras compra)
        {
            
            if((compra == null)||(compra.PrecioDeCompra==0))
            {
                throw new Exception("La compra no se ha podido realizar, peticion con errores");
            }
            await _bd.GuardarElemento<Compras>(compra);
        }
    }
}
