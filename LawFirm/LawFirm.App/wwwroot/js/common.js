function showSuccessToastr(message) {
    toastr.success(message, "Operation Successful", { timeOut: 5000 });
}

function showErrorToastr(message) {
    toastr.error(message, "Operation Failed", { timeOut: 5000 });
}

function showWarningToastr(message) {
    toastr.error(message, "Warning", { timeOut: 5000 });
}