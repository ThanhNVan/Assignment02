using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.LogicProviders;

public interface IUserLogicProvider : IBaseEntityLogicProvider<User>
{
    #region [ Public Methods - Login ]
    Task<bool> IsAdminLoginAsync(LoginModel model);

    Task<User> GetSingleByLoginAsync(LoginModel model);
    #endregion

    #region [ Public Methods - List ]
    Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId);

    Task<IEnumerable<User>> GetListByRoleIdAsync(string roleId);

    Task<IEnumerable<User>> GetListByPublisherIdAndRoleIdAsync(string publisherId, string roleId);

    Task<IEnumerable<User>> GetListByHiredDateRangeAsync(DateTimeRangeModel model);
    #endregion

    #region [ Public Methods - Single ]
    Task<User> GetSingleByEmailAsync(string email);
    #endregion
}
