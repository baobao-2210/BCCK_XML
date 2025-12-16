using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlybangiay.Class;
using Quanlybangiay;

namespace Quanlybangiay.GUI
{
    public partial class frmDangNhap : Form
    {
        FileXml Fxml = new FileXml();
        DangNhap dn = new DangNhap();
        
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Equals("") || txtMK.Text.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống các trường!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTenDN.Focus();
            }
            else
            {

                if (dn.kiemtraTTDN("TaiKhoan.xml",txtTenDN.Text, txtMK.Text) == true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    dn.layMaQuyen();
                    frmMain.tenDNMain = txtTenDN.Text;
                    
                    // Đánh dấu đăng nhập thành công và đóng form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenDN.Text = "";
                    txtMK.Text = "";
                    txtTenDN.Focus();
                }
            }
        }
        public string HoTen(string MaNhanVien)
        {
            return Fxml.LayGiaTri("NhanVien.xml", "MaNhanVien", MaNhanVien, "TenNhanVien"); ;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
