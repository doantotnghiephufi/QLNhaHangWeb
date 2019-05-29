using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class KhachHangModel
    {
        
        public string MaKH { get; set; }
        [StringLength(50),Required(ErrorMessage ="Họ và Tên không được để trống.")]
        public string TenKH { get; set; }
        [StringLength(9)]

        [RegularExpression("[0-9]{9}", ErrorMessage = "Số Chứng minh thư không hợp lệ.")]
        public string CMND { get; set; }
        [RegularExpression("(\\+84|0)\\d{9,10}", ErrorMessage = "Số điện thoại không hợp lệ."),Required(ErrorMessage ="Số điện thoại không được để trống.")]
        public string SDT { get; set; }
        
        public string DiaChiKH { get; set; }

        public double? TichLuy { get; set; }

        public DateTime? NgayTaoTT { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được để trống.")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 kí tự")]
        public string PassWord { get; set; }
        [Compare("PassWord",ErrorMessage ="Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassWord { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [RegularExpression("^[a-z0-9]+@([-a-z0-9]+\\.)+[a-z]{2,5}$", ErrorMessage = "Địa chỉ Email không hợp lệ.")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}