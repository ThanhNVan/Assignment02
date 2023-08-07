using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class RoleLogicProvider : BaseEntityLogicProvider<Role, IRoleDataProvider>, IRoleLogicProvider
{
    #region [ CTor ]
    public RoleLogicProvider(ILogger<BaseEntityLogicProvider<Role, IRoleDataProvider>> logger, 
                                IRoleDataProvider dataProvider) : base(logger, dataProvider) {
    }
    #endregion
}
