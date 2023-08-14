using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class BookNewPage
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
    public Book Book { get; set; }

    public IEnumerable<AuthorModel> Authors { get; set; }
    
    public IEnumerable<AuthorModel> AllAuthors { get; set; }

    public IEnumerable<Publisher> Publishers { get; set; }

    private string Role { get; set; }

    private string Warning { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }

        if (!string.IsNullOrEmpty(Role)) {
            this.Book = new Book();
            var allAuthors = await this.HttpClientContext.Author.GetListIsNotDeletedAsync();
            var allAuthorList = new List<AuthorModel>();
            foreach (var item in allAuthors) {
                var authorModel = new AuthorModel();
                authorModel.Id = item.Id;
                authorModel.FullName = item.FirstName + " " + item.LastName;
                allAuthorList.Add(authorModel);
            }

            this.AllAuthors = allAuthorList.AsEnumerable();

            this.Publishers = await this.HttpClientContext.Publisher.GetListIsNotDeletedAsync();
            if (AllAuthors != null) {
                this.Authors = new List<AuthorModel>() { this.AllAuthors.FirstOrDefault() };
            } else {
                this.Authors = new List<AuthorModel>() {};
            }
            this.Book.PublisherId = this.Publishers.FirstOrDefault().Id;
            this.Book.PublishedDate = DateTime.Now;
        }
        StateHasChanged();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task AddAsync() {
        var authorIds = new List<string>();
        foreach (var item in this.Authors)
        {
            authorIds.Add(item.Id);
        }

        var addBookModel = new AddBookModel() { 
            AuthorIds = authorIds,
            Book = this.Book,
        };

        var result = await this.HttpClientContext.Book.AddBookModelAsync(addBookModel);
        if (result) {
            this.Navigation.NavigateTo("/Admin/Books");
        }
        return;
    }

    private void AddAuthor() {
        var authorId = new AuthorModel();
        var result = this.Authors.ToList();
            result.Add(authorId);
        this.Authors = result.AsEnumerable();
    }

    private void RemoveAuthor(AuthorModel id) {
        var result = this.Authors.ToList();
        if (result.Count() <= 1) {
            return;
        }
        result.Remove(id);

        this.Authors = result;
    }
    #endregion
}
