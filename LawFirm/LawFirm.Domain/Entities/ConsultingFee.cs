namespace LawFirm.Domain.Entities;

public class ConsultingFee
{
    public Guid Id { get; set; }
    public decimal TotalAmmount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public List<Deposit> Deposits { get; set; }

    public Guid CaseId { get; set; }
}