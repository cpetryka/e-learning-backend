namespace E_Learning.Domain.Common.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
}