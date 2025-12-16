using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quanlybangiay.Class;
using System.Xml;

namespace Quanlybangiay.GUI
{
    public partial class frmNhanVien : UserControl
    {
        private bool isAdding = false;
        private bool isEditing = false;
        private bool isDragging = false;
        NhanVien nv = new NhanVien();
        FileXml Fxml = new FileXml();
        string MaNhanVien, TenNhanVien, NgaySinh, DiaChi, SDT, Email;
        public frmNhanVien()
        {
            InitializeComponent();

        }
        public void hienthiNhanVien()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NhanVien.xml");
            dgvNhanVien.DataSource = dt;

        }
        public void LoadDuLieu()
        {

            TenNhanVien = txtTenNhanVien.Text;
            DiaChi = txtDiaChi.Text;
            SDT = txtSDT.Text;
            Email = txtEmail.Text;


        }
        // Khởi tạo form: khóa mã NV, thiết lập tùy chọn tìm kiếm và nạp danh sách nhân viên.
        private void NhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            cboTimKiemMuc.Items.Add("Mã nhân viên");
            cboTimKiemMuc.Items.Add("Tên nhân viên");
            cboTimKiemMuc.SelectedIndex = 0;
            hienthiNhanVien();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvNhanVien.CurrentRow.Index;
            txtMaNhanVien.Text = dgvNhanVien.Rows[d].Cells[0].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[d].Cells[1].Value.ToString();
            var ngaySinhValue = dgvNhanVien.Rows[d].Cells[2].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(ngaySinhValue) &&
                DateTime.TryParseExact(ngaySinhValue, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out var parsedNgaySinh))
            {
                dtpNgaySinh.Value = parsedNgaySinh;
            }
            else
            {
                dtpNgaySinh.Text = ngaySinhValue;
            }
            txtDiaChi.Text = dgvNhanVien.Rows[d].Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[d].Cells[4].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[d].Cells[5].Value.ToString();
        }
        // Sinh mã nhân viên mới: lấy mã lớn nhất hiện có trong XML rồi +1 (dạng NVxxx).
        private string LayMaMoi()
        {
            DataTable dt = Fxml.HienThi("NhanVien.xml");

            if (dt.Rows.Count == 0)
                return "NV001";

            string maxId = dt.AsEnumerable()
                             .Select(row => row.Field<string>("MaNhanVien"))
                             .OrderByDescending(id => id)
                             .FirstOrDefault();

            if (string.IsNullOrEmpty(maxId))
                return "NV001";

            int numPart = int.Parse(maxId.Substring(2)) + 1;
            return "NV0" + numPart.ToString("D2");
        }
        private void SetControlState(bool enabled)
        {
            txtMaNhanVien.Enabled = false;
            txtDiaChi.Enabled = enabled;
            txtTenNhanVien.Enabled = enabled;
            txtSDT.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            txtEmail.Enabled = enabled;

        }
        private void ClearForm()
        {
            txtMaNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtTenNhanVien.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";

        }

        // Xử lý nút Thêm/Hủy thêm: bật chế độ thêm mới (clear form, sinh mã, mở control) hoặc hủy về trạng thái mặc định.
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                isEditing = false;

                ClearForm();

                txtMaNhanVien.Text = LayMaMoi();
                SetControlState(true);
                DateTime dt = DateTime.Parse(dtpNgaySinh.Text);
                btnThem.Text = "Hủy";
                tbnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnSave.Enabled = true;

            }
            else
            {
                isAdding = false;


                SetControlState(false);
                btnThem.Text = "Thêm";
                tbnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnXoa.Enabled = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAdding)
            {
                var ngaySinh = dtpNgaySinh.Value.ToString("dd-MM-yyyy");
                nv.themNV(txtMaNhanVien.Text, txtTenNhanVien.Text, ngaySinh,txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (isEditing)
            {
                var ngaySinh = dtpNgaySinh.Value.ToString("dd-MM-yyyy");
                nv.suaNV(txtMaNhanVien.Text, txtTenNhanVien.Text, ngaySinh, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            hienthiNhanVien();

            isAdding = false;
            isEditing = false;
            SetControlState(false);
            btnThem.Text = "Thêm";
            tbnSua.Text = "Sửa";
            btnThem.Enabled = true;
            tbnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = false;
        }

        private void tbnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                isEditing = true;
                isAdding = false;
                SetControlState(true);
                tbnSua.Text = "Hủy bỏ";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                isEditing = false;
                SetControlState(false);
                tbnSua.Text = "Sửa";
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSave.Enabled = false;

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân  viên này không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                nv.xoaNV(txtMaNhanVien.Text);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienthiNhanVien();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtNoiDungTimKiem.Text.Trim();
            string searchBy = cboTimKiemMuc.SelectedItem.ToString();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = Fxml.HienThi("NhanVien.xml");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable filteredTable = new DataTable();
            if (searchBy == "Mã nhân viên")
            {
                filteredTable = dt.AsEnumerable()
                                  .Where(row => row.Field<string>("MaNhanVien").ToLower().Contains(searchTerm.ToLower()))
                                  .CopyToDataTable();
            }
            else if (searchBy == "Tên nhân viên")
            {
                filteredTable = dt.AsEnumerable()
                                  .Where(row => row.Field<string>("TenNhanVien").ToLower().Contains(searchTerm.ToLower()))
                                  .CopyToDataTable();
            }

            if (filteredTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNhanVien.DataSource = null;
            }
            else
            {
                dgvNhanVien.DataSource = filteredTable;
            }
        }

        private void tbnHienThi_Click(object sender, EventArgs e)
        {
            hienthiNhanVien();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\NhanVien.xml";
            try
            {
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Chưa có file cần mở trong bin/debug", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
