using LawFirm.Domain.Common;

namespace LawFirm.Domain.Entities;

public class Case : AuditableEntity
{
    public Guid Id { get; set; }
    public string FileNumber { get; set; }
    public string ProsecutorOffice { get; set; }
    public string Fiscal { get; set; }
    public string CourtInCharge { get; set; }
    public string Judge { get; set; }
    public string ClientType { get; set; }
    public List<IlegalAct> IlegalActs { get; set; }
    public string Stage { get; set; }
    public List<Status> Status { get; set; }
    public List<Notificacion> Notificacions { get; set; }
    public List<Notes> Notes { get; set; }
    public List<CounterPart> CounterParts { get; set; }
    public List<Client> Clients { get; set; }
}