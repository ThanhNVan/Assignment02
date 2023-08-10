using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment02.WebApiProviders;

public class BookAuthorController : BaseEntityWebApiProvider<BookAuthor, IBookAuthorLogicProvider>
{
    #region [ CTor ]
    public BookAuthorController(ILogger<BaseEntityWebApiProvider<BookAuthor, IBookAuthorLogicProvider>> logger,
                                    IBookAuthorLogicProvider logicProvider,
                                    LogicContext logicContext) : base(logger, logicProvider, logicContext) {
    }
    #endregion

    #region [ Methods - Update ]
    [HttpPut(nameof(MethodUrl.UpdateBookAuthor))]
    public async Task<IActionResult> UpdateBookAuthorAsync([FromBody] UpdateBookAuthorModel model) {
        try {
            var result = await this._logicProvider.UpdateBookAuthorAsync(model);
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
