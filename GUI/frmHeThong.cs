using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlybangiay.GUI;
using Quanlybangiay.Class;

namespace Quanlybangiay
{
    public partial class frmMain : Form
    {
        FileXml Fxml = new FileXml();
        Main M = new Main();
        HeThong HT = new HeThong();
        public frmMain()
        {
            InitializeComponent();
        }
        public static string tenDNMain = "";
        public static string maNVMain = "";
        void ThongTinDangNhap()
        {

            lblHoTen.Text = M.HoTen(tenDNMain);
            lblTen.Text = M.HoTen(tenDNMain);
            

        }

        private UserControl currentWorkspace;

        // Thay nội dung panel workspace bằng UserControl mới (dock full, dọn control cũ).
        private void LoadWorkspaceControl(UserControl control)
        {
            if (pnlWorkspace == null)
            {
                return;
            }

            pnlWorkspace.SuspendLayout();
            pnlWorkspace.Controls.Clear();
            currentWorkspace = null;

            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                pnlWorkspace.Controls.Add(control);
                currentWorkspace = control;
            }

            pnlWorkspace.ResumeLayout();
        }

        public void ClearWorkspace()
        {
            LoadWorkspaceControl(null);
        }

        public void QuyenDangNhap(bool e)
        {
            mnuHeThong.Enabled = e;
            mnuKinhDoanh.Enabled = e;
            mnuQLNhanSu.Enabled = e;
            đăngXuấtToolStripMenuItem.Enabled = e;
            lblQuyen.Visible = e;
            lblHoTen.Visible = e;
            chuyểnĐổiDữLiệuToolStripMenuItem.Enabled = e;
            quảnLýPhiếuNhậpToolStripMenuItem.Enabled = e;
            đăngNhậpToolStripMenuItem.Enabled = !e;
            
            
            if (tenDNMain.Equals("admin"))
            {
                mnuQLNhanSu.Enabled = e;
                lblQuyen.Visible = e;
                lblHoTen.Visible = e;
                
                lblQuyen.Text = "Admin";
            }
            else
            {
                mnuQLNhanSu.Enabled = false;
                chuyểnĐổiDữLiệuToolStripMenuItem.Enabled = false;
                mnuHeThong.Enabled = true;
                lblQuyen.Text = "Nhân Viên";
                
            }
            if (e)
            {
                ThongTinDangNhap();
            }
            else
            {
                LoadWorkspaceControl(null);
            }
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmDangNhap())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    QuyenDangNhap(true);
                    đăngXuấtToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void từSQLXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HT.TaoXML();
                MessageBox.Show("Tạo XML thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
                      
         }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Không tự động mở form đăng nhập nữa vì đã đăng nhập từ form đăng nhập
            // Chỉ gán quyền nếu đã có thông tin đăng nhập
            if (!string.IsNullOrEmpty(tenDNMain))
            {
                QuyenDangNhap(true);
            }
            else
            {
                QuyenDangNhap(false);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reset thông tin đăng nhập
            QuyenDangNhap(false);
            tenDNMain = "";
            maNVMain = "";
            mnuHeThong.Enabled = true;
            đăngXuấtToolStripMenuItem.Enabled = false;
            lblHoTen.Text = "";
            lblQuyen.Text = "";
            
            // Đóng form main để quay lại form đăng nhập
            this.Close();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorkspaceControl(new frmNhanVien());
        }

        private void quảnLýTàiKhoảnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorkspaceControl(new frmTaiKhoanNV());
        }

        private void quảnLýHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorkspaceControl(new frmHang());
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorkspaceControl(new frmNhaCungCap());
        }



        private void từXMLSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HT.CapNhapSQL();
                MessageBox.Show("Cập nhập SQL server thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorkspaceControl(new frmHoaDon());
        }

        private void mnuKinhDoanh_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorkspaceControl(new frmPhieuNhapHang());
        }
    }
}
