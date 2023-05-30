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
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap DAL_HoaDonNhap = new DAL_HoaDonNhap();
        public DataTable getDHN()
        {
            return DAL_HoaDonNhap.getDonhangnhap();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_HoaDonNhap.kiemtramatrung(ma);
        }
        public bool themDHN(DTO_HoaDonNhap hdn)
        {
            return DAL_HoaDonNhap.themDHN(hdn);
        }
        public bool suaDHN(DTO_HoaDonNhap hdn)
        {
            return DAL_HoaDonNhap.suaDHN(hdn);
        }
        public bool xoaDHN(string ma)
        {
            return DAL_HoaDonNhap.xoaDHN(ma);
        }
        public DataTable TimKiemDHN(string tenhdn)
        {
            return DAL_HoaDonNhap.TimKiemDHN(tenhdn);
        }
    }
}

