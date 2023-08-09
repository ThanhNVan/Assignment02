﻿using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class BookController : BaseEntityWebApiProvider<Book, IBookLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;

    #endregion

    #region [ CTor ]
    public BookController(ILogger<BaseEntityWebApiProvider<Book, IBookLogicProvider>> logger,
                            IBookLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion

    #region [ Methods - List ]
    [HttpGet(nameof(MethodUrl.GetListByAuthorId) + "/{authorId}")]
    public async Task<IActionResult> GetListByAuthorIdAsync(string authorId) {
        try {
            var result = await this._logicContext.Book.GetListByAuthorIdAsync(authorId);
            if (result ==null || result.Count() <=0) {
                return NotFound();
            }
            return Ok(result);  
        } catch (ArgumentNullException ex) {
            this._logger.LogError(ex.Message);
            return BadRequest();
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion
}