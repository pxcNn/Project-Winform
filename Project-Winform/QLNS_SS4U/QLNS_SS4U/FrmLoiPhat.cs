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
    public partial class FrmLoiPhat : Form
    {
        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;
        public FrmLoiPhat()
        {
            InitializeComponent();
        }
        private int currentIndex = 0;

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLoiPhat_Load(object sender, EventArgs e)
        {
            _showHide(true);
            HienThiDanhSach();
            DisplayData();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            ckbTinhTrang.BackColor = Color.Transparent;
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
            sqlCmd.CommandText = "select * from LoiPhat";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvLoiPhat.Items.Clear();
            while (reader.Read())
            {
                int maloiphat = reader.GetInt32(0);
                string tenloiphat = reader.GetString(1);
                double mucphat = reader.GetDouble(2);
                DateTime ngaytao = reader.GetDateTime(3);
                DateTime ngaysua = reader.GetDateTime(4);
                bool hieuluc = reader.GetBoolean(5);

                ListViewItem lvi = new ListViewItem(maloiphat.ToString());
                lvi.SubItems.Add(tenloiphat);
                lvi.SubItems.Add(mucphat.ToString("N0"));
                lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(hieuluc.ToString());
                lvLoiPhat.Items.Add(lvi);
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
            txtTenLoiPhat.Text = "";
            txtMucPhat.Text = "";
            dateTimePickerNgaySua.Value = DateTime.Now;
            dateTimePickerNgayTao.Value = DateTime.Now;
            LoadDataToCheckBox("SELECT BiXoa FROM LoiPhat", ckbTinhTrang);

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
            string tenmucthuong = txtTenLoiPhat.Text.Trim();
            string mucthuong = txtMucPhat.Text.Trim().Replace(",", "");
            string ngaytao = dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd");
            string ngaysua = dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd");
            string hieuluc = ckbTinhTrang.Checked ? "1" : "0";


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert into LoiPhat values ('" + id + "', '" + tenmucthuong + "', '" + mucthuong + "'," +
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
            sqlCmd.CommandText = "update LoiPhat set MaLoiPhat = '" + txtID.Text.Trim() + "', TenLoiPhat = N'" + txtTenLoiPhat.Text.Trim() + "', SoPhat = '" + txtMucPhat.Text.Trim().Replace(",", "") + "'," +
                "NgayTao = '" + dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd") + "', NgayChinhSua = '" + dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd") + "', BiXoa = '" + (ckbTinhTrang.Checked ? "1" : "0") + "' where MaLoiPhat = '" + txtID.Text.Trim() + "'";
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
            sqlCmd.CommandText = "delete from LoiPhat where MaLoiPhat = '" + txtID.Text + "'";

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

        private void lvLoiPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLoiPhat.SelectedItems.Count == 0) return;

            // Lấy phần tử được chọn trên ListView
            ListViewItem lvi = lvLoiPhat.SelectedItems[0];

            // Hiển thị mẫu dữ liệu hiện hành
            txtMauHienHanh.Text = lvi.SubItems[0].Text;

            // Hiển thị tổng số mẫu dữ liệu trong ListView
            txtTongMau.Text = lvLoiPhat.Items.Count.ToString();

            ////Hiển thị từ listview sang textbox
            txtID.Text = lvi.SubItems[0].Text;
            txtTenLoiPhat.Text = lvi.SubItems[1].Text;
            txtMucPhat.Text = lvi.SubItems[2].Text;
            ////txtNgayTao.Text = lvi.SubItems[3].Text;
            ////txtNgaysua.Text = lvi.SubItems[4].Text;

            DateTime ngayTao = DateTime.ParseExact(lvi.SubItems[3].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgayTao.Text = ngayTao.ToString("yyyy-MM-dd");

            DateTime ngaySua = DateTime.ParseExact(lvi.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimePickerNgaySua.Text = ngaySua.ToString("yyyy-MM-dd");

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
            if (currentIndex < lvLoiPhat.Items.Count - 1)
            {
                currentIndex++;
                DisplayData();

            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentIndex = lvLoiPhat.Items.Count - 1;
            DisplayData();
        }

        private void DisplayData()
        {
            if (currentIndex >= 0 && currentIndex < lvLoiPhat.Items.Count)
            {
                ListViewItem selectedItem = lvLoiPhat.Items[currentIndex];
                selectedItem.Selected = true;

                txtID.Text = selectedItem.SubItems[0].Text;
                txtTenLoiPhat.Text = selectedItem.SubItems[1].Text;
                txtMucPhat.Text = selectedItem.SubItems[2].Text;

                DateTime ngayTao = DateTime.ParseExact(selectedItem.SubItems[3].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgayTao.Text = ngayTao.ToString("yyyy-MM-dd");

                DateTime ngaySua = DateTime.ParseExact(selectedItem.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgaySua.Text = ngaySua.ToString("yyyy-MM-dd");

                string dangLamViec = selectedItem.SubItems[5].Text;
                ckbTinhTrang.Checked = (dangLamViec == "True");

                txtMauHienHanh.Text = selectedItem.SubItems[0].Text;
                txtTongMau.Text = lvLoiPhat.Items.Count.ToString();
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
            sqlCmd.CommandText = "SELECT * FROM LoiPhat WHERE MaLoiPhat = @MaLoiPhat";
            sqlCmd.Connection = sqlCon;

            // Thêm tham số ID vào câu truy vấn
            sqlCmd.Parameters.AddWithValue("@MaLoiPhat", searchID);

            // Thực thi câu truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách hiện tại
            lvLoiPhat.Items.Clear();

            // Kiểm tra xem có dữ liệu trả về hay không
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Duyệt qua từng dòng kết quả
                while (reader.Read())
                {
                    int maloiphat = reader.GetInt32(0);
                    string tenloiphat = reader.GetString(1);
                    double mucphat = reader.GetDouble(2);
                    DateTime ngaytao = reader.GetDateTime(3);
                    DateTime ngaysua = reader.GetDateTime(4);
                    bool hieuluc = reader.GetBoolean(5);

                    // Hiển thị dữ liệu tìm kiếm trên ListView
                    ListViewItem lvi = new ListViewItem(maloiphat.ToString());
                    lvi.SubItems.Add(tenloiphat);
                    lvi.SubItems.Add(mucphat.ToString("N0"));
                    lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(hieuluc.ToString());
                    lvLoiPhat.Items.Add(lvi);
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
    }
}
