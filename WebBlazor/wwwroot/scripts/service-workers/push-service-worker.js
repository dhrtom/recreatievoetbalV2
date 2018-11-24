const pushNotificationTitle = 'Demo.AspNetCore.PushNotifications';

// https://developers.google.com/web/fundamentals/push-notifications/display-a-notification
self.addEventListener('push', function (event) {
    event.waitUntil(self.registration.showNotification(pushNotificationTitle, {
        body: event.data.text(),
        icon: '/img/push-notification-icon.png',
        badge: '/img/badge-128x128.png'
    }));
});

self.addEventListener('notificationclick', function (event) {
    event.notification.close();
});