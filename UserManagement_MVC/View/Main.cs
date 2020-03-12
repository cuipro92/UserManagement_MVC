using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement_MVC.View;

namespace UserManagement_MVC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            FullRoles(frmLogin.roles);
        }

        public void FullRoles(int roles)
        {
            if(roles == 1 )
            {
                btnAccount.Enabled = true;
            }
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAccount account = new frmAccount();
            account.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (frmLogin.roles == 1)
            {
                frmUser user = new frmUser();
                user.Show();
            }
            else
            {
                frmInfoUser infoUser = new frmInfoUser();
                infoUser.Show();
            }
               
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
