using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class NoteVmValidation : AbstractValidator<NoteVm>
{
    public NoteVmValidation()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}