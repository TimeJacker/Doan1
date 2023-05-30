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
    public class DAL_HoaDonBan: DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Đơn hàng nhập ra ngoài màn hình
        public DataTable getDonhangban()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from Donhangban", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from Donhangban where DonhangbanID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themDHB(DTO_HoaDonBan hdb)
        {
            try
            {
                _con.Open();
                string ngay = string.Format("{0}/{1}/{2}", hdb.Ngayban.Year, hdb.Ngayban.Month, hdb.Ngayban.Day);
                string sql = "Insert into Donhangban values('" + hdb.DonhangbanID + "',N'" + hdb.NhanvienID + "',N'" + hdb.KhachhangID + "',N'" + ngay + "',N'" + hdb.Trietkhauban + "')";
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
        public bool suaDHB(DTO_HoaDonBan hdb)
        {
            try
            {
                _con.Open();
                string ngay = string.Format("{0}/{1}/{2}", hdb.Ngayban.Year, hdb.Ngayban.Month, hdb.Ngayban.Day);
                string sql = "Update Donhangban set DonhangbanID=N'" + hdb.DonhangbanID + "', NhanvienID='" + hdb.NhanvienID + "', KhachhangID=N'" + hdb.KhachhangID + "',Ngayban=N'" + ngay + "',Trietkhauban=N'" + hdb.Trietkhauban + "' where DonhangbanID='" + hdb.DonhangbanID + "'";
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
        public bool xoaDHB(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from Donhangban where DonhangbanID='" + ma + "'";
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
        public DataTable TimKiemDHB(string tenhdb)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from Donhangban where  DonhangbanID LIKE N'%" + tenhdb + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}

