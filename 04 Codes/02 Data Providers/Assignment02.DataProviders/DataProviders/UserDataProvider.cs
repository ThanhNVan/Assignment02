using Assignment02.EntityProviders;
using Assignment02.SharedLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace Assignment02.DataProviders;

public class UserDataProvider : BaseEntityDataProvider<User, AppDbContext>, IUserDataProvider
{
    #region [ CTor ]
    public UserDataProvider(ILogger<BaseEntityDataProvider<User, AppDbContext>> logger, 
                                IDbContextFactory<AppDbContext> dbContextFactory) : base(logger, dbContextFactory) {
    }
    #endregion

    #region [ Public Methods - List ]
    public async Task<IEnumerable<User>> GetListByPublisherIdAsync(string publisherId) {
        try {
            using (var context = this.GetContext()) {
                var result = await context.Users.AsNoTracking().Where(x => x.PublisherId == publisherId).ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetListByRoleIdAsync(string roleId) {
        try {
            using (var context = this.GetContext()) {
                var result = await context.Users.AsNoTracking().Where(x => x.RoleId == roleId).ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetListByPublisherIdAndRoleIdAsync(string publisherId, string roleId) {
        try {
            using (var context = this.GetContext()) {
                var result = await context.Users.AsNoTracking().Where(x => x.RoleId == roleId && x.PublisherId == publisherId).ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetListByHiredDateRangeAsync(DateTimeRangeModel model) {
        try {
            using (var context = this.GetContext()) {
                var result = await context.Users.AsNoTracking().Where(x => x.HiredDate >= model.StartDate && x.HiredDate <= model.EndDate).ToListAsync();
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion

    #region [ Public Methods - Single ]
    public async Task<User> GetSingleByEmailAsync(string email) {
        try {
            using (var context = this.GetContext()) {
                var result = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }


    public async Task<User> GetSingleByLoginAsync(LoginModel model) {
        try {
            using (var context = this.GetContext()) {
                var result = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                return result;
            }
        } catch (Exception ex) {
            this._logger.LogError(ex.Message);
            return null;
        }
    }
    #endregion
}
