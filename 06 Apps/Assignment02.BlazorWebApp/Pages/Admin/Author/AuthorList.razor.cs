using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class AuthorList
{
    #region [ Fields ]
    private string _searchName;
    private IEnumerable<Author> _iEnumAuthorInit;
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
    public IQueryable<Author> IQueAuthor { get; set; }
    
    public List<Author> ListAuthor { get; set; }
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
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }
        StateHasChanged();

        if (!string.IsNullOrEmpty(Role)) {
            this._iEnumAuthorInit = (await this.HttpClientContext.Author.GetListIsNotDeletedAsync());

            this.ListAuthor = _iEnumAuthorInit.ToList();
            this.IQueAuthor = this._iEnumAuthorInit.AsQueryable();
        }
        StateHasChanged();
    }
    #endregion
}
