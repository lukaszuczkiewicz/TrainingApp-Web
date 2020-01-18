using System.Threading;
using System.Threading.Tasks;
using ApplicationQueries.Runners;
using Microsoft.Extensions.Options;
using Notification.Abstractions;
using Notification.Email;
using PlainCQRS.Core.Queries;

namespace Notification.BackgroudServices
{
    public class EmailBackgroudService
    {
        private readonly IEmailSender emailService;
        private readonly IQueryDispatcherAsync queryDispatcher;
        private readonly IOptions<DailyEmailConfiguration> dailyEmailConfiguration;

        public EmailBackgroudService(
            IEmailSender emailService, 
            IQueryDispatcherAsync queryDispatcher, 
            IOptions<DailyEmailConfiguration> dailyEmailConfiguration)
        {
            this.emailService = emailService;
            this.queryDispatcher = queryDispatcher;
            this.dailyEmailConfiguration = dailyEmailConfiguration;
        }

        public async Task SendDailyEmails()
        {
                var coaches = await queryDispatcher.ExecuteAsync(new GetCoachesQuery());

                foreach(var coach in coaches)
                {
                    await emailService.SendAsync(coach.Email, dailyEmailConfiguration.Value.FromWho, dailyEmailConfiguration.Value.HtmlContent, new CancellationToken());
                }
        }
    }
}
