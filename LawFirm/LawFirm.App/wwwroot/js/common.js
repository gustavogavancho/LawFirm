function showSuccessToastr(message) {
    toastr.success(message, "Operation Successful", { timeOut: 5000 });
}

function showErrorToastr(message) {
    toastr.error(message, "Operation Failed", { timeOut: 5000 });
}

function showWarningToastr(message) {
    toastr.error(message, "Warning", { timeOut: 5000 });
}

function requestNotificationPermission() {
    Notification.requestPermission().then(permission => {
        console.log(`Notification permission: ${permission}`);
    });
}

function showNotification(title, message) {
    if (Notification.permission === "granted") {
        new Notification(title, { body: message, icon: 'icon-512.png' });
    } else if (Notification.permission !== "denied") {
        Notification.requestPermission().then(permission => {
            if (permission === "granted") {
                new Notification(title, { body: message, icon: 'icon-512.png' });
            }
        });
    }
}