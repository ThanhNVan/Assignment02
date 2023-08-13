using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class BookListPage
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
    private string Role { get; set; }

    public IEnumerable<Book> BookIEnumerable { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }
        StateHasChanged();

        if (!string.IsNullOrEmpty(Role)) {
            this.BookIEnumerable = await this.HttpClientContext.Book.GetListAllAsync();
        }
        StateHasChanged();
    }
    #endregion

    #region [ Private Methods -  ]
    private void ViewDetail(string bookId) {
        this.Navigation.NavigateTo($"/Admin/Books/Details/{bookId}");
    }

    private void AddNew() {
        this.Navigation.NavigateTo("/Admin/Books/New");
    }
    #endregion
}
