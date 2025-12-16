using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Quanlybangiay.Class
{
    class HeThong
    {
        FileXml Fxml = new FileXml();
        public void TaoXML()
        {
            Fxml.TaoXML("ChiTietHoaDon");
            Fxml.TaoXML("Hang");
            Fxml.TaoXML("HoaDon");
            Fxml.TaoXML("NhanVien");
            Fxml.TaoXML("NhaCungCap");
            Fxml.TaoXML("PhieuNhap");
            Fxml.TaoXML("TaiKhoan");
            
        }
        void CapNhapTungBang(string tenBang)
        {
            string duongDan = @"" + tenBang + ".xml";
            DataTable table = Fxml.HienThi(duongDan);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "insert into " + tenBang + " values(";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += "N'" + table.Rows[i][j].ToString().Trim() + "',";
                }
                sql += "N'" + table.Rows[i][table.Columns.Count - 1].ToString().Trim() + "'";
                sql += ")";
                //MessageBox.Show(sql);
                Fxml.InsertOrUpDateSQL(sql);
            }
        }
        public void CapNhapSQL()
        {
            Fxml.InsertOrUpDateSQL("DELETE FROM ChiTietHoaDon");
            Fxml.InsertOrUpDateSQL("DELETE FROM HoaDon");
            Fxml.InsertOrUpDateSQL("DELETE FROM PhieuNhap");
            Fxml.InsertOrUpDateSQL("DELETE FROM Hang");
            Fxml.InsertOrUpDateSQL("DELETE FROM TaiKhoan");
            Fxml.InsertOrUpDateSQL("DELETE FROM NhanVien");
            Fxml.InsertOrUpDateSQL("DELETE FROM NhaCungCap");

            //Cập nhập toàn bộ dữ liệu các bảng
            CapNhapTungBang("NhaCungCap");
            CapNhapTungBang("NhanVien");
            CapNhapTungBang("TaiKhoan");
            CapNhapTungBang("Hang");
            CapNhapTungBang("HoaDon");
            CapNhapTungBang("ChiTietHoaDon");
            CapNhapTungBang("PhieuNhap");
        }
        

    }
}
