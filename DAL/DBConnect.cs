using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DBConnect
    {
       protected SqlConnection _con = new SqlConnection(@"Data Source=DESKTOP-B3I650Q\SQLEXPRESS;Initial Catalog=QLBH_hotenSV;Integrated Security=True");

    }
    
}
