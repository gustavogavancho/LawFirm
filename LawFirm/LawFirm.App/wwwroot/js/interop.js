window.scrollUtils = {
    scrollToTop: function () {
        window.scrollTo(0, 0);
    }
};

window.BlazorDownloadFile = function (fileName, contentBase64) {
    // Create a blob from the base64 content
    let blob = b64toBlob(contentBase64);

    // Create a URL for the blob
    let blobUrl = URL.createObjectURL(blob);

    // Create a link element
    let link = document.createElement("a");

    // Set link's href to the blob URL
    link.href = blobUrl;

    // Set link's download attribute to the file name
    link.download = fileName;

    // Append link to the body
    document.body.appendChild(link);

    // Click the link to initiate download
    link.click();

    // Remove the link from the body
    document.body.removeChild(link);
}

// Function to convert base64 to blob
function b64toBlob(b64Data) {
    let byteCharacters = atob(b64Data);
    let byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
        let slice = byteCharacters.slice(offset, offset + 512);

        let byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        let byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }

    let blob = new Blob(byteArrays, { type: 'application/octet-stream' });
    return blob;
}