using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Assignment02.HttpClientProviders;

public class AuthorHttpClientProvider : BaseEntityHttpClientProvider<Author>, IAuthorHttpClientProvider
{

    #region [ CTor ]
    public AuthorHttpClientProvider(IHttpClientFactory httpClientFactory, 
            ILogger<BaseEntityHttpClientProvider<Author>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Author;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<Author>> GetListByBookIdAsync(string bookId) {
        var result = default(IEnumerable<Author>);

        var url = this._entityUrl + MethodUrl.GetListByBookId + bookId;
        var httpClient = this.CreateClient();

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode) {
            result = JsonConvert.DeserializeObject<IEnumerable<Author>>(await  response.Content.ReadAsStringAsync());
        }

        return result;
    }
    #endregion

    #region [ Methods -  ]
    public async Task<Author> GetSingleByEmailAsync(string email) {
        var result = default(Author);

        var url = this._entityUrl + MethodUrl.GetSingleByEmail + email;
        var httpClient = this.CreateClient();

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode) {
            result = JsonConvert.DeserializeObject<Author>(await response.Content.ReadAsStringAsync());
        }

        return result;
    }
    #endregion

}
