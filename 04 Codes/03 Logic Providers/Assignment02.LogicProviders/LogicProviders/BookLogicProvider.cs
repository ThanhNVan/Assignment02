using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class BookLogicProvider : BaseEntityLogicProvider<Book, IBookDataProvider>, IBookLogicProvider
{
    #region [ CTor ]
    public BookLogicProvider(ILogger<BaseEntityLogicProvider<Book, IBookDataProvider>> logger, 
                                IBookDataProvider dataProvider) : base(logger, dataProvider) {
    }
    #endregion
}
