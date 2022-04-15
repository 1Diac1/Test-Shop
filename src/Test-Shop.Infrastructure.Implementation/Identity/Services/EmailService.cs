using Test_Shop.Infrastructure.Implementation.Settings;
using Test_Shop.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MimeKit;

namespace Test_Shop.Infrastructure.Implementation.Identity.Services
{
    public class EmailService : IEmailService
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly EmailConfiguration _emailConfiguration;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly EmailRoute _emailRoute;

        public EmailService(
            IActionContextAccessor actionContextAccessor,
            IOptions<EmailConfiguration> emailConfiguration, 
            IUrlHelperFactory urlHelperFactory, 
            IOptions<EmailRoute> emailRoute)
        {
            _actionContextAccessor = actionContextAccessor;
            _emailConfiguration = emailConfiguration.Value;
            _urlHelperFactory = urlHelperFactory;
            _emailRoute = emailRoute.Value;
        }


        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From, _emailConfiguration.Username));
            emailMessage.To.Add(new MailboxAddress("Receiver", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);

                await client.SendAsync(emailMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }

        public Task<string> GenerateConfirmationLink(string id, string token)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            var confirmationLink = urlHelper.Action(
                _emailRoute.Action,
                _emailRoute.Controller,
                new { userId = id, token },
                urlHelper.ActionContext.HttpContext.Request.Scheme);

            return Task.FromResult(confirmationLink);
        }
    }
}
