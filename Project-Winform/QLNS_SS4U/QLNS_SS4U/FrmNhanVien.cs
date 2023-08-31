using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace QLNS_SS4U
{
    public partial class FrmNhanVien : Form
    {
        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;
        private int currentIndex = 0;
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            _showHide(true);
            HienThiDanhSach();
            DisplayData();
            LoadPhongBanComboBox();



            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            ckbTinhTrang.BackColor = Color.Transparent;
            
        }

        private void LoadPhongBanComboBox()
        {
            // Tạo kết nối SQL
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();

            // Tạo câu truy vấn lấy danh sách phòng ban
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM PhongBan", sqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách phòng ban cũ (nếu có)
            cmbTenPB.Items.Clear();

            // Thêm giá trị mặc định
            cmbTenPB.Items.Add("Tất cả các phòng ban");

            // Duyệt qua từng dòng kết quả và thêm vào combobox
            while (reader.Read())
            {
                string tenPB = reader.GetString(1);
                cmbTenPB.Items.Add(tenPB);
            }

            // Đóng đọc dữ liệu
            reader.Close();

            // Đóng kết nối SQL
            sqlCon.Close();

            // Chọn giá trị mặc định
            cmbTenPB.SelectedIndex = 0;
        }

        private void HienThiDanhSach()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT NV.MaNV, NV.TenNV, NV.NgaSinh, NV.GioiTinh, NV.Email, NV.DienThoai, NV.DiaChi, NV.CCCD, PB.TenPB, CV.TenChucVu, L.TenMucLuong, NV.DangLamViec " +
                " FROM NhanVien NV INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu INNER JOIN Luong L ON NV.MaLuong = L.MaLuong";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvNhanVien.Items.Clear();
            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(2);
                string gioitinh = reader.GetString(3);
                string email = reader.GetString(4);
                string dienthoai = reader.GetString(5);
                string diachi = reader.GetString(6);
                string cccd = reader.GetString(7);
                string tenphongban = reader.GetString(8);
                string tenchucvu = reader.GetString(9);
                string tenmucluong = reader.GetString(10);
                bool hieuluc = reader.GetBoolean(11);


                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(ngaysinh.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(gioitinh);
                lvi.SubItems.Add(email);
                lvi.SubItems.Add(dienthoai);
                lvi.SubItems.Add(diachi);
                lvi.SubItems.Add(cccd);
                lvi.SubItems.Add(tenphongban);
                lvi.SubItems.Add(tenchucvu);
                lvi.SubItems.Add(tenmucluong);
                lvi.SubItems.Add(hieuluc.ToString());

                lvNhanVien.Items.Add(lvi);
                txtMauHienHanh.Text = lvi.SubItems[0].Text;
                txtTongMau.Text = lvNhanVien.Items.Count.ToString();

            }
            reader.Close();
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _showHide(false);
            txtID.Text = "";
            txtTenNV.Text = "";
            dateTimePickerNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtBaoHiem.Text = "";
            txtEmail.Text = "";
            LoadDataToComboBox("SELECT TenPB FROM PhongBan", cmbPhongBan);
            LoadDataToComboBox("SELECT TenChucVu FROM ChucVu", cmbChucVu);
            LoadDataToComboBox("SELECT TenMucLuong FROM Luong", cmbMucLuong);
            LoadDataToComboBox("SELECT DISTINCT GioiTinh FROM NhanVien", cmbGioiTinh);
            ckbTinhTrang.Checked = false; // Giá trị mặc định khi không check
            LoadDataToCheckBox("SELECT BiXoa FROM NhanVien", ckbTinhTrang);
            txtID.Focus();
        }
        private void LoadDataToComboBox(string query, ComboBox comboBox)
        {
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            comboBox.Items.Clear();
            while (reader.Read())
            {
                string item = reader.GetString(0);
                comboBox.Items.Add(item);
            }

            reader.Close();
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private void LoadDataToCheckBox(string query, CheckBox checkBox)
        {
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                bool value = reader.GetBoolean(0);
                checkBox.Checked = value;
            }

            reader.Close();
        }

        

        private void KhongdungPar()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            

            //Lấy dữ liệu
            string manv = txtID.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string ngaysinh = dateTimePickerNgaySinh.Value.ToString("yyyy-MM-dd");
            string gioitinh = cmbGioiTinh.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dienthoai = txtDienThoai.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string cccd = txtBaoHiem.Text.Trim();
            string tenphongban = cmbPhongBan.Text.Trim();
            string tenchucvu = cmbChucVu.Text.Trim();
            string tenmucluong = cmbMucLuong.Text.Trim();
            string hieuluc = ckbTinhTrang.Checked ? "1" : "0";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO NhanVien (MaNV, TenNV, NgaSinh, GioiTinh, Email, DienThoai, DiaChi, CCCD, MaPB, MaChucVu, MaLuong, DangLamViec) " +
                          "SELECT '" + manv + "', '" + tennv + "', '" + ngaysinh + "', N'" + gioitinh + "', '" + email + "', '" + dienthoai + "', " +
                          "'" + diachi + "', '" + cccd + "', PB.MaPB, CV.MaChucVu, L.MaLuong, '" + hieuluc + "' " +
                          "FROM PhongBan PB, ChucVu CV, Luong L " +
                          "WHERE PB.TenPB = N'" + tenphongban + "' AND CV.TenChucVu = N'" + tenchucvu + "' AND L.TenMucLuong = N'" + tenmucluong + "'";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();

            if (kq > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            _showHide(true);
            KhongdungPar();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _showHide(true);
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.CommandText = "UPDATE NhanVien " +
                     "SET NhanVien.MaNV = '" + txtID.Text.Trim() + "', " +
                     "NhanVien.TenNV = N'" + txtTenNV.Text.Trim() + "', " +
                     "NhanVien.NgaSinh = '" + dateTimePickerNgaySinh.Value.ToString("yyyy-MM-dd") + "', " +
                     "NhanVien.GioiTinh = N'" + cmbGioiTinh.Text.Trim() + "', " +
                     "NhanVien.Email = '" + txtEmail.Text.Trim() + "', " +
                     "NhanVien.DienThoai = '" + txtDienThoai.Text.Trim() + "', " +
                     "NhanVien.DiaChi = N'" + txtDiaChi.Text.Trim() + "', " +
                     "NhanVien.CCCD = '" + txtBaoHiem.Text.Trim() + "', " +
                     "NhanVien.DangLamViec = '" + (ckbTinhTrang.Checked ? "1" : "0") + "' " +
                    
                     
                     "WHERE NhanVien.MaNV = '" + txtID.Text.Trim() + "'";



            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Chỉnh sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Chỉnh sửa thông tin thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            _showHide(true);
            DialogResult kq = MessageBox.Show("Bạn có thực sự muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                Xoa();
            }
        }
        private void Xoa()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete NhanVien where MANV = '" + txtID.Text + "'";

            //SqlParameter parMaMA = new SqlParameter("@id", SqlDbType.Int);
            //parMaMA.Value = txtID.Text;
            //sqlCmd.Parameters.Add(parMaMA);
            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Xóa thông tin thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            _showHide(true);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            _showHide(false);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        

        private void btnDau_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayData();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayData();

            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < lvNhanVien.Items.Count - 1)
            {
                currentIndex++;
                DisplayData();

            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentIndex = lvNhanVien.Items.Count - 1;
            DisplayData();
        }

        private void DisplayData()
        {
            if (currentIndex >= 0 && currentIndex < lvNhanVien.Items.Count)
            {

                ListViewItem selectedItem = lvNhanVien.Items[currentIndex];
                selectedItem.Selected = true;

                txtID.Text = selectedItem.SubItems[0].Text;
                txtTenNV.Text = selectedItem.SubItems[1].Text;
                DateTime ngaysinh = DateTime.ParseExact(selectedItem.SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgaySinh.Text = ngaysinh.ToString("yyyy-MM-dd");
                ////txtNgayTao.Text = lvi.SubItems[3].Text;
                ////txtNgaysua.Text = lvi.SubItems[4].Text;
                cmbGioiTinh.Text = selectedItem.SubItems[3].Text;
                txtEmail.Text = selectedItem.SubItems[4].Text;
                txtDienThoai.Text = selectedItem.SubItems[5].Text;
                txtDiaChi.Text = selectedItem.SubItems[6].Text;
                txtBaoHiem.Text = selectedItem.SubItems[7].Text;
                cmbPhongBan.Text = selectedItem.SubItems[8].Text;
                cmbChucVu.Text = selectedItem.SubItems[9].Text;
                cmbMucLuong.Text = selectedItem.SubItems[10].Text;

                string dangLamViec = selectedItem.SubItems[11].Text;
                ckbTinhTrang.Checked = (dangLamViec == "True");

                txtMauHienHanh.Text = selectedItem.SubItems[0].Text;
                txtTongMau.Text = lvNhanVien.Items.Count.ToString();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập ID cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int searchID;
            if (!int.TryParse(txtTimKiem.Text, out searchID))
            {
                MessageBox.Show("ID phải là một số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo kết nối SQL
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            // Tạo câu truy vấn tìm kiếm
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT NV.MaNV, NV.TenNV, NV.NgaSinh, NV.GioiTinh, NV.Email, NV.DienThoai, NV.DiaChi, NV.CCCD, PB.TenPB, CV.TenChucVu, L.TenMucLuong, NV.DangLamViec " +
                " FROM NhanVien NV INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu INNER JOIN Luong L ON NV.MaLuong = L.MaLuong " +
            "WHERE NV.MaNV = @ID";
            sqlCmd.Connection = sqlCon;

            // Thêm tham số ID vào câu truy vấn
            sqlCmd.Parameters.AddWithValue("@ID", searchID);

            // Thực thi câu truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách hiện tại
            lvNhanVien.Items.Clear();

            // Kiểm tra xem có dữ liệu trả về hay không
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Duyệt qua từng dòng kết quả
                while (reader.Read())
                {
                    int manv = reader.GetInt32(0);
                    string tennv = reader.GetString(1);
                    DateTime ngaysinh = reader.GetDateTime(2);
                    string gioitinh = reader.GetString(3);
                    string email = reader.GetString(4);
                    string dienthoai = reader.GetString(5);
                    string diachi = reader.GetString(6);
                    string cccd = reader.GetString(7);
                    string tenphongban = reader.GetString(8);
                    string tenchucvu = reader.GetString(9);
                    string tenmucluong = reader.GetString(10);
                    bool hieuluc = reader.GetBoolean(11);


                    ListViewItem lvi = new ListViewItem(manv.ToString());
                    lvi.SubItems.Add(tennv);
                    lvi.SubItems.Add(ngaysinh.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(gioitinh);
                    lvi.SubItems.Add(email);
                    lvi.SubItems.Add(dienthoai);
                    lvi.SubItems.Add(diachi);
                    lvi.SubItems.Add(cccd);
                    lvi.SubItems.Add(tenphongban);
                    lvi.SubItems.Add(tenchucvu);
                    lvi.SubItems.Add(tenmucluong);
                    lvi.SubItems.Add(hieuluc.ToString());



                    lvNhanVien.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Đóng đọc dữ liệu
            reader.Close();

            // Đóng kết nối SQL
            sqlCon.Close();
        }

        private void cmbTenPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPhongBan = cmbTenPB.SelectedItem.ToString();

            if (selectedPhongBan == "Tất cả các phòng ban")
            {
                HienThiDanhSach();
            }
            else
            {
                HienThiDanhSachTheoPhongBan(selectedPhongBan);
            }
        }

        private void HienThiDanhSachTheoPhongBan(string tenPhongBan)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT NV.MaNV, NV.TenNV, NV.NgaSinh, NV.GioiTinh, NV.Email, NV.DienThoai, NV.DiaChi, NV.CCCD, PB.TenPB, CV.TenChucVu, L.TenMucLuong, NV.DangLamViec " +
                " FROM NhanVien NV INNER JOIN PhongBan PB ON NV.MaPB = PB.MaPB INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu INNER JOIN Luong L ON NV.MaLuong = L.MaLuong " +
            "WHERE PB.TenPB = @TenPB";

            sqlCmd.Parameters.AddWithValue("@TenPB", tenPhongBan);
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvNhanVien.Items.Clear();

            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(2);
                string gioitinh = reader.GetString(3);
                string email = reader.GetString(4);
                string dienthoai = reader.GetString(5);
                string diachi = reader.GetString(6);
                string cccd = reader.GetString(7);
                string tenphongban = reader.GetString(8);
                string tenchucvu = reader.GetString(9);
                string tenmucluong = reader.GetString(10);
                bool hieuluc = reader.GetBoolean(11);


                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(ngaysinh.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(gioitinh);
                lvi.SubItems.Add(email);
                lvi.SubItems.Add(dienthoai);
                lvi.SubItems.Add(diachi);
                lvi.SubItems.Add(cccd);
                lvi.SubItems.Add(tenphongban);
                lvi.SubItems.Add(tenchucvu);
                lvi.SubItems.Add(tenmucluong);
                lvi.SubItems.Add(hieuluc.ToString());

                lvNhanVien.Items.Add(lvi);

            }
            reader.Close();
            sqlCon.Close();

        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0) return;

            // Lấy phần tử được chọn trên ListView
            ListViewItem lvi = lvNhanVien.SelectedItems[0];

            // Hiển thị mẫu dữ liệu hiện hành
            txtMauHienHanh.Text = lvi.SubItems[0].Text;

            // Hiển thị tổng số mẫu dữ liệu trong ListView
            txtTongMau.Text = lvNhanVien.Items.Count.ToString();

            ////Hiển thị từ listview sang textbox
            txtID.Text = lvi.SubItems[0].Text;
            txtTenNV.Text = lvi.SubItems[1].Text;
            DateTime ngaysinh = DateTime.ParseExact(lvi.SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgaySinh.Text = ngaysinh.ToString("yyyy-MM-dd");

            cmbGioiTinh.Text = lvi.SubItems[3].Text;
            txtEmail.Text = lvi.SubItems[4].Text;
            txtDienThoai.Text = lvi.SubItems[5].Text;
            txtDiaChi.Text = lvi.SubItems[6].Text;
            txtBaoHiem.Text = lvi.SubItems[7].Text;
            
            cmbPhongBan.Text = lvi.SubItems[8].Text;
            cmbChucVu.Text = lvi.SubItems[9].Text;
            cmbMucLuong.Text = lvi.SubItems[10].Text;

            string dangLamViec = lvi.SubItems[11].Text;
            ckbTinhTrang.Checked = (dangLamViec == "True");
            
        }

        
    }
}
