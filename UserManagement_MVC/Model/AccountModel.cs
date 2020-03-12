using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_MVC.Model
{
    public class AccountModel
    {
        ///<summary>
        /// Mã của tài khoản
        ///</summary>
        public string AccountID { get; set; }
        ///<summary>
        /// Tên tài khoản
        ///</summary>
        public string Account { get; set; }
        ///<summary>
        /// Mật khẩu của tài khoản
        ///</summary>
        public string Password { get; set; }
        ///<summary>
        /// Quyền của tài khoản : 1-đầy đủ quyền, 0-chỉ đọc
        ///</summary>
        public int Roles { get; set; }
    }
}
