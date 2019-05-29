$(document).ready(function () {

    $("#back-top").hide();
    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#back-top').fadeIn();
            } else {
                $('#back-top').fadeOut();
            }
        });
        $('#back-top').click(function () {
            $('body,html').animate({
                scrollTop: 0
            }, 800);
            return false;
        });
    });

    $('#slider').nivoSlider();
    $('.dropdown-toggle').prop('disabled', true);

    $('ul.nav li.dropdown').hover(function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeIn(500);
    }, function () {
        $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
    });

    loadGallery(true, 'a.thumbnail');
    function disableButtons(counter_max, counter_current) {
        $('#show-previous-image, #show-next-image').show();
        if (counter_max == counter_current) {
            $('#show-next-image').hide();
        } else if (counter_current == 1) {
            $('#show-previous-image').hide();
        }
    }

    function loadGallery(setIDs, setClickAttr) {
        var current_image,
			selector,
			counter = 0;

        $('#show-next-image, #show-previous-image').click(function () {
            if ($(this).attr('id') == 'show-previous-image') {
                current_image--;
            } else {
                current_image++;
            }

            selector = $('[data-image-id="' + current_image + '"]');
            updateGallery(selector);
        });

        function updateGallery(selector) {
            var $sel = selector;
            current_image = $sel.data('image-id');
            $('#image-gallery-caption').text($sel.data('caption'));
            $('#image-gallery-title').text($sel.data('title'));
            $('#image-gallery-image').attr('src', $sel.data('image'));
            disableButtons(counter, $sel.data('image-id'));
        }

        if (setIDs == true) {
            $('[data-image-id]').each(function () {
                counter++;
                $(this).attr('data-image-id', counter);
            });
        }
        $(setClickAttr).on('click', function () {
            updateGallery($(this));
        });
    }

});

$(window).scroll(function () {
    if ($(this).scrollTop() > 515) {
        $('#menu-index').addClass("fix-nav");
    } else {
        $('#menu-index').removeClass("fix-nav");
    }
});


var timer = null;
function ShowAlertify(type, mesage, timing) {
    if (timing === undefined)
        timing = 3000;
    if (timer != null) {
        clearTimeout(timer);
    }
    var strType = "<button onclick='CloseAlert(this);' type='button' class='close'  aria-label='Close'><span>×</span></button>";
    strType += mesage;
    $('.alert-top-setting > .alert-' + type + ' > .cont').html(strType);
    $('.alert-top-setting > .alert-' + type).show();
    //$('.alert-top-setting').show();

    timer = setTimeout(function () {
        $('.alert-top-setting > .alert-' + type).hide();
    }, timing);

}

function CloseAlert(_this) {
    $(_this).parent().parent().hide();
}

//hàm giải mã ngày khi đưa object từ js lên server
function encodeDate(date) {
    var dateString = date.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    return month + "/" + day + "/" + year;
}

var m_strUpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
var m_strLowerCase = "abcdefghijklmnopqrstuvwxyz";
var m_strNumber = "0123456789";
var m_strCharacters = "!@#$%^&*?_~";
