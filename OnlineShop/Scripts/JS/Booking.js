$(document).ready(function () {
    var date_input = $('input[name="date"]'); //our date input has the name "date"
    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    var options = {
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    };
    //refresh combo khu vuc
    
    date_input.datepicker(options);
    $('#txtSoNguoi').change(function () {
        var maLoaiKV = $('#cboLoaiKhuvuc').val();
        var SLNguoi = $('#txtSoNguoi').val();
        if (maLoaiKV == -1) {
            $('#txtErMessage').html("Vui lòng chọn Loại Khu vực");
            return false;
        }
        $.ajax({
            url: '/aj/User/LoadKhuVucAjax',
            type: 'POST',
            data: { maLoaiKV: maLoaiKV, SLnguoi: SLNguoi },
            success: function (data) {
                $('#cboKhuvuc').html(data);
            },
            error: function () {

            }
        })
    })
    $('#cboLoaiKhuvuc').change(function () {
        var maLoaiKV = $(this).val();
        var SLNguoi = $('#txtSoNguoi').val();
        if (maLoaiKV == -1) {
            $('#txtErMessage').html("Vui lòng chọn Loại Khu vực");
            return false;
        }
        $.ajax({
            url: '/aj/User/LoadKhuVucAjax',
            type: 'POST',
            data: { maLoaiKV: maLoaiKV,SLnguoi: SLNguoi },
            success: function (data) {
                $('#cboKhuvuc').html(data);
            },
            error: function () {

            }
        })
    })
    $('#cboKhuvuc').change(function () {    
        if (isValid()) {
            //$('#txtErMessage').html('');
            loadVitri();
        }
    })
    
});

function loadVitri() {
    var param = {};
    var NgayDen = $('#txtNgayDen').val();
    var GioDen = $('#txtGioDen').val();
    var maKV = $('#cboKhuvuc').val();

    param.NgayDen = NgayDen;
    param.GioDen = GioDen;
    param.MaKhuVuc = maKV;
    $.ajax({
        url: '/aj/User/LoadVitriAjax',
        type: 'POST',
        data: param,
        success: function (data) {
            $('#cboVitri').html(data);
        },
        error: function () {

        }
    })
}
function closeModalBooking() {
    setTimeout(function () {
        $('#AlertModal').modal('hide');
    }, 500);
}
function showLogin() {
    openLoginModal();
    closeModalBooking();
}
function showRegister() {
    openRegisterModal();
    closeModalBooking();
}
function bookingnow() {
    if (isValid()) {
        
        $('#txtErMessage').html('');
        var NgayDen = $('#txtNgayDen').val();
        var GioDen = $('#txtGioDen').val();
        var SLNguoi = $('#txtSoNguoi').val();
        
        var UserName=$('#hdUserName').val();
        if (UserName === "") { //chưa login
            setTimeout(function () {
                $('#AlertModal').modal('show');
            }, 500);
            return false;
        }
        else {
            $('#tvSoNguoiDenDesktop').html($('#txtSoNguoi').val()+" người")
            $('#tvNgayDenDesktop').html($('#txtNgayDen').val())
            $('#tvGioDenDesktop').html($('#txtGioDen').val())
            setTimeout(function () {
                $('#ConfirmModal').modal('show');
            }, 500);
        }
    }
}
// Chuyển chuỗi kí tự (string) sang đối tượng Date()
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1]-1, mdy[0]);
}
//Chuyển chuổi giờ sang giây
function parseTime(str) {
    var mdy = str.split(':');
    return mdy[0] * 3600 + mdy[1] * 60;
}
function isValid() {
    var NgayDen = parseDate($('#txtNgayDen').val());
    var date = new Date();
    var daynow = date.getDate();
    var monthnow = date.getMonth();
    var yearnow = date.getFullYear();
    var datenow = new Date(yearnow, monthnow, daynow);

    var gioden = parseTime($('#txtGioDen').val());
    var timenow = (date.getHours() * 3600) + (date.getMinutes() * 60) + (date.getMilliseconds());
    var thoigiancho = gioden - (timenow + (30 * 60));// tính thời gian đặt trước 

    if (NgayDen.getTime() < datenow.getTime()) {
        $('#txtErMessage').html("Ngày đến không hợp lệ!");
        return false;
    }
    else if (NgayDen.getTime() == datenow.getTime()) {
        if (gioden < timenow) {
            $('#txtErMessage').html("Giờ đến không hợp lệ!");
            return false;
        }
            //Cảnh báo người dùng là nên đặt trước 30p 
        else if (thoigiancho <30) {
            $('#txtErMessage').html("Nên đặt trước khi đến từ 30 phút!");
            return false;
        }
    }
    return true;
}
function successBooking() {
    $('#ConfirmModal').modal('hide');
    var NgayDen = $('#txtNgayDen').val();
    var GioDen = $('#txtGioDen').val();
    var SLNguoi = $('#txtSoNguoi').val();
    var maVitri = $('#cboVitri').val();

    var param = {};
    param.NgayDen = NgayDen;
    param.GioDen = GioDen;
    param.SLnguoi = parseInt(SLNguoi);
    param.maVitri = maVitri;

    $.ajax({
        url: '/aj/User/BookingAjax',
        type: 'POST',
        data: param,
        success: function (data) {
            if (!data.error) {
                $('#alert-success').html(data.genHTMLAlert);
                $('#AlertModal').modal('show');
            }
        },
        error: function () {

        }
    });
}
function cancelBooking() {
        $('#ConfirmModal').modal('hide');
}