let _pushApiSupported = false;
let _serviceWorkerSupported = false;
let _pushServiceWorkerRegistration = null;
let _subScriptionResult = null;

var PushNotifications = (function () {
    function registerPushServiceWorker() {
        navigator.serviceWorker.register('/scripts/service-workers/push-service-worker.js', {scope: '/scripts/service-workers/push-service-worker/'})
            .then(function (serviceWorkerRegistration) {
                _pushServiceWorkerRegistration = serviceWorkerRegistration;

                console.log('Push Service Worker has been registered successfully');
            }).catch(function (error) {
            console.log('Push Service Worker registration has failed: ' + error);
        });
    }

    return {
        Initialize: function () {
            if (!'serviceWork' in navigator) {
                return;
            }
            _serviceWorkerSupported = true;

            if (!'PushManager' in window) {
                console.log('Push API not supported');
                return;
            }
            _pushApiSupported = true;
            registerPushServiceWorker();
        }
    };
})();


var UrlB64ToUint8Array = function UrlB64ToUint8Array(base64String) {
    const padding = '='.repeat((4 - base64String.length % 4) % 4);
    const base64 = (base64String + padding).replace(/\-/g, '+').replace(/_/g, '/');

    const rawData = window.atob(base64);
    const outputArray = new Uint8Array(rawData.length);

    for (let i = 0; i < rawData.length; ++i) {
        outputArray[i] = rawData.charCodeAt(i);
    }

    return outputArray;
};

window.InitPushNotifications = () =>
{
    if(_pushServiceWorkerRegistration !== null) {
        return true;
    }
    PushNotifications.Initialize();
    return true;
}

window.GetPushServiceWorkerRegistrationResult = () => {
    return _pushServiceWorkerRegistration;
}

window.GetSubscriptionResult = () => {
    return _subScriptionResult;
}

window.SetSubscription = () => {
    if(_subScriptionResult !== null){
        return _subScriptionResult;
    }
    _pushServiceWorkerRegistration.pushManager.getSubscription()
        .then(function (subscription) {
            _subScriptionResult = {notificationsBlocked : Notification.permission === 'denied', subscription : subscription, serviceWorkerSupported: _serviceWorkerSupported, pushApiSupported : _pushApiSupported};
        });
    return null;
}

window.SubscribeForPushNotifications = (applicationServerPublicKeyBase64) => {
    _pushServiceWorkerRegistration.pushManager.subscribe({
        userVisibleOnly: true,
        applicationServerKey: UrlB64ToUint8Array(applicationServerPublicKeyBase64)
    })
        .then(function (subscription) {
            console.log("Subscription OK");
            _subScriptionResult = {notificationsBlocked : Notification.permission === 'denied', subscription : subscription, serviceWorkerSupported: _serviceWorkerSupported, pushApiSupported : _pushApiSupported};
            return _subScriptionResult;
        }).catch(function (error) {
            _subScriptionResult = {notificationsBlocked : Notification.permission === 'denied', subscription : null, serviceWorkerSupported: _serviceWorkerSupported, pushApiSupported : _pushApiSupported, error : error};
            return _subScriptionResult;
        console.log("Subscription ERROR " + error);
        });
    return null;
}

window.UnsubscribeForPushNotifications = () => {
    _pushServiceWorkerRegistration.pushManager.getSubscription()
        .then(function (pushSubscription) {
            if (pushSubscription) {
                pushSubscription.unsubscribe();
                return encodeURIComponent(pushSubscription.endpoint);
            }
        });
}