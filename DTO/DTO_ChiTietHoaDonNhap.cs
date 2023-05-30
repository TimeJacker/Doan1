using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDonNhap
    {
        public string DonhangnhapID { get; set; }
        public string MathangID { get; set; }
        public string Slnhap { get; set; }
        public string DGnhap { get; set; }


       public DTO_ChiTietHoaDonNhap(string donhangnhapID, string mathangID, string slnhap, string dGnhap)
        {
            DonhangnhapID = donhangnhapID;
            MathangID = mathangID;
            Slnhap = slnhap;
            DGnhap = dGnhap;
        }
    }
}
