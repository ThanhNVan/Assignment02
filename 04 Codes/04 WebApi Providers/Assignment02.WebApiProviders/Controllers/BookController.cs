using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class BookController : BaseEntityWebApiProvider<Book, IBookLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;

    #endregion

    #region [ CTor ]
    public BookController(ILogger<BaseEntityWebApiProvider<Book, IBookLogicProvider>> logger,
                            IBookLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion
}