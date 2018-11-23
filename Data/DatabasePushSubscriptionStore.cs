using System;
using System.Threading;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;

namespace Data
{
    internal class DatabasePushSubscriptionStore : IPushSubscriptionStore
    {
        private readonly WebsiteDbContext _context;

        public DatabasePushSubscriptionStore(WebsiteDbContext context)
        {
            _context = context;
        }

        public Task StoreSubscriptionAsync(PushSubscription subscription)
        {
            _context.Subscriptions.Add(new WebsiteDbContext.PushSubscription(subscription));

            return _context.SaveChangesAsync();
        }

        public async Task<PushSubscription> GetSubscriptionAsync(string endpoint)
        {
            return await _context.Subscriptions.FindAsync(endpoint);
        }

        public async Task DiscardSubscriptionAsync(string endpoint)
        {
            var subscription = await _context.Subscriptions.FindAsync(endpoint);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }

        public Task ForEachSubscriptionAsync(Action<PushSubscription> action)
        {
            return ForEachSubscriptionAsync(action, CancellationToken.None);
        }

        public Task ForEachSubscriptionAsync(Action<PushSubscription> action, CancellationToken cancellationToken)
        {
            return _context.Subscriptions.AsNoTracking().ForEachAsync(action, cancellationToken);
        }
    }
}
