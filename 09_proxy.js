//sw.js

const CACHE_NAME = "V1"

const prefetchedResources = ['/', '/src/index.js', '/src/index.css']

// The install event is fired when the registration succeeds.
// After the install step, the browser tries to activate the service worker.
// Generally, we cache static resources that allow the website to run offline
self.addEventListener('install', event => {
  debugger;
  event.waitUntil(
    caches.open(CACHE_NAME)
      .then(cache => {
        return cache.addAll(prefetchedResources)
      })
  )
})

// on activation of the service worker => delete all stale caches
self.addEventListener('activate', event => {
  return caches.keys().then(keyList => {
    return Promise.all(keyList.map(key => {
      if (key !== CACHE_NAME) return caches.delete(key)
    }))
  })
})

self.addEventListener('fetch', event => {
  event.respondWith(
    caches.open(CACHE_NAME)
      .then(cache => cache.match(event.request))
      .then(response => {
        return response || fetch(event.request);
      })
  );
});


// index.js
fetch('/api/users/1/').then(response => {
    console.log(user) 
}).then(error => {
    console.log(error)
})