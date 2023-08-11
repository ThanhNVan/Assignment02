using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class PublisherDetailPage
{
    #region [ Properties - Parameter ]
    [Parameter]
    public string PublisherId { get; set; }
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
    public Publisher Publisher { get; set; }

    private string Role { get; set; }

    public IEnumerable<User> Users { get; set; }

    public IEnumerable<Book> Books { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this.Publisher = await this.HttpClientContext.Publisher.GetSingleByIdAsync(this.PublisherId);
            if (this.Publisher != null) {
                this.Users = await this.HttpClientContext.User.GetListByPublisherIdAsync(this.PublisherId);
                this.Books = await this.HttpClientContext.Book.GetListByPublisherIdAsync(this.PublisherId);
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
        var result = await this.HttpClientContext.Publisher.UpdateAsync(this.Publisher);
        if (result) {
            await this.OnInitializedAsync();
        }

    }

    private async Task SoftDeleteAsync() {
        var result = await this.HttpClientContext.Publisher.SoftDeleteAsync(this.Publisher.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private async Task RecoverAsync() {
        var result = await this.HttpClientContext.Publisher.RecoverAsync(this.Publisher.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private void ViewBookDetailPage(string bookId) {
        this.Navigation.NavigateTo($"/Admin/Books/Details/{bookId}");
    }
    #endregion
}
