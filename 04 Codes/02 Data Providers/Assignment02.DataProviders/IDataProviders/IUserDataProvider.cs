using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.DataProviders;

public interface IUserDataProvider : IBaseEntityDataProvider<User>
{
    #region [ Public Methods - List ]
    Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId);
    #endregion

    #region [ Public Methods - Single ]
    Task<User> GetSingleByEmailAsync(string email);
    #endregion
}
