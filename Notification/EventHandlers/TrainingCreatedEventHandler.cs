using PlainCQRS.Core.Events;
using Application.Coach.Events;
using Notification.Abstractions;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Notification
{
    public class TrainingCreatedEventHandler : IEventHandlerAsync<TrainingCreated>
    {
        private readonly IOptions<SendGridConfiguration> sendGridConfiguration;

        public TrainingCreatedEventHandler(IOptions<SendGridConfiguration> sendGridConfiguration)
        {
            this.sendGridConfiguration = sendGridConfiguration;
        }


        public async Task HandleAsync(TrainingCreated @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            var apiKey = sendGridConfiguration.Value.ApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sendGridConfiguration.Value.EmailAdress, @event.CoachName);
            var subject = "New Training";
            var to = new EmailAddress(@event.RunnerEmailAddress, "Runner");
            var htmlContent = @"<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
