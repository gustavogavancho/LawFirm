namespace LawFirm.Domain.Entities;

public class Note
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Guid CaseId { get; set; }
}