using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_BanHang.View
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
            this.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
            this.Show();
        }

        private void btnXe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmXe frm = new frmXe();
            frm.ShowDialog();
            this.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHoaDon frm = new frmHoaDon();
            frm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;

        }
    }
}
