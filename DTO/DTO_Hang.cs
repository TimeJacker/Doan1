using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Hang
    {
        public string LoaiHangID { get; set; }
        public string MathangID { get; set; }
        public string Tenhang { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public DTO_Hang() { }

        public DTO_Hang(string LoaiHangID, string MathangID, string Tenhang, string SoLuong, string DonGia)
        {
            this.LoaiHangID = LoaiHangID;
            this.MathangID = MathangID;
            this.Tenhang = Tenhang;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
        }
    }
}
