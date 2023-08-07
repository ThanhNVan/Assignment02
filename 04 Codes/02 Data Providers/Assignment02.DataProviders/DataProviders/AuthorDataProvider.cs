using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class AuthorDataProvider : BaseEntityDataProvider<Author, AppDbContext>, IAuthorDataProvider
{
    #region [ CTor ]
    public AuthorDataProvider(ILogger<BaseEntityDataProvider<Author, AppDbContext>> logger, 
                                IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion

    public async Task TestTransaction() {
        var context = base.GetContext();    
        var stragtegy = this.GetContext().Database.CreateExecutionStrategy();

        await stragtegy.ExecuteAsync( async () => {
            using (var transaction = await context.Database.BeginTransactionAsync()){
                try {
                    // save something here
                    // AsNoTracking()
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                } catch (Exception ex) {
                    this._logger.LogError(ex.Message);
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        });
    }
}
