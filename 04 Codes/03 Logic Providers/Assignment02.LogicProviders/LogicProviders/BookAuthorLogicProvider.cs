using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class BookAuthorLogicProvider : BaseEntityLogicProvider<BookAuthor, IBookAuthorDataProvider>, IBookAuthorLogicProvider
{
    #region [ CTor ]
    public BookAuthorLogicProvider(ILogger<BaseEntityLogicProvider<BookAuthor, IBookAuthorDataProvider>> logger,
                                    IBookAuthorDataProvider dataProvider) : base(logger, dataProvider) {
    }
    #endregion
}
