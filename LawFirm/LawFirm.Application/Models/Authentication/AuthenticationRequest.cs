using FluentValidation;

namespace LawFirm.Application.Models.Authentication;

public class AuthenticationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class AuthenticationValidator : AbstractValidator<AuthenticationRequest>
{
    public AuthenticationValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotNull().NotEmpty();
    }
}