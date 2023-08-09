using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Assignment02.HttpClientProviders;

public class BookHttpClientProvider : BaseEntityHttpClientProvider<Book>, IBookHttpClientProvider
{
    #region [ CTor ]
    public BookHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                ILogger<BaseEntityHttpClientProvider<Book>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Book;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId) {
        try {
            var url = this._entityUrl + MethodUrl.GetListByAuthorId + authorId;
            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            throw;
        }
    }
    #endregion
}
