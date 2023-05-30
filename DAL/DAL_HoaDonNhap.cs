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
    public class DAL_HoaDonNhap : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Đơn hàng nhập ra ngoài màn hình
        public DataTable getDonhangnhap()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from Donhangnhap", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from Donhangnhap where Donhangnhap='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themDHN(DTO_HoaDonNhap hdn)
        {
            try
            {
                _con.Open();
                string ngay = string.Format("{0}/{1}/{2}", hdn.Ngaynhap.Year, hdn.Ngaynhap.Month, hdn.Ngaynhap.Day);
                string sql = "Insert into Donhangnhap values('" + hdn.Donhangnhap + "',N'" + hdn.NhanvienID + "',N'" + hdn.NhaCCID + "',N'" + ngay + "',N'" + hdn.Trietkhaunhap + "')";
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
        public bool suaDHN(DTO_HoaDonNhap hdn)
        {
            try
            {
                _con.Open();
                string ngay = string.Format("{0}/{1}/{2}", hdn.Ngaynhap.Year, hdn.Ngaynhap.Month, hdn.Ngaynhap.Day);
                string sql = "Update Donhangnhap set Donhangnhap=N'" + hdn.Donhangnhap + "', NhanvienID='" + hdn.NhanvienID + "', NhaCCID=N'" + hdn.NhaCCID + "',Ngaynhap=N'" + ngay + "',Trietkhaunhap=N'" + hdn.Trietkhaunhap + "' where Donhangnhap='" + hdn.Donhangnhap + "'";
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
        public bool xoaDHN(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from Donhangnhap where Donhangnhap='" + ma + "'";
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
        public DataTable TimKiemDHN(string tenhdn)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from Donhangnhap where  Donhangnhap LIKE N'%" + tenhdn + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}

