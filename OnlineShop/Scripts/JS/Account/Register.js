function Continue() {
    var url = $('#hdUrlReferrer').val();
    if (url === "") {
        window.location.href = '/';
    } else {
        window.location.href = url;
    }
}