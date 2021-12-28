using Hau.GUI.BLL;
using Hau.GUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hau.GUI
{
    public partial class Form1 : Form
    {
        NhanVienBLL cusBLL = new NhanVienBLL();
        PhongBLL phgBLL = new PhongBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbMa.Text = "";
            tbTen.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            ckbGioiTinh.Checked = false;
            tbNoiSinh.Text = "";
            cbPhong.Text = "";
        }

        private void dataView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dataView.Rows[index];
            if (row.Cells[0].Value != null)
            {
            
                tbMa.Text = row.Cells[0].Value.ToString();
                tbTen.Text = row.Cells[1].Value.ToString();
                dtNgaySinh.Text = row.Cells[2].Value.ToString();
                ckbGioiTinh.Text = row.Cells[3].Value.ToString();
                tbNoiSinh.Text = row.Cells[4].Value.ToString();
                cbPhong.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<NhanVienDTO> lstCus = cusBLL.ReadNhanVien();
            foreach (NhanVienDTO cus in lstCus)
            {
                dataView.Rows.Add(cus.MaNV, cus.TenNV, cus.NgaySinh,cus.GioiTinh,cus.NoiSinh,cus.TenPhong);
            }
            List<PhongDTO> lstPhong= phgBLL.ReadPhongList();
            foreach (PhongDTO phong in lstPhong)
            {
                cbPhong.Items.Add(phong);
            }
            cbPhong.DisplayMember = "TenPhong";
        }
    }
}
