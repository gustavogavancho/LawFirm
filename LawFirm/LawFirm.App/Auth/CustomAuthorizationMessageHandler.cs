using Blazored.LocalStorage;
using LawFirm.App.Services.Base;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;

namespace LawFirm.App.Auth;

public class CustomAuthorizationMessageHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorageService;
    private readonly NavigationManager _navigation;

    public CustomAuthorizationMessageHandler(ILocalStorageService localStorageService,
        NavigationManager Navigation)
    {
        _localStorageService = localStorageService;
        _navigation = Navigation;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _localStorageService.GetItemAsync<string>("token");
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            _navigation.NavigateTo("/logout");
        }

        return response;
    }
}