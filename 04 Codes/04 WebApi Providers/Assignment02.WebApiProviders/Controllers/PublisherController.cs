using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class PublisherController : BaseEntityWebApiProvider<Publisher, IPublisherLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;
    #endregion

    #region [ CTor ]
    public PublisherController(ILogger<BaseEntityWebApiProvider<Publisher, IPublisherLogicProvider>> logger, 
                                IPublisherLogicProvider logicProvider,
                                LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion
}
