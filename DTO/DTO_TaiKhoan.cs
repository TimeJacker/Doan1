using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {
        public string TK { get; set; }
        public string MK { get; set; }
      
        public DTO_TaiKhoan() { }

        public DTO_TaiKhoan(string tk, string mk) 
        {
                this.TK = tk;
                this.MK = mk;

        }
    }
}
