using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class ConsultingFee : AuditableEntity
{
    public Guid Id { get; set; }
    public decimal TotalAmmount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public List<Deposit> Deposits { get; set; }

    public Guid CaseId { get; set; }
    public Case Case { get; set; }
}