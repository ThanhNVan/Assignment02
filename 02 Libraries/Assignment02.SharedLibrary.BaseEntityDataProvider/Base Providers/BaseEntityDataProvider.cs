using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.SharedLibrary;

public abstract class BaseEntityDataProvider<TEntity, TContext> : IBaseEntityDataProvider<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    #region [ Fields ]
    protected readonly ILogger<BaseEntityDataProvider<TEntity, TContext>> _logger;

    protected readonly IDbContextFactory<TContext> _dbContextFactory;
    #endregion

    #region [ CTor ]
    public BaseEntityDataProvider(ILogger<BaseEntityDataProvider<TEntity, TContext>> logger, IDbContextFactory<TContext> dbContextFactory) {
        this._logger = logger;
        this._dbContextFactory = dbContextFactory;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    public async virtual Task<bool> AddAsync(TEntity entity) {
        try {
            using (TContext context = GetContext()) {
                if (await context.Set<TEntity>().FindAsync(entity.Id) != null) {
                    this._logger.LogWarning($"Duplicated {nameof(TEntity)}");
                    return false;
                }

                await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<TEntity> GetSingleByIdAsync(string id) {
        var result = default(TEntity);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async virtual Task<bool> UpdateAsync(TEntity entity) {
        try {
            using (TContext context = GetContext()) {
                entity.LastUpdatedAt = DateTime.UtcNow;
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return true;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> SoftDeleteAsync(string entityId) {
        try {
            using (TContext context = GetContext()) {
                var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if (dbResult == null) {
                    this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                    return false;
                }
                dbResult.LastUpdatedAt = DateTime.UtcNow;
                dbResult.IsDeleted = true;
                context.Set<TEntity>().Update(dbResult);
                await context.SaveChangesAsync();
                return true;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<bool> RecoverAsync(string entityId) {
        try {
            using (TContext context = GetContext()) {
                var dbResult = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
                if (dbResult == null) {
                    this._logger.LogWarning($"Not Found {nameof(TEntity)}");
                    return false;
                }
                dbResult.LastUpdatedAt = DateTime.UtcNow;
                dbResult.IsDeleted = false;
                context.Set<TEntity>().Update(dbResult);
                await context.SaveChangesAsync();
                return true;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public async virtual Task<IEnumerable<TEntity>> GetListAllAsync() {
        var result = default(IEnumerable<TEntity>);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async virtual Task<IEnumerable<TEntity>> GetListIsDeletedAsync() {
        var result = default(IEnumerable<TEntity>);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == true).ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    public async virtual Task<IEnumerable<TEntity>> GetListIsNotDeletedAsync() {
        var result = default(IEnumerable<TEntity>);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == false).ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }

    public async virtual Task<int> CountAllAsync() {
        var result = default(int);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().CountAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    public async virtual Task<int> CountIsDeletedAsync() {
        var result = default(int);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == true).CountAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    public async virtual Task<int> CountIsNotDeletedAsync() {
        var result = default(int);
        try {
            using (TContext context = GetContext()) {
                result = await context.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == false).CountAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion

    #region [ Private Methods -  ]
    protected TContext GetContext() {
        return this._dbContextFactory.CreateDbContext();
    }
    #endregion
}
