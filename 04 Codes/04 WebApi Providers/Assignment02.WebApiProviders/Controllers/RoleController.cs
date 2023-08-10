using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class RoleController : BaseEntityWebApiProvider<Role, IRoleLogicProvider>
{
    #region [ CTor ]
    public RoleController(ILogger<BaseEntityWebApiProvider<Role, IRoleLogicProvider>> logger, 
                            IRoleLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider, logicContext) {
    }
    #endregion
}
