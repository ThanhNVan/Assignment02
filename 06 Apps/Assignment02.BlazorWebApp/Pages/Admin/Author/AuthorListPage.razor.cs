﻿using Assignment02.EntityProviders;
using Assignment02.HttpClientProviders;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment02.BlazorWebApp;

public partial class AuthorListPage
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
    public IEnumerable<Author> AuthorIEnumerable { get; set; }
    
    private string Role { get; set; }
    #endregion

    #region [ Methods - Override ]
    protected override async Task OnInitializedAsync() {
        try {
            this.Role = await SessionStorage.GetItemAsStringAsync(AppRole.Role);
        } catch {
        }
        StateHasChanged();

        if (!string.IsNullOrEmpty(Role)) {
            this.AuthorIEnumerable = await this.HttpClientContext.Author.GetListAllAsync();
        }
        StateHasChanged();
    }
    #endregion

    #region [ Private Methods -  ]
    private async Task DeleteAsync(string authorId) {
        await this.HttpClientContext.Author.SoftDeleteAsync(authorId);
        await this.OnInitializedAsync();
    }
    
    private void ViewDetail(string authorId) {
        this.Navigation.NavigateTo($"/Admin/Authors/Details/{authorId}");
    }

    private void AddNew() {
        this.Navigation.NavigateTo("/Admin/Authors/New");
    }
    #endregion
}
