using Assignment02.DataProviders;
using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.LogicProviders;

public class BookLogicProvider : BaseEntityLogicProvider<Book, IBookDataProvider>, IBookLogicProvider
{
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
    #endregion

    #region [ Methods - Update ]
    public async Task<bool> UpdateBookAndAuthorAsync(UpdateBookAndAuthorModel model) {
        if (string.IsNullOrEmpty(model.Book.Id) || model.Authors == null) {
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

        foreach (var dbItem in dbBookAuthor) {
            foreach (var apiItem in model.Authors) {
                if (dbItem.AuthorId != apiItem.Id) {
                    var dbResult = await this._dataContext.BookAuthor.GetSingleByIndexAsync(new BookAuthorModel { BookId = model.Book.Id, AuthorId = apiItem.Id });
                    if (dbResult == null) {
                        var newBookAuthor = new BookAuthor();
                        newBookAuthor.BookId = model.Book.Id;
                        newBookAuthor.AuthorId = apiItem.Id;
                        var aa = await this._dataContext.BookAuthor.AddAsync(newBookAuthor);
                    } else if (dbResult.IsDeleted == true) {
                        await this._dataContext.BookAuthor.RecoverAsync(dbResult.Id);
                    }
                } else {
                    
                    var aa = await this._dataContext.BookAuthor.SoftDeleteAsync(dbItem.Id);
                    
                }
            }
        }
        return true;
    }
    #endregion
}
