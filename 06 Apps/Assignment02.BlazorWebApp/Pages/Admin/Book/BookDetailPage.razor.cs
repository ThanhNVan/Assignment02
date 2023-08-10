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

    private Book Book { get; set; }

    private IEnumerable<Author> Authors { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this._book = await this.HttpClientContext.Book.GetSingleByIdAsync(this.BookId);
            this.Authors = await this.HttpClientContext.Author.GetListByBookIdAsync(this.BookId);
            //await this.GetPublisherAsync(this.Books);
            this.Book = this._book;
        }
        StateHasChanged();

        await base.OnInitializedAsync();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    #endregion
}
