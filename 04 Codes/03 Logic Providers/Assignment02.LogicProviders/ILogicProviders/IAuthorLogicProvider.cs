using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.LogicProviders;

public interface IAuthorLogicProvider : IBaseEntityLogicProvider<Author>
{
    #region [ Methods - List ]
    Task<IEnumerable<Author>> GetListByBookIdAsync(string bookId);
    #endregion
}
