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

    #region [ Methods - Single ]
    public async Task<BookAuthor> GetSingleByIndexAsync(BookAuthorModel model) {
        if (model == null) {
            return null;
        }
        if (string.IsNullOrEmpty(model.AuthorId) || string.IsNullOrEmpty(model.BookId)) {
            return null;
        }

        return await this._dataProvider.GetSingleByIndexAsync(model);
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<BookAuthor>> GetListByBookIdAsync(string bookId) {
        if (string.IsNullOrEmpty(bookId)) {
            return null;
        }

        return await this._dataProvider.GetListByBookIdAsync(bookId);
    }
    #endregion

}
