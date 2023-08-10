using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.DataProviders;

public interface IAuthorDataProvider : IBaseEntityDataProvider<Author>
{
    #region [ Methods -  ]
    Task<IEnumerable<Author>> GetListByBookIdAsync(string bookId);
    #endregion
}
