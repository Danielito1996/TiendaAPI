namespace TiendaAPI.Modelos.AreaAlmacen
{
    public interface IMateriaPrimaAdapter
    {
        int Id { get; set; }
        string Descripcion { get; set; }
        int Cantidad { get; set; }
        double Costo { get; set; }
    }
}
