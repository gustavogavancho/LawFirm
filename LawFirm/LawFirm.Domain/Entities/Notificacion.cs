namespace LawFirm.Domain.Entities;

public class Notificacion
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime NotificationDate { get; set; }
    public Guid CaseId { get; set; }
}