using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class BookDetailPage
{
    #region [ Fields ]
    private Book _book { get; set; }
    #endregion

    #region [ Properties - Inject - Parametter ]
    [Parameter]
    public string BookId { get; set; }

    [Inject]
    private NavigationManager Navigation { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }
    #endregion

    #region [ Properties ]
    private string Role { get; set; }

    private Book SelectedBook { get; set; }

    private IEnumerable<Author> SelectedAuthors { get; set; }

    private IEnumerable<Author> AllAuthors { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this._book = await this.HttpClientContext.Book.GetSingleByIdAsync(this.BookId);
            this._book.Publisher = await this.HttpClientContext.Publisher.GetSingleByIdAsync(this._book.PublisherId);
            this.SelectedAuthors = await this.HttpClientContext.Author.GetListByBookIdAsync(this.BookId);
            this.AllAuthors = await this.HttpClientContext.Author.GetListIsNotDeletedAsync();
            //await this.GetPublisherAsync(this.Books);
            this.SelectedBook = this._book;
        }
        StateHasChanged();

        await base.OnInitializedAsync();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task SaveAsync() {
        var aa = 1;
    }
    #endregion
}
