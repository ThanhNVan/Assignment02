using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Assignment02.HttpClientProviders;

public class BookAuthorHttpClientProvider : BaseEntityHttpClientProvider<BookAuthor>, IBookAuthorHttpClientProvider
{
    #region [ CTor ]
    public BookAuthorHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                        ILogger<BaseEntityHttpClientProvider<BookAuthor>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.BookAuthor;
    }
    #endregion

    #region [ Methods - Update ]
    public async Task<bool> AddNewBookAuthorAsync(AddBookModel model) {
        try {
            var url = this._entityUrl + MethodUrl.AddBookModel;
            var httpClient = this.CreateClient();
            var response = await httpClient.PostAsJsonAsync(url,model);

            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;   
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }
    #endregion
}
