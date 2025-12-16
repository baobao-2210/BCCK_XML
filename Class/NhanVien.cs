using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

namespace Quanlybangiay.Class
{
    class NhanVien
    {
        FileXml Fxml = new FileXml();
        public bool kiemtra(string MaNhanVien)
        {
            XmlTextReader reader = new XmlTextReader("TaiKhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode nodeList = doc.SelectSingleNode("/TaiKhoan[MaNhanVien='" + MaNhanVien + "']");
            reader.Close();
            bool kq = true;
            if (nodeList == null)
            {
                kq = false;
            }
            return kq;
        }
        public void themNV(string MaNhanVien, string TenNhanVien, string NgaySinh, string DiaChi, string SDT, string Email)
        {
            string noiDung = "<_x0027_NhanVien_x0027_>" +
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<TenNhanVien>" + TenNhanVien + "</TenNhanVien>" +
                    "<NgaySinh>" + NgaySinh + "</NgaySinh>" +
                    "<DiaChi>" + DiaChi + "</DiaChi>" +
                    "<SDT>" + SDT + "</SDT>" +
                    "<Email>" + Email + "</Email>" +
                    "</_x0027_NhanVien_x0027_>";
            Fxml.Them("NhanVien.xml", noiDung);
        }
        public void suaNV(string MaNhanVien, string TenNhanVien, string NgaySinh, string DiaChi, string SDT, string Email)
        {

            string noiDung = "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<TenNhanVien>" + TenNhanVien + "</TenNhanVien>" +
                    "<NgaySinh>" + NgaySinh + "</NgaySinh>" +
                    "<DiaChi>" + DiaChi + "</DiaChi>" +
                    "<SDT>" + SDT + "</SDT>" +
                    "<Email>" + Email + "</Email>";

            Fxml.Sua("NhanVien.xml", "_x0027_NhanVien_x0027_", "MaNhanVien", MaNhanVien, noiDung);


        }
        public void xoaNV(string MaNhanVien)
        {
            Fxml.Xoa("NhanVien.xml", "_x0027_NhanVien_x0027_", "MaNhanVien", MaNhanVien);
        }
        public DataTable LoadMaNhanVien()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NhanVien.xml");
            return dt;
        }
        public DataTable LoadTable()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NhanVien.xml");
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = LoadMaNhanVien();
            int soDong = LoadMaNhanVien().Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < soDong; j++)
                {
                    if (dt.Rows[i]["MaNhanVien"].ToString().Equals(dtKhachHang.Rows[j]["TenNhanVien"].ToString()))
                    {
                        dt.Rows[i]["MaNhanVien"] = dtKhachHang.Rows[j]["TenNhanVien"];
                    }
                }
            }

            return dt;
        }
        public bool kiemtraNgayThang(string MaNhanVien, int Ngay, int Thang, int Nam)
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("ChamCong.xml");
            dt.DefaultView.RowFilter = "MaNhanVien ='" + MaNhanVien + "' AND Ngay='" + Ngay + "' AND Thang='" + Thang + "' AND Nam='" + Nam + "'";
            if (dt.DefaultView.Count > 0)

                return true;

            return false;
        }
       
    }
}
