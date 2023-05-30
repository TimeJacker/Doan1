using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiHang
    {
        public string loaihangID { get; set; }
        public string TenLH { get; set; }
      
        public DTO_LoaiHang() { }

        public DTO_LoaiHang(string loaihangID, string TenLH)
        {
                this.loaihangID = loaihangID;
                this.TenLH = TenLH;

        }
    }
}
