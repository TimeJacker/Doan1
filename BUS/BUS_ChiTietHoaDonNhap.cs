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
    public class BUS_ChiTietHoaDonNhap
    {
        DAL_ChiTietHoaDonNhap DAL_ChiTietDHN = new DAL_ChiTietHoaDonNhap();
        public DataTable getChiTietDHN()
        {
            return DAL_ChiTietDHN.getChiTietDHN();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_ChiTietDHN.kiemtramatrung(ma);
        }
        public bool themctdhn(DTO_ChiTietHoaDonNhap ctdhn)
        {
            return DAL_ChiTietDHN.themctdhn(ctdhn);
        }
        public bool suactdhn(DTO_ChiTietHoaDonNhap ctdhn)
        {
            return DAL_ChiTietDHN.suactdhn(ctdhn);
        }
        public bool xoactdhn(string ma)
        {
            return DAL_ChiTietDHN.xoactdhn(ma);
        }
        public DataTable TimKiemctdhn(string tenkctdhn)
        {
            return DAL_ChiTietDHN.TimKiemctdhn(tenkctdhn);
        }
    }
}
