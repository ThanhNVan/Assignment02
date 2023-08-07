namespace Assignment02.SharedLibrary;

public interface IBaseEntityHttpClientProvider<TEntity> : IBaseEntityDataProvider<TEntity>
    where TEntity : BaseEntity
{

}
