using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class PublisherListPage
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
    public IEnumerable<Publisher> PubliserIEnumerable { get; set; }

    private string Role { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this.PubliserIEnumerable = await this.HttpClientContext.Publisher.GetListAllAsync();
        }
        StateHasChanged();
    }
    #endregion

    #region [ Private Methods -  ]
    private void ViewDetail(string publiserId) {
        this.Navigation.NavigateTo($"/Admin/Publishers/Details/{publiserId}");
    }
    #endregion
}
