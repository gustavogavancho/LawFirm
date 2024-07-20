namespace LawFirm.Application.Features.ConsutingFees.Models;

public class ConsultingFeeVM
{
    public Guid Id { get; set; }
    public decimal TotalAmmount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public List<DepositVm> Deposits { get; set; }
}