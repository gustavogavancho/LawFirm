namespace LawFirm.Application.Features.Cases.Models;

public class CaseVm
{
    public string FileNumber { get; set; }
    public List<CounterPartVm> CounterParts { get; set; }
}