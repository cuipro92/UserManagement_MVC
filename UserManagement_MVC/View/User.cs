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
    public partial class frmUser : Form
    {
        UserController user = new UserController();

        // set a variable to check acction add or edit 1-add, 2-edit
        public int temp = 0;

        public frmUser()
        {
            InitializeComponent();
            LoadData();
            SetNullTextBox();
            DisplayButtonDefault();
        }

        public void LoadData()
        {
            gridUser.DataSource = user.LoadData();
        }

        public void SetNullTextBox()
        {
            txtID.Text = "";
            txtUserName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
        }

        public void DisplayButtonDefault()
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            gridUser.Enabled = true;
        }

        public void DisplayButtonAction()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            gridUser.Enabled = false;
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
            if (MessageBox.Show("Bạn có chắc chắn là muốn xóa người dùng: " + txtUserName.Text + " không?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (user.DeleteUser(txtID.Text.ToString()))
                {
                    MessageBox.Show("Xóa người dùng thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa người dùng thất bại", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SetNullTextBox();
            DisplayButtonDefault();
            gridUser.DataSource = user.LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check textbox null
            if (txtID.Text == "" || txtUserName.Text == "" || txtAddress.Text == "" || txtEmail.Text == "" || cboGender.Text == "")
            {
                MessageBox.Show("Không được để trống các trường", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Action is add
                if (temp == 1)
                {
                    if (user.InsertUser(txtID.Text, txtUserName.Text, dateBirthday.Text, txtAddress.Text, txtEmail.Text, cboGender.Text))
                    {
                        MessageBox.Show("Thêm người dùng thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm người dùng thất bại", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Action is edit
                if (temp == 2)
                {
                    if (user.UpdateUser(txtID.Text, txtUserName.Text, dateBirthday.Text, txtAddress.Text, txtEmail.Text, cboGender.Text))
                    {
                        MessageBox.Show("Sửa người dùng thành công", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa người dùng thất bại", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtID.Enabled = true;
                }

            }
            SetNullTextBox();
            DisplayButtonDefault();
            gridUser.DataSource = user.LoadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            SetNullTextBox();
            DisplayButtonDefault();
        }

        private void gridUser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gridUser.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUserName.Text = gridUser.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateBirthday.Text = gridUser.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAddress.Text = gridUser.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = gridUser.Rows[e.RowIndex].Cells[4].Value.ToString();
            cboGender.Text = gridUser.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridUser.DataSource = user.LoadDateCondition(txtInfoUser.Text);
        }
    }
}
