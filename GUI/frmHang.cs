using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Quanlybangiay.Class;

using System.Windows.Forms;
using System.Xml;


namespace Quanlybangiay.GUI
{
    public partial class frmHang : UserControl
    {
        private bool isAdding = false;
        private bool isEditing = false;
        private bool isDragging = false;
        FileXml Fxml = new FileXml();
        Hang H = new Hang();
        NhaCungCap ncc = new NhaCungCap();
        public frmHang()
        {
            InitializeComponent();
        }
        public void hienthiHang()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("Hang.xml");
            dgvHang.DataSource = dt;
        }
        private string LayMaMoi()
        {
            DataTable dt = Fxml.HienThi("Hang.xml");

            if (dt.Rows.Count == 0)
                return "GI001";

            string maxId = dt.AsEnumerable()
                             .Select(row => row.Field<string>("MaHang"))
                             .OrderByDescending(id => id)
                             .FirstOrDefault();

            if (string.IsNullOrEmpty(maxId))
                return "GI001";

            int numPart = int.Parse(maxId.Substring(2)) + 1;
            return "GI0" + numPart.ToString("D2");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                isEditing = false;
                ClearForm();
                txtMaHang.Text = LayMaMoi();
                SetControlState(true);

                btnThem.Text = "Hủy";
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                isAdding = false;


                SetControlState(false);
                btnThem.Text = "Thêm";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnSave.Enabled = false;

            }
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            cboTimKiemMuc.Items.Add("Mã hàng");
            cboTimKiemMuc.Items.Add("Tên hàng");
            cboTimKiemMuc.SelectedIndex = 0;
            hienthiHang();
        }
        void LoadTable()
        {
            DataTable dt = new DataTable();
            dt = ncc.LoadTable();
            dgvHang.DataSource = dt;
        }
        private void LoadComboboxData()
        {
            DataTable dtKhachHang = Fxml.HienThi("NhaCungCap.xml");
            cbbMaNCC.DataSource = dtKhachHang;
            cbbMaNCC.DisplayMember = "TenNCC";
            cbbMaNCC.ValueMember = "MaNCC";


        }

        private void SetControlState(bool enabled)
        {
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = enabled;
            txtDonGia.Enabled = enabled;
            txtSoLuong.Enabled = enabled;
            txtDonViTinh.Enabled = enabled;
            cbbMaNCC.Enabled = enabled;
            btnChooseImage.Enabled = enabled;

        }
        private void ClearForm()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtDonViTinh.Text = "";
            pictureBox.Image = null;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                isEditing = true;
                isAdding = false;
                SetControlState(true);
                btnSua.Text = "Hủy bỏ";
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                isEditing = false;
                SetControlState(false);
                btnSua.Text = "Sửa";
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
                H.xoaH(txtMaHang.Text);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienthiHang();
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            hienthiHang();
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

            DataTable dt = Fxml.HienThi("Hang.xml");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable filteredTable = new DataTable();
            if (searchBy == "Mã hàng")
            {
                filteredTable = dt.AsEnumerable()
                                  .Where(row => row.Field<string>("MaHang").ToLower().Contains(searchTerm.ToLower()))
                                  .CopyToDataTable();
            }
            else if (searchBy == "Tên hàng")
            {
                filteredTable = dt.AsEnumerable()
                                  .Where(row => row.Field<string>("TenHang").ToLower().Contains(searchTerm.ToLower()))
                                  .CopyToDataTable();
            }

            if (filteredTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHang.DataSource = null;
            }
            else
            {
                dgvHang.DataSource = filteredTable;
            }
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvHang.CurrentRow.Index;
            txtMaHang.Text = dgvHang.Rows[d].Cells[0].Value.ToString();
            txtTenHang.Text = dgvHang.Rows[d].Cells[1].Value.ToString();
            txtDonViTinh.Text = dgvHang.Rows[d].Cells[2].Value.ToString();
            txtDonGia.Text = dgvHang.Rows[d].Cells[3].Value.ToString();
            txtSoLuong.Text = dgvHang.Rows[d].Cells[4].Value.ToString();
            cbbMaNCC.SelectedValue = dgvHang.Rows[d].Cells["MaNCC"].Value.ToString();
            string imagePath = dgvHang.Rows[d].Cells["HinhAnh"].Value.ToString();
            if (System.IO.File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
                MessageBox.Show("Không tìm thấy hình ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Hang.xml";
            try
            {
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Chưa có file cần mở trong bin/debug", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Tên hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAdding)
            {
                string duongDanHinhAnh = txtHinhAnh.Text;
                H.themH(txtMaHang.Text, txtTenHang.Text, txtDonViTinh.Text, txtDonGia.Text, txtSoLuong.Text, duongDanHinhAnh, cbbMaNCC.SelectedValue.ToString());
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (isEditing)
            {
                string duongDanHinhAnh = txtHinhAnh.Text;
                if (string.IsNullOrEmpty(duongDanHinhAnh))
                {

                    string maGiay = txtMaHang.Text;

                    DataTable dt = Fxml.HienThi("Hang.xml");


                    DataRow[] foundRows = dt.Select("MaHang = '" + maGiay + "'");

                    if (foundRows.Length > 0)
                    {
                        duongDanHinhAnh = foundRows[0]["HinhAnh"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm với mã " + maGiay, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                H.suaH(txtMaHang.Text, txtTenHang.Text, txtDonViTinh.Text, txtDonGia.Text, txtSoLuong.Text, duongDanHinhAnh, cbbMaNCC.SelectedValue.ToString());
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            hienthiHang();

            isAdding = false;
            isEditing = false;
            SetControlState(false);
            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*",
                Title = "Chọn ảnh sản phẩm"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                txtHinhAnh.Text = openFileDialog.FileName;
            }
        }

        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
