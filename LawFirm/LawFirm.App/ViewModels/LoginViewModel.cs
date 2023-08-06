using FluentValidation;

namespace LawFirm.App.ViewModels;

public class LoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginViewModelValidation : AbstractValidator<LoginViewModel>
{
    public LoginViewModelValidation()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}