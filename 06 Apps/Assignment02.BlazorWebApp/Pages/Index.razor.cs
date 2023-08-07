using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class Index
{
    #region [ Properties - Inject ]
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    private string Email { get; set; }
    private string Password { get; set; }
    private string Warning { get; set; } = string.Empty;
    #endregion

    #region [ Methods - Public ]
    public async Task LoginAsync() {
        var isValid = CheckValidInput();
        if (!isValid) {
            return;
        }

        var isAdmin = await HttpClientContext.User.IsAdminLoginAsync(Email, Password);

        if (isAdmin) {
            await SessionStorage.SetItemAsStringAsync(AppRole.Role, AppRole.Admin);
            NavigationManager.NavigateTo("Books", true);
            return;
        } else {
            this.Warning = "Invalid Input";
            return;
        }
    }
    #endregion

    #region [ Methods - Private ]
    private bool CheckValidInput() {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password)) {
            this.Warning = "Invalid Input";
            return false;   
        }
        return true;
    }
    #endregion
}
