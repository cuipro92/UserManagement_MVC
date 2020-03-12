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
    public partial class frmInfoUser : Form
    {
        UserController user = new UserController();
        public frmInfoUser()
        {
            InitializeComponent();
            gridInfoUser.DataSource = user.LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtInfoUser.Text == "")
            {
                gridInfoUser.DataSource = user.LoadData();
            }
            else
            {
                gridInfoUser.DataSource = user.LoadDateCondition(txtInfoUser.Text);
            }
        }
    }
}
