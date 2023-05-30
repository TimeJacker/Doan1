using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan DAL_TaiKhoan = new DAL_TaiKhoan();

        public bool Login(DTO_TaiKhoan tk)
        {
            return DAL_TaiKhoan.Login(tk);  
        }
        public int kiemtratktrung(string ma)
        {
            return DAL_TaiKhoan.kiemtratktrung(ma);
        }
        public bool themTK(DTO_TaiKhoan tk)
        {
            return DAL_TaiKhoan.themtk(tk);
        }
        public bool DoiMK(DTO_TaiKhoan tk)
        {
            return DAL_TaiKhoan.Doimk(tk);
        }
    }
}
