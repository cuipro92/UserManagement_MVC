using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_MVC.Model
{
   

    class DBConnect
    {
        public static MySqlConnection conn;
        public static MySqlCommand cmd;
        public static DataTable dt; 
        public static MySqlDataAdapter da;
        public static String config = "Server=localhost;Database=user_management;user=root;Pwd=123456;SslMode=none;Character Set=UTF8";
        
        public static DataTable CreateTable(string sql)
        {
            conn = new MySqlConnection(config);
            conn.Open();
            da = new MySqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static int ExecuteNonQuery(string sql)
        {
            int rs = 0;
            try
            {
                conn = new MySqlConnection(config);
                conn.Open();
                cmd = new MySqlCommand(sql,conn);
                rs = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {

            }
            return rs;
        }
    }
}
