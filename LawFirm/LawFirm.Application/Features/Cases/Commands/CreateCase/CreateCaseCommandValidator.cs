using FluentValidation;

namespace LawFirm.Application.Features.Cases.Commands.CreateCase;

public class CreateCaseCommandValidator :AbstractValidator<CreateCaseCommand>
{
    public CreateCaseCommandValidator()
    {
        RuleFor(x => x.FileNumber).NotEmpty();
        RuleFor(x => x.Ids).NotEmpty();
        RuleFor(x => x.CounterParts).NotEmpty();
    }
}