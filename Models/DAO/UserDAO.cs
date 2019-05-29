using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.DAO
{
    public class UserDAO
    {
        NhaHangDbContext db = null;
        public UserDAO()
        {
            db = new EF.NhaHangDbContext();
        }
       
        public bool isExist(string SDT)
        {
            var account = db.KhachHangs.Where(t => t.SDT == SDT).FirstOrDefault();
            if (account != null)
            {
                return true;
            }
            return false;
        }
        public KhachHang getAccountByUserName(string MaKH)
        {
            var account = db.KhachHangs.FirstOrDefault(t => t.MaKH == MaKH);
            return account;
        }
        public KhachHang getAccountBySDT(string SDT)
        {
            var account = db.KhachHangs.FirstOrDefault(t => t.SDT == SDT);
            return account;
        }
        public KhachHang getAccountByEmail(string Email)
        {
            var account = db.KhachHangs.FirstOrDefault(t => t.Email == Email);
            return account;
        }
        /// <summary>
        /// -1:Tài khoản chưa được kích hoạt/ 0: Tài khoản không tồn tại /1:Đăng nhập thành công/ 2:sai mật khẩu
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int Login(string userName,string passWord)
        {
            var result = db.KhachHangs.FirstOrDefault(t => t.SDT == userName || t.Email==userName);
            if(result != null)
            {
                if (result.PASSWORD == passWord)
                {
                    if (result.isValid == false)
                        return -1;
                    return 1;
                }
                else
                    return 2; // sai mật khẩu
            }
            else
            {
                return 0; // Tài khoản không tồn tại
            }
        }
    }
}
