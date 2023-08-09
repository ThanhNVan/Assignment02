using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.LogicProviders;

public interface IBookLogicProvider : IBaseEntityLogicProvider<Book>
{
    #region [ Methods - List ]
    Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId);
    #endregion
}
