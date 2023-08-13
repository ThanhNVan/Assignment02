using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.LogicProviders;

public interface IBookAuthorLogicProvider : IBaseEntityLogicProvider<BookAuthor>
{
    #region [ Methods - Single ]
    Task<BookAuthor> GetSingleByIndexAsync(BookAuthorModel model);
    #endregion
}
