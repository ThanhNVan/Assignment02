using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class UserController : BaseEntityWebApiProvider<User, IUserLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;
    #endregion

    #region [ CTor ]
    public UserController(ILogger<BaseEntityWebApiProvider<User, IUserLogicProvider>> logger, 
                            IUserLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion
}
