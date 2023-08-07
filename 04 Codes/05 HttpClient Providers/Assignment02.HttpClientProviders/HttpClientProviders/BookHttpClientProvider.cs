using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.HttpClientProviders;

public class BookHttpClientProvider : BaseEntityHttpClientProvider<Book>, IBookHttpClientProvider
{
    #region [ CTor ]
    public BookHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                ILogger<BaseEntityHttpClientProvider<Book>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Book;
    }
    #endregion
}
