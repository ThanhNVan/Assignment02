using Assignment02.EntityProviders;
using Assignment02.LogicProviders;
using Assignment02.SharedLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace Assignment02.WebApiProviders;

public class UserController : BaseEntityWebApiProvider<User, IUserLogicProvider>
{
    #region [ Fields ]
    private readonly LogicContext _logicContext;
    #endregion

    #region [ CTor ]
    public UserController(ILogger<BaseEntityWebApiProvider<User, IUserLogicProvider>> logger, 
                            IUserLogicProvider logicProvider,
                            LogicContext logicContext) : base(logger, logicProvider) {
        this._logicContext = logicContext;
    }
    #endregion

    #region [ Public Methods - Login ]
    [HttpPost(nameof(MethodUrl.Login))]
    public async Task<IActionResult> LoginAsync([FromBody] Admin entity) {
        try {
            var result = await this._logicContext.User.IsAdminLoginAsync(entity.Email, entity.Password);
            if (result) {
                return Ok();
            }
            return BadRequest();
        } catch (ArgumentNullException ex) {
            this._logger.LogError(ex.Message);
            return BadRequest();
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region [ Public Methods - List ]
    [HttpGet(nameof(MethodUrl.GetListByPublisherId) + "/{publisherId}")]
    public async Task<IActionResult> GetListByPublisherIdAsync(string publisherId) {
        try {
            var result = await this._logicContext.User.GetListByPublisherIdAsync(publisherId);
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

    #region [ Public Methods - Single ]
    [HttpGet(nameof(MethodUrl.GetSingleByEmail) + "/{email}")]
    public async Task<IActionResult> GetSingleByEmailAsync(string email) {
        try {
            var result = await this._logicContext.User.GetSingleByEmailAsync(email);
            if (result == null ) {
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
