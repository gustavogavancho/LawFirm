using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class CounterPartVmValidation : AbstractValidator<CounterPartVm>
{
    public CounterPartVmValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Nit).NotEmpty();
    }
}