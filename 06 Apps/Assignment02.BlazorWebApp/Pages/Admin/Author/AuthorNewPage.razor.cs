using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class AuthorNewPage
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
    public Author Author { get; set; }
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
            this.Author = new Author();
        }
        StateHasChanged();
    }
    #endregion

    #region [ Methods - Private ]
    private async Task CancelAsync() {

        await this.OnInitializedAsync();
    }

    private async Task AddAsync() {
        var dbResult = await this.HttpClientContext.Author.GetSingleByEmailAsync(this.Author.Email);

        if (dbResult != null) {
            this.Warning = "Email cannot be duplicated";
            return;
        }

        var result = await this.HttpClientContext.Author.AddAsync(this.Author);
        if (result) {
            this.Navigation.NavigateTo("/Admin/Authors");
        }
    }
    #endregion
}
