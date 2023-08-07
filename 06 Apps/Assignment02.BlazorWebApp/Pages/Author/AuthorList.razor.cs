using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp.Pages;

public partial class AuthorList
{
    #region [ Fields ]
    private string _searchName;
    private IEnumerable<Author> _iEnumAuthorInit;
    #endregion

    #region [ Properties ]
    [Inject]
    private NavigationManager Navigation { get; set; }

    [Inject]
    private ISessionStorageService SessionStorage { get; set; }

    [Inject]
    private HttpClientContext HttpClientContext { get; set; }

    public IQueryable<Author> IQueAuthor { get; set; }
    private string Role { get; set; }

    public string SearchName {
        get => this._searchName;
        set {
            this._searchName= value;
            //this.Search();
        }
    }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        //try {
        //    this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        //} catch {
        //    this.Role = string.Empty;
        //}
        //StateHasChanged();

        //if (!Role.IsNullOrEmpty()) {
            this._iEnumAuthorInit = await this.HttpClientContext.Author.GetListAllAsync();

            this.IQueAuthor = this._iEnumAuthorInit.AsQueryable();
        //}
        StateHasChanged();
    }
    #endregion
}
