using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace Assignment02.DataProviders;

public class BookDataProvider : BaseEntityDataProvider<Book, AppDbContext>, IBookDataProvider
{
    #region [ CTor ]
    public BookDataProvider(ILogger<BaseEntityDataProvider<Book, AppDbContext>> logger, 
                            IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId) {
        var result = default(IEnumerable<Book>);

        try {
            using (var context = await this.GetContextAsync()) {
                result= await (from book in context.Books.AsNoTracking()
                                 join bookAuthor in context.BookAuthors.AsNoTracking() on book.Id equals bookAuthor.BookId
                                 where bookAuthor.AuthorId == authorId
                                 select book).ToListAsync();
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }

        return result;
    }

    public async Task<IEnumerable<Book>> GetListByPublisherIdAsync(string publisherId) {
        var result = default(IEnumerable<Book>);

        try {
            using (var context = await this.GetContextAsync()) {
                result = await context.Books.AsNoTracking().Where(x => x.PublisherId == publisherId).ToListAsync();
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }

        return result;
    }
    #endregion

}
