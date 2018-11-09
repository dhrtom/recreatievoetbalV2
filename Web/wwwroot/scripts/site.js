// Notification
function notify(msg) {
    if (!("Notification" in window)) {
        alert("This browser does not support desktop notification");
    }else if (Notification.permission === "granted") {
        // If it's okay let's create a notification
        var notification = new Notification(msg);
    } else if (Notification.permission !== "denied") {
        Notification.requestPermission(function (permission) {
            // If the user accepts, let's create a notification
            if (permission === "granted") {
                var notification = new Notification(msg);
            }
        });
    }
}

function processMessage(msgObj) {
    try {
        if (msgObj.type == 1) {
            notify(msgObj.message);
            return "received";
        }
        console.log(msgObj);
    } catch (err) {
        console.log(err);
    }
}