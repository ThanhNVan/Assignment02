using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.DataProviders;

public interface IBookAuthorDataProvider : IBaseEntityDataProvider<BookAuthor>
{
    #region [ Methods - Single ]
    Task<BookAuthor> GetSingleByIndexAsync(UpdateBookAuthorModel model);
    #endregion
}
