using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    [Serializable]
    public class SessionUserBO
    {
        public string UserID { set; get; }
        public string CMND { set; get; }
        public string Name { set; get; }
        public string PassWord { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}