using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        public string KhachHangID { get; set; }
        public string HotenKH { get; set; }
        public string DiachiKH { get; set; }
        public string EmailKH { get; set; }
        public string SdtKH { get; set; }
        public DTO_KhachHang() { }

        public DTO_KhachHang(string KhachHangID, string HotenKH, string DiachiKH, string EmailKH,  string SdtKH)
        {
            this.KhachHangID = KhachHangID;
            this.HotenKH = HotenKH;
            this.DiachiKH= DiachiKH;
            this.EmailKH= EmailKH;
            this.SdtKH= SdtKH;  
        }
    }
}
