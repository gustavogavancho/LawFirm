using LawFirm.Application.Features.Clients.Models;

namespace LawFirm.Application.Features.Cases.Models;

public class CaseVm
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string FileNumber { get; set; }
    public string ProsecutorOffice { get; set; }
    public string Fiscal { get; set; }
    public string CourtInCharge { get; set; }
    public string Judge { get; set; }
    public string ClientType { get; set; }
    public string Stage { get; set; }
    public List<CounterPartVm> CounterParts { get; set; }
    public List<ClientVm> Clients { get; set; }
}