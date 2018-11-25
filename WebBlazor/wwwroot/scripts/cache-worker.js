let _deferredPrompt = null;

window.addEventListener('beforeinstallprompt', (e) => {
    // Prevent Chrome 67 and earlier from automatically showing the prompt
    e.preventDefault();
// Stash the event so it can be triggered later.
_deferredPrompt = e;
});

window.HasAddToHomeScreen = () =>
{
    return _deferredPrompt != null;
}
window.AddToHomeScreen = () => {
    _deferredPrompt.prompt();
    return true;
}

var CacheWorker = (function () {

    let cacheServiceWorkerRegistration;

    function writeToConsole(text) {
        console.log(text);
    };

    function registerCahceServiceWorker() {
        navigator.serviceWorker.register('/cache-service-worker.js', { scope: '/' })
            .then(function (serviceWorkerRegistration) {
                cacheServiceWorkerRegistration = serviceWorkerRegistration;

                // initializeUIState();

                writeToConsole('Cache Service Worker has been registered successfully');
            }).catch(function (error) {
            writeToConsole('Cache Service Worker registration has failed: ' + error);
        });
    };
    
    return {
        initialize: function () {
            // initializeConsole();

            if (!'serviceWork' in navigator) {
                writeToConsole('Service Workers are not supported');
                return;
            }

            registerCahceServiceWorker();
        }
    };
})();

CacheWorker.initialize();