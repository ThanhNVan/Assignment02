using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.HttpClientProviders;

public class UserHttpClientProvider : BaseEntityHttpClientProvider<User>, IUserHttpClientProvider
{
    #region [ CTor ]
    public UserHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                    ILogger<BaseEntityHttpClientProvider<User>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.User;
    }
    #endregion
}
