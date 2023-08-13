using FluentValidation;

namespace LawFirm.App.ViewModels;

public class ChangePasswordViewModel
{
    public string Id { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class ChangePasswordViewModelValidation : AbstractValidator<ChangePasswordViewModel>
{
    public ChangePasswordViewModelValidation()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password and Confirm Password must match");
    }
}