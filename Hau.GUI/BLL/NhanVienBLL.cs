using Hau.GUI.DAO;
using Hau.GUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hau.GUI.BLL
{
    public class NhanVienBLL
    {

        NhanVienDAO dao = new NhanVienDAO();
        
        public List<NhanVienDTO> ReadNhanVien()
        {
            List<NhanVienDTO> lstNV = dao.ReadNhanVien();
            return lstNV;
        }
        public void NewNhanVien(NhanVienDTO NV)
        {
            dao.NewNhanVien(NV);
        }
        public void DeleteNhanVien(NhanVienDTO NV)
        {
            dao.DeleteNhanVien(NV);
        }
       public void EditNhanVien(NhanVienDTO NV)
        {
            dao.EditNhanVien(NV);
        }
    }
}
