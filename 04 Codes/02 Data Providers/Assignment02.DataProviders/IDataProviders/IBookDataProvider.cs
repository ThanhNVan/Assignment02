﻿using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;

namespace Assignment02.DataProviders;

public interface IBookDataProvider : IBaseEntityDataProvider<Book>
{
    #region [ Methods - List ]
    Task<IEnumerable<Book>> GetListByAuthorIdAsync(string authorId);
    Task<IEnumerable<Book>> GetListByPublisherIdAsync(string publisherId);
    #endregion

    #region [ Methods - Add ]
    Task<bool> AddBookModelAsync(AddBookModel model);
    #endregion

}
