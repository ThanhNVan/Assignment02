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

    #region [ Methods - Update ]
    public async Task<bool> UpdateBookAuthorAsync(UpdateBookAuthorModel model) {
        var dbResult = await this.GetSingleByIndexAsync(model);
        if (dbResult == null) {
            var bookAuthor = new BookAuthor();
            bookAuthor.AuthorId = model.AuthorId;
            bookAuthor.BookId = model.BookId;
            return await this.AddAsync(bookAuthor);
        }
        if (dbResult.IsDeleted == true) {
            return await this.RecoverAsync(dbResult.Id);
        }

        return false;
    }
    #endregion

    #region [ Methods - Single ]
    public async Task<BookAuthor> GetSingleByIndexAsync(UpdateBookAuthorModel model) {
        if (model == null) {
            return null;
        }
        if (string.IsNullOrEmpty(model.AuthorId) || string.IsNullOrEmpty(model.BookId)) {
            return null;
        }

        return await this._dataProvider.GetSingleByIndexAsync(model);
    }
    #endregion
}
