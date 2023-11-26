using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion
{
    public class CientVmValidation : AbstractValidator<ClientVm>
    {
        public CientVmValidation()
        {
            RuleFor(x => x.ClientType).NotEmpty();
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
}
