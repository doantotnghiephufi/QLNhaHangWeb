
function CreateAccount() {
    var username = ($('#USERNAME').val());
    var password = $('#PASSWORD').val();
    var name = $('#NAME').val();
    var address = $('#ADDRESS').val();
    var email = $('#EMAIL').val();
    var phone = $('#PHONE').val();
    //var status = $('#Status').is(':checked');
    if ($('#NAME').val().trim() == "") {
        ShowAlertify('warning', 'Vui lòng nhập tên kết quả mong đợi!');
        $("#NAME").focus();
        return false;
    }
        var acc = {
            UserName: username,
            PassWord: password,
            Name: name,
            Address: address,
            Email: email,
            Phone: phone,
            Status: status
        };
        $.ajax({
            url: '/Admin/aj/User/CreateUserAjax',
            type: 'POST',
            data: {
                objAccount: JSON.stringify(acc)
            },
            dataType: 'json',
            success: function (data) {
                if (data.iserror) {
                    ShowAlertify('danger', 'Đã có lỗi xảy ra. Vui lòng kiểm tra lại!');
                }
                else {
                    if (data.isExistUser) {
                        ShowAlertify('warning', 'Tài khoản đã tồn tại. Vui lòng kiểm tra lại!')
                        $('#UserName').focus();
                        return false;
                    }
                    else {
                        ShowAlertify('success', 'Thêm tài khoản thành công!', 3000);
                        setTimeout(function () {
                            location.href = "#";
                        }, 3000);
                    }

                }
            },
            error: function (e) {
                ShowAlertify('danger', 'Đã có lỗi xảy ra khi thao tác. Vui lòng nhấn F5 để thực hiện lại!');
            }
        });
}