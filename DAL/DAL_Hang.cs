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
    public class DAL_Hang: DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Mặt Hàng ra ngoài màn hình
        public DataTable getMatHang()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from MatHang", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from MatHang where MathangID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themMH(DTO_Hang h)
        {
            try
            {
                _con.Open();
                string sql = "Insert into MatHang values('" + h.LoaiHangID + "',N'" + h.MathangID + "',N'" + h.Tenhang + "',N'" + h.SoLuong + "',N'" + h.DonGia + "')";
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
        public bool suaMH(DTO_Hang h)
        {
            try
            {
                _con.Open();
                string sql = "Update MatHang set LoaiHangID=N'" + h.LoaiHangID + "', Tenhang='" + h.Tenhang + "', SoLuong=N'" + h.SoLuong + "',DonGia=N'"+h.DonGia+"' where MatHangID='" + h.MathangID + "'";
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
        public bool xoaMH(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from MatHang where MathangID='" + ma + "'";
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
        public DataTable TimKiemMH(string tenh)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from MatHang where  Tenhang LIKE N'%" + tenh + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}
