namespace LawFirm.Application.Features.ConsutingFees.Models;

public class DepositVm
{
    public Guid Id { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal PaymentDate { get; set; }
    public string Reference { get; set; }
}