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
    public partial class GUI_LoaiHang : Form
    {
        BUS_LoaiHang buslh = new BUS_LoaiHang();
        bool ok;
        public GUI_LoaiHang()
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

        private void GUI_LoaiHang_Load(object sender, EventArgs e)
        {
            dgvDSLH.DataSource = buslh.getLoaiHang();
            locktext();
        }

        private void dgvDSLH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtID.Enabled = false;
            txtID.Text = dgvDSLH[0, hang].Value.ToString();
            txtTen.Text = dgvDSLH[1, hang].Value.ToString();
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
            string LoaiHangID = txtID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (buslh.xoaLH(LoaiHangID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSLH.DataSource = buslh.getLoaiHang();
                }
            }
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string loaihangID = txtID.Text;
            string TenLH = txtTen.Text;
            DTO_LoaiHang lh = new DTO_LoaiHang(loaihangID,TenLH);
            if (ok == true)
            {
                if (buslh.kiemtramatrung(loaihangID) == 1)
                {
                    MessageBox.Show("Mã loại hàng này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (buslh.themLH(lh) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSLH.DataSource = buslh.getLoaiHang();
                    }
                }
            }
            else
            {
                if (buslh.suaLH(lh) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSLH.DataSource = buslh.getLoaiHang();
                }
            }
            locktext();
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSLH.DataSource = buslh.TimKiemLH(txtTKLH.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void txtTKLH_TextChanged_1(object sender, EventArgs e)
        {
            reset();
        }
        #region Method
        public void reset()
        {
            txtID.Text = "";
            txtTen.Text = "";
        }
        public void unlock()
        {
            txtID.Enabled = true;
            txtTen.Enabled = true;
           

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void locktext()
        {
            txtID.Enabled = false;
            txtTen.Enabled = false;
            

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            export2Excel(dgvDSLH, @"D:\", "Danh Sách Loại Hàng");
        }
    }
}
