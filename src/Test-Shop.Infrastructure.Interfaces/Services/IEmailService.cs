using System.Threading.Tasks;

namespace Test_Shop.Infrastructure.Interfaces.Services
{
    public interface IEmailService
    {
        Task<string> GenerateConfirmationLink(string userId, string token);
        Task SendEmailAsync(string email, string subject, string message);
    }
}
