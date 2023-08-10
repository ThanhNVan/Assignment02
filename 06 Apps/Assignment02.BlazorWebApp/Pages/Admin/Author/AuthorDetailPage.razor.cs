using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class AuthorDetailPage
{
    #region [ Fields ]
    private Author _author;
    #endregion

    #region [ Properties - Inject - Parametter ]
    [Parameter]
    public string AuthorId { get; set; }

    [Inject]
    private NavigationManager Navigation { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    private string Role { get; set; }

    private Author Author { get; set; }

    private IEnumerable<Book> Books { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this._author = await this.HttpClientContext.Author.GetSingleByIdAsync(this.AuthorId);
            this.Books = await this.HttpClientContext.Book.GetListByAuthorIdAsync(this.AuthorId);
            await this.GetPublisherAsync(this.Books);
            this.Author = this._author;
        }
        StateHasChanged();

        await base.OnInitializedAsync();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task UpdateAsync() {
        var result = await this.HttpClientContext.Author.UpdateAsync(this.Author);
        if (result) {
            await this.OnInitializedAsync();
        }

    }

    private async Task SoftDeleteAsync() {
        var result = await this.HttpClientContext.Author.SoftDeleteAsync(this.Author.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }
    
    private async Task RecoverAsync() {
        var result = await this.HttpClientContext.Author.RecoverAsync(this.Author.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private async Task GetPublisherAsync(IEnumerable<Book> books) {
        foreach (var book in books) {
            book.Publisher = await this.HttpClientContext.Publisher.GetSingleByIdAsync(book.PublisherId);
        }
    }

    private void ViewDetail(string bookId) {
        this.Navigation.NavigateTo($"/Admin/Books/Details/{bookId}");
    }
    #endregion
}
