using Hau.GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hau.GUI.DAO
{
    public class PhongDAO:DBConnection
    {
        public List<PhongDTO> ReadPhongList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Phong", conn);
            SqlDataReader reader = cmd.ExecuteReader();
  

            List<PhongDTO> lstphg = new List<PhongDTO>();
            while (reader.Read())
            {
                PhongDTO phg = new PhongDTO();
                phg.MaPhong = int.Parse(reader["MaPhong"].ToString());
                phg.TenPhong = reader["TenPhong"].ToString();
                lstphg.Add(phg);
            }
            conn.Close();
            return lstphg;
        }
        public PhongDTO ReadPhong(int MaPhong)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Phong where MaPhong=" + MaPhong.ToString(), conn);
            PhongDTO phg = new PhongDTO();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                phg.MaPhong = int.Parse(reader["MaPhong"].ToString());
                phg.TenPhong = reader["TenPhong"].ToString();
            }
            conn.Close();
            return phg;
        }
    }
}
