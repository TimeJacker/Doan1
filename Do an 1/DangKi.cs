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
    public partial class DangKi : Form
    {
        BUS_TaiKhoan tk = new BUS_TaiKhoan();
        public DangKi()
        {
            InitializeComponent();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtUser.Text;
            string MatKhau = txtPass.Text;
            DTO_TaiKhoan TK = new DTO_TaiKhoan(TaiKhoan, MatKhau);
            if (tk.kiemtratktrung(TaiKhoan) == 1)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                if (tk.themTK(TK) == true)
                {
                    MessageBox.Show("Đăng kí thành công");
                    Main Hp = new Main();
                    Hp.Show();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.Show();
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
                errTK.SetError(txtUser, "Bạn cần nhập username!!!");

            }
            else
            {
                e.Cancel = false;
                errTK.SetError(txtUser, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                e.Cancel = true;
                txtPass.Focus();
                errMK.SetError(txtPass, "Bạn cần nhập Password!!!");

            }
            else
            {
                e.Cancel = false;
                errMK.SetError(txtPass, "");
            }
        }

        private void txtPass2_Validating(object sender, CancelEventArgs e)
        {
            string password = txtPass.Text;
            string confirmPassword = txtPass2.Text;
            if (string.IsNullOrEmpty(txtPass2.Text) || password != confirmPassword)
            {
                e.Cancel = true;
                txtPass.Focus();
                errMK2.SetError(txtPass2, "Bạn cần nhập Password or Mật khẩu nhập phải ko chính xác!!!");

            }
            else
            {
                e.Cancel = false;
                errMK2.Clear();
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtPass.PasswordChar = (char)0;
                txtPass2.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
                txtPass2.PasswordChar = '*';
            }
        }
    }
}
