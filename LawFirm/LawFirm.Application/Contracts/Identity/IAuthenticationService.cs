using LawFirm.Application.Models.Authentication;
using LawFirm.Identity.Models;

namespace LawFirm.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    Task DeleteUserAsync(string id);
    Task<List<ApplicationUser>> GetUsersAsync();
    Task<bool> ChangePasswordAsync(string id, string password);
}