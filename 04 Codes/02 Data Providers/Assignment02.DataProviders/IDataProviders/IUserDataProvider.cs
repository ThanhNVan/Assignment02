using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.DataProviders;

public interface IUserDataProvider : IBaseEntityDataProvider<User>
{
    #region [ Public Methods - List ]
    Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId);

    Task<IEnumerable<User>> GetListByRoleIdAsync(string roleId);

    Task<IEnumerable<User>> GetListByPublisherIdAndRoleIdAsync(string publisherId, string roleId);

    Task<IEnumerable<User>> GetListByHiredDateRangeAsync(DateTimeRangeModel model);
    #endregion

    #region [ Public Methods - Single ]
    Task<User> GetSingleByEmailAsync(string email);

    Task<User> GetSingleByLoginAsync(LoginModel model);
    #endregion
}
