using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Assignment02.WebApiProviders;

public class AuthorController : BaseEntityWebApiProvider<Author, IAuthorLogicProvider>
{
    #region [ CTor ]
    public AuthorController(ILogger<BaseEntityWebApiProvider<Author, IAuthorLogicProvider>> logger, 
                            IAuthorLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider, logicContext) {
    }
    #endregion

    #region [ Public Methods -  ]
    //[Authorize]
    //[HttpGet(nameof(MethodUrl.GetListIsNotDeleted))]
    //public async override Task<IActionResult> GetListIsNotDeletedAsync() {
    //    return await base.GetListIsNotDeletedAsync();
    //}
    #endregion

    #region [ Methods - List ]
    [HttpGet(nameof(MethodUrl.GetListByBookId) + "/{BookId}")]
    public async Task<IActionResult> GetListByBookIdAsync(string bookId) {
        try {
            var result = await this._logicProvider.GetListByBookIdAsync(bookId);
            if (result == null || result.Count() <= 0) {
                return NotFound("Empty");
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
    #region [ Methods - Single ]
    [HttpGet(nameof(MethodUrl.GetSingleByEmail) + "/{email}")]
    public async Task<IActionResult> GetSingleByEmailAsync(string email) {
        try {
            var result = await this._logicProvider.GetSingleByEmailAsync(email);
            if (result == null) {
                return NotFound("Empty");
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
