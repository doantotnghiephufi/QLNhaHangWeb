var itemperpage = 2;
var isloadserver = 0;
var UserController = {
    init: function () {
        UserController.loadData();
        UserController.registerEvent();
    },
    registerEvent: function () {
        $("#tblData tr[data-isdata='1']").dblclick(function () {

            var id = $(this).attr('data-userID');

            window.open('/Admin/user/edit/' + id);
        });
        UserController.initTableClick();
    },
    loadData: function () {
        param = {};
        param.intPageIndex = 0;
        param.intPageSize = itemperpage;
        $.ajax({
            url: '/Admin/User/LoadData',
            type: 'POST',
            data: param,
            dataType: 'json',
            success: function (response) {
                if (!response.iserror) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            UserName: item.UserName,
                            Name: item.Name,
                            Email: item.Email,
                            Address: item.Address,
                            Phone: item.Phone,
                            Status: item.Status == true ? "<span class=\"label label-success\">Active</span>" : "<span class=\"label label-danger\">Locked</span>",
                        });
                        
                    });
                    $('#tblData').html(html);
                    var optInit = getOptionsFrom_loadData();
                    if (parseInt(response.totalRow) > parseInt(itemperpage)) {
                        $("#PaginationManagePupil").pagination(response.totalRow, optInit);
                        $("#PaginationManagePupil").show();
                    }
                    else {
                        $("#PaginationManagePupil").hide();
                    }
                    UserController.registerEvent();
                }
                else
                    ShowAlertify('danger', 'Đã có lỗi xảy ra! Vui lòng kiểm tra lại', 3000);
            }
        })
    },
    initTableClick: function () {
        // cập nhật
        $('span[data-name="EditAccount"]').click(function () {
            var id = $(this).data('id');
            window.open('/Admin/user/edit/' + id);
        });
        //Xóa
        $('span[data-name="DeleteAccount"]').click(function () {
            var id = $(this).data('id');
            $('#txtNotification').html('Bạn có chắc muốn xóa Tài khoản đã chọn?');
            $('#modalComfirmDeleteRequest').modal('toggle');
            _thisRequest = this;
        });
    }
}
UserController.init();
function getOptionsFrom_loadData() {
    var opt = { callback: pageSelectCallback_searchManageAccount };
    return opt;
}
function pageSelectCallback_searchManageAccount(page_index, jq) {
    if (isloadserver == 0) {
        param = {};
        param.intPageIndex = page_index;
        param.intPageSize = itemperpage;
        $.ajax({
            url: '/Admin/User/LoadData',
            data:param,
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (!response.iserror) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            UserName: item.UserName,
                            Name: item.Name,
                            Email: item.Email,
                            Address: item.Address,
                            Phone: item.Phone,
                            Status: item.Status == true ? "<span class=\"label label-success\">Active</span>" : "<span class=\"label label-danger\">Locked</span>",
                        });

                    });
                    isloadserver = 0;
                    $('#tblData').html(html);
                    if (parseInt(response.totalRow) > parseInt(itemperpage)) {
                        $("#PaginationManagePupil").show();
                    }
                    else {
                        $("#PaginationManagePupil").hide();
                    };
                    //$('[data-type="tooltip"]').tooltip();
                    //$('[data-toggle="tooltip"]').tooltip({
                    //    html: true,
                    //    content: function () {
                    //        return $(this).attr('title');
                    //    }
                    //});
                    UserController.registerEvent();
                }
                else
                    ShowAlertify('danger', 'Đã có lỗi xảy ra! Vui lòng kiểm tra lại', 3000);
            }
        });
    }
    isloadserver = 0;
    return false;
}
function AddAccount() {
    window.open('/Admin/user/create');
}
function DeleteAccount() {
        param: { };
        var id = $('#dongUser').data('id');
        param.id = id;
        $.ajax({
            url: '/aj/Account/Login',
            type: 'POST',
            data: param,
            dataType: 'json',
            success: function (response) {
                if (response.iserror) {
                    ShowAlertify('danger', 'Có lỗi xảy ra, Vui lòng thử lại sau!');
                } else {
                    if (response.result== 1)
                    {
                        ShowAlertify('success', 'Xóa loại điểm thành công!', 3000);
                        UserController.loadData();
                    }
                    else
                        ShowAlertify('warning', 'Không tìm thấy User', 3000);
                }
                $('#modalComfirmDeleteRequest').modal('toggle');
            },
            error: function (e) {
                //hideLoadingInGrid('#modalComfirmDeleteRequest', '#btnConfirm');
                ShowAlertify('danger', 'Đã có lỗi xảy ra khi thao tác. Vui lòng nhấn F5 để thực hiện lại!');

            }
        });
}