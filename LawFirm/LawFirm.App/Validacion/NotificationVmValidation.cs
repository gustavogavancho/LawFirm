using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class NotificationVmValidation : AbstractValidator<NotificationVm>
{
    public NotificationVmValidation()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.NotificationDate).NotNull();
    }
}