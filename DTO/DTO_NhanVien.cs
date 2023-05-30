using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        public string NhanVienID { get; set; }
        public string HotenNV { get; set; }
        public string GioitinhNV { get; set; }
        public DateTime NgaysinhNV { get; set; }
        public string diachiNV { get; set; }
        public string EmailNV { get; set; }
        public string SdtNV { get; set; }
        public DTO_NhanVien() { }

        public DTO_NhanVien(string nhanVienID, string hotenNV, string gioitinhNV, DateTime ngaysinhNV, string diachiNV, string emailNV, string sdtNV)
        {
            this.NhanVienID = nhanVienID;
            this.HotenNV = hotenNV;
            this.GioitinhNV = gioitinhNV;
            this.NgaysinhNV = ngaysinhNV;
            this.diachiNV = diachiNV;
            this.EmailNV = emailNV;
            this.SdtNV = sdtNV;
        }
    }
}
