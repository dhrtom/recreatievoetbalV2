var CacheWorker = (function () {

    var filesToCache = [
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
        // './_framework/_bin/netstandard.dll',
        './_framework/_bin/System.Net.Http.dll',
        './_framework/_bin/Mono.WebAssembly.Interop.dll',
        './_framework/_bin/System.dll',
        './_framework/_bin/System.Core.dll',
        //The compiled project .dll's
        // './_framework/_bin/WebBlazor.dll'
    ];
    
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