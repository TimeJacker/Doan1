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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        private void quảnLýLoạiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_LoaiHang qllh = new GUI_LoaiHang();
            qllh.ShowDialog();
        }

        private void quảnLýXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_Hang qlxe = new GUI_Hang();
            qlxe.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhanVien qlnv = new GUI_NhanVien();
            qlnv.ShowDialog();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_KhachHang qlkh = new GUI_KhachHang();
            qlkh.ShowDialog();
        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDonNhap qlhdn = new GUI_HoaDonNhap();
            qlhdn.ShowDialog();
        }

        private void quảnLýHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDonBan qlhdb = new GUI_HoaDonBan();
            qlhdb.ShowDialog();
        }

        private void quảnLýChiTiếtHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ChiTietDHN qlcthdn = new GUI_ChiTietDHN();
            qlcthdn.ShowDialog();
        }

        private void quảnLýChiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ChiTietDHB qlcthdb = new GUI_ChiTietDHB();
            qlcthdb.ShowDialog();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKi dangKi = new DangKi();   
            dangKi.ShowDialog();
            this.Hide();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhaCC ncc = new GUI_NhaCC();
            ncc.ShowDialog();
        }
    }
}
