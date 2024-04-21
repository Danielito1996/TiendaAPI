namespace TiendaAPI.Modelos.AreaElaboracion
{
    public class IngredienteAdaptado:IIngredienteAdaptado
    {
        public double Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public int MateriaPrimaId { get; set; }
        public string Descripcion { get; set; }

    }
}
