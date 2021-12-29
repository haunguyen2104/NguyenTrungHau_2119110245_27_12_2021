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
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = tbMa.Text;
            nv.TenNV = tbTen.Text;
            nv.NgaySinh = dtNgaySinh.Value;
            if (ckbGioiTinh.Checked)
            {
                nv.GioiTinh = ckbGioiTinh.Text;
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.NoiSinh = tbNoiSinh.Text;
            nv.Phong = (PhongDTO)cbPhong.SelectedItem;
            if (String.IsNullOrEmpty(tbMa.Text) || String.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cusBLL.NewNhanVien(nv);
                dataView.Rows.Add(nv.MaNV,nv.TenNV,nv.NgaySinh,nv.GioiTinh,nv.NoiSinh,nv.Phong.TenPhong);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new  NhanVienDTO();
            nv.MaNV = tbMa.Text;
            //nv.TenNV = tbTen.Text;
            //nv.NgaySinh = dtNgaySinh.Value;
            //if (ckbGioiTinh.Checked)
            //{
            //    nv.GioiTinh = ckbGioiTinh.Text;
            //}
            //else
            //{
            //    nv.GioiTinh = "Nữ";
            //}
            //nv.NoiSinh = tbNoiSinh.Text;
            //nv.Phong = (PhongDTO)cbPhong.SelectedItem;
            cusBLL.DeleteNhanVien(nv);
            int index = dataView.CurrentCell.RowIndex;
            dataView.Rows.RemoveAt(index);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataView.CurrentRow;
            if (row != null)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = tbMa.Text;
                nv.TenNV = tbTen.Text;
                nv.NgaySinh = dtNgaySinh.Value;
                if (ckbGioiTinh.Checked)
                {
                    nv.GioiTinh = ckbGioiTinh.Text;
                }
                else
                {
                    nv.GioiTinh = "Nữ";
                }
                nv.NoiSinh = tbNoiSinh.Text;
                nv.Phong = (PhongDTO)cbPhong.SelectedItem;
                cusBLL.EditNhanVien(nv);

                row.Cells[0].Value = nv.MaNV;
                row.Cells[1].Value = nv.TenNV;
                row.Cells[2].Value = nv.NgaySinh;
                row.Cells[3].Value = nv.GioiTinh;
                row.Cells[4].Value = nv.NoiSinh;
                row.Cells[5].Value = nv.TenPhong;
            }
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
