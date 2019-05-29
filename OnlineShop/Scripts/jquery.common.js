(function ($) {

    $('[data-required="true"]').not($('input[type="checkbox"]')).on({

        "keyup change blur": function () {
            if ($(this).val().length == 0) {
                $(this).attr("data-valid", "1");
                var id = $(this).attr('id');
                objGlobal = new Global();
                var texterror = objGlobal.ErrorText("error" + id);
                $("#error" + id).html(texterror);

            }
            else {
                var id = $(this).attr('id');
                $(this).removeAttr("data-valid");
                $("#error" + id).html("");
            }
        }
    });

    $('[data-select="true"]').bind('change blur', function () {
        if ($.trim($(this).find('option:selected').val()) == '-1') {
            $(this).attr("data-valid", "1");
            var id = $(this).attr('id');
            objGlobal = new Global();
            var texterror = objGlobal.ErrorText("error" + id);
            $("#error" + id).html(texterror);

        }
        else {
            var id = $(this).attr('id');
            $(this).removeAttr("data-valid");
            $("#error" + id).html("");
        }
    });

    $('[data-charspecia="specia"]').bind('change blur', function () {
        var result = $(this).val();
        var regEx = new RegExp(/^[\s!@#$%^&*()?.\|/><"'ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+$/);
        for (var i = 0; i < result.length; i++) {
            if (regEx.test(result[i])) {
                $(this).attr("data-valid", "1");
                var id = $(this).attr('id');
                objGlobal = new Global();
                $("#error" + id).html("vui lòng không nhập nội dung có dấu và kí tự đặc biệt");
            }
            else {
                var id = $(this).attr('id');
                $(this).removeAttr("data-valid");
                $("#error" + id).html("");
            }

        }
    });

    $('[data-type="email"]').on({
        "keyup change blur": function () {
            objGlobal = new Global();
            if ($(this).val().trim() != '' && !objGlobal.isEmail($(this).attr('id'))) {
                $(this).attr("data-valid", "1");
                var id = $(this).attr('id');
                objGlobal = new Global();
                $("#error" + id).html("Email không đúng định dạng");
            }
            else {
                var id = $(this).attr('id');
                $(this).removeAttr("data-valid");
                $("#error" + id).html("");
            }
        }
    });


    $('[data-compare="true"]').on({
        change: function () {
            if ($(this).data("cmndcompare") != undefined) {
                iddatecurrent = $(this).attr("id");
                iddatecompare = $(this).data("cmndcompare");

                if ($("#" + iddatecurrent).val() != "" && $("#" + iddatecompare).val() != "") {
                    if ($("#" + iddatecurrent).data("typeid") == $("#" + iddatecompare).data("typeid")) {
                        if ($("#" + iddatecurrent).val() == $("#" + iddatecompare).val()) {
                            $("#" + iddatecurrent).attr("data-valid", "1");
                            $("#" + iddatecompare).attr("data-valid", "1");
                            $("#error" + iddatecurrent).html("Không được trùng Loại giấy tờ");
                            $("#error" + iddatecompare).html("Không được trùng Loại giấy tờ");
                        }
                        else {
                            var id = $(this).attr('id');
                            $("#" + iddatecurrent).removeAttr("data-valid");
                            $("#" + iddatecompare).removeAttr("data-valid");
                            $("#error" + iddatecurrent).html("");
                            $("#error" + iddatecompare).html("");
                        }
                    }
                }
            }
        }
    });

    $('[data-type="datepicker"]').on({
        "keyup blur ": function () {
            objGlobal = new Global();
            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();

            var outDate = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();
            if (DateDiff($(this).val(), outDate, 2) < 0) {
                $(this).attr("data-valid", "1");
                var id = $(this).attr('id');
                $("#error" + id).html("Ngày không lớn hơn ngày hiện tại");
            }
            else {
                var id = $(this).attr('id');
                $(this).removeAttr("data-valid");
                $("#error" + id).html("");
            }

        }
    });

    var temp = new Date();

    $('[data-type="datetimepicker"]').datetimepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '-100:-0',
        dateFormat: 'dd/mm/yy',
        timeFormat: 'HH:mm',
        maxDate: temp
    });

    $('[data-type="datepicker"]').datepicker({
        changeMonth: true,
        changeYear: true,
      //  yearRange: '-100:-0',
        dateFormat: 'dd/mm/yy',
        pickTime: false,
     //   minDate: temp
     //   maxDate: temp
    });
    $('[data-type="datepickerexcept"]').datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '-100:-0',
        dateFormat: 'dd/mm/yy',
        pickTime: false

    });
    $('[data-icon="datetime"]').click(function () {
        // alert($(this).parent().prev().val());
        $(this).parent().prev().focus();
    });
    $('[data-icon="datetimepicker"]').click(function () {
        // alert($(this).parent().prev().val());
        $(this).parent().prev().children().focus();
    });

    $('[data-type="datepickercurrentnext"]').datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '-100:-0',
        dateFormat: 'dd/mm/yy',
        pickTime: false,
        minDate: temp

    });
    $.datepicker.regional['vi'] = {
        closeText: 'Đóng',
        prevText: '&#x3c;Trước',
        nextText: 'Tiếp&#x3e;',
        currentText: 'Hôm nay',
        monthNames: ['Tháng Một', 'Tháng Hai', 'Tháng Ba', 'Tháng Tư', 'Tháng Năm', 'Tháng Sáu',
        'Tháng Bảy', 'Tháng Tám', 'Tháng Chín', 'Tháng Mười', 'Tháng Mười Một', 'Tháng Mười Hai'],
        monthNamesShort: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
        'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
        dayNames: ['Chủ Nhật', 'Thứ Hai', 'Thứ Ba', 'Thứ Tư', 'Thứ Năm', 'Thứ Sáu', 'Thứ Bảy'],
        dayNamesShort: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
        dayNamesMin: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
        weekHeader: 'Tu',
        dateFormat: 'dd/mm/yy',
        firstDay: 0,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['vi']);
    $('[data-type="number"]').bind('blur keyup keypress keydown', function () {
        objGlobal = new Global();
        var t = objGlobal.GenNumber($(this).val());
        $(this).val(t);
    });
    $('[data-type="cmnd"]').bind('blur keyup keypress keydown', function () {
        objGlobal = new Global();
        var t = objGlobal.GenNumber($(this).val());
        $(this).val(t);
        if (t.length == 9 || t.length == 12) {
            var id = $(this).attr('id');
            $("#" + id).removeAttr("data-valid");
            $("#error" + id).html("");
        }
        else {
            if (t.length > 0) {
                var id = $(this).attr('id');
                $("#" + id).attr("data-valid", "1");
                var texterror = objGlobal.ErrorText("error" + id);
                $("#error" + id).html('Số CMND phải là 9 hoặc 12 số');
            }
        }


    });
    $('[data-type="phone"]').bind('keyup keypress keydown', function () {
        objGlobal = new Global();
        //var t = objGlobal.GenNumber($(this).val());
        //$(this).val(t);
        var result = '';
        if ($(this).val() != "") {
            var value1 = $(this).val().replace(/-/g, '')
            if (value1.length == 10) {

                var value = $(this).val().replace(/-/g, '').substr(0, 10);
                if (!objGlobal.isNumber(value)) {
                    $(this).val('');
                    return;
                }
                if (value.length >= 4 && value.length < 7) {
                    result += value.substr(0, 3) + '-' + value.substr(3);
                }
                else if (value.length >= 7) {
                    result += value.substr(0, 3) + '-' + value.substr(3, 3) + '-' + value.substr(6);
                }
                else {
                    result += value;
                }
                var regEx = new RegExp(/^([0-9]{3,3})+\-([0-9]{3,3})+\-([0-9]{4,4})$/);
                if (regEx.test(result.trim())) {
                    var id = $(this).attr('id');
                    $("#" + id).removeAttr("data-valid");
                    $("#error" + id).html("");
                }
                else {
                    var id = $(this).attr('id');
                    $("#" + id).attr("data-valid", "1");
                    $("#error" + id).html('Điện thoại không đúng định dạng');
                }
            }
            else {

                var value = $(this).val().replace(/-/g, '').substr(0, 11);
                if (!objGlobal.isNumber(value)) {
                    $(this).val('');
                    return;
                }
                if (value.length >= 4 && value.length < 7) {
                    result += value.substr(0, 3) + '-' + value.substr(3);
                }
                else if (value.length >= 7) {
                    result += value.substr(0, 3) + '-' + value.substr(3, 3) + '-' + value.substr(6);
                }
                else {
                    result += value;
                }
                var regEx = new RegExp(/^([0-9]{3,3})+\-([0-9]{3,3})+\-([0-9]{5,5})$/);
                if (regEx.test(result.trim())) {
                    var id = $(this).attr('id');
                    $("#error" + id).html("");
                }
                else {
                    var id = $(this).attr('id');
                    $("#" + id).attr("data-valid", "1");
                    $("#error" + id).html('Điện thoại không đúng định dạng');
                }
            }
        }
        else {
            var id = $(this).attr('id');
            $("#" + id).removeAttr("data-valid");
            $("#error" + id).html("");
        }

        $(this).val(result);

    });

    $('[data-special="special"]').keyup(function (e) {
        objGlobal = new Global();
        var regEx = objGlobal.isSpecialCharacter($(this).val());
        $(this).val(regEx);
    });

})(jQuery);
String.prototype.replaceAll = function (strTarget, // The substring you want to replace
    strSubString // The string you want to replace in.
    ) {
    var strText = this;
    var intIndexOfMatch = strText.indexOf(strTarget);
    while (intIndexOfMatch != -1) {
        strText = strText.replace(strTarget, strSubString);
        intIndexOfMatch = strText.indexOf(strTarget);
    }
    return (strText);
}
Array.prototype.contains = function (obj) {
    var i = this.length;
    while (i--) {
        if (this[i] === obj) {
            return true;
        }
    }
    return false;
}

