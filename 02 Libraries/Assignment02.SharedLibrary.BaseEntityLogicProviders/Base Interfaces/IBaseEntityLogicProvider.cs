namespace Assignment02.SharedLibrary;

public interface IBaseEntityLogicProvider<TEntity> : IBaseEntityDataProvider<TEntity>
    where TEntity : BaseEntity
{
}
