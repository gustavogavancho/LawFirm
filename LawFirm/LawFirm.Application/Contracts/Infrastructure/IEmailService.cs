using LawFirm.Application.Models.Mail;

namespace LawFirm.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}