var objAjax = null;
function Global() { }
Global.prototype.callBack = '';
Global.prototype.isHandlerCallBack = false;
Global.prototype.aJaxCall = function (url, type, dataIni, beginFunc, funcCallBack, funcError) {
  
    objAjax = null;
    objGlobal = new Global();
    if (beginFunc == undefined || beginFunc == null)
        beginFunc = function () {
            //return objGlobal.showLoading();
        };
    if (funcCallBack == undefined || funcCallBack == null)
        funcCallBack = function () {
            //return objGlobal.closeMess();
        };

    objAjax = $.ajax({
        type: type,
        url: url,
        //async: false,
        cache: false,
        traditional: true,
        beginSend: beginFunc(),
        data: dataIni,
        //dataType: "json",
        success: function (arg) { funcCallBack(arg); },
        error: function () {
            if (funcError != undefined && funcError != null)
                funcError();
        },
        complete: function (e, xhr, settings) {
            if (e.status === 302) {

            }
        }
    });
}
Global.prototype.showLoading = function () {
    if ($('#divLoading'))
        $('#divLoading').show();
}
Global.prototype.hideLoading = function () {
    if ($('#divLoading'))
        $('#divLoading').hide();
}

Global.prototype.isNumber = function (strNumber) {
    var regEx = new RegExp(/^ *[0-9]+ *$/);
    if (strNumber.trim().length > 0 && regEx.test(strNumber.trim())) {
        return true;
    }
    else
        return false;
}

