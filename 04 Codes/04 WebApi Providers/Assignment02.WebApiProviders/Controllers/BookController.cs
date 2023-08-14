using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class BookController : BaseEntityWebApiProvider<Book, IBookLogicProvider>
{
    #region [ CTor ]
    public BookController(ILogger<BaseEntityWebApiProvider<Book, IBookLogicProvider>> logger,
                            IBookLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider, logicContext) {
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

    [HttpGet(nameof(MethodUrl.GetListByPublisherId) + "/{publisherId}")]
    public async Task<IActionResult> GetListByPublisherIdAsync(string publisherId) {
        try {
            var result = await this._logicContext.Book.GetListByPublisherIdAsync(publisherId);
            if (result == null || result.Count() <= 0) {
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

    #region [ Methods - Update ]
    [HttpPut(nameof(MethodUrl.UpdateBookAndAuthor))]
    public async Task<IActionResult> UpdateBookAndAuthorAsync([FromBody] AddBookModel model) {
        try {
            var result = await this._logicProvider.UpdateBookAndAuthorAsync(model);
            if (result) {
                return Ok();
            }
            return BadRequest("Not Good");
        } catch (ArgumentNullException ex) {
            this._logger.LogError(ex.Message);
            return BadRequest();
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region [ Methods - Add ]
    [HttpPost(nameof(MethodUrl.AddBookModel))]
    public async Task<IActionResult> UpdateBookAuthorAsync([FromBody] AddBookModel model) {
        try {
            var result = await this._logicProvider.AddBookModelAsync(model);
            if (result) {
                return Ok("Updated");
            }
            return BadRequest();
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion
}