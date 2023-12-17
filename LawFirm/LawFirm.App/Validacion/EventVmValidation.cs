using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class EventVmValidation : AbstractValidator<EventVm>
{
    public EventVmValidation()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.EventStartDate).NotNull();
        RuleFor(x => x.EventEndDate).NotNull();
    }
}