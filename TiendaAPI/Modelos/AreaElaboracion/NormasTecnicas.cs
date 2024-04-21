
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaAPI.Modelos.Generales;
using TiendaAPI.Servicios.Aplicacion.Factory;

namespace TiendaAPI.Modelos.AreaElaboracion
{
    public class NormasTecnicas : IEntity
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public List<Ingrediente> Ingredientes {get; set; }

        public double? PrecioDeCosto{get; set; }

        /* public double CalcularPrecioDeCosto()
         {
             double acumulado = 0;
             foreach (var item in Ingredientes)
             {
                 acumulado += item.Cantidad * item.Producto.Precio;
             }
             return acumulado;}*/

    }
}
