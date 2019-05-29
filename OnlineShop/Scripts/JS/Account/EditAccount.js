function EditAccount() {
    var id = parseInt($('#hdAccountID').val());
    var password = $('#PassWord').val();
    var name = $('#Name').val();
    var address = $('#Address').val();
    var email = $('#Email').val();
    var phone = $('#Phone').val();
    var status = $('#Status').is(':checked');
    if ($('#Name').val().trim() == "") {
        ShowAlertify('warning', 'Vui lòng nhập tên kết quả mong đợi!');
        $("#Name").focus();
        return false;
    }
    $.ajax({
        url: '/Admin/user/EditAccountAjax',
        type: 'POST',
        data: JSON.stringify({
            id:id,
            password: password,
            name: name,
            address: address,
            email: email,
            phone: phone,
            status:status
        }),
        contentType: "application/json",
        dataType: 'json',
        success: function (data) {
            if (data.iserror) {
                ShowAlertify('danger', 'Đã có lỗi xảy ra. Vui lòng kiểm tra lại!');
            }
            else {
                ShowAlertify('success', 'Cập nhật tài khoản người dùng thành công!', 3000);
                setTimeout(function () {
                    location.href = "/Admin/user";
                }, 1000);
            }
        },
        error: function (e) {
            ShowAlertify('danger', 'Đã có lỗi xảy ra khi thao tác. Vui lòng nhấn F5 để thực hiện lại!');
        }
    });
}