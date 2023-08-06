using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.SharedLibrary;

public interface IBaseEntityDataProvider<TEntity> 
    where TEntity : BaseEntity
{
    #region [ Public Methods - CRUD ]
    Task<bool> AddAsync(TEntity entity);

    Task<TEntity> GetSingleByIdAsync(string id);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> SoftDeleteAsync(string entityId);
    
    Task<bool> RecoverAsync(string entityId);

    Task<IEnumerable<TEntity>> GetListAllAsync();

    Task<IEnumerable<TEntity>> GetListIsDeletedAsync();

    Task<IEnumerable<TEntity>> GetListIsNotDeletedAsync();

    Task<int> CountAllAsync();

    Task<int> CountIsDeletedAsync();

    Task<int> CountIsNotDeletedAsync();
    #endregion
}
