using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace Assignment02.HttpClientProviders;

public class UserHttpClientProvider : BaseEntityHttpClientProvider<User>, IUserHttpClientProvider
{
    #region [ CTor ]
    public UserHttpClientProvider(IHttpClientFactory httpClientFactory, 
                                    ILogger<BaseEntityHttpClientProvider<User>> logger) : base(httpClientFactory, logger) {
        this._entityUrl = EntityUrl.User;
    }
    #endregion

    #region [ Public Methods - Login ]
    public async Task<bool> IsAdminLoginAsync(LoginModel model) {
        try {
            var url = this._entityUrl + MethodUrl.AdminLogin;
            var httpClient = this.CreateClient();
            var response = await httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;

        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<User> LoginAsync(LoginModel model) {
        try {
            var url = this._entityUrl + MethodUrl.Login;
            var httpClient = this.CreateClient();
            var response = await httpClient.PostAsJsonAsync(url, model);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                return result;
            }
            return null;

        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            throw;
        }
    }
    #endregion

    #region [ Public Methods - List ]
    public async Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId) {
        try {
            var url = this._entityUrl + MethodUrl.GetListByPublisherId + publisherId; 
            var httpClient = this.CreateClient();
            var response = await httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<User>>(await  response.Content.ReadAsStringAsync());
                return result;
            }
            return null;

        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            throw;
        }
    }
    #endregion

    #region [ Public Methods - Single ]
    public async Task<User> GetSingleByEmailAsync(string email) {
        try {
            var url = this._entityUrl + MethodUrl.GetSingleByEmail + email;
            var httpClient = this.CreateClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                return result;
            }
            return null;

        } catch(Exception ex) {
            this._logger.LogError(ex.Message);
            throw;
        }
    }
    #endregion
}
