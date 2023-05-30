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
    public class BUS_NhaCC
    {
            DAL_NhaCC DAL_NhaCC = new DAL_NhaCC();
            public DataTable getNhaCC()
            {
                return DAL_NhaCC.getNhaCC();
            }
            public int kiemtramatrung(string ma)
            {
                return DAL_NhaCC.kiemtramatrung(ma);
            }
            public bool themNhacc(DTO_NhaCC nhaCC)
            {
                return DAL_NhaCC.themNhacc(nhaCC);
            }
            public bool suaNhacc(DTO_NhaCC nhaCC)
            {
                return DAL_NhaCC.suaNhacc(nhaCC);
            }
            public bool xoaNhacc(string ma)
            {
                return DAL_NhaCC.xoaNhacc(ma);
            }
            public DataTable TimKiemNhacc(string tennhacc)
            {
                return DAL_NhaCC.TimKiemNhacc(tennhacc);
            }
        }
    }

