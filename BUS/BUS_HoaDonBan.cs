using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan DAL_HoaDonBan = new DAL_HoaDonBan();
        public DataTable getDHB()
        {
            return DAL_HoaDonBan.getDonhangban();
        }
        public int kiemtramatrung(string ma)
        {
            return DAL_HoaDonBan.kiemtramatrung(ma);
        }
        public bool themDHB(DTO_HoaDonBan hdb)
        {
            return DAL_HoaDonBan.themDHB(hdb);
        }
        public bool suaDHB(DTO_HoaDonBan hdb)
        {
            return DAL_HoaDonBan.suaDHB(hdb);
        }
        public bool xoaDHB(string ma)
        {
            return DAL_HoaDonBan.xoaDHB(ma);
        }
        public DataTable TimKiemDHB(string tenhdb)
        {
            return DAL_HoaDonBan.TimKiemDHB(tenhdb);
        }
    }
}
