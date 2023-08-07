using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class UserLogicProvider : BaseEntityLogicProvider<User, IUserDataProvider>, IUserLogicProvider
{
    #region [ CTor ]
    public UserLogicProvider(ILogger<BaseEntityLogicProvider<User, IUserDataProvider>> logger,  
                                IUserDataProvider dataProvider) : base(logger, dataProvider) {
    }
    #endregion
}
