using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class AddConsultingFeeVmValidation : AbstractValidator<ConsultingFeeVM>
{
    public AddConsultingFeeVmValidation()
    {
        RuleFor(x => x.TotalAmmount).NotNull().GreaterThan(0);
        RuleFor(x => x.ExpirationDate).NotNull().GreaterThan(DateTime.Today.Date).WithMessage("The date must be greater than today's date.");
    }
}