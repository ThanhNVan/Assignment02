using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace Assignment02.LogicProviders;

public class UserLogicProvider : BaseEntityLogicProvider<User, IUserDataProvider>, IUserLogicProvider
{
    #region [ Methods -  ]
    private LoginModel Admin { get; set; }
    #endregion

    #region [ CTor ]
    public UserLogicProvider(ILogger<BaseEntityLogicProvider<User, IUserDataProvider>> logger,  
                                IUserDataProvider dataProvider,
                                LoginModel admin) : base(logger, dataProvider) {
        Admin = admin;
    }
    #endregion

    #region [ Public Methods - Login ]
    public async Task<bool> IsAdminLoginAsync(LoginModel model) {
        if (string.IsNullOrEmpty(model.Email)) {
            return false;
        }

        if (string.IsNullOrEmpty(model.Password)) {
            return false;
        }

        if (model.Email == Admin.Email && model.Password == Admin.Password) {
            await Task.CompletedTask;
            return true;
        }
        return false;
    }

    public async Task<User> GetSingleByLoginAsync(LoginModel model) {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password)) {
            return null;
        }
        return await _dataProvider.GetSingleByLoginAsync(model);
    }
    #endregion

    #region [ Public Methods - List ]
    public async Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId) {
        if (!string.IsNullOrEmpty(publisherId)) {
            return await this._dataProvider.GetListByPublisherIdAsync(publisherId);
        }
        return null;
    }

    public async Task<IEnumerable<User>> GetListByRoleIdAsync(string roleId) {
        var result = default(IEnumerable<User>);    
        if (string.IsNullOrEmpty(roleId)) {
            return result;
        }
        result = await this._dataProvider.GetListByRoleIdAsync(roleId);

        return result;
    }

    public async Task<IEnumerable<User>> GetListByPublisherIdAndRoleIdAsync(string publisherId, string roleId) {
        var result = default(IEnumerable<User>);
        if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(publisherId)) {
            return result;
        }
        result = await this._dataProvider.GetListByPublisherIdAndRoleIdAsync(publisherId,roleId);

        return result;
    }

    public async Task<IEnumerable<User>> GetListByHiredDateRangeAsync(DateTimeRangeModel model) {
        var result = default(IEnumerable<User>);
        if (model.EndDate < model.StartDate) {
            return result;
        }
        result = await this._dataProvider.GetListByHiredDateRangeAsync(model);

        return result;
    }
    #endregion

    #region [ Public Methods - Single ]
    public async Task<User> GetSingleByEmailAsync(string email) {
        if (!string.IsNullOrEmpty(email)) {
            return await this._dataProvider.GetSingleByEmailAsync(email);
        }
        return null;
    }
    #endregion
}
