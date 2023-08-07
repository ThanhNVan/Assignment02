using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class RoleDataProvider : BaseEntityDataProvider<Role, AppDbContext>, IRoleDataProvider
{
    #region [ CTor ]
    public RoleDataProvider(ILogger<BaseEntityDataProvider<Role, AppDbContext>> logger, 
                            IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion
}
