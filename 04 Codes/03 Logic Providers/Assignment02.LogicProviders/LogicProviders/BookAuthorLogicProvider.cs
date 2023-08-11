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

    #region [ Methods - Update ]
    public async Task<bool> UpdateBookAuthorAsync(UpdateBookAuthorModel model) {
        if (model == null || model.AuthorIds == null || string.IsNullOrEmpty(model.BookId)) {
            return false;
        }

        var dbList = await this.GetListByBookIdAsync(model.BookId);
        foreach (var item in dbList)
        {
            await this.SoftDeleteAsync(item.Id);
        }
        //var result = model.AuthorIds.ToList();

        //var intersectionList = new List<string>();

        //foreach (var item in dbList) {
        //    var dbEntity = result.FirstOrDefault(x => x == item.AuthorId);
        //    if (dbEntity != null) {
        //        intersectionList.Add(dbEntity);
        //        result.Remove(dbEntity);
        //    }
        //}       
        //model.AuthorIds = result;

        foreach (var item in model.AuthorIds) {
            if (string.IsNullOrEmpty(item)) {
                return false;
            }
            var dbResult = await this.GetSingleByIndexAsync(new BookAuthorModel {BookId = model.BookId, AuthorId = item });
            if (dbResult == null) {
                dbResult = new BookAuthor();
                dbResult.AuthorId = item;
                dbResult.BookId = model.BookId;
                await this.AddAsync(dbResult);
            } else if (dbResult.IsDeleted) {
                await this.RecoverAsync(dbResult.Id);
            }
        }
        return true;
    }
    #endregion
}
