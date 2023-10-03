using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class CounterPart : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Nit { get; set; }

    public Guid CaseId { get; set; }
}