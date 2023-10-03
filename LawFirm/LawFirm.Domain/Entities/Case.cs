using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class Case : AuditableEntity
{
    public Guid Id { get; set; }
    public string FileNumber { get; set; }

    public List<CounterPart> CounterParts { get; set; }

    public List<Client> Clients { get; set; }
}