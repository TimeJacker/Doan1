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
    public class DAL_ChiTietHoaDonNhap: DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Mặt Hàng ra ngoài màn hình
        public DataTable getChiTietDHN()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from ChiTietDHN", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from ChiTietDHN where DonhangnhapID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themctdhn(DTO_ChiTietHoaDonNhap ctdhn)
        {
            try
            {
                _con.Open();
                string sql = "Insert into ChiTietDHN values('" + ctdhn.DonhangnhapID + "',N'" + ctdhn.MathangID + "',N'" + ctdhn.Slnhap + "',N'" + ctdhn.DGnhap + "')";
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
        public bool suactdhn(DTO_ChiTietHoaDonNhap ctdhn)
        {
            try
            {
                _con.Open();
                string sql = "Update ChiTietDHN set DonhangnhapID=N'" + ctdhn.DonhangnhapID + "', MathangID='" + ctdhn.MathangID + "', Slnhap=N'" + ctdhn.Slnhap + "',DGnhap=N'" + ctdhn.DGnhap + "' where DonhangnhapID='" + ctdhn.DonhangnhapID + "'";
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
        public bool xoactdhn(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from ChiTietDHN where ChiTietDHNID='" + ma + "'";
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
        public DataTable TimKiemctdhn(string ctdhn)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from ChiTietDHN where  DonhangnhapID LIKE N'%" + ctdhn + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}

