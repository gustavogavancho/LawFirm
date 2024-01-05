using FluentValidation;

namespace LawFirm.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.EventStartDate).NotNull();
        RuleFor(x => x.EventEndDate).NotNull().Must((instace, endDate) => endDate > instace.EventStartDate).WithMessage(@"'Fecha Fin' no debe ser igual a 'Fecha Inicio'.");
        RuleFor(x => x.CaseId).NotEmpty();
    }
}