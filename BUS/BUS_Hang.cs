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
    public class BUS_Hang
    {
        DAL_Hang DAL_MatHang = new DAL_Hang();
        public DataTable getMatHang()
        {
            return DAL_MatHang.getMatHang();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_MatHang.kiemtramatrung(ma);
        }
        public bool themMH(DTO_Hang h)
        {
            return DAL_MatHang.themMH(h);
        }
        public bool suaMH(DTO_Hang h)
        {
            return DAL_MatHang.suaMH(h);
        }
        public bool xoaMH(string ma)
        {
            return DAL_MatHang.xoaMH(ma);
        }
        public DataTable TimKiemMH(string tenkh)
        {
            return DAL_MatHang.TimKiemMH(tenkh);
        }
    }
}

