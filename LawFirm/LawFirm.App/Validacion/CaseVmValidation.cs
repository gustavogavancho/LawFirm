using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class CaseVmValidation : AbstractValidator<CaseVm>
{
    public CaseVmValidation()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.FileNumber).NotEmpty();
        RuleFor(x => x.ProsecutorOffice).NotEmpty();
        RuleFor(x => x.Fiscal).NotEmpty();
        RuleFor(x => x.CourtInCharge).NotEmpty();
        RuleFor(x => x.Judge).NotEmpty();
        RuleFor(x => x.ClientType).NotEmpty();
        RuleFor(x => x.Stage).NotEmpty();
        RuleForEach(x => x.CounterParts).SetValidator(new CounterPartVmValidation());
        RuleForEach(x => x.Charges).SetValidator(new ChargeVmValidation());
        RuleForEach(x => x.Notifications).SetValidator(new NotificationVmValidation());
        RuleForEach(x => x.Statuses).SetValidator(new StatusVmValidation());
        RuleForEach(x => x.Notes).SetValidator(new NoteVmValidation());
    }
}