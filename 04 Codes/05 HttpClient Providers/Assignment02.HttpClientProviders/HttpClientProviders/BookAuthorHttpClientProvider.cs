using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.HttpClientProviders;

public class BookAuthorHttpClientProvider : BaseEntityHttpClientProvider<BookAuthor>, IBookAuthorHttpClientProvider
{
    #region [ CTor ]
    public BookAuthorHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                        ILogger<BaseEntityHttpClientProvider<BookAuthor>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.BookAuthor;
    }
    #endregion
}
