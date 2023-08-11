using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.HttpClientProviders;

public interface IBookAuthorHttpClientProvider : IBaseEntityHttpClientProvider<BookAuthor>
{

    #region [ Methods - Update ]
    Task<bool> UpdateBookAuthorAsync(UpdateBookAuthorModel model);
    #endregion
}
