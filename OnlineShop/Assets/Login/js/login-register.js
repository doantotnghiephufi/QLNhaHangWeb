/*
 *
 * login-register modal
 * Autor: Creative Tim
 * Web-autor: creative.tim
 * Web script: http://creative-tim.com
 * 
 */
function showRegisterForm(){
    $('.loginBox').fadeOut('fast',function(){
        $('.registerBox').fadeIn('fast');
        $('.login-footer').fadeOut('fast',function(){
            $('.register-footer').fadeIn('fast');
        });
        $('.modal-title').html('Register with');
    }); 
    $('.error').removeClass('alert alert-danger').html('');
       
}
function showLoginForm(){
    $('#loginModal .registerBox').fadeOut('fast',function(){
        $('.loginBox').fadeIn('fast');
        $('.register-footer').fadeOut('fast',function(){
            $('.login-footer').fadeIn('fast');    
        });
        
        $('.modal-title').html('Login with');
    });       
     $('.error').removeClass('alert alert-danger').html(''); 
}

function openLoginModal(){
    showLoginForm();
    setTimeout(function(){
        $('#loginModal').modal('show');    
    }, 230);
    
}
function closeModal(){
    setTimeout(function(){
        $('#loginModal').modal('hide');    
    },1000);
}
function openRegisterModal(){
    showRegisterForm();
    setTimeout(function(){
        $('#loginModal').modal('show');    
    }, 230);
    
}
function Validate() {
    //$('#frmLogin').submit();
    if ($('#txtUserName').val().trim() == "" || $('#txtPassWord').val().trim()=="") {
        var message = "Vui lòng nhập tên tài khoản hoặc mật khẩu !";
        shakeModal(message);
        return false;
    }
    else
        return true;
}
function loginAjax() {
    if (Validate()) {
        var param = {};
        var userName = $('#txtUserName').val();
        var passWord = $('#txtPassWord').val();
        param.userName = userName;
        param.passWord = passWord;
        $.ajax({
            url: '/aj/account/login',
            type: 'POST',
            data: param,
            success: function (data) {
                if (data.bolIsLogin) {
                    window.location.href = data.url;
                    closeModal();
                }
                else {
                    shakeModal(data.messageError);
                }
            },
            error: function () {

            }
        });
    }

}

function shakeModal(message){
    $('#loginModal .modal-dialog').addClass('shake');
             $('.error').addClass('alert alert-danger').html(message);
             $('input[type="password"]').val('');
             setTimeout( function(){ 
                 $('#loginModal .modal-dialog').removeClass('shake');
                 $('.error').addClass('alert alert-danger').html("");
                 $('.error').removeClass('alert alert-danger');
    }, 3000 ); 
}

   