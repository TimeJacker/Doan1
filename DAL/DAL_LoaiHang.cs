using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_LoaiHang: DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách LHách Hàng ra ngoài màn hình
        public DataTable getLoaiHang()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from LoaiHang", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from LoaiHang where loaihangID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themLH(DTO_LoaiHang lh)
        {
            try
            {
                _con.Open();
                string sql = "Insert into LoaiHang values('" + lh.loaihangID + "',N'" + lh.TenLH + "')";
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
        public bool suaLH(DTO_LoaiHang lh)
        {
            try
            {
                _con.Open();
                string sql = "Update LoaiHang set TenLH=N'" + lh.TenLH + "' where loaihangID='" + lh.loaihangID + "'";
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
        public bool xoaLH(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from LoaiHang where loaihangID='" + ma + "'";
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
        public DataTable TimKiemLH(string TenLH)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from LoaiHang where TenLH  LIKE N'%" + TenLH + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}

