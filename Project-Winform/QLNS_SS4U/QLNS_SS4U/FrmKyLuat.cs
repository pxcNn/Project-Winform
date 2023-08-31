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
    public partial class FrmKyLuat : Form
    {
        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;

        public FrmKyLuat()
        {
            InitializeComponent();
        }

        private int currentIndex = 0;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmKyLuat_Load(object sender, EventArgs e)
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
            sqlCmd.CommandText = "SELECT KyLuat.MaKyLuat, KyLuat.MaNV, NhanVien.TenNV, KyLuat.MaLoiPhat, LoiPhat.TenLoiPhat, KyLuat.NgayPhat, KyLuat.NgayTao, KyLuat.NgayChinhSua, KyLuat.BiXoa " +
                                 "FROM KyLuat " +
                                "INNER JOIN NhanVien ON KyLuat.MaNV = NhanVien.MaNV " +
                                 "INNER JOIN LoiPhat ON KyLuat.MaLoiPhat = LoiPhat.MaLoiPhat ";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvPhat.Items.Clear();
            while (reader.Read())
            {
                int makyluat = reader.GetInt32(0);
                int manhanvien = reader.GetInt32(1);
                string tenNV = reader.GetString(2);
                int maloiphat = reader.GetInt32(3);
                string tenloiphat = reader.GetString(4);
                DateTime ngayphat = reader.GetDateTime(5);
                DateTime ngaytao = reader.GetDateTime(6);
                DateTime ngaysua = reader.GetDateTime(7);
                bool hieuluc = reader.GetBoolean(8);


                ListViewItem lvi = new ListViewItem(makyluat.ToString());
                lvi.SubItems.Add(manhanvien.ToString());
                lvi.SubItems.Add(tenNV);
                lvi.SubItems.Add(maloiphat.ToString());
                lvi.SubItems.Add(tenloiphat);
                lvi.SubItems.Add(ngayphat.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(hieuluc.ToString());

                lvPhat.Items.Add(lvi);
                txtMauHienHanh.Text = lvi.SubItems[0].Text;
                txtTongMau.Text = lvPhat.Items.Count.ToString();
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
            txtMaLoiPhat.Text = "";
            LoadDataToCheckBox("SELECT BiXoa FROM KyLuat", ckbTinhTrang);
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
            string maloiphat = txtMaLoiPhat.Text.Trim();
            string ngayphat = dateTimePickerNgayPhat.Value.ToString("yyyy-MM-dd");
            string ngaytao = dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd");
            string ngaysua = dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd");
            string hieuluc = ckbTinhTrang.Checked ? "1" : "0";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert into KyLuat values ('" + id + "', '" + manv + "', '" + maloiphat + "', '" + ngayphat + "'," +
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
            sqlCmd.CommandText = " update KyLuat set MaKyLuat = '" + txtID.Text.Trim() + "', MaNV = '" + txtMaNV.Text.Trim() + "', MaLoiPhat = '" + txtMaLoiPhat.Text.Trim() + "', NgayPhat = '" + dateTimePickerNgayPhat.Value.ToString("yyyy-MM-dd") + "'," +
                "NgayTao = '" + dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd") + "', NgayChinhSua = '" + dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd") + "', BiXoa = '" + (ckbTinhTrang.Checked ? "1" : "0") + "' where MaKyLuat = '" + txtID.Text.Trim() + "'";
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
            _showHide(false);
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
            sqlCmd.CommandText = "delete from KyLuat where MaKyluat = '" + txtID.Text + "'";

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

        private void lvPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhat.SelectedItems.Count == 0) return;

            // Lấy phần tử được chọn trên ListView
            ListViewItem lvi = lvPhat.SelectedItems[0];

            // Hiển thị mẫu dữ liệu hiện hành
            txtMauHienHanh.Text = lvi.SubItems[0].Text;

            // Hiển thị tổng số mẫu dữ liệu trong ListView
            txtTongMau.Text = lvPhat.Items.Count.ToString();

            // Đếm số lượng giá trị trong txtID
            int count = 0;
            foreach (ListViewItem item in lvPhat.Items)
            {
                if (item.SubItems[0].Text == txtID.Text)
                {
                    count++;
                }
            }
            txtID.Text = count.ToString();




            ////Hiển thị từ listview sang textbox
            txtID.Text = lvi.SubItems[0].Text;
            txtMaNV.Text = lvi.SubItems[1].Text;
            txtMaLoiPhat.Text = lvi.SubItems[3].Text;
            ////txtNgayTao.Text = lvi.SubItems[3].Text;
            ////txtNgaysua.Text = lvi.SubItems[4].Text;

            DateTime ngaythuong = DateTime.ParseExact(lvi.SubItems[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgayPhat.Text = ngaythuong.ToString("yyyy-MM-dd");

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
            if (currentIndex < lvPhat.Items.Count - 1)
            {
                currentIndex++;
                DisplayData();

            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentIndex = lvPhat.Items.Count - 1;
            DisplayData();
        }

        private void DisplayData()
        {
            if (currentIndex >= 0 && currentIndex < lvPhat.Items.Count)
            {
                ListViewItem selectedItem = lvPhat.Items[currentIndex];
                selectedItem.Selected = true;

                txtID.Text = selectedItem.SubItems[0].Text;
                txtMaNV.Text = selectedItem.SubItems[1].Text;
                txtMaLoiPhat.Text = selectedItem.SubItems[3].Text;

                DateTime ngaythuong = DateTime.ParseExact(selectedItem.SubItems[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgayPhat.Text = ngaythuong.ToString("yyyy-MM-dd");

                DateTime ngayTao = DateTime.ParseExact(selectedItem.SubItems[6].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgayTao.Text = ngayTao.ToString("yyyy-MM-dd");

                DateTime ngaySua = DateTime.ParseExact(selectedItem.SubItems[7].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgaySua.Text = ngaySua.ToString("yyyy-MM-dd");

                string dangLamViec = selectedItem.SubItems[8].Text;
                ckbTinhTrang.Checked = (dangLamViec == "True");

                txtMauHienHanh.Text = selectedItem.SubItems[0].Text;
                txtTongMau.Text = lvPhat.Items.Count.ToString();
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
            sqlCmd.CommandText = "SELECT KyLuat.MaKyLuat, KyLuat.MaNV, NhanVien.TenNV, KyLuat.MaLoiPhat, LoiPhat.TenLoiPhat, KyLuat.NgayPhat, KyLuat.NgayTao, KyLuat.NgayChinhSua, KyLuat.BiXoa " +
                                 "FROM KyLuat " +
                                "INNER JOIN NhanVien ON KyLuat.MaNV = NhanVien.MaNV " +
                                 "INNER JOIN LoiPhat ON KyLuat.MaLoiPhat = LoiPhat.MaLoiPhat " +
                                 "where MaKyLuat = @Id ";
            sqlCmd.Connection = sqlCon;

            // Thêm tham số ID vào câu truy vấn
            sqlCmd.Parameters.AddWithValue("@Id", searchID);

            // Thực thi câu truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách hiện tại
            lvPhat.Items.Clear();

            // Kiểm tra xem có dữ liệu trả về hay không
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Duyệt qua từng dòng kết quả
                while (reader.Read())
                {
                    int makyluat = reader.GetInt32(0);
                    int manhanvien = reader.GetInt32(1);
                    string tenNV = reader.GetString(2);
                    int maloiphat = reader.GetInt32(3);
                    string tenloiphat = reader.GetString(4);
                    DateTime ngayphat = reader.GetDateTime(5);
                    DateTime ngaytao = reader.GetDateTime(6);
                    DateTime ngaysua = reader.GetDateTime(7);
                    bool hieuluc = reader.GetBoolean(8);

                    // Hiển thị dữ liệu tìm kiếm trên ListView
                    ListViewItem lvi = new ListViewItem(makyluat.ToString());
                    lvi.SubItems.Add(manhanvien.ToString());
                    lvi.SubItems.Add(tenNV.ToString());
                    lvi.SubItems.Add(maloiphat.ToString());
                    lvi.SubItems.Add(tenloiphat.ToString());
                    lvi.SubItems.Add(ngayphat.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(hieuluc.ToString());

                    lvPhat.Items.Add(lvi);
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
            sqlCmd.CommandText = "SELECT KL.MaKyLuat, NV.MaNV, NV.TenNV, LP.MaLoiPhat, LP.TenLoiPhat, KL.NgayPhat, KL.NgayTao, KL.NgayChinhSua, KL.BiXoa   " +
                "FROM KyLuat KL " +
                "INNER JOIN NhanVien NV ON KL.MaNV = NV.MaNV " +
                "INNER JOIN LoiPhat LP ON LP.MaLoiPhat = KL.MaLoiPhat " +
                "INNER JOIN PhongBan PB ON PB.MaPB = NV.MaPB " +
                "WHERE PB.TenPB = @TenPB";

            sqlCmd.Parameters.AddWithValue("@TenPB", tenPhongBan);
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvPhat.Items.Clear();
            
            while (reader.Read())
            {
                int makyluat = reader.GetInt32(0);
                int manhanvien = reader.GetInt32(1);
                string tenNV = reader.GetString(2);
                int maloiphat = reader.GetInt32(3);
                string tenloiphat = reader.GetString(4);
                DateTime ngayphat = reader.GetDateTime(5);
                DateTime ngaytao = reader.GetDateTime(6);
                DateTime ngaysua = reader.GetDateTime(7);
                bool hieuluc = reader.GetBoolean(8);


                ListViewItem lvi = new ListViewItem(makyluat.ToString());
                lvi.SubItems.Add(manhanvien.ToString());
                lvi.SubItems.Add(tenNV);
                lvi.SubItems.Add(maloiphat.ToString());
                lvi.SubItems.Add(tenloiphat);
                lvi.SubItems.Add(ngayphat.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(hieuluc.ToString());

                lvPhat.Items.Add(lvi);

            }
            reader.Close();
            sqlCon.Close();
           
        }

        private void dateTimePickerNgayTao_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
