using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class BookAuthorDataProvider : BaseEntityDataProvider<BookAuthor, AppDbContext>, IBookAuthorDataProvider
{
    #region [ CTor ]
    public BookAuthorDataProvider(ILogger<BaseEntityDataProvider<BookAuthor, AppDbContext>> logger, 
                                    IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion

    #region [ Methods - Single ]
    public async Task<BookAuthor> GetSingleByIndexAsync(BookAuthorModel model) {
        try {
            using var context = await this.GetContextAsync();
            var result = await context.BookAuthors.AsNoTracking().FirstOrDefaultAsync(x => x.AuthorId == model.AuthorId && x.BookId == model.BookId);
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<BookAuthor>> GetListByBookIdAsync(string bookId) {
        try {
            using var context = await this.GetContextAsync();
            var result = await context.BookAuthors.AsNoTracking().Where(x => x.BookId == bookId && x.IsDeleted== false).ToListAsync();
            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion
}
