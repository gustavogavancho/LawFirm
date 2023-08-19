using FluentValidation;
using System.Text.RegularExpressions;

namespace LawFirm.App.ViewModels;

public record UserViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}

public class UserViewModelValidation : AbstractValidator<UserViewModel>
{
    public UserViewModelValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.UserName).NotEmpty().Must(BeFreeFromSpecialCharacters).WithMessage("Username cannot contain special characters.");
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password and Confirm Password must match");
    }

    private bool BeFreeFromSpecialCharacters(string username)
    {
        // Define your own logic to check for special characters.
        // You can use regular expressions or any other method you prefer.
        // Here's a simple example using regular expression to disallow special characters.
        return !Regex.IsMatch(username, @"[@!#$%^&*()_+{}\[\]:;<>,.?~\\/-]") && !username.Contains("ñ", StringComparison.OrdinalIgnoreCase);
    }
}