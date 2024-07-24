using FluentValidation;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Validacion;

public class AddConsultingFeeVmValidation : AbstractValidator<ConsultingFeeVM>
{
    public AddConsultingFeeVmValidation()
    {
        RuleFor(x => x.TotalAmmount).NotNull();
        RuleFor(x => x.ExpirationDate).NotNull();
    }
}