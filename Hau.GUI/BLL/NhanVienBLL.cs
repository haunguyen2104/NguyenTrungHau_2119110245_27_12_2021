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
            List<NhanVienDTO> lstCus = dao.ReadNhanVien();
            return lstCus;
        }
        public void NewNhanVien(NhanVienDTO cus)
        {
            dao.NewNhanVien(cus);
        }
        public void DeleteNhanVien(NhanVienDTO cus)
        {
            dao.DeleteNhanVien(cus);
        }
       public void EditNhanVien(NhanVienDTO cus)
        {
            dao.EditNhanVien(cus)
        }
    }
}
