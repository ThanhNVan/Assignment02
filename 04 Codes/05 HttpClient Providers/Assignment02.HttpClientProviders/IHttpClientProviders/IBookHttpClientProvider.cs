using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.HttpClientProviders;

public interface IBookHttpClientProvider : IBaseEntityHttpClientProvider<Book>
{
    #region [ Methods - List ]
    Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId);
    #endregion

    #region [ Methods - Update ]
    Task<bool> UpdateBookAndAuthorAsync(UpdateBookAndAuthorModel model);

    Task<IEnumerable<Book>> GetListByPublisherIdAsync(string publisherId);
    #endregion
}
