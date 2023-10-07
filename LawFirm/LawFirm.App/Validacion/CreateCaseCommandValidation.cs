using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class CreateCaseCommandValidation : AbstractValidator<CreateCaseCommand>
{
    public CreateCaseCommandValidation()
    {
        RuleFor(x => x.FileNumber).NotEmpty();
    }
}