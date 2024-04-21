namespace TiendaAPI.Servicios.Aplicacion.Factory
{
    public class GenericFactory : IGenericFactory
    {
        public async Task<T> ConstruirElemento<T>() where T : IEntity, new()
        {
            return new T();
        }
    }
}
