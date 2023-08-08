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
}
