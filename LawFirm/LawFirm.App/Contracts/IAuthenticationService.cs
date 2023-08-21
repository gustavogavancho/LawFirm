using LawFirm.App.ViewModels;

namespace LawFirm.App.Contracts;

public interface IAuthenticationService
{
    Task<bool> Authenticate(string email, string password);
    Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
    Task ChangePassword(ChangePasswordViewModel changePasswordViewModel);
    Task DeleteUser(Guid id);
    Task<List<UserListViewModel>> GetUsers();
    Task Logout();
}