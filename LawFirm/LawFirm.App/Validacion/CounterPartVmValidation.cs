using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class CounterPartVmValidation : AbstractValidator<CounterPartVm>
{
    public CounterPartVmValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Nit).Must(nit => nit.ToString().Length == 8 || nit.ToString().Length == 11).WithMessage("Nit must be 8 or 11 digits.");
    }
}