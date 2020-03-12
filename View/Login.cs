using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement_MVC.Controller;

namespace UserManagement_MVC.View
{
    public partial class frmLogin : Form
    {
        AccountController account = new AccountController();

        public static string acc = "";
        public static string pass = "";
        public static int roles = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(account.CheckLogin(txtAccount.Text, txtPassword.Text))
            {

                acc = AccountController.acc;
                pass = AccountController.pass;
                roles = AccountController.roles;
                this.Hide();
                frmMain main = new frmMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, xin kiểm tra lại tài khoản và mật khẩu", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
