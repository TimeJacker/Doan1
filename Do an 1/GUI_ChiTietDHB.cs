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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;


namespace Do_an_1
{
    public partial class GUI_ChiTietDHB : Form
    {
        BUS_HoaDonBan HDB = new BUS_HoaDonBan();
        BUS_ChiTietHoaDonBan ctHDB = new BUS_ChiTietHoaDonBan();
        BUS_Hang bushang = new BUS_Hang();
        bool ok;
        public GUI_ChiTietDHB()
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
        private void GUI_ChiTietDHB_Load(object sender, EventArgs e)
        {
            dgvDSctHD.DataSource = ctHDB.getChiTietDHB();
            locktext();
            loadcbb();
        }

        private void dgvDSctHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            cbHDid.Enabled = false;
            cbHDid.Text = dgvDSctHD[0, hang].Value.ToString();
            cbMaXe.Text = dgvDSctHD[1, hang].Value.ToString();
            txtSoLuong.Text = dgvDSctHD[2, hang].Value.ToString();
            txtDonGia.Text = dgvDSctHD[3, hang].Value.ToString();
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
            cbHDid.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string DHNID = cbHDid.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (ctHDB.xoactdhb(DHNID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSctHD.DataSource = ctHDB.getChiTietDHB();
                }
            }
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string DonhangBan = cbHDid.Text;
            string MathangID = cbMaXe.Text;
            string SlBan = txtSoLuong.Text;
            string DGBan = txtDonGia.Text;
            DTO_ChiTietHoaDonBan hdb = new DTO_ChiTietHoaDonBan(DonhangBan, MathangID, SlBan, DGBan);
            if (ok == true)
            {
                if (ctHDB.kiemtramatrung(DonhangBan) == 1)
                {
                    MessageBox.Show("Mã đơn này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (ctHDB.themctdhb(hdb) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSctHD.DataSource = ctHDB.getChiTietDHB();
                    }
                }
            }
            else
            {
                if (ctHDB.suactdhb(hdb) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSctHD.DataSource = ctHDB.getChiTietDHB();
                }
            }
            locktext();
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSctHD.DataSource = ctHDB.TimKiemctdhb(txtTKctHDB.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Method
        void loadcbb()
        {
            cbMaXe.DataSource = bushang.getMatHang();
            cbMaXe.DisplayMember = "MathangID";
            cbMaXe.ValueMember = "MathangID";

            cbHDid.DataSource = HDB.getDHB();
            cbHDid.DisplayMember = "DonhangBanID";
            cbHDid.ValueMember = "DonhangBanID";
        }
        public void reset()
        {
            cbMaXe.Text = "";
            cbHDid.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";

        }
        public void unlock()
        {
            cbMaXe.Enabled = true;
            cbHDid.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGia.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void locktext()
        {

            cbMaXe.Enabled = false;
            cbHDid.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGia.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            export2Excel(dgvDSctHD, @"D:\", "Danh Sách Chi Tiết Đơn hàng bán");
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errorProvider1.SetError(txtSoLuong, "Số lượng ko chứa chữ!!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errorProvider2.SetError(txtDonGia, "Đơn giá ko chứa chữ!!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
