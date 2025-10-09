using System.Net;
using System.Net.Mail;
using E_Learning.Domain.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace E_Learning.Infrastructure.Email;

/// <summary>
/// Provides an SMTP-based email sender implementation using configuration from <see cref="SmtpOptions"/>.
/// </summary>
public  class SmtpEmailSender : IEmailSender
{
    private readonly SmtpOptions _options;

    public SmtpEmailSender(IOptions<SmtpOptions> options)
    {
        _options = options.Value;
    }

    /// <summary>
    /// Sends an email using the SMTP server specified in <see cref="SmtpOptions"/>.
    /// </summary>
    /// <param name="to">Recipient email address.</param>
    /// <param name="subject">Email subject line.</param>
    /// <param name="body">Email message body (HTML or plain text).</param>
    /// <param name="isHtml">If true, sends the body as HTML; otherwise as plain text.</param>
    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
    {
        using var message = new MailMessage
        {
            From = new MailAddress(_options.FromAddress, _options.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = isHtml
        };
        message.To.Add(to);

        using var client = new SmtpClient(_options.Host, _options.Port)
        {
            Credentials = new NetworkCredential(_options.Username, _options.Password),
            EnableSsl = _options.EnableSsl,
            Timeout = _options.TimeoutMs,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false
        };

        await client.SendMailAsync(message);
    }
}