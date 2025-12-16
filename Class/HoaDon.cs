using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Quanlybangiay.Class
{
    class HoaDon
    {
        FileXml Fxml = new FileXml();
        public void themHD(string SoHoaDon, string MaNhanVien, string NgayLap, string TongTien)
        {
            string noiDung = "<_x0027_HoaDon_x0027_>" +
                    "<SoHoaDon>" + SoHoaDon + "</SoHoaDon>" +
                    "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                    "<NgayLap>" + NgayLap + "</NgayLap>" +
                    "<TongTien>" + TongTien + "</TongTien>" +
                    "</_x0027_HoaDon_x0027_>";
            Fxml.Them("HoaDon.xml", noiDung);
        }
        public void xoaHD(string SoHoaDon)
        {
            Fxml.Xoa("HoaDon.xml", "_x0027_HoaDon_x0027_", "SoHoaDon", SoHoaDon);
        }
        public DataTable LoadMaHoaDon()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("HoaDon.xml");
            return dt;
        }

        public DataTable LoadTable()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("HoaDon.xml");
            DataTable dtKhachHang = new DataTable();
            dtKhachHang = LoadMaHoaDon();
            int soDong = LoadMaHoaDon().Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < soDong; j++)
                {
                    if (dt.Rows[i]["SoHoaDon"].ToString().Equals(dtKhachHang.Rows[j]["SoHoaDon"].ToString()))
                    {
                        dt.Rows[i]["SoHoaDon"] = dtKhachHang.Rows[j]["MaNhanVien"];
                    }
                }
            }

            return dt;
        }

    }
}
