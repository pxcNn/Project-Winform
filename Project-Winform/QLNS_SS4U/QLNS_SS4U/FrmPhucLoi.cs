using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNS_SS4U
{
    public partial class FrmPhucLoi : Form
    {
        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;

     

        public FrmPhucLoi()
        {
            InitializeComponent();
        }
        private int currentIndex = 0;



        private void Form1_Load(object sender, EventArgs e)
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
            sqlCmd.CommandText = "select * from PhucLoi";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvKhenThuong.Items.Clear();
            while (reader.Read())
            {
                int maphucloi = reader.GetInt32(0);
                string tenphucloi = reader.GetString(1);
                double mucthuong = reader.GetDouble(2);
                DateTime ngaytao = reader.GetDateTime(3);
                DateTime ngaysua = reader.GetDateTime(4);
                bool hieuluc = reader.GetBoolean(5);

                ListViewItem lvi = new ListViewItem(maphucloi.ToString());
                lvi.SubItems.Add(tenphucloi);
                lvi.SubItems.Add(mucthuong.ToString("N0"));
                lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(hieuluc.ToString());
                lvKhenThuong.Items.Add(lvi);
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
            txtTenMucThuong.Text = "";
            txtMucThuong.Text = "";
            dateTimePickerNgayTao.Value = DateTime.Now;
            dateTimePickerNgaySua.Value = DateTime.Now;
            LoadDataToCheckBox("SELECT BiXoa FROM PhucLoi", ckbTinhTrang);
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
            string tenmucthuong = txtTenMucThuong.Text.Trim();
            string mucthuong = txtMucThuong.Text.Trim().Replace(",", "");
            string ngaytao = dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd");
            string ngaysua = dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd");
            string hieuluc = (ckbTinhTrang.Checked ? "1" : "0");


            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert into PhucLoi values ('"+id+ "', '"+tenmucthuong+ "', '"+mucthuong+"'," +
                "'"+ngaytao+ "', '"+ngaysua+"', '"+hieuluc+"')";
            sqlCmd.Connection = sqlCon;
            int kq = sqlCmd.ExecuteNonQuery();

        if(kq>0)
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
            sqlCmd.CommandText = " update PhucLoi set MaPhucLoi = '"+txtID.Text.Trim()+ "', TenPhucLoi = N'" + txtTenMucThuong.Text.Trim() + "', SoTienThuong = '" + txtMucThuong.Text.Trim().Replace(",", "") + "'," +
                "NgayTao = '" + dateTimePickerNgayTao.Value.ToString("yyyy-MM-dd")+ "', NgaySuaDoi = '" + dateTimePickerNgaySua.Value.ToString("yyyy-MM-dd")+ "', BiXoa = '"+ (ckbTinhTrang.Checked ? "1" : "0") + "' where MaPhucLoi = '" +txtID.Text.Trim()+ "'" ;
            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if (kq >0)
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
            sqlCmd.CommandText = "delete from PhucLoi where MaPhucLoi = '"+txtID.Text+"'";

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
            rptKhenThuong rptKhenThuong = new rptKhenThuong();
            rptKhenThuong.Show();
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KN_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if(sqlCon.State==ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("kết nối thành công");
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if(sqlCon != null && sqlCon.State==ConnectionState.Open)
            {
                sqlCon.Close();
                MessageBox.Show("Đóng kết nối thành công");
            }    
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }    

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lvKhenThuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKhenThuong.SelectedItems.Count == 0) return;

            // Lấy phần tử được chọn trên ListView
            ListViewItem lvi = lvKhenThuong.SelectedItems[0];

            // Hiển thị mẫu dữ liệu hiện hành
            txtMauHienHanh.Text = lvi.SubItems[0].Text;

            // Hiển thị tổng số mẫu dữ liệu trong ListView
            txtTongMau.Text = lvKhenThuong.Items.Count.ToString();

            ////Hiển thị từ listview sang textbox
            txtID.Text = lvi.SubItems[0].Text;
            txtTenMucThuong.Text = lvi.SubItems[1].Text;
            txtMucThuong.Text = lvi.SubItems[2].Text;
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
            if (currentIndex < lvKhenThuong.Items.Count - 1)
            {
                currentIndex++  ;
                DisplayData();

            }

           
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentIndex = lvKhenThuong.Items.Count - 1;
            DisplayData();




        }

        private void DisplayData()
        {
            if (currentIndex >= 0 && currentIndex < lvKhenThuong.Items.Count)
            {
                ListViewItem selectedItem = lvKhenThuong.Items[currentIndex];
                selectedItem.Selected = true;

                txtID.Text = selectedItem.SubItems[0].Text;
                txtTenMucThuong.Text = selectedItem.SubItems[1].Text;
                txtMucThuong.Text = selectedItem.SubItems[2].Text;

                DateTime ngayTao = DateTime.ParseExact(selectedItem.SubItems[3].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgayTao.Text = ngayTao.ToString("yyyy-MM-dd");

                DateTime ngaySua = DateTime.ParseExact(selectedItem.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTimePickerNgaySua.Text = ngaySua.ToString("yyyy-MM-dd");

                string dangLamViec = selectedItem.SubItems[5].Text;
                ckbTinhTrang.Checked = (dangLamViec == "True");

                txtMauHienHanh.Text = selectedItem.SubItems[0].Text;
                txtTongMau.Text = lvKhenThuong.Items.Count.ToString();
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
            sqlCmd.CommandText = "SELECT * FROM PhucLoi WHERE MaPhucLoi = @ID";
            sqlCmd.Connection = sqlCon;

            // Thêm tham số ID vào câu truy vấn
            sqlCmd.Parameters.AddWithValue("@ID", searchID);

            // Thực thi câu truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Xóa danh sách hiện tại
            lvKhenThuong.Items.Clear();

            // Kiểm tra xem có dữ liệu trả về hay không
            if (reader.HasRows)
            {
                MessageBox.Show("Đã tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Duyệt qua từng dòng kết quả
                while (reader.Read())
                {
                    int maphucloi = reader.GetInt32(0);
                    string tenphucloi = reader.GetString(1);
                    double mucthuong = reader.GetDouble(2);
                    DateTime ngaytao = reader.GetDateTime(3);
                    DateTime ngaysua = reader.GetDateTime(4);
                    bool hieuluc = reader.GetBoolean(5);

                    // Hiển thị dữ liệu tìm kiếm trên ListView
                    ListViewItem lvi = new ListViewItem(maphucloi.ToString());
                    lvi.SubItems.Add(tenphucloi);
                    lvi.SubItems.Add(mucthuong.ToString("N0"));
                    lvi.SubItems.Add(ngaytao.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(ngaysua.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(hieuluc.ToString());
                    lvKhenThuong.Items.Add(lvi);
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
