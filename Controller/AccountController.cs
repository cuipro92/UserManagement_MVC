using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_MVC.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace UserManagement_MVC.Controller
{
    class AccountController
    {
        AccountModel account = new AccountModel();
        public static string acc = "";
        public static string pass = "";
        public static int roles = 0;
        public DataTable LoadData()
        {
            DataTable dt;
            string sql = "select * from account";
            dt = DBConnect.CreateTable(sql);
            return dt;
        }

        public bool InsertAccount(string accountID, string account, string password, int roles)
        {
            bool rs = false;
            String sql = "INSERT INTO account (AccountID, Account, Password, Roles) " +
                "VALUES ('" + accountID + "' , '" + account + "', '" + password + "', '" + roles + "')";
            if (DBConnect.ExecuteNonQuery(sql) > 0)
            {
                rs = true;
            }
            return rs;
        }

        public bool DeleteAccount(string accountID)
        {
            bool rs = false;
            String sql = " DELETE FROM account WHERE AccountID = '" + accountID + "'";
            if (DBConnect.ExecuteNonQuery(sql) > 0)
            {
                rs = true;
            }
            return rs;
        }

        public bool UpdateAccount(string accountID, string account, string password, int roles)
        {
            bool rs = false;
            String sql = "UPDATE account " +
                "SET Account = '" + account + "', Password='" + password + "'" +
                ", Roles= '" + roles + "'" + "WHERE AccountID = '" + accountID + "'";
            if (DBConnect.ExecuteNonQuery(sql) > 0)
            {
                rs = true;
            }
            return rs;
        }

        public bool CheckLogin(string account, string password)
        {
            bool rs = false;
            String sql = "SELECT* FROM account where Account = '" + account + "' AND Password = '" + password + "'";

            MySqlConnection conn = new MySqlConnection(DBConnect.config);
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                acc = dr["Account"].ToString();
                pass = dr["Password"].ToString();
                roles = int.Parse(dr["Roles"].ToString());
                rs = true;
            }
            return rs;
        }
    }
}
