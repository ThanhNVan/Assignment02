using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class BookDataProvider : BaseEntityDataProvider<Book, AppDbContext>, IBookDataProvider
{
    #region [ CTor ]
    public BookDataProvider(ILogger<BaseEntityDataProvider<Book, AppDbContext>> logger, 
                            IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion
}
