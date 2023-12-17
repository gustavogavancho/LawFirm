using FluentValidation;

namespace LawFirm.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.EventStartDate).NotNull();
        RuleFor(x => x.EventEndDate).NotNull();
        RuleFor(x => x.CaseId).NotEmpty();
    }
}