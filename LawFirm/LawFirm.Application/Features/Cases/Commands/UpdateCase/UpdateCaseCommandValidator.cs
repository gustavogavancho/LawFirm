using FluentValidation;

namespace LawFirm.Application.Features.Cases.Commands.UpdateCase;

public class UpdateCaseCommandValidator : AbstractValidator<UpdateCaseCommand>
{
    public UpdateCaseCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.FileNumber).NotEmpty();
        RuleFor(x => x.Ids).NotEmpty();
        RuleFor(x => x.CounterParts).NotEmpty();
        RuleFor(x => x.ProsecutorOffice).NotEmpty();
        RuleFor(x => x.Fiscal).NotEmpty();
        RuleFor(x => x.CourtInCharge).NotEmpty();
        RuleFor(x => x.Judge).NotEmpty();
        RuleFor(x => x.ClientType).NotEmpty();
        RuleFor(x => x.Stage).NotEmpty();
    }
}