namespace LawFirm.Domain.Entities;

public class Deposit
{
    public Guid Id { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal PaymentDate { get; set; }
    public string Reference { get; set; }

    public Guid ConsultingFeeId { get; set; }
}