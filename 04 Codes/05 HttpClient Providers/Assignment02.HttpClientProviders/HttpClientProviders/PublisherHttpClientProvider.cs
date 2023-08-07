using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.HttpClientProviders;

public class PublisherHttpClientProvider : BaseEntityHttpClientProvider<Publisher>, IPublisherHttpClientProvider
{
    #region [ CTor ]
    public PublisherHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                        ILogger<BaseEntityHttpClientProvider<Publisher>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Publisher;
    }
    #endregion
}
