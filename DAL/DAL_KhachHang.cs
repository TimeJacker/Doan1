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
    public class DAL_KhachHang : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Khách Hàng ra ngoài màn hình
        public DataTable getKhachHang()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from KhachHang", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from KhachHang where KhachHangID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themKH(DTO_KhachHang kh)
        {
            try
            {
                _con.Open();
                string sql = "Insert into KhachHang values('" + kh.KhachHangID + "',N'" + kh.HotenKH + "',N'" + kh.DiachiKH + "',N'" + kh.EmailKH + "',N'" + kh.SdtKH + "')";
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
        public bool suaKH(DTO_KhachHang kh)
        {
            try
            {
                _con.Open();
                string sql = "Update KhachHang set HotenKH=N'" + kh.HotenKH + "',DiachiKH=N'" + kh.DiachiKH + "', EmailKH='" + kh.EmailKH + "', SdtKH=N'" + kh.SdtKH + "' where KhachHangID='" + kh.KhachHangID + "'";
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
        public bool xoaKH(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from KhachHang where KhachHangID='" + ma + "'";
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
        public DataTable TimKiemKH(string tenkh)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from KhachHang where  HotenKH LIKE N'%" + tenkh + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}
