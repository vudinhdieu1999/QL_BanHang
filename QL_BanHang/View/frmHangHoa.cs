﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QL_BanHang.Control;
using QL_BanHang.Obiect;

namespace QL_BanHang.View
{
    public partial class frmXe : Form
    {
        HangHoaCtr hhCtr = new HangHoaCtr();
        private int flagLuu = 0;
        public frmXe()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            DataTable dtDS = new System.Data.DataTable();
            dtDS = hhCtr.GetData();
            dtgvDS.DataSource = dtDS;
            binhding();
            DisEnl(false);
        }

        private void binhding()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dtgvDS.DataSource, "MaXe");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dtgvDS.DataSource, "TenXe");

            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dtgvDS.DataSource, "DonGia");
            txtSL.DataBindings.Clear();
            txtSL.DataBindings.Add("Text", dtgvDS.DataSource, "SoLuong");
        }

        private void clearData()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDonGia.Text = "";
            txtSL.Text = "";
        }

        private void addData(HangHoaObj xe)
        {
            xe.Ma_Xe = txtMa.Text.Trim();
            xe.DonGia = int.Parse(txtDonGia.Text.Trim());
            xe.SoLuong = int.Parse(txtSL.Text.Trim());
            xe.Ten_Xe = txtTen.Text.Trim();
        }

        private void addXe(HangHoaObj xe)
        {
            xe.SoLuong = int.Parse(txtSL.Text.Trim()) + xe.SoLuong;
        }

        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtMa.Enabled = e;
            txtTen.Enabled = e;
            txtDonGia.Enabled = e;
            txtSL.Enabled = e;
            btnNhapHang.Enabled = !e;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();
            DisEnl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa xe này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hhCtr.DelData(txtMa.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmHangHoa_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            HangHoaObj hhObj = new HangHoaObj();
            addData(hhObj);
            if (flagLuu == 0)
            {
                if (hhCtr.AddData(hhObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (flagLuu == 1)
            {
                if (hhCtr.UpdData(hhObj))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                addXe(hhObj);
                if (hhCtr.UpdData(hhObj))
                    MessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Nhập hàng không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmHangHoa_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                frmHangHoa_Load(sender, e);
            else
                return;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            flagLuu = 2;
            btnNhapHang.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtSL.Enabled = true;
            txtSL.Focus();
            txtSL.Text = "";


        }

       



    }
}
