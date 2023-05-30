using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonBan
    {
        public string DonhangbanID { get; set; }
        public string NhanvienID { get; set; }
        public string KhachhangID { get; set; }
        public DateTime Ngayban { get; set; }
        public string Trietkhauban { get; set; }
        public DTO_HoaDonBan() { }

        public DTO_HoaDonBan(string donhangban, string nhanvienID, string KhachhangID, DateTime ngaynhap, string trietkhauban)
        {
            this.DonhangbanID = donhangban;
            this.NhanvienID = nhanvienID;
            this.KhachhangID = KhachhangID;
            this.Ngayban = ngaynhap;
            this.Trietkhauban = trietkhauban;
        }
    }
}
