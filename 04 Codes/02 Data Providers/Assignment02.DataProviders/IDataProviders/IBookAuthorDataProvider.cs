using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.DataProviders;

public interface IBookAuthorDataProvider : IBaseEntityDataProvider<BookAuthor>
{
    #region [ Methods - Single ]
    Task<BookAuthor> GetSingleByIndexAsync(BookAuthorModel model);
    #endregion

    #region [ Methods - List ]
    Task<IEnumerable<BookAuthor>> GetListByBookIdAsync(string bookId);
    #endregion
}
