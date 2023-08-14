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
            return null;
        }
    }

    public async Task<IEnumerable<Book>> GetListByPublisherIdAsync(string publisherId) {
        try {
            var url = this._entityUrl + MethodUrl.GetListByPublisherId + publisherId;
            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion

    #region [ Methods - Update ]
    public async Task<bool> UpdateBookAndAuthorAsync(AddBookModel model) {
        try {
            var url = this._entityUrl + MethodUrl.UpdateBookAndAuthor;
            var httpClient = this.CreateClient();

            var response = await httpClient.PutAsJsonAsync(url, model);

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

    #region [ Methods - Add ]
    public async Task<bool> AddBookModelAsync(AddBookModel model) {
        try {
            var url = this._entityUrl + MethodUrl.AddBookModel;
            var httpClient = this.CreateClient();

            var response = await httpClient.PostAsJsonAsync(url, model);

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
