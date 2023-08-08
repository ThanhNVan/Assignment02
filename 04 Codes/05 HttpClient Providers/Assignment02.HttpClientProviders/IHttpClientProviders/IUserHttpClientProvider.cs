using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.HttpClientProviders;

public interface IUserHttpClientProvider : IBaseEntityHttpClientProvider<User>
{
    #region [ Public Methods - Login ]
    Task<bool> IsAdminLoginAsync(LoginModel model);
    #endregion

    #region [ Public Methods - List ]
    Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId);
    #endregion

    #region [ Public Methods - Single ]
    Task<User> GetSingleByEmailAsync(string email);
    #endregion
}