Global.prototype.isMobile = function (strNumber) {
    var regEx = new RegExp(/^ *[0-9]+ *$/);
    if (strNumber.trim().length > 9 && regEx.test(strNumber.trim())) {
        return true;
    }
    else
        return false;
}
Global.prototype.GenNumber = function (str) {
    for (var i = 0; i < str.length; i++) {
        var temp = str.substring(i, i + 1);
        if (!(temp >= 0 && temp <= 9)) {
            return str.substring(0, str.length - 1);
        }
        if (temp == " ")
            return str.substring(0, i);
    }
    return str;
}
Global.prototype.IsCMND = function (strNumber) {
    var regEx = new RegExp(/^ *[0-9]+ *$/);
    if (strNumber.trim().length >= 9 && strNumber.trim().length < 12 && regEx.test(strNumber.trim())) {
        return true;
    }
    else
        return false;
}

/*kiểm tra chuỗi có phải là Email hay không */
Global.prototype.isEmail = function (IDctrl) {
    var regEx = new RegExp(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/);
    if ($("#" + IDctrl).length > 0) {
        var str = $("#" + IDctrl).val();
        if (regEx.test(str.trim())) {
            return true;
        }
    }
    return false;
}

var popupStatus = 0; // set value
Global.prototype.LoadPopupAlert = function () {

    if (popupStatus == 0) { // if value is 0, show popup
        $("#toPopup").fadeIn(500); // fadein popup div
        $("#backgroundPopup").css("opacity", "0.7"); // css opacity, supports IE7, IE8
        $("#backgroundPopup").fadeIn(0001);
        popupStatus = 1; // and set value to 1
    }
}
Global.prototype.DisablePopupAlert = function () {
    if (popupStatus == 1) { // if value is 1, close popup
        $("#toPopup").fadeOut("normal");
        $("#backgroundPopup").fadeOut("normal");
        popupStatus = 0;  // and set value to 0
    }
}
Global.prototype.ErrorText = function (text) {
    switch (text) {
        case "errorTeachingSessionid": return "Chọn buổi học"; break; 
        case "errorOffSchoolReasonid": return "Chọn lý do nghỉ học"; break;
        case "errorerrorOffSchoolReasonNote": return "Chưa nhập ghi chú"; break;
        case "errorUserName": return "Chưa nhập tên đăng nhập"; break;
        case "errorPassWord": return "Chưa nhập mật khẩu"; break;
        case "errorOffSchoolReasonNote": return "Không được nhập mã HTML"; break;
    }
}

