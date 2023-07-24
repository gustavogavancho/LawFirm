using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class CourtCase : AuditableEntity
{
    public Guid Id { get; set; }
    public Client Client { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Nit { get; set; } = default!;
}