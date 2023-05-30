using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien DAL_NhanVien = new DAL_NhanVien();
        public DataTable getNhanVien()
        {
            return DAL_NhanVien.getNhanVien();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_NhanVien.kiemtramatrung(ma);
        }
        public bool themNV(DTO_NhanVien nv)
        {
            return DAL_NhanVien.themNV(nv);
        }
        public bool suaNV(DTO_NhanVien nv)
        {
            return DAL_NhanVien.suaNV(nv);
        }
        public bool xoaSV(string ma)
        {
            return DAL_NhanVien.xoaNV(ma);
        }
        public DataTable TimKiemNV(string tennv)
        {
            return DAL_NhanVien.TimKiemNV(tennv);
        }
    }
}
