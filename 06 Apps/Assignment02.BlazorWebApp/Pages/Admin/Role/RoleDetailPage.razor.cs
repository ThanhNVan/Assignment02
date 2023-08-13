using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class RoleDetailPage
{
    #region [ Properties ]
    [Parameter]
    public string RoleId { get; set; }
    #endregion

    #region [ Properties - Inject]
    [Inject]
    private NavigationManager Navigation { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    public Role RoleItem { get; set; }
    private string Role { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {

            this.RoleItem = await this.HttpClientContext.Role.GetSingleByIdAsync(this.RoleId);
        }
        StateHasChanged();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task UpdateAsync() {
        var result = await this.HttpClientContext.Role.UpdateAsync(this.RoleItem);
        if (result) {
            await this.OnInitializedAsync();
        }

    }

    private async Task SoftDeleteAsync() {
        var result = await this.HttpClientContext.Role.SoftDeleteAsync(this.RoleItem.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private async Task RecoverAsync() {
        var result = await this.HttpClientContext.Role.RecoverAsync(this.RoleItem.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }
    #endregion
}
