using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.SharedLibrary;

public abstract class BaseEntityLogicProvider<TEntity, TDataProvider> : IBaseEntityLogicProvider<TEntity>
    where TEntity : BaseEntity
    where TDataProvider : IBaseEntityDataProvider<TEntity>
{
    #region [ Fields ]
    protected readonly ILogger<BaseEntityLogicProvider<TEntity, TDataProvider>> _logger;
    protected readonly TDataProvider _dataProvider;
    #endregion

    #region [ CTor ]
    public BaseEntityLogicProvider(ILogger<BaseEntityLogicProvider<TEntity, TDataProvider>> logger, TDataProvider dataProvider) {
        this._logger = logger;
        this._dataProvider = dataProvider;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    public async virtual Task<bool> AddAsync(TEntity entity) {
        if (entity == null) {
            this._logger.LogWarning($"Null {nameof(TEntity)}");
            return false;
        }
        var result = await this._dataProvider.AddAsync(entity);
        return result;
    }

    public async virtual Task<TEntity> GetSingleByIdAsync(string id) {
        var result = default(TEntity);
        if (string.IsNullOrEmpty(id)) {
            this._logger.LogWarning($"IsNullOrEmpty: {nameof(TEntity)} Id");
            return result;
        }
        result = await this._dataProvider.GetSingleByIdAsync(id);
        return result;
    }

    public async virtual Task<bool> UpdateAsync(TEntity entity) {
        var result = default(bool);
        if (string.IsNullOrEmpty(entity.Id)) {
            this._logger.LogWarning($"IsNullOrEmpty: Id");
            return result;
        }
        result = await this._dataProvider.UpdateAsync(entity);

        return result;
    }

    public async virtual Task<bool> SoftDeleteAsync(string entityId) {
        var result = default(bool);
        if (string.IsNullOrEmpty(entityId)) {
            this._logger.LogWarning($"IsNullOrEmpty: entityId");
            return result;
        }
        result = await this._dataProvider.SoftDeleteAsync(entityId);
        return result;
    }

    public async virtual Task<bool> RecoverAsync(string entityId) {
        var result = default(bool);
        if (string.IsNullOrEmpty(entityId)) {
            this._logger.LogWarning($"IsNullOrEmpty: entityId");
            return result;
        }
        result = await this._dataProvider.RecoverAsync(entityId);
        return result;
    }

    public async virtual Task<IEnumerable<TEntity>> GetListAllAsync() {
        var result = default(IEnumerable<TEntity>);

        result = await this._dataProvider.GetListAllAsync();

        return result;

    }

    public async virtual Task<IEnumerable<TEntity>> GetListIsDeletedAsync() {
        var result = default(IEnumerable<TEntity>);

        result = await this._dataProvider.GetListIsDeletedAsync();

        return result;
    }
    public async virtual Task<IEnumerable<TEntity>> GetListIsNotDeletedAsync() {
        var result = default(IEnumerable<TEntity>);

        result = await this._dataProvider.GetListIsNotDeletedAsync();

        return result;
    }

    public async virtual Task<int> CountAllAsync() {
        var result = default(int);

        result = await this._dataProvider.CountAllAsync();

        return result;
    }
    public async virtual Task<int> CountIsDeletedAsync() {
        var result = default(int);

        result = await this._dataProvider.CountIsDeletedAsync();

        return result;
    }
    public async virtual Task<int> CountIsNotDeletedAsync() {
        var result = default(int);

        result = await this._dataProvider.CountIsNotDeletedAsync();

        return result;
    }
    #endregion
}
