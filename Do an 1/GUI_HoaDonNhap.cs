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
    public partial class GUI_HoaDonNhap : Form
    {
        BUS_NhanVien busnv = new BUS_NhanVien();
        BUS_HoaDonNhap bushdn = new BUS_HoaDonNhap();
        BUS_NhaCC busncc = new BUS_NhaCC();
        bool ok;
        public GUI_HoaDonNhap()
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
        private void GUI_HoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvDSHD.DataSource = bushdn.getDHN();
            locktext();
            loadcbb();
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtDHNID.Enabled = false;
            txtDHNID.Text = dgvDSHD[0, hang].Value.ToString();
            cbNVID.Text = dgvDSHD[1, hang].Value.ToString();
            cbNCCID.Text = dgvDSHD[2, hang].Value.ToString();
            dtpNhap.Text = dgvDSHD[3, hang].Value.ToString();
            txtTrK.Text = dgvDSHD[4, hang].Value.ToString();
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
            txtDHNID.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string DHNID = txtDHNID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (bushdn.xoaDHN(DHNID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSHD.DataSource = bushdn.getDHN();
                }
            }
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string Donhangnhap = txtDHNID.Text;
            string NhanvienID = cbNVID.Text;
            string NhaCCID = cbNCCID.Text;
            DateTime Ngaynhap = DateTime.Parse(dtpNhap.Value.ToShortDateString()); ;
            string Trietkhaunhap = txtTrK.Text;
            DTO_HoaDonNhap hdn = new DTO_HoaDonNhap(Donhangnhap, NhanvienID, NhaCCID, Ngaynhap, Trietkhaunhap);
            if (ok == true)
            {
                if (bushdn.kiemtramatrung(Donhangnhap) == 1)
                {
                    MessageBox.Show("Mã đơn này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (bushdn.themDHN(hdn) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSHD.DataSource = bushdn.getDHN();
                    }
                }
            }
            else
            {
                if (bushdn.suaDHN(hdn) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSHD.DataSource = bushdn.getDHN();
                }
            }
            locktext();
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSHD.DataSource = bushdn.TimKiemDHN(txtTK.Text);
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

            cbNCCID.DataSource = busncc.getNhaCC();
            cbNCCID.DisplayMember = "NhaCCID";
            cbNCCID.ValueMember = "NhaCCID";
        }
        public void reset()
        {
            cbNVID.Text = "";
            txtDHNID.Text = "";
            txtDonGia.Text = "";
            cbNCCID.Text = "";
            txtTrK.Text = "";
            dtpNhap.Text = "";
        }
        public void unlock()
        {
            cbNVID.Enabled = true;
            txtDHNID.Enabled = true;
            cbNCCID.Enabled = true;
            dtpNhap.Enabled = true;
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
            txtDHNID.Enabled = false;
            cbNCCID.Enabled = false;
            dtpNhap.Enabled = false;
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
            export2Excel(dgvDSHD, @"D:\", "Danh Sách Hóa Đơn Nhập");
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
