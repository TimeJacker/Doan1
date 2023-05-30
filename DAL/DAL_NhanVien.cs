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
    public class DAL_NhanVien : DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //hiển thị danh sách Nhân viên ra ngoài màn hình
        public DataTable getNhanVien()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from NhanVien", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        void thucthisql(string sql)
        {
            _con.Open();
            cmd = new SqlCommand(sql, _con);
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public int kiemtramatrung(string ma)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from NhanVien where NhanVienID='" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themNV(DTO_NhanVien nv)
        {
            try
            {
                _con.Open();
                string ngay = string.Format("{0}/{1}/{2}", nv.NgaysinhNV.Year, nv.NgaysinhNV.Month, nv.NgaysinhNV.Day);
                string sql = "Insert into NhanVien values('" + nv.NhanVienID + "',N'" + nv.HotenNV + "',N'" + nv.GioitinhNV + "','" + ngay + "',N'" + nv.diachiNV + "',N'" + nv.EmailNV + "','" + nv.SdtNV + "')";
                SqlCommand cmd = new SqlCommand(sql,_con);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                _con.Close();   
            }
            return false;
        }
        public bool suaNV(DTO_NhanVien nv)
        {
            try
            {
                _con.Open();
                string ngay = string.Format("{0}/{1}/{2}", nv.NgaysinhNV.Year, nv.NgaysinhNV.Month, nv.NgaysinhNV.Day);
                string sql = "Update NhanVien set HotenNV=N'" + nv.HotenNV + "',GioitinhNV=N'" + nv.GioitinhNV + "', NgaysinhNV='" + ngay + "', diachiNV=N'" + nv.diachiNV + "',EmailNV='" + nv.EmailNV + "',SdtNV=N'" + nv.SdtNV + "' where NhanVienID='" + nv.NhanVienID + "'";
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
        public bool xoaNV(string ma)
        {
            try
            {
                _con.Open();
                string sql = "Delete from NhanVien where NhanVienID='" + ma + "'";
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
        public DataTable TimKiemNV(string tennv)
        {
            _con.Open();
            SqlDataAdapter datk = new SqlDataAdapter("Select * from NhanVien where  HotenNV LIKE N'%" + tennv + "%'", _con);
            DataTable dttk = new DataTable();
            datk.Fill(dttk);
            _con.Close();
            return dttk;
        }
    }
}
