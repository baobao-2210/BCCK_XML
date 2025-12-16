using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Quanlybangiay.Class;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quanlybangiay.GUI
{
    public partial class frmPhieuNhapHang : UserControl
    {
        PhieuNhap pn = new PhieuNhap();
        FileXml Fxml = new FileXml();
        NhanVien nv = new NhanVien();
        private bool isAdding = false; private bool isEditing = false;
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }

        public void hienthiPhieuNhap()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("PhieuNhap.xml");
            dgvPhieuNhapHang.DataSource = dt;
        }

        private void dgvPhieuNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvPhieuNhapHang.CurrentRow.Index;
            txtMaPhieu.Text = dgvPhieuNhapHang.Rows[d].Cells[0].Value.ToString();
            txtMaHang.Text = dgvPhieuNhapHang.Rows[d].Cells[1].Value.ToString();
            txtMaNhanVien.Text = dgvPhieuNhapHang.Rows[d].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvPhieuNhapHang.Rows[d].Cells[3].Value.ToString();
            var ngayLapValue = dgvPhieuNhapHang.Rows[d].Cells[4].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(ngayLapValue) &&
                DateTime.TryParseExact(ngayLapValue, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out var parsedNgayLap))
            {
                dptNgaylapPhieu.Value = parsedNgayLap;
            }
            else
            {
                dptNgaylapPhieu.Text = ngayLapValue;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                isEditing = false;
                ClearForm();
                txtMaPhieu.Text = LayMaMoi().ToString();
                SetControlState(true);

                btnThem.Text = "Hủy";
                btnSave.Enabled = true;
            }
            else
            {
                isAdding = false;
                SetControlState(false);
                btnThem.Text = "Thêm";
                btnSave.Enabled = false;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ko tìm thấy máy in");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var mainForm = FindForm() as Quanlybangiay.frmMain;
            mainForm?.ClearWorkspace();
        }

        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {

            hienthiPhieuNhap();
        }
        private int LayMaMoi()
        {
            DataTable dt = Fxml.HienThi("PhieuNhap.xml");

            if (dt.Rows.Count == 0)
                return 1;

            int maxId = dt.AsEnumerable()
                          .Select(row => row.Field<int>("MaPhieu"))
                          .OrderByDescending(id => id)
                          .FirstOrDefault();

            return maxId + 1;
        }
        private void SetControlState(bool enabled)
        {
            txtMaHang.Enabled = enabled;
            txtMaNhanVien.Enabled = enabled;
            txtMaPhieu.Enabled = false;
            txtSoLuong.Enabled = enabled;

        }
        private void ClearForm()
        {
            txtMaHang.Text = "";
            txtMaNhanVien.Text = "";
            txtMaPhieu.Text = "";
            txtSoLuong.Text = "";
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
                       
                        return false;
                    }
                    row["SoLuong"] = soLuongHienTai + thayDoiSoLuong;
                    break;
                }
            }
            dtHang.WriteXml("Hang.xml", XmlWriteMode.WriteSchema);
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string maHang = txtMaHang.Text;
            int thayDoiSoLuong = int.Parse(txtSoLuong.Text);
            if (pn.kiemtraMaPhieu(txtMaPhieu.Text) == true)
            {
                MessageBox.Show("Mã phiếu đã tồn tại");
            }
            else
            {
                if (nv.kiemtra(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Ma Nhan Vien Khong");
                }
                else
                {
                    if (isAdding)
                    {
                        if (CậpNhậtSoLuongHang(maHang, thayDoiSoLuong))
                        {
                            DateTime dt = dptNgaylapPhieu.Value;
                            pn.themPN(txtMaPhieu.Text, txtMaHang.Text, txtMaNhanVien.Text, txtSoLuong.Text, dt.ToString("dd-MM-yyyy"));
                            MessageBox.Show("Thêm thành công");
                            hienthiPhieuNhap();
                            txtMaPhieu.Focus();
                        }
                    }
                    hienthiPhieuNhap();

                    isAdding = false;
                    isEditing = false;
                    SetControlState(false);
                    btnThem.Text = "Thêm";
                    btnThem.Enabled = true;
                    btnSave.Enabled = false;
                }

            }
        }
    }
}
