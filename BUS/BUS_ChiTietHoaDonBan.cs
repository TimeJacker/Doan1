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
   public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan DAL_ChiTietDHB = new DAL_ChiTietHoaDonBan();
        public DataTable getChiTietDHB()
        {
            return DAL_ChiTietDHB.getChiTietDHB();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_ChiTietDHB.kiemtramatrung(ma);
        }
        public bool themctdhb(DTO_ChiTietHoaDonBan ctdhb)
        {
            return DAL_ChiTietDHB.themctdhb(ctdhb);
        }
        public bool suactdhb(DTO_ChiTietHoaDonBan ctdhb)
        {
            return DAL_ChiTietDHB.suactdhb(ctdhb);
        }
        public bool xoactdhb(string ma)
        {
            return DAL_ChiTietDHB.xoactdhb(ma);
        }
        public DataTable TimKiemctdhb(string tenkctdhb)
        {
            return DAL_ChiTietDHB.TimKiemctdhb(tenkctdhb);
        }
    }
}
