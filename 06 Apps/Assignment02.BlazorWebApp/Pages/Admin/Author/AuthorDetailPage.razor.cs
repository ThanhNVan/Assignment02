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
        StateHasChanged();

        if (!string.IsNullOrEmpty(Role)) {
            this.Books = await this.HttpClientContext.Book.GetListByAuthorIdAsync(this.AuthorId);    
            this.Author = await this.HttpClientContext.Author.GetSingleByIdAsync(this.AuthorId);
        }
        StateHasChanged();
    }
    #endregion
}
