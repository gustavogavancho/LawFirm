using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class CreateClientCommandValidation : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidation()
    {
        RuleFor(x => x.ClientType).NotEmpty();
        RuleFor(x => x.Nit).NotNull().Must(nit => nit.ToString().Length == 8 || nit.ToString().Length == 11).WithMessage("Nit must be either 8 or 11 digits.");
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();

        When(x => x.ClientType == "Natural Person", () =>
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        });

        When(x => x.ClientType == "Legal Person", () =>
        {
            RuleFor(x => x.BusinessName).NotNull();
            RuleFor(x => x.Representative).NotNull();
        });
    }
}
