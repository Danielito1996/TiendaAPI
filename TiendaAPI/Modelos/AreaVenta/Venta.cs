using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaVenta
{
    public class Venta : IEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public List<Producto> Productos{get; set; } 

        public double ActualizarMonto()
        {
            double acumulado = 0;
            foreach (var item in Productos)
            {
                acumulado += item.Precio;
            }
            return acumulado;
        }
        
    }
}
