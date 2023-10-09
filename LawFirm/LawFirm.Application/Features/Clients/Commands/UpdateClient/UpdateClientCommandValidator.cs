using FluentValidation;

namespace LawFirm.Application.Features.Clients.Commands.UpdateClient;

public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(x => x.ClientType).NotEmpty().Must(x => x == "Natural Person" || x == "Legal Person").WithMessage("Client type must be either 'Natural Person' or 'Legal Person'.");
        RuleFor(x => x.Nit).NotNull();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();

        When(x => x.ClientType == "Natural Person", () =>
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Nit).Must(nit => nit.ToString().Length == 8).WithMessage("Nit must be 8 digits.");
            RuleFor(x => x.LastName).NotEmpty();
        });

        When(x => x.ClientType == "Legal Person", () =>
        {
            RuleFor(x => x.BusinessName).NotNull();
            RuleFor(x => x.Representative).NotNull();
            RuleFor(x => x.Nit).Must(nit => nit.ToString().Length == 11).WithMessage("Nit must be 11 digits.");
        });
    }
}