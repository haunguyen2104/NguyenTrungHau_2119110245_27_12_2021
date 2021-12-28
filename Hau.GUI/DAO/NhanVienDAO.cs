using Hau.GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hau.GUI.DAO
{

    public class NhanVienDAO : DBConnection
    {
        //slide 62
        public List<NhanVienDTO> ReadNhanVien()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select MaNV,TenNV,NgaySinh,GioiTinh,NoiSinh,TenPhong from NhanVien NV, Phong P where NV.MaPhong=P.MaPhong ", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<NhanVienDTO> lstCus = new List<NhanVienDTO>();
            PhongDAO are = new PhongDAO();
            while (reader.Read())
            {
                NhanVienDTO cus = new NhanVienDTO();
                cus.MaNV = reader["MaNV"].ToString();
                cus.TenNV = reader["TenNV"].ToString();
                cus.NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                cus.GioiTinh = reader["GioiTinh"].ToString();
                cus.NoiSinh = reader["NoiSinh"].ToString();

                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }


        public void EditNhanVien(NhanVienDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update NhanVien set TenNV=@TenNV,MaPhong=@MaPhong where MaNV=@MaNV", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNV", cus.MaNV));
            cmd.Parameters.Add(new SqlParameter("@TenNV", cus.TenNV));
            cmd.Parameters.Add(new SqlParameter("@MaPhong", cus.TenPhong.MaPhong));
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void DeleteNhanVien(NhanVienDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from NhanVien where MaNV=@MaNV", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNV", cus.MaNV));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewNhanVien(NhanVienDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into NhanVien values(@MaNV,@TenNV,@MaPhong) ", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNV", cus.MaNV));
            cmd.Parameters.Add(new SqlParameter("@TenNV", cus.TenNV));
            cmd.Parameters.Add(new SqlParameter("@MaPhong", cus.TenPhong.MaPhong));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }

}
