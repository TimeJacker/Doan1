using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_1
{
    public partial class DangNhap : Form
    {
        BUS_TaiKhoan bUS_TaiKhoan = new BUS_TaiKhoan();
        
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            DTO_TaiKhoan tk = new DTO_TaiKhoan(username,password);
            if (bUS_TaiKhoan.Login(tk) == true)
            {
                MessageBox.Show("Đăng nhập thành công");
                Main Hp = new Main();
                this.Hide();
                Hp.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng , Vui lòng đăng nhập lại");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                e.Cancel = true;
                txtUser.Focus();
                errUser.SetError(txtUser, "Bạn cần nhập username!!!");

            }
            else
            {
                e.Cancel = false;
                errUser.SetError(txtUser, "");
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                e.Cancel = true;
                txtPass.Focus();
                errPass.SetError(txtPass, "Bạn cần nhập Password!!!");

            }
            else
            {
                e.Cancel = false;
                errPass.SetError(txtPass, "");
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
                txtPass.PasswordChar = (char)0;
            else
                txtPass.PasswordChar = '*';
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            DangKi DK = new DangKi();
            DK.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Main Hp = new Main();
            Hp.Show();
        }
    }
}
