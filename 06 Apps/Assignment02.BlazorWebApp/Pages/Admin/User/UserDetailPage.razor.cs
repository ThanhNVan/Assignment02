using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class UserDetailPage
{
	#region [ Properties ]
	[Parameter]
	public string UserId { get; set; }
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
    public User User { get; set; }

    private IEnumerable<Role> Roles { get; set; }

    private IEnumerable<Publisher> Publishers { get; set; }
    private string Role { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this.User = await this.HttpClientContext.User.GetSingleByIdAsync(this.UserId);
            if (this.User != null) {
                this.Roles = await this.HttpClientContext.Role.GetListIsNotDeletedAsync();
                this.Publishers = await this.HttpClientContext.Publisher.GetListIsNotDeletedAsync();
                this.User.Role = this.Roles.FirstOrDefault(x => x.Id == this.User.RoleId);
                this.User.Publisher = this.Publishers.FirstOrDefault(x => x.Id == this.User.PublisherId);
            }
        }
        StateHasChanged();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task UpdateAsync() {
        var result = await this.HttpClientContext.User.UpdateAsync(this.User);
        if (result) {
            await this.OnInitializedAsync();
        }

    }

    private async Task SoftDeleteAsync() {
        var result = await this.HttpClientContext.User.SoftDeleteAsync(this.User.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private async Task RecoverAsync() {
        var result = await this.HttpClientContext.User.RecoverAsync(this.User.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }
    #endregion
}
