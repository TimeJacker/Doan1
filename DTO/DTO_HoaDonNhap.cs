using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTO_HoaDonNhap
    {
        public string Donhangnhap { get; set; }
        public string NhanvienID { get; set; }
        public string NhaCCID { get; set; }
        public DateTime Ngaynhap { get; set; }
        public string Trietkhaunhap { get; set; }
        public DTO_HoaDonNhap() { }

        public DTO_HoaDonNhap(string donhangnhap, string nhanvienID, string nhaCCID, DateTime ngaynhap, string trietkhaunhap)
        {
            this.Donhangnhap = donhangnhap;
            this.NhanvienID = nhanvienID;
            this.NhaCCID = nhaCCID;
            this.Ngaynhap = ngaynhap;
            this.Trietkhaunhap = trietkhaunhap;
        }
    }
}