/*kiểm tra ký tự đặc biệt */
Global.prototype.isSpecialCharacter = function (str) {
    var regEx = str.replace(/[`~!@#$%^&*()_|+\-=?;:",.<>\{\}\[\]\\\/]/g, "");
    return regEx;
}

function Cookie() { }
Cookie.prototype.set = function (key, value, expiredays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + expiredays);
    var myDate = new Date();
    myDate.setMonth(myDate.getMonth() + 12);
    document.cookie = key + "=" + value + ((expiredays == null) ? "; expires=" + myDate + ";path=/" : "; expires=" + exdate.toUTCString() + ";path=/");
}

Cookie.prototype.get = function (key) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(key + "=");
        if (c_start != -1) {
            c_start = c_start + key.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length
            return document.cookie.substring(c_start, c_end);
        }
    }
    return "";
}

Cookie.prototype.update = function (key, NewValue) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(key + "=");
        if (c_start != -1) {
            c_start = c_start + key.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length
            var value = document.cookie.substring(c_start, c_end);
            document.cookie.replace(value, NewValue);
            var CookieName = key + "=";
            var CookieAfter = document.cookie.substring(c_end, document.cookie.length);
            document.cookie = CookieName + NewValue + CookieAfter;
        }
    }
}

Cookie.prototype.clear = function (key) {
    Cookie.prototype.set(key, "", -1);
}


function DateDiff(startDate, EndDate, type) {
    var sDate, eDate;
    if (type == 1) {
        sDate = new Date(startDate);
        eDate = new Date(startDate);
    }
    else if (type == 2) {
        var arrSDate = startDate.split("/");
        var arrEDate = EndDate.split("/");
        sDate = new Date(arrSDate[1] + "/" + arrSDate[0] + "/" + arrSDate[2]);
        eDate = new Date(arrEDate[1] + "/" + arrEDate[0] + "/" + arrEDate[2]);
    }
    return (eDate.valueOf() - sDate.valueOf()) / 1000 / 3600 / 24;
};

function RemoveScript(c) {
    r = c.replace(/(<script(.|\n)*<\/script>)|(&lt;script(.|\n)*&lt;\/script&gt;)/gi, "");
    return r;
}

//chi cho nhap so
Global.prototype.isPressNumber = function (str) {
    var regEx = str.replace(/[a-zA-Z `~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/g, "");
    return regEx;
}
//chi nhap chu va số the
Global.prototype.isCharacNumber = function (str) {
    var regEx = str.replace(/[ `~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/g, "");
    return regEx;
}

Global.prototype.IsRemoveUnicode = function (str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "");
    str = str.replace(/đ/g, "");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, " ");

    //str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1- 
    //str = str.replace(/^\-+|\-+$/g, "");
    return str;
}

function betweenDiff2(startDate, endDte) {
    dd = startDate.substr(0, 2).split("/");
    mm = startDate.substr(3, 2).split("/");
    yy = startDate.substr(6, 5).trim();

    ddd = endDte.substr(0, 2).split("/");
    mmm = endDte.substr(3, 2).split("/");
    yyy = endDte.substr(6, 5).trim();

    if (yy > yyy) {
        return true;
    }
    else if (String(yyy) == String(yy)) {
        if (mm > mmm) {
            return true;
        }
        else if (String(mmm) == String(mm)) {
            if (dd > ddd) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }

}


function fmDateTime(__this) {
    var y = new Date();
    var fdate = $(__this).val();
   
    //"20/09/1989 20:09"
    dd = fdate.substr(0, 2).split("_");
    mm = fdate.substr(3, 2).split("_");
    yy = fdate.substr(6, 5).trim();
    hh = fdate.substr(11, 2);
    ss = fdate.substr(14, 2);
    if (hh[0] == "") { hh = "0" + hh[1]; if (hh == "00") { hh = "01"; } }
    if (hh[1] == "") { hh = "0" + hh[0]; if (hh == "00") { hh = "01"; } }
    if (ss[0] == "") { ss = "0" + ss[1]; if (ss == "00") { ss = "01"; } }
    if (ss[1] == "") { ss = "0" + hh[0]; if (ss == "00") { ss = "01"; } }
    if (dd[0] == "") { dd = "0" + dd[1]; if (dd == "00") { dd = "01"; } }
    if (dd[1] == "") { dd = "0" + dd[0]; if (dd == "00") { dd = "01"; } }
    if (mm[0] == "") { mm = "0" + mm[1]; if (mm == "00") { mm = "01"; } }
    if (mm[1] == "") { mm = "0" + mm[0]; if (mm == "00") { mm = "01"; } }
    if (dd == "00") { dd = "01"; }
    else {
        if (parseInt(yy) == y.getFullYear()) {
            if (parseInt(dd) > getDate(y.getDate()))
                dd = getDate(y.getDate());
        }
    }
    if (mm == "00") {
        mm = "01";
    }
    else {
        if (parseInt(yy) == y.getFullYear()) {
            if (parseInt(mm) > getMonth(y.getMonth() + 1))
                mm = getMonth(y.getMonth() + 1);
        }
    }
    if (dd > 31) { dd = "01"; }
    if (mm > 12) { mm = "01"; }
    else {
        var arr_month30 = ["04", "06", "09", "11"];
        var arr_month31 = ["01", "03", "05", "07", "08", "10", "12"];
        for (var i = 0; i < arr_month30.length; i++) {
            if (mm == arr_month30[i] && parseInt(dd) > 30)
                dd = "01";
        }
        for (var j = 0; j < arr_month31.length; j++) {
            if (mm == arr_month31[i] && parseInt(dd) > 31)
                dd = "01";
        }
        if (mm == "02") {
            if (leap_year(yy)) {
                if (dd > 29) { dd = "01"; }
            } else {
                if (dd > 28) { dd = "01"; }
            }
        }
    }
    if (parseInt(hh) > 24) {
        hh = "00";
    }
    if (parseInt(ss) > 60) {
        ss = "00";
    }

    if (parseInt(yy) < 1700) { yy = "1700"; } else {
        if (parseInt(yy) > y.getFullYear()) { yy = y.getFullYear(); }
    }

    fdate = dd + "/" + mm + "/" + yy + " " + hh + ":" + ss;
    $(__this).val(fdate);
}

