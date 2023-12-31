﻿using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment02.DataProviders;

public class AuthorDataProvider : BaseEntityDataProvider<Author, AppDbContext>, IAuthorDataProvider
{
    #region [ CTor ]
    public AuthorDataProvider(ILogger<BaseEntityDataProvider<Author, AppDbContext>> logger, 
                                IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion

    #region [ Methods - List ]
    public async Task<IEnumerable<Author>> GetListByBookIdAsync(string bookId) {
        var result = default(IEnumerable<Author>);
        try {
            using var context = await this.GetContextAsync();
            result = await (from author in context.Authors.AsNoTracking()
                            join bookAuthor in context.BookAuthors.AsNoTracking() on author.Id equals bookAuthor.AuthorId
                            where bookAuthor.BookId == bookId && bookAuthor.IsDeleted == false
                            select author).ToListAsync();
            return result;
        } catch(Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion

    #region [ Methods - Single ]
    public async Task<Author> GetSingleByEmailAsync(string email) {
        var result = default (Author);

        try {
            using var context = await this.GetContextAsync();

            result = await context.Authors.FirstOrDefaultAsync(author => author.Email == email);

            return result;
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return result;
        }
    }
    #endregion
}
