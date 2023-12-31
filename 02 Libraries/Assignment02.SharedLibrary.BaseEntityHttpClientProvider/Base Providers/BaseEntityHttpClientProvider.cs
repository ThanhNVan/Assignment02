﻿using Assignment02.EntityProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Assignment02.SharedLibrary;

public abstract class BaseEntityHttpClientProvider<TEntity> : IBaseEntityHttpClientProvider<TEntity>
    where TEntity : BaseEntity
{
    #region [ Fields ]
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly ILogger<BaseEntityHttpClientProvider<TEntity>> _logger;
    protected string _entityUrl;
    #endregion

    #region [ CTor ]
    public BaseEntityHttpClientProvider(IHttpClientFactory httpClientFactory,
                                        ILogger<BaseEntityHttpClientProvider<TEntity>> logger) {

        this._httpClientFactory = httpClientFactory;
        this._logger = logger;
    }
    #endregion

    #region [ Public Methods - CRUD ]
    public virtual async Task<bool> AddAsync(TEntity entity) {
        try {
            var url = this._entityUrl + MethodUrl.Add;

            var httpClient = this.CreateClient();

            var result =await httpClient.PostAsJsonAsync(url, entity);

            if (result.IsSuccessStatusCode) {
                return true;
            }

            return false;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<TEntity> GetSingleByIdAsync(string id) {
        try {
            var url = this._entityUrl + MethodUrl.GetSingleById + id;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<TEntity>( await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity) {
        try {
            var url = this._entityUrl + MethodUrl.Update;

            var httpClient = this.CreateClient();

            var response = await httpClient.PutAsJsonAsync(url, entity);

            if(response.IsSuccessStatusCode) {
                return true;
            }
            return false;

        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> SoftDeleteAsync(string entityId) {
        try {
            var url = this._entityUrl + MethodUrl.SoftDelete + entityId;

            var httpClient = this.CreateClient();

            var response = await httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> RecoverAsync(string entityId) {
        try {
            var url = this._entityUrl + MethodUrl.Recover;

            var httpClient = this.CreateClient();

            var response = await httpClient.PutAsJsonAsync(url, entityId);

            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return false;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetListAllAsync() {
        try {
            var url = this._entityUrl + MethodUrl.GetListAll;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetListIsDeletedAsync() {
        try {
            var url = this._entityUrl + MethodUrl.GetListIsDeleted;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetListIsNotDeletedAsync() {
        try {
            var url = this._entityUrl + MethodUrl.GetListIsNotDeleted;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return null;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public virtual async Task<int> CountAllAsync() {
        try {
            var url = this._entityUrl + MethodUrl.CountAll;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return -1;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return -1;
        }
    }

    public virtual async Task<int> CountIsDeletedAsync() {
        try {
            var url = this._entityUrl + MethodUrl.CountIsDeleted;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return -1;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return -1;
        }
    }
    public virtual async Task<int> CountIsNotDeletedAsync() {
        try {
            var url = this._entityUrl + MethodUrl.CountIsNotDeleted;

            var httpClient = this.CreateClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return result;
            }

            return -1;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return -1;
        }
    }
    #endregion

    #region [ Private Methods -  ]
    protected HttpClient CreateClient() {
        return this._httpClientFactory.CreateClient(RoutingUrl.BaseClientName);
    }

    protected StringContent GetJsonPayload<TPayload>(TPayload payload) {
        return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
    }
    #endregion
}
