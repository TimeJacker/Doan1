using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDonBan
    {
        public string DonhangbanID { get; set; }
        public string MathangID { get; set; }
        public string Slban { get; set; }
        public string DGban { get; set; }


        public DTO_ChiTietHoaDonBan(string donhangbanID, string mathangID, string slban, string dgban)
        {
            DonhangbanID = donhangbanID;
            MathangID = mathangID;
            Slban = slban;
            DGban = dgban;
        }
    }
}
