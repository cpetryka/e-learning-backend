namespace E_Learning.Infrastructure.Email;

public class SmtpOptions
{
    public string Host { get; init; } = default!;
    public int Port { get; init; } = 587;
    public string Username { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string FromAddress { get; init; } = default!;
    public string FromName { get; init; } = "e-learning";
    public bool EnableSsl { get; init; } = true;
    public int TimeoutMs { get; init; } = 15000;
}