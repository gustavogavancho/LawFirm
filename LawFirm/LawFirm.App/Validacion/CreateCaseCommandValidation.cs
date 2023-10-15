using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class CreateCaseCommandValidation : AbstractValidator<CreateCaseCommand>
{
    public CreateCaseCommandValidation()
    {
        RuleFor(x => x.FileNumber).NotEmpty();
        RuleFor(x => x.ProsecutorOffice).NotEmpty();
        RuleFor(x => x.Fiscal).NotEmpty();
        RuleFor(x => x.CourtInCharge).NotEmpty();
        RuleFor(x => x.Judge).NotEmpty();
        RuleFor(x => x.ClientType).NotEmpty();
        RuleFor(x => x.Stage).NotEmpty();
    }
}