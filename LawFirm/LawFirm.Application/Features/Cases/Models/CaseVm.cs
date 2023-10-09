namespace LawFirm.Application.Features.Cases.Models;

public class CaseVm
{
    public Guid Id { get; set; }
    public string FileNumber { get; set; }
    public List<CounterPartVm> CounterParts { get; set; }
}