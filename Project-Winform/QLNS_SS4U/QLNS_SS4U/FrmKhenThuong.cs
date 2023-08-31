using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_SS4U
{
    public partial class FrmKhenThuong : Form
    {
        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;
        public FrmKhenThuong()
        {
            InitializeComponent();
        }
        private int currentIndex = 0;

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmKhenThuong_Load(object sender, EventArgs e)
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
            sqlCmd.CommandText = "SELECT KhenThuong.MaKhenThuong, KhenThuong.MaNV, NhanVien.TenNV, KhenThuong.MaPhucLoi, PhucLoi.TenPhucLoi, KhenThuong.NgayThuong, KhenThuong.NgayTao, KhenThuong.NgaySuaDoi, KhenThuong.BiXoa " +
        "FROM KhenThuong " +
        "INNER JOIN NhanVien ON KhenThuong.MaNV = NhanVien.MaNV " +
        "INNER JOIN PhucLoi ON KhenThuong.MaPhucLoi = PhucLoi.MaPhucLoi";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvKhen.Items.Clear();
            while (reader.Read())
            {
                int makhenthuong = reader.GetInt32(0);
                int manhanvien = reader.GetInt32(1);
                string tenNV = reader.GetString(2);
                int maphucloi = reader.GetInt32(3);
                string tenPhucLoi = reader.GetString(4);
                DateTime ngaythuong = reader.GetDateTime(5);
                DateTime ngaytao = reader.GetDateTime(6);
                DateTime ngaysua = reader.GetDateTime(7);
                bool hieuluc = reader.GetBoolean(8);


                ListViewItem lvi = new ListViewItem(makhenthuong.ToString());
                lvi.SubItems.Add(manhanvien.ToString());
                lvi.SubItems.Add(tenNV);
                lvi.SubItems.Add(maphucloi.ToString());
                lvi.SubItems.Add(tenPhucLoi);
                lvi.SubItems.Add(ngaythuong.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(hieuluc.ToString());

                lvKhen.Items.Add(lvi);
                txtMauHienHanh.Text = lvi.SubItems[0].Text;
                txtTongMau.Text = lvKhen.Items.Count.ToString();
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
            txtMaNV.Text = "";
            txtMaPhucLoi.Text = "";
            dateTimePickerNgayThuong.Value = DateTime.Now;
            dateTimePickerNgayTao.Value = DateTime.Now;
            dateTimePickerNgaySua.Value = DateTime.Now;
            LoadDataToCheckBox("SELECT BiXoa FROM KhenThuong", ckbTinhTrang);
            txtID.Focus();
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
            string id = txtID.Text.Trim();
            string manv = txtMaNV.Text.Trim();
            string maphucloi = txtMaPhucLoi.Text.Trim();
            string ngaythuong = dateTimePickerNgayThuong.Value.ToString("yyyy-MM-dd");
            string ngaytao = dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd");
            string ngaysua = dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd");
            string hieuluc = ckbTinhTrang.Checked ? "1" : "0";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert into KhenThuong values ('" + id + "', '" + manv + "', '" + maphucloi + "', '" + ngaythuong + "'," +
                "'" + ngaytao + "', '" + ngaysua + "', '" + hieuluc + "')";
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
            sqlCmd.CommandText = "update KhenThuong set MaKhenThuong = '" + txtID.Text.Trim() + "', MaNV = N'" + txtMaNV.Text.Trim() + "', MaPhucLoi = '" + txtMaPhucLoi.Text.Trim() + "', NgayThuong = '" + dateTimePickerNgayThuong.Value.ToString("yyyy-MM-dd") + "'," +
                "NgayTao = '" + dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd") + "', NgaySuaDoi = '" + dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd") + "', BiXoa = '" + (ckbTinhTrang.Checked ? "1" : "0") + "' where MaKhenThuong = '" + txtID.Text.Trim() + "'";
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
            sqlCmd.CommandText = "delete from KhenThuong where MaKhenThuong = '" + txtID.Text + "'";

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            _showHide(true);
            KhongdungPar();
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

        private void lvKhen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKhen.SelectedItems.Count == 0) return;

            // Lấy phần tử được chọn trên ListView
            ListViewItem lvi = lvKhen.SelectedItems[0];

            // Hiển thị mẫu dữ liệu hiện hành
            txtMauHienHanh.Text = lvi.SubItems[0].Text;

            // Hiển thị tổng số mẫu dữ liệu trong ListView
            txtTongMau.Text = lvKhen.Items.Count.ToString();

            ////Hiển thị từ listview sang textbox
            txtID.Text = lvi.SubItems[0].Text;
            txtMaNV.Text = lvi.SubItems[1].Text;
            txtMaPhucLoi.Text = lvi.SubItems[3].Text;
            ////txtNgayTao.Text = lvi.SubItems[3].Text;
            ////txtNgaysua.Text = lvi.SubItems[4].Text;
            
            DateTime ngaythuong = DateTime.ParseExact(lvi.SubItems[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgayThuong.Text = ngaythuong.ToString("yyyy-MM-dd");

            DateTime ngayTao = DateTime.ParseExact(lvi.SubItems[6].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgayTao.Text = ngayTao.ToString("yyyy-MM-dd");

            DateTime ngaySua = DateTime.ParseExact(lvi.SubItems[7].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgaySua.Text = ngaySua.ToString("yyyy-MM-dd");

            string dangLamViec = lvi.SubItems[8].Text;
            ckbTinhTrang.Checked = (dangLamViec == "True");
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
            if (currentIndex < lvKhen.Items.Count - 1)
            {
                currentIndex++;
                DisplayData();

            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentIndex = lvKhen.Items.Count - 1;
            DisplayData();
        }

        private void DisplayData()
        {
            if (currentIndex >= 0 && currentIndex < lvKhen.Items.Count)
            {
                ListViewItem selectedItem = lvKhen.Items[currentIndex];
                selectedItem.Selected = true;

                txtID.Text = selectedItem.SubItems[0].Text;
                txtMaNV.Text = selectedItem.SubItems[1].Text;
                txtMaPhucLoi.Text = selectedItem.SubItems[3].Text;

                DateTime ngaythuong = DateTime.ParseExact(selectedItem.SubItems[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgayThuong.Text = ngaythuong.ToString("yyyy-MM-dd");

                DateTime ngayTao = DateTime.ParseExact(selectedItem.SubItems[6].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgayTao.Text = ngayTao.ToString("yyyy-MM-dd");

                DateTime ngaySua = DateTime.ParseExact(selectedItem.SubItems[7].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgaySua.Text = ngaySua.ToString("yyyy-MM-dd");

                string dangLamViec = selectedItem.SubItems[8].Text;
                ckbTinhTrang.Checked = (dangLamViec == "True");

                txtMauHienHanh.Text = selectedItem.SubItems[0].Text;
                txtTongMau.Text = lvKhen.Items.Count.ToString();
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
            sqlCmd.CommandText = "SELECT K.MaKhenThuong, K.MaNV, N.TenNV, K.MaPhucLoi, P.TenPhucLoi, K.NgayThuong, K.NgayTao, K.NgaySuaDoi, K.BiXoa " +
            "FROM KhenThuong K " +
            "JOIN NhanVien N ON K.MaNV = N.MaNV " +
            "JOIN PhucLoi P ON K.MaPhucLoi = P.MaPhucLoi " +
            "WHERE K.MaKhenThuong = @MaKhenThuong ";
            sqlCmd.Connection = sqlCon;

            // Thêm tham số ID vào câu truy vấn
            sqlCmd.Parameters.AddWithValue("@MaKhenThuong", searchID);

            // Thực thi câu truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách hiện tại
            lvKhen.Items.Clear();

            // Kiểm tra xem có dữ liệu trả về hay không
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Duyệt qua từng dòng kết quả
                while (reader.Read())
                {
                    int makhenthuong = reader.GetInt32(0);
                    int manhanvien = reader.GetInt32(1);
                    string tenNV = reader.GetString(2);
                    int maphucloi = reader.GetInt32(3);
                    string tenPhucLoi = reader.GetString(4);
                    DateTime ngaythuong = reader.GetDateTime(5);
                    DateTime ngaytao = reader.GetDateTime(6);
                    DateTime ngaysua = reader.GetDateTime(7);
                    bool hieuluc = reader.GetBoolean(8);

                    // Hiển thị dữ liệu tìm kiếm trên ListView
                    ListViewItem lvi = new ListViewItem(makhenthuong.ToString());
                    lvi.SubItems.Add(manhanvien.ToString());
                    lvi.SubItems.Add(tenNV.ToString());
                    lvi.SubItems.Add(maphucloi.ToString());
                    lvi.SubItems.Add(tenPhucLoi.ToString());
                    lvi.SubItems.Add(ngaythuong.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(hieuluc.ToString());

                    lvKhen.Items.Add(lvi);
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayThuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaPhucLoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMauHienHanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtHieuLuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaysua_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayTao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTongMau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

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
            sqlCmd.CommandText = "SELECT KT.MaKhenThuong, NV.MaNV, NV.TenNV, PL.MaPhucLoi, PL.TenPhucLoi, KT.NgayThuong, KT.NgayTao, KT.NgaySuaDoi, KT.BiXoa   " +
                "FROM KhenThuong KT " +
                "INNER JOIN NhanVien NV ON KT.MaNV = NV.MaNV " +
                "INNER JOIN PhucLoi PL ON KT.MaPhucLoi = PL.MaPhucLoi " +
                "INNER JOIN PhongBan PB ON PB.MaPB = NV.MaPB " +
                "WHERE PB.TenPB = @TenPB";

            sqlCmd.Parameters.AddWithValue("@TenPB", tenPhongBan);
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvKhen.Items.Clear();
            while (reader.Read())
            {
                int makhenthuong = reader.GetInt32(0);
                int manhanvien = reader.GetInt32(1);
                string tenNV = reader.GetString(2);
                int maphucloi = reader.GetInt32(3);
                string tenPhucLoi = reader.GetString(4);
                DateTime ngaythuong = reader.GetDateTime(5);
                DateTime ngaytao = reader.GetDateTime(6);
                DateTime ngaysua = reader.GetDateTime(7);
                bool hieuluc = reader.GetBoolean(8);


                ListViewItem lvi = new ListViewItem(makhenthuong.ToString());
                lvi.SubItems.Add(manhanvien.ToString());
                lvi.SubItems.Add(tenNV);
                lvi.SubItems.Add(maphucloi.ToString());
                lvi.SubItems.Add(tenPhucLoi);
                lvi.SubItems.Add(ngaythuong.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(hieuluc.ToString());

                lvKhen.Items.Add(lvi);
            }
            reader.Close();
            sqlCon.Close();
        }
    }
}
