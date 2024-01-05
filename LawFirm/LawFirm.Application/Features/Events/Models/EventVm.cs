namespace LawFirm.Application.Features.Events.Models;

public class EventVm
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime EventStartDate { get; set; }
    public DateTime EventEndDate { get; set; }
    public Guid CaseId { get; set; }
}