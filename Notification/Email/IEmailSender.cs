using System.Threading;
using System.Threading.Tasks;

namespace Notification.Email
{
    public interface IEmailSender
    {
        Task SendAsync(string emailAddress, string fromWho, string content, CancellationToken cancellationToken);
    }
}
