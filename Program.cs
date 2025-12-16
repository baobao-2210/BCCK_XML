using Quanlybangiay.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quanlybangiay
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Vòng lặp để cho phép đăng nhập/đăng xuất nhiều lần
            while (true)
            {
                // Hiển thị form đăng nhập
                frmDangNhap frmLogin = new frmDangNhap();
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, mở form main
                    frmMain frm = new frmMain();
                    frm.QuyenDangNhap(true);
                    Application.Run(frm);
                    // Khi form main đóng (do đăng xuất), quay lại vòng lặp để hiển thị form đăng nhập
                }
                else
                {
                    // Nếu đăng nhập bị hủy (đóng form), thoát ứng dụng
                    break;
                }
            }
        }
    }
}
