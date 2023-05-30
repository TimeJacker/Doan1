using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhaCC
    {
        public string NhaCCID { get; set; }
        public string TenNCC { get; set; }
        public string diachiNCC { get; set; }
        public string SdtNCC { get; set; }
    
        public DTO_NhaCC() { }  

        public DTO_NhaCC(string NhaCCID, string TenNCC, string diachiNCC, string SdtNCC)
        {
            this.NhaCCID = NhaCCID;
            this.TenNCC = TenNCC;
            this.diachiNCC = diachiNCC;
            this.SdtNCC = SdtNCC;
            
        }
    }
}
