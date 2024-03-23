using LawFirm.Application.Features.Cases.Models;
using LawFirm.Application.Features.Events.Models;
using MediatR;

namespace LawFirm.Application.Features.Cases.Commands.UpdateCase;

public class UpdateCaseCommand : IRequest
{
    public string Description { get; set; }
    public Guid Id { get; set; }
    public List<Guid> Ids { get; set; }
    public string FileNumber { get; set; }
    public string ProsecutorOffice { get; set; }
    public string Fiscal { get; set; }
    public string CourtInCharge { get; set; }
    public string Judge { get; set; }
    public string ClientType { get; set; }
    public string Stage { get; set; }
    public List<CounterPartVm> CounterParts { get; set; }
    public List<ChargeVm> Charges { get; set; }
    public List<EventVm> Events { get; set; }
}