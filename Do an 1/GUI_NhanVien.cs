using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace Do_an_1
{
    public partial class GUI_NhanVien : Form
    {
        BUS_NhanVien busnv = new BUS_NhanVien();
        bool ok;
        public GUI_NhanVien()
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
        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            dgvDSNV.DataSource= busnv.getNhanVien();
            locktext();
            
        }
        public void reset()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtGT.Text = "";
            dtpBir.Text = "";
            txtDiachi.Text = "";
            txtEmail.Text = "";
            txtSdt.Text = "";
        }
        public void unlock()
        {
            txtID.Enabled = true;
            txtTen.Enabled = true;
            txtGT.Enabled = true;
            dtpBir.Enabled = true;
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
            txtGT.Enabled = false;
            dtpBir.Enabled = false;
            txtDiachi.Enabled = false;
            txtEmail.Enabled = false;
            txtSdt.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            unlock();
            ok = true;
            reset();
        }

        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtID.Enabled = false;
            txtID.Text = dgvDSNV[0, hang].Value.ToString();
            txtTen.Text = dgvDSNV[1, hang].Value.ToString();
            txtGT.Text = dgvDSNV[2, hang].Value.ToString();
            dtpBir.Text = dgvDSNV[3, hang].Value.ToString();
            txtDiachi.Text = dgvDSNV[4, hang].Value.ToString();
            txtEmail.Text = dgvDSNV[5, hang].Value.ToString();
            txtSdt.Text = dgvDSNV[6, hang].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unlock();
            ok = false;
            txtID.Enabled = false;
            

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string NhanVienID = txtID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (busnv.xoaSV(NhanVienID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSNV.DataSource = busnv.getNhanVien();
                }
            }
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSNV.DataSource = busnv.TimKiemNV(txtTKNV.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            string nhanVienID = txtID.Text;
            string hotenNV = txtTen.Text;
            string gioitinhNV = txtGT.Text;
            DateTime ngaysinhNV = DateTime.Parse(dtpBir.Value.ToShortDateString());
            string diachiNV = txtDiachi.Text;
            string emailNV = txtEmail.Text;
            string sdtNV = txtSdt.Text;
            DTO_NhanVien nv = new DTO_NhanVien(nhanVienID, hotenNV, gioitinhNV, ngaysinhNV, diachiNV, emailNV, sdtNV);
            if (ok == true)
            {
                if (busnv.kiemtramatrung(nhanVienID) == 1)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (busnv.themNV(nv) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSNV.DataSource = busnv.getNhanVien();
                    }
                }
            }
            else
            {
                if (busnv.suaNV(nv) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSNV.DataSource = busnv.getNhanVien();
                }
            }
            locktext();
            reset();

        }

        private void txtTKNV_TextChanged(object sender, EventArgs e)
        {
            reset();
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

        private void txtGT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errGioitinh.SetError(txtGT, "Giới tinh ko chứa số!!!");
            }
            else
            {
                errGioitinh.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            export2Excel(dgvDSNV, @"D:\", "Danh Sách Nhân Viên");
        }
    }
}
