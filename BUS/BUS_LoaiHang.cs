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
    public class BUS_LoaiHang
    {
        DAL_LoaiHang DAL_LoaiHang = new DAL_LoaiHang();
        public DataTable getLoaiHang()
        {
            return DAL_LoaiHang.getLoaiHang();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_LoaiHang.kiemtramatrung(ma);
        }
        public bool themLH(DTO_LoaiHang lh)
        {
            return DAL_LoaiHang.themLH(lh);
        }
        public bool suaLH(DTO_LoaiHang lh)
        {
            return DAL_LoaiHang.suaLH(lh);
        }
        public bool xoaLH(string ma)
        {
            return DAL_LoaiHang.xoaLH(ma);
        }
        public DataTable TimKiemLH(string tenLH)
        {
            return DAL_LoaiHang.TimKiemLH(tenLH);
        }
    }
}

