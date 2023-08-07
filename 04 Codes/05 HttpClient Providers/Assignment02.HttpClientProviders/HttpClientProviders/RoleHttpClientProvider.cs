using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.HttpClientProviders;

public class RoleHttpClientProvider : BaseEntityHttpClientProvider<Publisher>, IRoleHttpClientProvider
{
    #region [ CTor ]
    public RoleHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                    ILogger<BaseEntityHttpClientProvider<Publisher>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Role;
    }
    #endregion
}
