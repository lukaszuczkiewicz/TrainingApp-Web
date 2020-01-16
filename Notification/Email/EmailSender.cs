using Microsoft.Extensions.Options;
using Notification.Abstractions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SendGridConfiguration> sendGridConfiguration;

        public EmailSender(IOptions<SendGridConfiguration> sendGridConfiguration)
        {
            this.sendGridConfiguration = sendGridConfiguration;
        }

        public async Task SendAsync(string emailAddress, string fromWho, string content, CancellationToken cancellationToken = default)
        {
            var apiKey = sendGridConfiguration.Value.SendGridKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sendGridConfiguration.Value.EmailAdress, fromWho);
            var subject = "New Training";
            var to = new EmailAddress(emailAddress, null);
            string htmlContent = $@"<span>{content}<span>"; // todo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }

}
