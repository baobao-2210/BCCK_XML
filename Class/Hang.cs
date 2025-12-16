using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Quanlybangiay.Class
{
    class Hang
    {
        FileXml Fxml = new FileXml();
        public bool kiemtraMaHang(string MaHang)
        {
            XmlTextReader reader = new XmlTextReader("Hang.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/Hang[MaHang='" + MaHang + "']");
            reader.Close();
            bool kq = true;
            if (node != null)
            {
                return kq = true;
            }
            else
            {
                return kq = false;

            }

        }
        public void themH(string MaHang, string TenHang, string DonViTinh, string DonGia, string SoLuong, string HinhAnh, string MaNCC)
        {
            string noiDung = "<_x0027_Hang_x0027_>" +
                    "<MaHang>" + MaHang + "</MaHang>" +
                    "<TenHang>" + TenHang + "</TenHang>" +
                    "<DonViTinh>" + DonViTinh + "</DonViTinh>" +
                    "<DonGia>" + DonGia + "</DonGia>" +
                    "<SoLuong>" + SoLuong + "</SoLuong>" +
                     "<HinhAnh>" + HinhAnh + "</HinhAnh>" +
                    "<MaNCC>" + MaNCC + "</MaNCC>" +
                    "</_x0027_Hang_x0027_>";
            Fxml.Them("Hang.xml", noiDung);
        }
        public void suaH(string MaHang, string TenHang, string DonViTinh, string DonGia, string SoLuong, string HinhAnh, string MaNCC)
        {

            string noiDung = "<MaHang>" + MaHang + "</MaHang>" +
                    "<TenHang>" + TenHang + "</TenHang>" +
                    "<DonViTinh>" + DonViTinh + "</DonViTinh>" +
                    "<DonGia>" + DonGia + "</DonGia>" +
                    "<SoLuong>" + SoLuong + "</SoLuong>" +
                    "<HinhAnh>" + HinhAnh + "</HinhAnh>" +
                    "<MaNCC>" + MaNCC + "</MaNCC>" ;

            Fxml.Sua("Hang.xml", "_x0027_Hang_x0027_", "MaHang", MaHang, noiDung);

        }
        public void xoaH(string MaHang)
        {
            Fxml.Xoa("Hang.xml", "_x0027_Hang_x0027_", "MaHang", MaHang);
        }
        public DataTable LoadMaHang()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("Hang.xml");
            return dt;
        }

        public DataTable LoadTable()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("Hang.xml");
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = LoadMaHang();
            int soDong = LoadMaHang().Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < soDong; j++)
                {
                    if (dt.Rows[i]["MaHang"].ToString().Equals(dtKhachHang.Rows[j]["MaHang"].ToString()))
                    {
                        dt.Rows[i]["MaHang"] = dtKhachHang.Rows[j]["TenHang"];
                    }
                }
            }

            return dt;
        }

    }

}
