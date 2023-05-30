using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang DAL_KhachHang = new DAL_KhachHang();
        public DataTable getKhachHang()
        {
            return DAL_KhachHang.getKhachHang();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_KhachHang.kiemtramatrung(ma);
        }
        public bool themKH(DTO_KhachHang kh)
        {
            return DAL_KhachHang.themKH(kh);
        }
        public bool suaKH(DTO_KhachHang kh)
        {
            return DAL_KhachHang.suaKH(kh);
        }
        public bool xoaKH(string ma)
        {
            return DAL_KhachHang.xoaKH(ma);
        }
        public DataTable TimKiemKH(string tenkh)
        {
            return DAL_KhachHang.TimKiemKH(tenkh);
        }
    }
}
