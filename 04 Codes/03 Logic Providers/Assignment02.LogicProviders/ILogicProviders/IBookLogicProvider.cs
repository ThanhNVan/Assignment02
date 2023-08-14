using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.LogicProviders;

public interface IBookLogicProvider : IBaseEntityLogicProvider<Book>
{
    #region [ Methods - List ]
    Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId);
    #endregion

    #region [ Methods - Update ]
    Task<bool> UpdateBookAndAuthorAsync(AddBookModel model);

    Task<IEnumerable<Book>> GetListByPublisherIdAsync(string publisherId);
    #endregion

    #region [ Methods - Add ]
    Task<bool> AddBookModelAsync(AddBookModel model);
    #endregion
}
