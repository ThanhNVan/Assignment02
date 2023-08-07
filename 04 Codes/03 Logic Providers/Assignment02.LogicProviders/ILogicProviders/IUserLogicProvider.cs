using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.LogicProviders;

public interface IUserLogicProvider : IBaseEntityLogicProvider<User>
{
    #region [ Public Methods - Login ]
    Task<bool> IsAdminLoginAsync(string email, string password);
    #endregion

    #region [ Public Methods - List ]
    Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId);
    #endregion

    #region [ Public Methods - Single ]
    Task<User> GetSingleByEmailAsync(string email);
    #endregion
}
