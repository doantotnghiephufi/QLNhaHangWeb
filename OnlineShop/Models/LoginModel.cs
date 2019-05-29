using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [DisplayName("Số điện thoại")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Vui lòng nhập số điện thoại")]
        [RegularExpression("(\\+84|0)\\d{9,10}", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string UserName { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string PassWord { set; get; }
        
        public bool RememberMe { set; get; }
    }
}