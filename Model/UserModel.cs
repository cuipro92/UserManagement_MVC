using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_MVC.Model
{
    class UserModel
    {
        ///<summary>
        /// Mã của người dùng
        ///</summary>
        public static string UserID { get; set; }
        ///<summary>
        /// Tên người dùng
        ///</summary>
        public static string UserName { get; set; }
        ///<summary>
        /// Ngày sinh
        ///</summary>
        public static DateTime Birthday { get; set; }
        ///<summary>
        /// Địa chỉ
        ///</summary>
        public static string Address { get; set; }
        ///<summary>
        /// Email
        ///</summary>
        public static string Email { get; set; }
        ///<summary>
        /// Giới tính
        ///</summary>
        public static string Gender { get; set; }

    }
}
