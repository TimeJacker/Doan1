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
    public class DAL_ChiTietHoaDonBan : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách CtDonHangBan ra ngoài màn hình
        public DataTable getChiTietDHB()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from ChiTietDHB", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }

        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from ChiTietDHB where DonhangbanID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themctdhb(DTO_ChiTietHoaDonBan ctdhb)
        {
            try
            {
                _con.Open();
                string sql = "Insert into ChiTietDHB values('" + ctdhb.DonhangbanID + "',N'" + ctdhb.MathangID + "',N'" + ctdhb.Slban + "',N'" + ctdhb.DGban + "')";
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
        public bool suactdhb(DTO_ChiTietHoaDonBan ctdhb)
        {
            try
            {
                _con.Open();
                string sql = "Update ChiTietDHB set DonhangbanID=N'" + ctdhb.DonhangbanID + "', MathangID='" + ctdhb.MathangID + "', Slban=N'" + ctdhb.Slban + "',DGban=N'" + ctdhb.DGban + "' where DonhangbanID='" + ctdhb.DonhangbanID + "'";
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
        public bool xoactdhb(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from ChiTietDHB where DonhangbanID='" + ma + "'";
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
        public DataTable TimKiemctdhb(string ctdhb)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from ChiTietDHB where  DonhangbanID LIKE N'%" + ctdhb + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}
