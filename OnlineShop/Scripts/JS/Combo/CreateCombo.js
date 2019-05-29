$(function () {
    $('#btnUpload').click(function () {
        $('#fileUpload').trigger('click');
    });
    // bắt sự kiện change data của fileUpload
    $('#fileUpload').change(function () {
        //Kiểm tra trình duyệt có hỗ trợ FormData hay k?
        if (window.FormData !== undefined) {
            //lấy dứ liệu trên fileUpload
            var fileUpload = $('#fileUpload').get(0);
            var files = fileUpload.files;
            var formData = new FormData();
            //đưa dữ liệu vào form
            formData.append('file', files[0]);
            $.ajax({
                type: 'POST',
                url: '/admin/category/CreateComboAjax',
                contentType: false,
                processData: false,
                data: formData,
                success: function (result) {

                },
                error: function () {
                    ShowAlertify('danger','Có lỗi xảy ra. Vui lòng kiểm tra lại!')
                }
            });
        }
    });
});