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
    public partial class frmNhaCungCap : UserControl
    {

        private bool isAdding = false;
        private bool isEditing = false;
        private bool isDragging = false;
        FileXml Fxml = new FileXml();
        NhaCungCap ncc = new NhaCungCap();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        public void hienthiNCC()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("NhaCungCap.xml");
            dgvNhaCungCap.DataSource = dt;
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            cboTimKiemMuc.Items.Add("Mã nhà cung cấp");
            cboTimKiemMuc.Items.Add("Tên nhà cung cấp");
            cboTimKiemMuc.SelectedIndex = 0;
            hienthiNCC();
        }
        private string LayMaMoi()
        {
            DataTable dt = Fxml.HienThi("NhaCungCap.xml");

            if (dt.Rows.Count == 0)
                return "NC001";

            string maxId = dt.AsEnumerable()
                             .Select(row => row.Field<string>("MaNCC"))
                             .OrderByDescending(id => id)
                             .FirstOrDefault();

            if (string.IsNullOrEmpty(maxId))
                return "NC001";

            int numPart = int.Parse(maxId.Substring(2)) + 1;
            return "NC0" + numPart.ToString("D2");
        }
        private void SetControlState(bool enabled)
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtMoTa.Enabled = enabled;

        }
        private void ClearForm()
        {
            txtTenNCC.Text = "";
            txtMaNCC.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtMoTa.Text = "";

        }

  

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            hienthiNCC();
        }


        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvNhaCungCap.CurrentRow.Index;
            txtMaNCC.Text = dgvNhaCungCap.Rows[d].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.Rows[d].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap.Rows[d].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhaCungCap.Rows[d].Cells[3].Value.ToString();
            txtEmail.Text = dgvNhaCungCap.Rows[d].Cells[4].Value.ToString();
            txtMoTa.Text = dgvNhaCungCap.Rows[d].Cells[5].Value.ToString();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                isEditing = false;
                ClearForm();
                txtMaNCC.Text = LayMaMoi();
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
                btnXoa.Enabled = false;

            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân  viên này không?",
                                                    "Xác nhận xóa",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ncc.xoaNCC(txtMaNCC.Text);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienthiNCC();
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string searchTerm = txtNoiDungTimKiem.Text.Trim();
            string searchBy = cboTimKiemMuc.SelectedItem.ToString();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = Fxml.HienThi("NhaCungCap.xml");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable filteredTable = new DataTable();
            if (searchBy == "Mã nhà cung cấp")
            {
                filteredTable = dt.AsEnumerable()
                                  .Where(row => row.Field<string>("MaNCC").ToLower().Contains(searchTerm.ToLower()))
                                  .CopyToDataTable();
            }
            else if (searchBy == "Tên nhà cung cấp")
            {
                filteredTable = dt.AsEnumerable()
                                  .Where(row => row.Field<string>("TenNCC").ToLower().Contains(searchTerm.ToLower()))
                                  .CopyToDataTable();
            }

            if (filteredTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNhaCungCap.DataSource = null;
            }
            else
            {
                dgvNhaCungCap.DataSource = filteredTable;
            }
        }

        private void btnHienThi_Click_1(object sender, EventArgs e)
        {
            hienthiNCC();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\NhaCungCap.xml";
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
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Tên hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAdding)
            {
                ncc.themNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtMoTa.Text);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (isEditing)
            {
                ncc.suaNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtMoTa.Text);
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            hienthiNCC();

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
    }
    }

