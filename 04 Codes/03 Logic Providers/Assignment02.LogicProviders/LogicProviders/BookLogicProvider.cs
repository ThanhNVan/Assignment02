using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class BookLogicProvider : BaseEntityLogicProvider<Book, IBookDataProvider>, IBookLogicProvider {
    #region [ Fields ]
    protected readonly DataContext _dataContext;
    #endregion

    #region [ CTor ]
    public BookLogicProvider(ILogger<BaseEntityLogicProvider<Book, IBookDataProvider>> logger,
                                IBookDataProvider dataProvider,
                                DataContext dataContext) : base(logger, dataProvider) {
        this._dataContext = dataContext;
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId) {
        if (string.IsNullOrEmpty(authorId)) {
            return null;
        }

        var result = await this._dataProvider.GetListByAuthorIdAsync(authorId);

        return result;
    }

    public async Task<IEnumerable<Book>> GetListByPublisherIdAsync(string publisherId) {
        if (string.IsNullOrEmpty(publisherId)) {
            return null;
        }

        var result = await this._dataProvider.GetListByPublisherIdAsync(publisherId);

        return result;
    }
    #endregion

    #region [ Methods - Update ]
    public async Task<bool> UpdateBookAndAuthorAsync(AddBookModel model) {
        if (string.IsNullOrEmpty(model.Book.Id) || model.AuthorIds == null) {
            return false;
        }

        var updateBookResult = await this.UpdateAsync(model.Book);

        if (!updateBookResult) {
            return false;
        }

        var dbBookAuthor = await this._dataContext.BookAuthor.GetListByBookIdAsync(model.Book.Id);

        foreach (var item in dbBookAuthor) {
            await this._dataContext.BookAuthor.SoftDeleteAsync(item.Id);
        }

        foreach (var item in model.AuthorIds) {
            var dbEntity = await this._dataContext.BookAuthor.GetSingleByIndexAsync(new BookAuthorModel { BookId = model.Book.Id, AuthorId = item });
            if (dbEntity == null) {
                var bookAuthor = new BookAuthor();
                bookAuthor.BookId = model.Book.Id;
                bookAuthor.AuthorId = item;
                await this._dataContext.BookAuthor.AddAsync(bookAuthor);
            } else {
                await this._dataContext.BookAuthor.RecoverAsync(dbEntity.Id); 
            }
        } 
        
        return true;
    }
    #endregion

    #region [ Methods - Add ]
    public async Task<bool> AddBookModelAsync(AddBookModel model) {
        if (model == null || model.Book == null || model.AuthorIds == null ) { 
            return false; 
        }
        return await this._dataProvider.AddBookModelAsync(model);
    }
    #endregion
}
