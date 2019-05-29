$(document).ready(function () {
    $('#btnUpload').click(function () {
        $('#fileUpload').trigger('click');
    })
    // bắt sự kiện change data của fileupload
    $('#fileUpload').change(function () {
        //lấy dữ liệu trên fileUpload
        var fileUpload = $('#fileUpload').get(0);
        var files = fileUpload.files;
        var formData = new FormData();
        formData.append('file', files[0]);
        upLoadFiles(formData);
    });


    $('#btnAdd').click(function () {
        //kiểm tra trình duyệt có hỗ trợ FormData
        if (window.FormData != undefined) {
            var tenmonan = $('#TenMonAn').val();
            if (tenmonan === "") {
                ShowAlertify('warning', 'Vui lòng nhập Tên món ăn!');
                $('#TenMonAn').focus();
                return false;
            }
            //lấy dữ liệu trên fileUpload
            var fileUpload = $('#fileUpload').get(0);
            var files = fileUpload.files;
            if (files == undefined || files.length == 0) {
                ShowAlertify('warning', 'Vui lòng chọn hình ảnh!');
                $('#btnUpload').focus();
                return false;
            }
            //Tạo đối tượng formdata
            var formdata = new FormData();
            
            var loaimonanID = $('#cboLoaiMonAn').val();
            if (loaimonanID === "-1") {
                ShowAlertify('warning', 'Vui lòng chọn loại món ăn!');
                $('#cboLoaiMonAn').focus();
                return false;
            }
            //đưa dữ liệu vào form
            formdata.append('file', files[0]);
            formdata.append('tenmonan', tenmonan);
            formdata.append('loaimonanID', parseInt(loaimonanID));
            $.ajax({
                type: 'POST',
                url: '/Admin/aj/Food/CreateFoodAjax',
                contentType: false, //khong header
                processData: false, //không xử lý dữ liệu
                data: formdata,
                success: function (data) {
                    if(data.iserror)
                    {
                        ShowAlertify('danger', data.messageError);
                    }
                    else {
                        if(data.isExist)
                        {
                            ShowAlertify('danger','Món ăn đã tồn lại. Xin vui lòng kiểm tra lại!')
                        }
                        else {
                            ShowAlertify('success', 'Thêm mới món ăn thành công!');

                        }
                            
                    }
                },
                error: function (e) {
                    ShowAlertify('danger', 'Đã có lỗi xảy ra khi thao tác. Vui lòng nhấn F5 để thực hiện lại!');
                }
            });
        }
    })
});
function upLoadFiles(formData) {
    $.ajax({
        url: '/Admin/aj/Food/UploadFile',
        type: 'POST',
        contentType: false,
        processData:false,
        data: formData,
        success: function (data) {
            $('#HinhAnh').attr('src', data.urlImg);
            $('#txtTenHinh').text(data.name);
        },
        error: function (e) {
            ShowAlertify('danger', 'Đã có lỗi xảy ra khi thao tác Upload. Vui lòng nhấn F5 để thực hiện lại!');
        }
    });
}