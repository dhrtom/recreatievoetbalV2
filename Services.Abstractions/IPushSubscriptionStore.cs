using System;
using System.Threading;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;

namespace Services.Abstractions
{
    public interface IPushSubscriptionStore
    {
        Task StoreSubscriptionAsync(PushSubscription subscription);

        Task<PushSubscription> GetSubscriptionAsync(string endpoint);
        
        Task DiscardSubscriptionAsync(string endpoint);

        Task ForEachSubscriptionAsync(Action<PushSubscription> action);

        Task ForEachSubscriptionAsync(Action<PushSubscription> action, CancellationToken cancellationToken);
    }
}
