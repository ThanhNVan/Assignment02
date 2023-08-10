using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.HttpClientProviders;

public interface IAuthorHttpClientProvider : IBaseEntityHttpClientProvider<Author>
{
    #region [ Methods - List ]
    Task<IEnumerable<Author>> GetListByBookIdAsync(string bookId);    
    #endregion
}
