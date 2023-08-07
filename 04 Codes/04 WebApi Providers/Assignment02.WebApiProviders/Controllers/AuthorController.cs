using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class AuthorController : BaseEntityWebApiProvider<Author, IAuthorLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;
    #endregion

    #region [ CTor ]
    public AuthorController(ILogger<BaseEntityWebApiProvider<Author, IAuthorLogicProvider>> logger, 
                            IAuthorLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion

    #region [ Public Methods -  ]
    //[HttpGet(nameof(MethodUrl.GetListIsNotDeleted))]
    //[Authorize]
    //public async override Task<IActionResult> GetListIsNotDeletedAsync() {
    //    return await base.GetListIsNotDeletedAsync();
    //}
    #endregion
}
