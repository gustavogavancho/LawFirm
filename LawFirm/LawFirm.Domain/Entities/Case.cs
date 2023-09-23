using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class Case : AuditableEntity
{
    public Guid Id { get; set; }
    public Client Client { get; set; }
    public string FileNumber { get; set; }
    public List<string> Defendant { get; set; }
}