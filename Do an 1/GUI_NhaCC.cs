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
    public partial class GUI_NhaCC : Form
    {
        public GUI_NhaCC()
        {
            InitializeComponent();
        }
        BUS_NhaCC busncc = new BUS_NhaCC();
        bool ok;
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
        private void GUI_NhaCC_Load(object sender, EventArgs e)
        {
            dgvDSNCC.DataSource = busncc.getNhaCC();
            locktext();
        }
        public void reset()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
        }
        public void unlock()
        {
            txtID.Enabled = true;
            txtTen.Enabled = true;
            txtDiachi.Enabled = true;
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

        private void dgvDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = e.RowIndex;
            txtID.Enabled = false;
            txtID.Text = dgvDSNCC[0, hang].Value.ToString();
            txtTen.Text = dgvDSNCC[1, hang].Value.ToString();
            txtDiachi.Text = dgvDSNCC[2, hang].Value.ToString();
            txtSdt.Text = dgvDSNCC[3, hang].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unlock();
            ok = false;
            txtID.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string NhaCCID = txtID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (busncc.xoaNhacc(NhaCCID) == true)
                {
                    MessageBox.Show("Xoa thanh cong");
                    dgvDSNCC.DataSource = busncc.getNhaCC();
                }
            }
            reset();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm thành công");
            dgvDSNCC.DataSource = busncc.TimKiemNhacc(txtTKNCC.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string NhaCCID = txtID.Text;
            string TenNCC = txtTen.Text;
            string diachiNCC = txtDiachi.Text;
            string SdtNCC = txtSdt.Text;
            DTO_NhaCC ncc = new DTO_NhaCC(NhaCCID, TenNCC, diachiNCC, SdtNCC); 
            if (ok == true)
            {
                if (busncc.kiemtramatrung(NhaCCID) == 1)
                {
                    MessageBox.Show("Mã nhà cung cấp này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    if (busncc.themNhacc(ncc) == true)
                    {
                        MessageBox.Show("Them thanh cong");
                        dgvDSNCC.DataSource = busncc.getNhaCC();
                    }
                }
            }
            else
            {
                if (busncc.suaNhacc(ncc) == true)
                {
                    MessageBox.Show("Sua thanh cong");
                    dgvDSNCC.DataSource = busncc.getNhaCC();   
                }
            }
            locktext();
            reset();

        }

        private void txtTKNCC_TextChanged(object sender, EventArgs e)
        {
            reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            export2Excel(dgvDSNCC, @"D:\", "Danh Sách Nhà Cung Cấp");
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự vừa được nhấn
                errorSDT.SetError(txtSdt, "Số điện thoại ko chứa chữ!!!");
            }
            else
            {
                errorSDT.Clear();
            }
        }
    }
 }


