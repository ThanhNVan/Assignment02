using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.HttpClientProviders;

public class AuthorHttpClientProvider : BaseEntityHttpClientProvider<Author>, IAuthorHttpClientProvider
{

    #region [ CTor ]
    public AuthorHttpClientProvider(IHttpClientFactory httpClientFactory, 
            ILogger<BaseEntityHttpClientProvider<Author>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Author;
    }
    #endregion
}
