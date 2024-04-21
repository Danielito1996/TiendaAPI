namespace TiendaAPI.Servicios.Aplicacion.Factory
{
    public interface IGenericFactory
    {
        Task<T> ConstruirElemento<T>() where T : IEntity, new();
    }
}
