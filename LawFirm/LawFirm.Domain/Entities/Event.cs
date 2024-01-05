using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class Event : AuditableEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }

    public Guid CaseId { get; set; }
}