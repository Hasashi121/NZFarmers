namespace NZFarmers.Services
{
    public interface IEmailService
    {
        Task SendContactEmailAsync(string fromEmail, string subject, string message);
    }
}