using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hau.GUI.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public PhongDTO Phong { get; set; }

        public string TenPhong{
           get { return Phong.TenPhong; } }
    }
}
