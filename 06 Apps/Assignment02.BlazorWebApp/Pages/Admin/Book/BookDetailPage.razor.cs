using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
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

    private List<AuthorModel> SelectedAuthors { get; set; }

    private List<AuthorModel> AllAuthors { get; set; }
    private IEnumerable<Publisher> AllPublishers { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this._book = await this.HttpClientContext.Book.GetSingleByIdAsync(this.BookId);
            this.AllPublishers = await this.HttpClientContext.Publisher.GetListIsNotDeletedAsync();
            this._book.Publisher = this.AllPublishers.FirstOrDefault(x => x.Id == this._book.PublisherId);

            var allAuthor = await this.HttpClientContext.Author.GetListIsNotDeletedAsync();
            this.AllAuthors = new List<AuthorModel>() { };
            foreach (var item in allAuthor) {
                if (!string.IsNullOrEmpty(item.Id)) {

                    var authorModel = new AuthorModel() {
                        Id = item.Id,
                        FullName = item.FirstName + " " + item.LastName,
                    };
                    this.AllAuthors.Add(authorModel);
                }
            }

            var selectedAuthors = await this.HttpClientContext.Author.GetListByBookIdAsync(this.BookId);
            this.SelectedAuthors = new List<AuthorModel>() { };
            foreach (var item in selectedAuthors) {
                if (!string.IsNullOrEmpty(item.Id)) {

                    var authorModel = new AuthorModel() {
                        Id = item.Id,
                    };
                    this.SelectedAuthors.Add(authorModel);
                }
            }

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
        var authorIds = new List<string>() { };
        foreach (var item in this.SelectedAuthors) {
            if (!string.IsNullOrEmpty(item.Id)) {
                authorIds.Add(item.Id);
            }
        }
        var model = new AddBookModel {
            Book = this.SelectedBook,
            AuthorIds = authorIds,
        };

        var result = await this.HttpClientContext.Book.UpdateBookAndAuthorAsync(model);

        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private void AddAuthor() {
        var newAuthor = this.AllAuthors.FirstOrDefault();
        var result = this.SelectedAuthors.ToList();
        result.Add(newAuthor);

        this.SelectedAuthors = result;
    }

    private void RemoveAuthor(AuthorModel author) {
        var result = this.SelectedAuthors.ToList();
        if (result.Count() <= 1) {
            return;
        }
        result.Remove(author);

        this.SelectedAuthors = result;
    }

    private async Task SoftDeleteAsync() {
        var result = await this.HttpClientContext.Book.SoftDeleteAsync(this.SelectedBook.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }

    private async Task RecoverAsync() {
        var result = await this.HttpClientContext.Book.RecoverAsync(this.SelectedBook.Id);
        if (result) {
            await this.OnInitializedAsync();
        }
    }
    #endregion
}
