using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DAL_NhaCC : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Khách Hàng ra ngoài màn hình
        public DataTable getNhaCC()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from NHACC", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from NHACC where NhaCCID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themNhacc(DTO_NhaCC nhacc)
        {
            try
            {
                _con.Open();
                string sql = "Insert into NHACC values('" +nhacc.NhaCCID + "',N'" +nhacc.TenNCC + "',N'" +nhacc.diachiNCC + "',N'" +nhacc.SdtNCC + "')";
                SqlCommand cmd = new SqlCommand(sql, _con);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public bool suaNhacc(DTO_NhaCC nhacc)
        {
            try
            {
                _con.Open();
                string sql = "Update NHACC set TenNCC=N'" +nhacc.TenNCC + "',diachiNCC=N'" +nhacc.diachiNCC + "', SdtNCC='" +nhacc.SdtNCC + "' where NhaCCID='" + nhacc.NhaCCID + "'";
                SqlCommand cmd = new SqlCommand(sql, _con);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public bool xoaNhacc(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from NHACC where NhaCCID='" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, _con);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                _con.Close();
            }
            return false;
        }
        public DataTable TimKiemNhacc(string tennhacc)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from NHACC where  TenNCC LIKE N'%" + tennhacc + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}
