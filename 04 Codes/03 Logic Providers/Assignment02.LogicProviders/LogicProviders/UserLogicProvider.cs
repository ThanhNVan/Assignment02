using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class UserLogicProvider : BaseEntityLogicProvider<User, IUserDataProvider>, IUserLogicProvider
{
    #region [ Methods -  ]
    private Admin Admin { get; set; }
    #endregion

    #region [ CTor ]
    public UserLogicProvider(ILogger<BaseEntityLogicProvider<User, IUserDataProvider>> logger,  
                                IUserDataProvider dataProvider,
                                Admin admin) : base(logger, dataProvider) {
        Admin = admin;
    }
    #endregion

    #region [ Public Methods - Login ]
    public async Task<bool> IsAdminLoginAsync(string email, string password) {
        if (email == Admin.Email && password == Admin.Password) {
            await Task.CompletedTask;
            return true;
        }
        return false;
    }
    #endregion

    #region [ Public Methods - List ]
    public async Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId) {
        if (!string.IsNullOrEmpty(publisherId)) {
            return await this._dataProvider.GetListByPublisherIdAsync(publisherId);
        }
        return null;
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
