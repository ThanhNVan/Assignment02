using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class PublisherDataProvider : BaseEntityDataProvider<Publisher, AppDbContext>, IPublisherDataProvider
{
    #region [ CTor ]
    public PublisherDataProvider(ILogger<BaseEntityDataProvider<Publisher, AppDbContext>> logger, 
                                IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion
}
