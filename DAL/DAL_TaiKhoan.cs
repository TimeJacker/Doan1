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
    public class DAL_TaiKhoan : DBConnect
    {

        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DataTable getUser()
        {
            _con.Open();
            da = new SqlDataAdapter("Select * from TaiKhoan", _con);
            dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public bool Login(DTO_TaiKhoan tk)
        {
            try
            {
                _con.Open();
                string sql = "select * from TaiKhoan where TK = '" + tk.TK + "' and MK = '" + tk.MK + "'";
                SqlCommand cmd = new SqlCommand(sql, _con);
                SqlDataReader dt = cmd.ExecuteReader();
                if (dt.Read() == true)
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
        public int kiemtratktrung(string tk)
        {
            _con.Open();
            int i;
            string sql = "Select count(*) from TaiKhoan where TK='" + tk.Trim() + "'";
            cmd = new SqlCommand(sql, _con);
            i = (int)cmd.ExecuteScalar();
            _con.Close();
            return i;
        }
        public bool themtk(DTO_TaiKhoan tk)
        {
            try
            {
                _con.Open();
                string sql = "Insert into TaiKhoan values('" + tk.TK + "',N'" + tk.MK + "')";
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
        public bool Doimk(DTO_TaiKhoan tk)
        {
            try
            {
                _con.Open();
                string sql = "Update TaiKhoan set MK=N'" + tk.MK + "' where TK='" + tk.TK + "'";
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
    }
}
