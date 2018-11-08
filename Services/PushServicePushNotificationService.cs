using System;
using System.Threading;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;
using Lib.Net.Http.WebPush.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Abstractions;

namespace Services
{
    internal class PushServicePushNotificationService : IPushNotificationService
    {
        private readonly PushNotificationServiceOptions _options;
        private readonly PushServiceClient _pushClient;

        private readonly ILogger _logger;

        public string PublicKey { get { return _options.PublicKey; } }

        public PushServicePushNotificationService(IOptions<PushNotificationServiceOptions> optionsAccessor, IVapidTokenCache vapidTokenCache, PushServiceClient pushClient, ILogger<PushServicePushNotificationService> logger)
        {
            _options = optionsAccessor.Value;

            _pushClient = pushClient;
            _pushClient.DefaultAuthentication = new VapidAuthentication("BPggdcXPKdvSpyjQHXlufrPQ7YPs_3TsoMnrDkg3wJ7mc-6l2fXEzjJlAopRaWdR1f5MRpxil68rLqDpYFp-YN0", "dO6qPKtyBD9TWsOksZqA527DplqID0czx-K1-LqjynU")
            {
                Subject = "mailto:dhrtom@hotmail.com",
                TokenCache = vapidTokenCache
            };

            _logger = logger;
        }

        public Task SendNotificationAsync(PushSubscription subscription, PushMessage message)
        {
            return SendNotificationAsync(subscription, message, CancellationToken.None);
        }

        public async Task SendNotificationAsync(PushSubscription subscription, PushMessage message, CancellationToken cancellationToken)
        {
            try
            {
                await _pushClient.RequestPushMessageDeliveryAsync(subscription, message, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed requesting push message delivery to {0}.", subscription.Endpoint);
            }
        }
    }
}
