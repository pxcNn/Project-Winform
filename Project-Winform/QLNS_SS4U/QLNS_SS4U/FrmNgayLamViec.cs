using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_SS4U
{
    public partial class FrmNgayLamViec : Form
    {

        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;
        private int currentIndex = 0;
        public FrmNgayLamViec()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmNgayLamViec_Load(object sender, EventArgs e)
        {
            _showHide(true);
            HienThiDanhSach();
            DisplayData();
            LoadPhongBanComboBox();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
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
            sqlCmd.CommandText = "SELECT NLV.MaNgayLamViec, NV.MaNV, NV.TenNV, PB.TenPB, NLV.NgayLamViec, NLV.DangLamViec " +
        "FROM NgayLamViec NLV " +
        "JOIN NhanVien NV ON NLV.MaNV = NV.MaNV " +
        "JOIN PhongBan PB ON NV.MaPB = PB.MaPB ";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvNgayLamViec.Items.Clear();
            while (reader.Read())
            {
                int mangaylamviec = reader.GetInt32(0);
                int manv = reader.GetInt32(1);
                string tennv = reader.GetString(2);
                string tenphongban = reader.GetString(3);
                DateTime ngaylamviec = reader.GetDateTime(4);
                bool danglamviec = reader.GetBoolean(5);



                ListViewItem lvi = new ListViewItem(mangaylamviec.ToString());
                lvi.SubItems.Add(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(tenphongban);
                lvi.SubItems.Add(ngaylamviec.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(danglamviec.ToString());


                lvNgayLamViec.Items.Add(lvi);
                txtMauHienHanh.Text = lvi.SubItems[0].Text;
                txtTongMau.Text = lvNgayLamViec.Items.Count.ToString();
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
            dateTimePickerNLV.Value = DateTime.Now;
            

            txtID.Focus();
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
            string ngaylamviec = dateTimePickerNLV.Value.ToString("yyyy-MM-dd");
            string hieuluc = ckbTinhTrang.Checked ? "1" : "0";



            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert into NgayLamViec values ('" + id + "', '" + manv + "', '" + ngaylamviec + "',  '" + hieuluc + "')";
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
            sqlCmd.CommandText = "update NgayLamViec set MaNgayLamViec = '" + txtID.Text.Trim() + "', MaNV = N'" + txtMaNV.Text.Trim() + "', NgayLamViec = '" + dateTimePickerNLV.Value.ToString("yyyy-MM-dd") + "', DangLamViec = '" + (ckbTinhTrang.Checked ? "1" : "0") + "'  where MaNgayLamViec = '" + txtID.Text.Trim() + "' ";
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
            sqlCmd.CommandText = "delete from NgayLamViec where MaNgayLamViec = '" + txtID.Text + "'";

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

        private void lvTamUng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNgayLamViec.SelectedItems.Count == 0) return;

            // Lấy phần tử được chọn trên ListView
            ListViewItem lvi = lvNgayLamViec.SelectedItems[0];

            // Hiển thị mẫu dữ liệu hiện hành
            txtMauHienHanh.Text = lvi.SubItems[0].Text;

            // Hiển thị tổng số mẫu dữ liệu trong ListView
            txtTongMau.Text = lvNgayLamViec.Items.Count.ToString();

            ////Hiển thị từ listview sang textbox
            txtID.Text = lvi.SubItems[0].Text;
            txtMaNV.Text = lvi.SubItems[1].Text;
            ////txtNgayTao.Text = lvi.SubItems[3].Text;
            ////txtNgaysua.Text = lvi.SubItems[4].Text;
            DateTime ngaylamviec = DateTime.ParseExact(lvi.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNLV.Text = ngaylamviec.ToString("yyyy-MM-dd");

            string dangLamViec = lvi.SubItems[5].Text;
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
            if (currentIndex < lvNgayLamViec.Items.Count - 1)
            {
                currentIndex++;
                DisplayData();

            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentIndex = lvNgayLamViec.Items.Count - 1;
            DisplayData();
        }

        private void DisplayData()
        {
            if (currentIndex >= 0 && currentIndex < lvNgayLamViec.Items.Count)
            {
                ListViewItem selectedItem = lvNgayLamViec.Items[currentIndex];
                selectedItem.Selected = true;

                txtID.Text = selectedItem.SubItems[0].Text;
                txtMaNV.Text = selectedItem.SubItems[1].Text;
                ////txtNgayTao.Text = lvi.SubItems[3].Text;
                ////txtNgaysua.Text = lvi.SubItems[4].Text;
                DateTime ngaylamviec = DateTime.ParseExact(selectedItem.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNLV.Text = ngaylamviec.ToString("yyyy-MM-dd");

                string dangLamViec = selectedItem.SubItems[5].Text;
                ckbTinhTrang.Checked = (dangLamViec == "True");


                txtMauHienHanh.Text = selectedItem.SubItems[0].Text;
                txtTongMau.Text = lvNgayLamViec.Items.Count.ToString();
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
            sqlCmd.CommandText = "SELECT NLV.MaNgayLamViec, NV.MaNV, NV.TenNV, PB.TenPB, NLV.NgayLamViec, NLV.DangLamViec " +
        "FROM NgayLamViec NLV " +
        "JOIN NhanVien NV ON NLV.MaNV = NV.MaNV " +
        "JOIN PhongBan PB ON NV.MaPB = PB.MaPB " + 
            "WHERE NLV.MaNgayLamViec = @ID ";
            sqlCmd.Connection = sqlCon;

            // Thêm tham số ID vào câu truy vấn
            sqlCmd.Parameters.AddWithValue("@ID", searchID);

            // Thực thi câu truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách hiện tại
            lvNgayLamViec.Items.Clear();

            // Kiểm tra xem có dữ liệu trả về hay không
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Duyệt qua từng dòng kết quả
                while (reader.Read())
                {
                    int mangaylamviec = reader.GetInt32(0);
                    int manv = reader.GetInt32(1);
                    string tennv = reader.GetString(2);
                    string tenphongban = reader.GetString(3);
                    DateTime ngaylamviec = reader.GetDateTime(4);
                    bool danglamviec = reader.GetBoolean(5);



                    ListViewItem lvi = new ListViewItem(mangaylamviec.ToString());
                    lvi.SubItems.Add(manv.ToString());
                    lvi.SubItems.Add(tennv);
                    lvi.SubItems.Add(tenphongban);
                    lvi.SubItems.Add(ngaylamviec.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(danglamviec.ToString());



                    lvNgayLamViec.Items.Add(lvi);
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
            sqlCmd.CommandText = "SELECT NLV.MaNgayLamViec, NV.MaNV, NV.TenNV, PB.TenPB, NLV.NgayLamViec, NLV.DangLamViec " +
                "FROM NgayLamViec NLV " +
                "JOIN NhanVien NV ON NLV.MaNV = NV.MaNV " +
                "JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "WHERE PB.TenPB = @TenPB";

            sqlCmd.Parameters.AddWithValue("@TenPB", tenPhongBan);
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvNgayLamViec.Items.Clear();
            while (reader.Read())
            {
                int maNgayLamViec = reader.GetInt32(0);
                int maNV = reader.GetInt32(1);
                string tenNV = reader.GetString(2);
                string tenPB = reader.GetString(3);
                DateTime ngayLamViec = reader.GetDateTime(4);
                bool dangLamViec = reader.GetBoolean(5);

                // Tạo ListViewItem mới và thêm vào ListView
                ListViewItem item = new ListViewItem(maNgayLamViec.ToString());
                item.SubItems.Add(maNV.ToString());
                item.SubItems.Add(tenNV);
                item.SubItems.Add(tenPB);
                item.SubItems.Add(ngayLamViec.ToString("dd/MM/yyyy"));
                item.SubItems.Add(dangLamViec.ToString());

                lvNgayLamViec.Items.Add(item);
            }
            reader.Close();
            sqlCon.Close();
        }
    }
}
