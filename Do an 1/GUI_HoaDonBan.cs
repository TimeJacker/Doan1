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
    public partial class GUI_HoaDonBan : Form
    {
        BUS_NhanVien busnv = new BUS_NhanVien();
        BUS_HoaDonBan bushdb = new BUS_HoaDonBan();
        BUS_KhachHang buskh = new BUS_KhachHang();
        bool ok;
        public GUI_HoaDonBan()
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
        private void GUI_HoaDonBan_Load(object sender, EventArgs e)
        {
            dgvDSHDB.DataSource = bushdb.getDHB();
            locktext();
            loadcbb();
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtDHBID.Enabled = false;
            txtDHBID.Text = dgvDSHDB[0, hang].Value.ToString();
            cbNVID.Text = dgvDSHDB[1, hang].Value.ToString();
            cbKHID.Text = dgvDSHDB[2, hang].Value.ToString();
            dtpBan.Text = dgvDSHDB[3, hang].Value.ToString();
            txtTrK.Text = dgvDSHDB[4, hang].Value.ToString();
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
            txtDHBID.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string DHBID = txtDHBID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (bushdb.xoaDHB(DHBID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSHDB.DataSource = bushdb.getDHB();
                }
            }
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string Donhangban = txtDHBID.Text;
            string NhanvienID = cbNVID.Text;
            string KhachHangID = cbKHID.Text;
            DateTime Ngaynhap = DateTime.Parse(dtpBan.Value.ToShortDateString()); ;
            string Trietkhauban = txtTrK.Text;
            DTO_HoaDonBan hdb = new DTO_HoaDonBan(Donhangban, NhanvienID, KhachHangID, Ngaynhap, Trietkhauban);
            if (ok == true)
            {
                if (bushdb.kiemtramatrung(Donhangban) == 1)
                {
                    MessageBox.Show("Mã đơn này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (bushdb.themDHB(hdb) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSHDB.DataSource = bushdb.getDHB();
                    }
                }
            }
            else
            {
                if (bushdb.suaDHB(hdb) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSHDB.DataSource = bushdb.getDHB();
                }
            }
            locktext();
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSHDB.DataSource = bushdb.TimKiemDHB(txtTK.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Method
        void loadcbb()
        {
            cbNVID.DataSource = busnv.getNhanVien();
            cbNVID.DisplayMember = "NhanVienID";
            cbNVID.ValueMember = "NhanVienID";

            cbKHID.DataSource = buskh.getKhachHang();
            cbKHID.DisplayMember = "KhachHangID";
            cbKHID.ValueMember = "KhachHangID";
        }
        public void reset()
        {
            cbNVID.Text = "";
            txtDHBID.Text = "";
            txtDonGia.Text = "";
            cbKHID.Text = "";
            txtTrK.Text = "";
            dtpBan.Text = "";
        }
        public void unlock()
        {
            cbNVID.Enabled = true;
            txtDHBID.Enabled = true;
            cbKHID.Enabled = true;
            dtpBan.Enabled = true;
            txtSoLuong.Enabled = true;
            txtTrK.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void locktext()
        {

            cbNVID.Enabled = false;
            txtDHBID.Enabled = false;
            cbKHID.Enabled = false;
            dtpBan.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTrK.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            export2Excel(dgvDSHDB, @"D:\", "Danh Sách Hóa Đơn Bán");
        }

        private void txtTrK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errorProvider1.SetError(txtTrK, "Triết khấu ko chứa chữ!!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
