using FluentValidation;

namespace LawFirm.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.EventStartDate).NotNull();
        RuleFor(x => x.EventEndDate).NotNull();
        RuleFor(x => x.CaseId).NotEmpty();
    }
}