using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class UserListPage
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
    public IEnumerable<User> Users { get; set; }
    public IEnumerable<Role> Roles{ get; set; }
    public IEnumerable<Publisher> Publishers { get; set; }
    private string Role { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this.Users = await this.HttpClientContext.User.GetListAllAsync();
            this.Roles = await this.HttpClientContext.Role.GetListAllAsync();
            this.Publishers = await this.HttpClientContext.Publisher.GetListAllAsync();
            foreach (var item in Users) {
                item.Role = this.Roles.FirstOrDefault(x => x.Id == item.RoleId);
                item.Publisher = this.Publishers.FirstOrDefault(x => x.Id == item.PublisherId);
            }
        }
        StateHasChanged();
    }
    #endregion

    #region [ Private Methods -  ]
    private void ViewUserDetailPage(string userId) {
        this.Navigation.NavigateTo($"/Admin/Users/Details/{userId}");
    }
    #endregion
}
