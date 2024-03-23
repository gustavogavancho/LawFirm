using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class ChargeVmValidation : AbstractValidator<ChargeVm>
{
    public ChargeVmValidation()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}