using Hau.GUI.DAO;
using Hau.GUI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hau.GUI.BLL
{
    public class PhongBLL
    {
        PhongDAO dao = new PhongDAO();
        public List<PhongDTO> ReadPhongList()
        {
            List<PhongDTO> lstArea = dao.ReadPhongList();
            return lstArea;
        }
    }
}
