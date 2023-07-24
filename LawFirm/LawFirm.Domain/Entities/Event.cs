using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class Event : AuditableEntity
{
    public Guid Id { get; set; }
    public Client Client { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
}