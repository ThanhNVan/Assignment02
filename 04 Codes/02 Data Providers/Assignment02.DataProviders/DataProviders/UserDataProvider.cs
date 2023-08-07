using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class UserDataProvider : BaseEntityDataProvider<User, AppDbContext>, IUserDataProvider
{
    #region [ CTor ]
    public UserDataProvider(ILogger<BaseEntityDataProvider<User, AppDbContext>> logger, 
                                IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion
}
