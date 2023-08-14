using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class UserNewPage
{
    #region [ Properties - Inject]
    [Inject]
    private NavigationManager Navigation { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    public User User{ get; set; }

    private string WarningEmail { get; set; }    

    private string Role { get; set; }

    private IEnumerable<Role> Roles { get; set; }

    private IEnumerable<Publisher> Publishers { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {

            this.User = new User();
            this.User.HiredDate = DateTime.UtcNow.AddDays(1);
            this.Roles = await this.HttpClientContext.Role.GetListIsNotDeletedAsync();
            this.Publishers = await this.HttpClientContext.Publisher.GetListIsNotDeletedAsync();
            this.User.RoleId = this.Roles.FirstOrDefault().Id;
            this.User.PublisherId = this.Publishers.FirstOrDefault().Id;
        }
        StateHasChanged();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task AddAsync() {
        var dbResult = await this.HttpClientContext.User.GetSingleByEmailAsync(this.User.Email);
        if (dbResult!= null) {
            this.WarningEmail = "Email cannot be duplicated";
            return;
        }

        var result = await this.HttpClientContext.User.AddAsync(this.User);
        if (result) {
            this.Navigation.NavigateTo("/Admin/Users");
        }
    }
    #endregion
}
