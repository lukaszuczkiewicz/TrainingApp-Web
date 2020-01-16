using PlainCQRS.Core.Events;
using Application.Coach.Events;
using System.Threading.Tasks;
using System.Threading;
using Notification.Email;

namespace Application.Notification
{
    public class TrainingCreatedEventHandler : IEventHandlerAsync<TrainingCreated>
    {
        private readonly IEmailSender emailSender;

        public TrainingCreatedEventHandler(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
       
        public async Task HandleAsync(TrainingCreated @event, CancellationToken cancellationToken = default)
        {
            await emailSender.SendAsync(@event.RunnerEmailAddress, @event.CoachName, @event.TrainingDetail, cancellationToken);
        }
    }
}
