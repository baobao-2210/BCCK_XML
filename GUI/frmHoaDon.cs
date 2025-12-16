using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Quanlybangiay.Class;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Quanlybangiay.GUI
{
    public partial class frmHoaDon : UserControl
    {
        FileXml Fxml = new FileXml();
        HoaDon H = new HoaDon();
        private bool isAdding = false; private bool isEditing = false;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void hienthiHoaDon()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("HoaDon.xml");
            dtgHoaDon.DataSource = dt;
        }




        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || cmbMaNhanVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi thanh toán!");
                return;
            }

            try
            {

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "HoaDon.pdf");

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);

                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                Paragraph title = new Paragraph("Hóa Đơn Bán Hàng", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new Paragraph(" ", vietnameseFont));

                doc.Add(new Paragraph($"Số Hóa Đơn: {textBox1.Text}", vietnameseFont));
                doc.Add(new Paragraph($"Mã Nhân Viên: {cmbMaNhanVien.SelectedValue}", vietnameseFont));
                doc.Add(new Paragraph($"Ngày Lập: {dateTimePicker1.Value.ToString("dd-MM-yyyy")}", vietnameseFont));
                doc.Add(new Paragraph($"Tổng tiền: {txtTongTien.Text} VNĐ", vietnameseFont));
                doc.Add(new Paragraph("-----------------------------------", vietnameseFont));
                doc.Add(new Paragraph("Cảm ơn quý khách đã mua hàng!", vietnameseFont));

                doc.Close();

                MessageBox.Show("Hóa đơn đã được lưu thành file PDF.", "Thông báo");

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                isEditing = false;
                ClearForm();
                textBox1.Text = LayMaMoi().ToString();
                SetControlState(true);

                btnThem.Text = "Hủy";
                button3.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                isAdding = false;
                SetControlState(false);
                btnThem.Text = "Thêm";
                button3.Enabled = true;
                btnSave.Enabled = false;
            }
        }
        private void SetControlState(bool enabled)
        {
            textBox1.Enabled = false;
            txtTongTien.Enabled = enabled;

        }
        private void ClearForm()
        {
            txtTongTien.Text = "";
            textBox1.Text = "";

        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            hienthiHoaDon();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            // Load dữ liệu cho ComboBox Mã Nhân Viên
            DataTable dtNhanVien = Fxml.HienThi("NhanVien.xml");
            cmbMaNhanVien.DataSource = dtNhanVien;
            cmbMaNhanVien.DisplayMember = "MaNhanVien";
            cmbMaNhanVien.ValueMember = "MaNhanVien";

            // Load dữ liệu cho ComboBox Mã Hàng
            DataTable dtHang = Fxml.HienThi("Hang.xml");
            cmbMaHang.DataSource = dtHang;
            cmbMaHang.DisplayMember = "MaHang";
            cmbMaHang.ValueMember = "MaHang";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            H.xoaHD(textBox1.Text);
            MessageBox.Show("Xóa thành công");
            hienthiHoaDon();
        }

        private void dtgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dtgHoaDon.CurrentRow.Index;
            textBox1.Text = dtgHoaDon.Rows[d].Cells[0].Value.ToString();
            cmbMaNhanVien.SelectedValue = dtgHoaDon.Rows[d].Cells[1].Value.ToString();
            var ngayLapValue = dtgHoaDon.Rows[d].Cells[2].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(ngayLapValue) &&
                DateTime.TryParseExact(ngayLapValue, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out var parsedNgayLap))
            {
                dateTimePicker1.Value = parsedNgayLap;
            }
            else
            {
                dateTimePicker1.Text = ngayLapValue;
            }
            txtTongTien.Text = dtgHoaDon.Rows[d].Cells[3].Value.ToString();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var mainForm = FindForm() as Quanlybangiay.frmMain;
            mainForm?.ClearWorkspace();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtDonGia.Text))
            {
                txtTongTien.Text = "";
                return;
            }

            try
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                int donGia = int.Parse(txtDonGia.Text);
                long tongTien = soLuong * donGia;
                txtTongTien.Text = tongTien.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng phải là một số nguyên hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Text = "";
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = Fxml.LayGiaTri("Hang.xml", "MaHang", cmbMaHang.SelectedValue.ToString(), "DonGia");

        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbMaHang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbMaHang.SelectedValue != null)
            {
                string donGia = Fxml.LayGiaTri("Hang.xml", "MaHang", cmbMaHang.SelectedValue.ToString(), "DonGia");
                txtDonGia.Text = donGia;
            }
        }
        private int LayMaMoi()
        {
            DataTable dt = Fxml.HienThi("HoaDon.xml");

            if (dt.Rows.Count == 0)
                return 1;

            int maxId = dt.AsEnumerable()
                          .Select(row => row.Field<int>("SoHoaDon"))
                          .OrderByDescending(id => id)
                          .FirstOrDefault();

            return maxId + 1;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string maHang = cmbMaHang.SelectedValue.ToString();
            int thayDoiSoLuong = -int.Parse(txtSoLuong.Text);
            if (isAdding)
            {
                if (CậpNhậtSoLuongHang(maHang, thayDoiSoLuong))
                {
                    DateTime dt = dateTimePicker1.Value;
                    H.themHD(textBox1.Text, cmbMaNhanVien.SelectedValue.ToString(), dt.ToString("dd-MM-yyyy"), txtTongTien.Text);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            hienthiHoaDon();

            isAdding = false;
            isEditing = false;
            SetControlState(false);
            btnThem.Text = "Thêm";
            btnThem.Enabled = true;
            button3.Enabled = true;
            btnSave.Enabled = false;
        }
        private bool CậpNhậtSoLuongHang(string maHang, int thayDoiSoLuong)
        {
            DataTable dtHang = Fxml.HienThi("Hang.xml");
            foreach (DataRow row in dtHang.Rows)
            {
                if (row["MaHang"].ToString().Equals(maHang))
                {
                    int soLuongHienTai = int.Parse(row["SoLuong"].ToString());
                    if (soLuongHienTai + thayDoiSoLuong < 0)
                    {
                        MessageBox.Show("Đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    row["SoLuong"] = soLuongHienTai + thayDoiSoLuong;
                    break;
                }
            }
            dtHang.WriteXml("Hang.xml", XmlWriteMode.WriteSchema);
            return true;
        }

    }
}
