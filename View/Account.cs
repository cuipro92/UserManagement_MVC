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
    public partial class frmAccount : Form
    {
        AccountController account = new AccountController();

        // set a variable to check acction add or edit 1-add, 2-edit
        public int temp = 0;

        public frmAccount()
        {
            InitializeComponent();
            LoadData();
            SetNullTextBox();
            DisplayButtonDefault();

        }

        public void LoadData()
        {
            gridAccount.DataSource = account.LoadData();
        }

        public void SetNullTextBox()
        {
            txtID.Text = "";
            txtAccount.Text = "";
            txtPassword.Text = "";
            txtRoles.Text = "";
        }

        public void DisplayButtonDefault()
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            gridAccount.Enabled = true;
        }

        public void DisplayButtonAction()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            gridAccount.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            temp = 1;
            DisplayButtonAction();
            SetNullTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            temp = 2;
            DisplayButtonAction();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn là muốn xóa tài khoản: " + txtAccount.Text +" không?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (account.DeleteAccount(txtID.Text.ToString()))
                {
                    MessageBox.Show("Xóa tài khoản thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SetNullTextBox();
            DisplayButtonDefault();
            gridAccount.DataSource = account.LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check textbox null
            if (txtID.Text == "" || txtAccount.Text == "" || txtPassword.Text == "" || txtRoles.Text == "")
            {
                MessageBox.Show("Không được để trống các trường", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Action is add
                if (temp == 1)
                {
                    if (account.InsertAccount(txtID.Text.ToString(), txtAccount.Text.ToString(), txtPassword.Text.ToString(), int.Parse(txtRoles.Text.ToString())))
                    {
                        MessageBox.Show("Thêm tài khoản thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Action is edit
                if (temp == 2)
                {
                    if (account.UpdateAccount(txtID.Text.ToString(), txtAccount.Text.ToString(), txtPassword.Text.ToString(), int.Parse(txtRoles.Text.ToString())))
                    {
                        MessageBox.Show("Sửa tài khoản thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa tài khoản thất bại", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtID.Enabled = true;
                }

            }
            SetNullTextBox();
            DisplayButtonDefault();
            gridAccount.DataSource = account.LoadData();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            SetNullTextBox();
            DisplayButtonDefault();
        }

        private void gridAccount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gridAccount.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAccount.Text = gridAccount.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPassword.Text = gridAccount.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRoles.Text = gridAccount.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
