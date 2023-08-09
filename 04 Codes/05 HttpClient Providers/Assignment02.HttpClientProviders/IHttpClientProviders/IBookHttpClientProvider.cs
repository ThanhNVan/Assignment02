using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.HttpClientProviders;

public interface IBookHttpClientProvider : IBaseEntityHttpClientProvider<Book>
{
    #region [ Methods - List ]
    Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId);
    #endregion
}
