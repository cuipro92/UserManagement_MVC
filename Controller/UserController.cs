using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement_MVC.Model;

namespace UserManagement_MVC.Controller
{
    class UserController
    {
        UserModel user = new UserModel();
        public DataTable LoadData()
        {
            DataTable dt;
            string sql = "SELECT * FROM user";
            dt = DBConnect.CreateTable(sql);
            return dt;
        }

        public bool InsertUser(string userID, string userName, string birthday, string address, string email, string gender)
        {
            bool rs = false;
            String sql = "INSERT INTO user (UserID, UserName, Birthday, Address, Email, Gender) " +
                "VALUES ('" + userID + "' , '" + userName + "', '" + birthday + "', '" + address + "', '" + email + "', '" + gender + "')";
            if (DBConnect.ExecuteNonQuery(sql) > 0)
            {
                rs = true;
            }
            return rs;
        }

        public bool DeleteUser(string userID)
        {
            bool rs = false;
            String sql = " DELETE FROM user WHERE UserID = '" + userID + "'";
            if (DBConnect.ExecuteNonQuery(sql) > 0)
            {
                rs = true;
            }
            return rs;
        }

        public bool UpdateUser(string userID, string userName, string birthday, string address, string email, string gender)
        {
            bool rs = false;
            String sql = "UPDATE user " +
                "SET UserName='" + userName + "', Birthday = '" + birthday + "',Address = '" + address + "'" +
                ", Email= '" + email + "', Gender = '" + gender + "' WHERE UserID = '" + userID + "'";
            if (DBConnect.ExecuteNonQuery(sql) > 0)
            {
                rs = true;
            }
            return rs;
        }

        public DataTable LoadDateCondition(string text)
        {
            DataTable dt;
            string sql = "SELECT * FROM user WHERE userID LIKE '%" + text + "%' or " +
                "UserName LIKE '%" + text + "%' or " +
                "Birthday LIKE '%" + text + "%' or " +
                "Address LIKE '%" + text + "%' or " +
                "Email LIKE '%" + text + "%' or " +
                "Gender LIKE '%" + text + "%'";
            dt = DBConnect.CreateTable(sql);
            return dt;
        }
    }
}
