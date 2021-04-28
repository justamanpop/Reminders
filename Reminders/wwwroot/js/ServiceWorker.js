self.addEventListener('push', function (event) {

    var body;

    if (event.data) {
        body = e.data.text();
    }

    else {
        body = "No data in event";
    }

    var options = {
        body: body,
        icon:"./lifeCycle.jpg",
        vibrate=[100, 50, 100],
        data: {
            dateOfArrival: Date.now()
        },
        actions: [
            {
                action: "explore", title: "Go interact with this!",
                icon: "images/checkmark.jpg"
            },
            {
                action: "close", title: "Ignore",
                icon: "redx.png"
            },
        ]
    };

    event.waitUntil(self.registration.showNotification("Push Notification", options));

});

self.addEventListener('notificationclick', function (e) {
    var notification = e.notification;
    var action = e.action;

    if (action === 'close') {
        notification.close();
    } else {
        // Some actions
        clients.openWindow('http://www.example.com');
        notification.close();
    }
});