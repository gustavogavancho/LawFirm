using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class StatusVmValidation : AbstractValidator<StatusVm>
{
    public StatusVmValidation()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}