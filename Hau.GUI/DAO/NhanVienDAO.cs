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
            SqlCommand cmd = new SqlCommand("Select * from NhanVien", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<NhanVienDTO> lstCus = new List<NhanVienDTO>();
            PhongDAO phg = new PhongDAO();
            while (reader.Read())
            {
                NhanVienDTO cus = new NhanVienDTO();
                cus.MaNV = reader["MaNV"].ToString();
                cus.TenNV = reader["TenNV"].ToString();
                cus.NgaySinh = DateTime.Parse(reader["NgaySinh"].ToString());
                cus.GioiTinh = reader["GioiTinh"].ToString();
                cus.NoiSinh = reader["NoiSinh"].ToString();
                cus.Phong = phg.ReadPhong(int.Parse(reader["MaPhong"].ToString()));

                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }


        public void EditNhanVien(NhanVienDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update NhanVien set TenNV=@TenNV,NgaySinh=@NgaySinh,GioiTinh=@GioiTinh,NoiSinh=@NoiSinh,MaPhong=@MaPhong where MaNV=@MaNV", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNV", cus.MaNV));
            cmd.Parameters.Add(new SqlParameter("@TenNV", cus.TenNV));
            cmd.Parameters.Add(new SqlParameter("@NgaySinh", cus.NgaySinh));
            cmd.Parameters.Add(new SqlParameter("@GioiTinh", cus.GioiTinh));
            cmd.Parameters.Add(new SqlParameter("@NoiSinh", cus.NoiSinh));
            cmd.Parameters.Add(new SqlParameter("@MaPhong", cus.Phong.MaPhong));
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
            SqlCommand cmd = new SqlCommand("insert into NhanVien values(@MaNV,@TenNV,@NgaySinh,@GioiTinh,@NoiSinh,@MaPhong) ", conn);
            cmd.Parameters.Add(new SqlParameter("@MaNV", cus.MaNV));
            cmd.Parameters.Add(new SqlParameter("@TenNV", cus.TenNV));
            cmd.Parameters.Add(new SqlParameter("@NgaySinh", cus.NgaySinh));
            cmd.Parameters.Add(new SqlParameter("@GioiTinh", cus.GioiTinh));
            cmd.Parameters.Add(new SqlParameter("@NoiSinh", cus.NoiSinh));
            cmd.Parameters.Add(new SqlParameter("@MaPhong", cus.Phong.MaPhong));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }

}
