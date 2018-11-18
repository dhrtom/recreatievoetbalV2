const CACHE_NAME = 'v11';
let resTrack = new Map();

const urlsToCache = [
    './',
    //Html and css files
    './index.html',
    './css/site.css',
    './css/bootstrap/bootstrap.min.css',
    './css/open-iconic/font/css/open-iconic-bootstrap.min.css',
    './css/open-iconic/font/fonts/open-iconic.woff',
    //Blazor framework
    './_framework/blazor.webassembly.js',
    './_framework/blazor.boot.json',
    //Our additional files
    './manifest.json',
    './serviceworker.js',
    './icons/icon-192x192.png',
    './icons/icon-512x512.png',
    //The web assembly/.net dll's
    './_framework/wasm/mono.js',
    './_framework/wasm/mono.wasm',
    './_framework/_bin/Microsoft.AspNetCore.Blazor.Browser.dll',
    './_framework/_bin/Microsoft.AspNetCore.Blazor.dll',
    './_framework/_bin/Microsoft.Extensions.DependencyInjection.Abstractions.dll',
    './_framework/_bin/Microsoft.Extensions.DependencyInjection.dll',
    './_framework/_bin/Microsoft.JSInterop.dll',
    './_framework/_bin/mscorlib.dll',
    './_framework/_bin/netstandard.dll',
    './_framework/_bin/System.Net.Http.dll',
    './_framework/_bin/Mono.WebAssembly.Interop.dll',
    './_framework/_bin/System.dll',
    './_framework/_bin/System.Core.dll',
    //The compiled project .dll's
    './_framework/_bin/DotnetPwaSample.dll'
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
    console.log('fetch: ' + event.request.url);
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