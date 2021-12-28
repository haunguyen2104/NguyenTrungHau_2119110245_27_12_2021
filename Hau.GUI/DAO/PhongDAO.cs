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
            SqlCommand cmd = new SqlCommand("select * from phong", conn);
            SqlDataReader reader = cmd.ExecuteReader();
  

            List<PhongDTO> lstphg = new List<PhongDTO>();
            while (reader.Read())
            {
                PhongDTO phg = new PhongDTO();
                phg.MaPhong = int.Parse(reader["id"].ToString());
                phg.TenPhong = reader["name"].ToString();
                lstphg.Add(phg);
            }
            conn.Close();
            return lstphg;
        }
        public PhongDTO ReadPhong(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from phgs where id=" + id.ToString(), conn);
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
