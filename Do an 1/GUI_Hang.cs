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
    public partial class GUI_Hang : Form
    {
        BUS_Hang bush = new BUS_Hang();
        BUS_LoaiHang buslh = new BUS_LoaiHang();
        bool ok;
        public GUI_Hang()
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
        private void GUI_Hang_Load(object sender, EventArgs e)
        {
            dgvDSMH.DataSource = bush.getMatHang();
            locktext();
            loadcbb();
        }

        private void dgvDSMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtMaXe.Enabled = false;
            cbLoaiXe.Text = dgvDSMH[0, hang].Value.ToString();
            txtMaXe.Text = dgvDSMH[1, hang].Value.ToString();
            txtTenXe.Text = dgvDSMH[2, hang].Value.ToString();
            txtSoLuong.Text = dgvDSMH[3, hang].Value.ToString();
            txtDonGia.Text = dgvDSMH[4, hang].Value.ToString();

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
            txtMaXe.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MathangID = txtMaXe.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (bush.xoaMH(MathangID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSMH.DataSource = bush.getMatHang();
                }
            }
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string LoaiHangID = cbLoaiXe.Text;
            string MathangID = txtMaXe.Text;
            string Tenhang = txtTenXe.Text;
            string SoLuong = txtSoLuong.Text;
            string DonGia = txtDonGia.Text;
            DTO_Hang h = new DTO_Hang( LoaiHangID,  MathangID, Tenhang, SoLuong, DonGia);
            if (ok == true)
            {
                if (bush.kiemtramatrung(MathangID) == 1)
                {
                    MessageBox.Show("Mã xe này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (bush.themMH(h) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSMH.DataSource = bush.getMatHang();
                    }
                }
            }
            else
            {   
                if (bush.suaMH(h) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSMH.DataSource = bush.getMatHang();
                }
            }
            locktext();
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSMH.DataSource = bush.TimKiemMH(txtTKH.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTKNV_TextChanged(object sender, EventArgs e)
        {
            reset();    
        }
        #region Method
        void loadcbb()
        {
            cbLoaiXe.DataSource = buslh.getLoaiHang();
            cbLoaiXe.DisplayMember = "LoaiHangID";
            cbLoaiXe.ValueMember = "LoaiHangID";
        }
        public void reset()
        {
            cbLoaiXe.Text = "";
            txtMaXe.Text = "";
            txtTenXe.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
        }
        public void unlock()
        {
            cbLoaiXe.Enabled = true;
            txtMaXe.Enabled = true;
            txtTenXe.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGia.Enabled = true;


            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void locktext()
        {

            cbLoaiXe.Enabled = false;
            txtMaXe.Enabled = false;
            txtTenXe.Enabled = false;
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
            export2Excel(dgvDSMH, @"D:\", "Danh Sách Xe");
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
