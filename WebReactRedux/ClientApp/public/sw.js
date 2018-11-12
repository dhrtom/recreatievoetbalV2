const CACHE_NAME = 'v11';
let resTrack = new Map();

const urlsToCache = [
    '/',
    '/Home/FallBack',
    '/Team',
    '/dist/app.bundle.js',
    '/dist/vendor.bundle.js',
    '/css/all.css',
    '/dist/vendor.css'
];

const ignoreRequests = new RegExp('(' + ['/Home/TriggerPush'].join('(\/?)|\\') + ')$');

// Install
self.addEventListener('install', function(event) {
    event.waitUntil(
        caches.open(CACHE_NAME).then(function(cache) {
            return cache.addAll(urlsToCache);
        })
    );
});

// activate
self.addEventListener('activate', event => {
    console.log('Activating new service worker...');

    const cacheWhitelist = [CACHE_NAME];

    event.waitUntil(
        caches.keys().then(cacheNames => {
            return Promise.all(
                cacheNames.map(cacheName => {
                    if (cacheWhitelist.indexOf(cacheName) === -1) {
                        return caches.delete(cacheName);
                    }
                })
            );
        })
    );
});

// Fetch
self.addEventListener('fetch', function (event) {

    if (ignoreRequests.test(event.request.url)) {
        console.log('ignored: ', event.request.url);
        // request will be networked
        return;
    }

    event.respondWith(retrieveFromCache(event));
});


// Catch first strategy
function retrieveFromCache(event) {

    return caches.open(CACHE_NAME).then(function (cache) {

        return cache.match(event.request).then(function (response) {
            if (response) {
                return response;
            }

            if (navigator.onLine) {
                var fetchRequest = event.request.clone();
                return fetch(fetchRequest).then(
                    function (response) {
                        if (!response || response.status !== 200 || response.type !== 'basic') {
                            return response;
                        }

                        var responseToCache = response.clone();
                        cache.put(event.request, responseToCache);
                        resTrack.set(event.request.url, new Date().getTime());
                        return response;
                    });
            } else {
                // sendNotification("You are offline, you will be redirected to home page.");
                return caches.match(self.location.origin + '/Home/Fallback');

            }
        })
    })
};

self.addEventListener('message', function (event) {
    reply = processMessage(event.data);
    event.ports[0].postMessage(reply);
});

// Send message to service worker
function send_message_to_sw(msg) {
    navigator.serviceWorker.controller.postMessage(msg);
}