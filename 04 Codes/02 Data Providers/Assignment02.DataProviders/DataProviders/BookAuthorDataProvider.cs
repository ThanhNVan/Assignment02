using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class BookAuthorDataProvider : BaseEntityDataProvider<BookAuthor, AppDbContext>, IBookAuthorDataProvider
{
    #region [ CTor ]
    public BookAuthorDataProvider(ILogger<BaseEntityDataProvider<BookAuthor, AppDbContext>> logger, 
                                    IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion
}
