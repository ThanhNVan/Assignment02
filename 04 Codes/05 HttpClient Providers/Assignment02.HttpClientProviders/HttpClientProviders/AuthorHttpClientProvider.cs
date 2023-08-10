using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Assignment02.HttpClientProviders;

public class AuthorHttpClientProvider : BaseEntityHttpClientProvider<Author>, IAuthorHttpClientProvider
{

    #region [ CTor ]
    public AuthorHttpClientProvider(IHttpClientFactory httpClientFactory, 
            ILogger<BaseEntityHttpClientProvider<Author>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.Author;
    }
    #endregion

    #region [ Methods -  ]
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
}
