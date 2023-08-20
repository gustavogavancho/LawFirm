using AutoMapper;
using Blazored.LocalStorage;
using LawFirm.App.Auth;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;
using LawFirm.App.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Net.Http.Headers;

namespace LawFirm.App.Services;

public class AuthenticationService : BaseDataService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly IMapper _mapper;

    public AuthenticationService(IClient client, 
        ILocalStorageService localStorage, 
        AuthenticationStateProvider authenticationStateProvider,
        IMapper mapper) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _mapper = mapper;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        try
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(authenticationResponse.Token);
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
        var response = await _client.RegisterAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }
        return false;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
        ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
        _client.HttpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<List<UserListViewModel>> GetUsers()
    {
        List<UserListViewModel> mappedUsers = default!;
        try
        {
            var users = await _client.UsersAsync();

            mappedUsers = _mapper.Map<List<UserListViewModel>>(users);

            
        }
        catch (ApiException ex) when(ex.StatusCode == 401)
        {

        }
        return mappedUsers;
    }

    public async Task<bool> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
    {
        var request = _mapper.Map<ChangePasswordRequest>(changePasswordViewModel);

        var response = await _client.ChangePasswordAsync(request);

        return response;
    }

    public async Task DeleteUser(Guid id)
    {
        await _client.DeleteUserAsync(id);
    }
}