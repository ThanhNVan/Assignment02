using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class PublisherLogicProvider : BaseEntityLogicProvider<Publisher, IPublisherDataProvider>, IPublisherLogicProvider
{
    #region [ CTor ]
    public PublisherLogicProvider(ILogger<BaseEntityLogicProvider<Publisher, IPublisherDataProvider>> logger, 
                                    IPublisherDataProvider dataProvider) : base(logger, dataProvider) {
    }
    #endregion
}
