using LawFirm.Application.Models.Authentication;
using LawFirm.Identity.Models;

namespace LawFirm.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    Task<List<ApplicationUser>> GetUsers();
    Task<bool> ChangePassword(string id, string password);
}