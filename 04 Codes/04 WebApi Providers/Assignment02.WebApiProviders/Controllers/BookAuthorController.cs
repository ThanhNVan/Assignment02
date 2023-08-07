﻿using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class BookAuthorController : BaseEntityWebApiProvider<BookAuthor, IBookAuthorLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;

    #endregion

    #region [ CTor ]
    public BookAuthorController(ILogger<BaseEntityWebApiProvider<BookAuthor, IBookAuthorLogicProvider>> logger,
                                    IBookAuthorLogicProvider logicProvider,
                                    LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion
}
