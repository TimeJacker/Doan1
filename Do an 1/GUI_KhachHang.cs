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
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
namespace Do_an_1
{
    public partial class GUI_KhachHang : Form
    {
        BUS_KhachHang buskh = new BUS_KhachHang();
        bool ok;
        public GUI_KhachHang()
        {
            InitializeComponent();
        }
        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            dgvDSKH.DataSource = buskh.getKhachHang();
            locktext();
        }
        public void reset()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtDiachi.Text = "";
            txtEmail.Text = "";
            txtSdt.Text = "";
        }
        public void unlock()
        {
            txtID.Enabled = true;
            txtTen.Enabled = true;
            txtDiachi.Enabled = true;
            txtEmail.Enabled = true;
            txtSdt.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void locktext()
        {
            txtID.Enabled = false;
            txtTen.Enabled = false;
            txtDiachi.Enabled = false;
            txtEmail.Enabled = false;
            txtSdt.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtID.Enabled = false;
            txtID.Text = dgvDSKH[0, hang].Value.ToString();
            txtTen.Text = dgvDSKH[1, hang].Value.ToString();
            txtDiachi.Text = dgvDSKH[2, hang].Value.ToString();
            txtEmail.Text = dgvDSKH[3, hang].Value.ToString();
            txtSdt.Text = dgvDSKH[4, hang].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            unlock();
            ok = true;
            reset();    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unlock();
            ok = false;
            txtID.Enabled = false;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string KhachHangID = txtID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (buskh.xoaKH(KhachHangID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                   dgvDSKH.DataSource = buskh.getKhachHang();
                }
            }
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string KhachHangID = txtID.Text;
            string HotenKH = txtTen.Text;
            string DiachiKH = txtDiachi.Text;
            string EmailKH = txtEmail.Text;
            string SdtKH = txtSdt.Text;
            DTO_KhachHang kh = new DTO_KhachHang( KhachHangID, HotenKH,  DiachiKH,  EmailKH,  SdtKH);
            if (ok == true)
            {
                if (buskh.kiemtramatrung(KhachHangID) == 1)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (buskh.themKH(kh) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSKH.DataSource = buskh.getKhachHang();
                    }
                }
            }
            else
            {
                if (buskh.suaKH(kh) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSKH.DataSource = buskh.getKhachHang();
                }
            }
            locktext();
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSKH.DataSource = buskh.TimKiemKH(txtTKKH.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void txtTKKH_TextChanged(object sender, EventArgs e)
        {
            reset();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            export2Excel(dgvDSKH, @"D:\", "Danh Sách Khách Hàng");
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errSdt.SetError(txtSdt, "Số điện thoại ko chứa chữ!!!");
            }
            else
            {
                errSdt.Clear();
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errHoten.SetError(txtTen, "Họ tên ko chứa số!!!");
            }
            else
            {
                errHoten.Clear();
            }
        }
    }
}
