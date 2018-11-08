using System.Threading;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;

namespace Services.Abstractions
{
    public interface IPushNotificationsQueue
    {
        void Enqueue(PushMessage message);

        Task<PushMessage> DequeueAsync(CancellationToken cancellationToken);
    }
}
