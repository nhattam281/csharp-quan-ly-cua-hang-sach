using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using GUI.Properties;

namespace GUI.Popups
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(TaiKhoanBLL.IsValid(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                TaiKhoan t = TaiKhoanBLL.Select(txtTenDangNhap.Text);
                GlobalSettings.userID = TaiKhoanBLL.fullUserID(t);
                GlobalSettings.userName = txtTenDangNhap.Text;
                GlobalSettings.userType = TaiKhoanBLL.fullUserType(t);

                Settings.Default.Log_UserName = txtTenDangNhap.Text;
                Settings.Default.Log_Password = txtMatKhau.Text;
                Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
            }else
            {
                MessageBox.Show("Tài khoản và mật khẩu không chính xác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMK.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
