using TiendaAPI.Modelos.AreaFinanzas;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;

namespace TiendaAPI.Servicios.AreaFinanzas
{
    public class ServiciosFinancieros
    {
        private IPorSQLite _bd;
        private IAlmacen _almacen;
        public ServiciosFinancieros(IPorSQLite bd,IAlmacen almacen)
        {
            _bd = bd;
            _almacen = almacen;
        }
        public async Task RealizarCompra(Adquisicion adquisicion)
        {
            await _bd.GuardarElemento<Adquisicion>(adquisicion);    

        }
    }
}
