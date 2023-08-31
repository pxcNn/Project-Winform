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

namespace QLNS_SS4U
{
    public partial class FrmTinhLuong : Form
    {

        string strCon = System.IO.File.ReadAllText("config.txt");

        SqlConnection sqlCon = null;
        public FrmTinhLuong()
        {
            InitializeComponent();
            btnTinh.Click += btnTinh_Click;
        }

        private void FrmTinhLuong_Load(object sender, EventArgs e)
        {
           
            HienThiDanhSach();          
            LoadPhongBanComboBox();
            LoadThangComboBox();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }

        private void LoadThangComboBox()
        {
            cmbThang.Items.Clear();
            cmbThang.Items.Add("Tất cả các tháng");
            cmbThang.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++)
            {
                cmbThang.Items.Add(i);
            }
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
            sqlCmd.CommandText = sqlCmd.CommandText = "SELECT " +
                "NV.MaNV, " +
                "NV.TenNV, " +
                "PB.TenPB, " +
                "FORMAT(COALESCE(L.SoTienLuong, 0), 'N0') AS SoTienLuong, " +
                "FORMAT(COALESCE(L.TroCap, 0), 'N0') AS PhuCap, " +
                "FORMAT(COALESCE(NV.Cong, 0), 'N0') AS Cong, " +
                "FORMAT((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)), 'N0') AS TongLuongTT, " +
                "FORMAT(COALESCE(PhucLoi.SoTienThuong, 0), 'N0') AS SoTienThuong, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105), 'N0') AS BaoHiem, " +
                "FORMAT((((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)\r\n, 'N0') AS ThueTNCN,  " +
                "FORMAT(COALESCE(LoiPhat.SoPhat, 0), 'N0') AS SoPhat, " +
                "FORMAT(COALESCE(TU.SoTienUng, 0), 'N0') AS SoTienUng, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105) + COALESCE(PhucLoi.SoTienThuong, 0) - COALESCE(LoiPhat.SoPhat, 0) - COALESCE(TU.SoTienUng, 0)) - (((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)) , 'N0') AS ThucNhan " +
                "FROM NhanVien NV " +
                "LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "LEFT JOIN Luong L ON NV.MaLuong = L.MaLuong " +
                "LEFT JOIN KhenThuong KT ON NV.MaNV = KT.MaNV " +
                "LEFT JOIN KyLuat KL ON NV.MaNV = KL.MaNV " +
                "LEFT JOIN TamUng TU ON NV.MaNV = TU.MaNV " +
                "LEFT JOIN PhucLoi ON PhucLoi.MaPhucLoi = KT.MaPhucLoi " +
                "LEFT JOIN LoiPhat ON KL.MaLoiPhat = LoiPhat.MaLoiPhat ";

            sqlCmd.Connection = sqlCon;


            SqlDataReader reader = sqlCmd.ExecuteReader();


            lvTinhLuong.Items.Clear();
            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                string tenpb = reader.GetString(2);
                string sotienluong = reader.GetString(3);
                string phucap = reader.GetString(4);
                string cong = reader.GetString(5);
                string tongluongtt = reader.GetString(6);
                string sotienthuong = reader.GetString(7);
                string baohiem = reader.GetString(8);
                string thuetncn = reader.GetString(9);
                string sotienphat = reader.GetString(10);
                string sotienung = reader.GetString(11);
                string thucnhan = reader.GetString(12);



                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(tenpb);
                lvi.SubItems.Add(sotienluong.ToString());
                lvi.SubItems.Add(phucap.ToString());
                lvi.SubItems.Add(cong.ToString());
                lvi.SubItems.Add(tongluongtt.ToString());
                lvi.SubItems.Add(sotienthuong.ToString());
                lvi.SubItems.Add(baohiem.ToString());
                lvi.SubItems.Add(thuetncn.ToString());            
                lvi.SubItems.Add(sotienphat.ToString());
                lvi.SubItems.Add(sotienung.ToString());
                lvi.SubItems.Add(thucnhan.ToString());


                lvTinhLuong.Items.Add(lvi);

            }
            reader.Close();

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
            sqlCmd.CommandText = sqlCmd.CommandText = "SELECT " +
                "NV.MaNV, " +
                "NV.TenNV, " +
                "PB.TenPB, " +
                "FORMAT(COALESCE(L.SoTienLuong, 0), 'N0') AS SoTienLuong, " +
                "FORMAT(COALESCE(L.TroCap, 0), 'N0') AS PhuCap, " +
                "FORMAT(COALESCE(NV.Cong, 0), 'N0') AS Cong, " +
                "FORMAT((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)), 'N0') AS TongLuongTT, " +
                "FORMAT(COALESCE(PhucLoi.SoTienThuong, 0), 'N0') AS SoTienThuong, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105), 'N0') AS BaoHiem, " +
                "FORMAT((((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)\r\n, 'N0') AS ThueTNCN,  " +

                "FORMAT(COALESCE(LoiPhat.SoPhat, 0), 'N0') AS SoPhat, " +
                "FORMAT(COALESCE(TU.SoTienUng, 0), 'N0') AS SoTienUng, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105) + COALESCE(PhucLoi.SoTienThuong, 0) - COALESCE(LoiPhat.SoPhat, 0) - COALESCE(TU.SoTienUng, 0)) - (((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)) , 'N0') AS ThucNhan " +
                "FROM NhanVien NV " +
                "LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "LEFT JOIN Luong L ON NV.MaLuong = L.MaLuong " +
                "LEFT JOIN KhenThuong KT ON NV.MaNV = KT.MaNV " +
                "LEFT JOIN KyLuat KL ON NV.MaNV = KL.MaNV " +
                "LEFT JOIN TamUng TU ON NV.MaNV = TU.MaNV " +
                "LEFT JOIN PhucLoi ON PhucLoi.MaPhucLoi = KT.MaPhucLoi " +
                "LEFT JOIN LoiPhat ON KL.MaLoiPhat = LoiPhat.MaLoiPhat " +
            "WHERE PB.TenPB = @TenPB";

            sqlCmd.Parameters.AddWithValue("@TenPB", tenPhongBan);
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvTinhLuong.Items.Clear();

            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                string tenpb = reader.GetString(2);
                string sotienluong = reader.GetString(3);
                string phucap = reader.GetString(4);
                string cong = reader.GetString(5);
                string tongluongtt = reader.GetString(6);
                string sotienthuong = reader.GetString(7);
                string baohiem = reader.GetString(8);
                string thuetncn = reader.GetString(9);
                string sotienphat = reader.GetString(10);
                string sotienung = reader.GetString(11);
                string thucnhan = reader.GetString(12);

                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(tenpb);
                lvi.SubItems.Add(sotienluong.ToString());
                lvi.SubItems.Add(phucap.ToString());
                lvi.SubItems.Add(cong.ToString());
                lvi.SubItems.Add(tongluongtt.ToString());
                lvi.SubItems.Add(sotienthuong.ToString());
                lvi.SubItems.Add(baohiem.ToString());
                lvi.SubItems.Add(thuetncn.ToString());
                lvi.SubItems.Add(sotienphat.ToString());
                lvi.SubItems.Add(sotienung.ToString());
                lvi.SubItems.Add(thucnhan.ToString());

                lvTinhLuong.Items.Add(lvi);

            }
            reader.Close();
            sqlCon.Close();

        }

        private void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThang.SelectedItem.ToString() == "Tất cả các tháng")
            {
                HienThiDanhSach();
            }
            //else
            //{
            //    int selectedMonth = Convert.ToInt32(cmbThang.SelectedItem.ToString());
            //    HienThiDanhSachTheoThang(selectedMonth);
            //}

            else
            {
                string selectedPhongBan = cmbTenPB.SelectedItem.ToString();
                int selectedMonth = Convert.ToInt32(cmbThang.SelectedItem.ToString());
                HienThiDanhSachTheoPhongBanVaThang(selectedPhongBan, selectedMonth);
            }
        }

        private void HienThiDanhSachTheoPhongBanVaThang(string tenPhongBan, int selectedMonth)
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
            sqlCmd.CommandText = sqlCmd.CommandText = "SELECT " +
                "NV.MaNV, " +
                "NV.TenNV, " +
                "PB.TenPB, " +
                "FORMAT(COALESCE(L.SoTienLuong, 0), 'N0') AS SoTienLuong, " +
                "FORMAT(COALESCE(L.TroCap, 0), 'N0') AS PhuCap, " +
                "FORMAT(COALESCE(NV.Cong, 0), 'N0') AS Cong, " +
                "FORMAT((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)), 'N0') AS TongLuongTT, " +
                "FORMAT(COALESCE(PhucLoi.SoTienThuong, 0), 'N0') AS SoTienThuong, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105), 'N0') AS BaoHiem, " +
                "FORMAT((((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)\r\n, 'N0') AS ThueTNCN,  " +

                "FORMAT(COALESCE(LoiPhat.SoPhat, 0), 'N0') AS SoPhat, " +
                "FORMAT(COALESCE(TU.SoTienUng, 0), 'N0') AS SoTienUng, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105) + COALESCE(PhucLoi.SoTienThuong, 0) - COALESCE(LoiPhat.SoPhat, 0) - COALESCE(TU.SoTienUng, 0)) - (((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)) , 'N0') AS ThucNhan " +
                "FROM NhanVien NV " +
                "LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "LEFT JOIN Luong L ON NV.MaLuong = L.MaLuong " +
                "LEFT JOIN KhenThuong KT ON NV.MaNV = KT.MaNV " +
                "LEFT JOIN KyLuat KL ON NV.MaNV = KL.MaNV " +
                "LEFT JOIN TamUng TU ON NV.MaNV = TU.MaNV " +
                "LEFT JOIN PhucLoi ON PhucLoi.MaPhucLoi = KT.MaPhucLoi " +
                "LEFT JOIN LoiPhat ON KL.MaLoiPhat = LoiPhat.MaLoiPhat " +
            "LEFT JOIN NgayLamViec ON NgayLamViec.MaNV = NV.MaNV " +
                "WHERE MONTH(NgayLamViec.NgayLamViec) = @NgayLamViec  and PB.TenPB LIKE @TenPB";
            sqlCmd.Connection = sqlCon;
            sqlCmd.Parameters.AddWithValue("@NgayLamViec", selectedMonth);
            sqlCmd.Parameters.AddWithValue("@TenPB", tenPhongBan);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            lvTinhLuong.Items.Clear();

            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                string tenpb = reader.GetString(2);
                string sotienluong = reader.GetString(3);
                string phucap = reader.GetString(4);
                string cong = reader.GetString(5);
                string tongluongtt = reader.GetString(6);
                string sotienthuong = reader.GetString(7);
                string baohiem = reader.GetString(8);
                string thuetncn = reader.GetString(9);
                string sotienphat = reader.GetString(10);
                string sotienung = reader.GetString(11);
                string thucnhan = reader.GetString(12);

                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(tenpb);
                lvi.SubItems.Add(sotienluong.ToString());
                lvi.SubItems.Add(phucap.ToString());
                lvi.SubItems.Add(cong.ToString());
                lvi.SubItems.Add(tongluongtt.ToString());
                lvi.SubItems.Add(sotienthuong.ToString());
                lvi.SubItems.Add(baohiem.ToString());
                lvi.SubItems.Add(thuetncn.ToString());
                lvi.SubItems.Add(sotienphat.ToString());
                lvi.SubItems.Add(sotienung.ToString());
                lvi.SubItems.Add(thucnhan.ToString());

                lvTinhLuong.Items.Add(lvi);
            }

            reader.Close();
            sqlCon.Close();
        }

        private void HienThiDanhSachTheoThang(int selectedMonth)
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
            sqlCmd.CommandText = sqlCmd.CommandText = "SELECT " +
                "NV.MaNV, " +
                "NV.TenNV, " +
                "PB.TenPB, " +
                "FORMAT(COALESCE(L.SoTienLuong, 0), 'N0') AS SoTienLuong, " +
                "FORMAT(COALESCE(L.TroCap, 0), 'N0') AS PhuCap, " +
                "FORMAT(COALESCE(NV.Cong, 0), 'N0') AS Cong, " +
                "FORMAT((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)), 'N0') AS TongLuongTT, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) * 0.105), 'N0') AS BaoHiem, " +
                "FORMAT(COALESCE(PhucLoi.SoTienThuong, 0), 'N0') AS SoTienThuong, " +
                "FORMAT(COALESCE(LoiPhat.SoPhat, 0), 'N0') AS SoPhat, " +
                "FORMAT(COALESCE(TU.SoTienUng, 0), 'N0') AS SoTienUng, " +
                "FORMAT((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0) - COALESCE(NV.BaoHiem, 0) + COALESCE(PhucLoi.SoTienThuong, 0) - COALESCE(LoiPhat.SoPhat, 0) - COALESCE(TU.SoTienUng, 0)), 'N0') AS ThucNhan " +
                "FROM NhanVien NV " +
                "LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "LEFT JOIN Luong L ON NV.MaLuong = L.MaLuong " +
                "LEFT JOIN KhenThuong KT ON NV.MaNV = KT.MaNV " +
                "LEFT JOIN KyLuat KL ON NV.MaNV = KL.MaNV " +
                "LEFT JOIN TamUng TU ON NV.MaNV = TU.MaNV " +
                "LEFT JOIN PhucLoi ON PhucLoi.MaPhucLoi = KT.MaPhucLoi " +
                "LEFT JOIN LoiPhat ON KL.MaLoiPhat = LoiPhat.MaLoiPhat " +
            "LEFT JOIN NgayLamViec ON NgayLamViec.MaNV = NV.MaNV " +
                "WHERE MONTH(NgayLamViec.NgayLamViec) = @NgayLamViec ";

            sqlCmd.Parameters.AddWithValue("@NgayLamViec", selectedMonth);
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvTinhLuong.Items.Clear();

            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                string tenpb = reader.GetString(2);
                string sotienluong = reader.GetString(3);
                string phucap = reader.GetString(4);
                string cong = reader.GetString(5);
                string tongluongtt = reader.GetString(6);
                string baohiem = reader.GetString(7);
                string sotienthuong = reader.GetString(8);
                string sotienphat = reader.GetString(9);
                string sotienung = reader.GetString(10);
                string thucnhan = reader.GetString(11);



                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(tenpb);
                lvi.SubItems.Add(sotienluong.ToString());
                lvi.SubItems.Add(phucap.ToString());
                lvi.SubItems.Add(cong.ToString());
                lvi.SubItems.Add(tongluongtt.ToString());
                lvi.SubItems.Add(baohiem.ToString());
                lvi.SubItems.Add(sotienthuong.ToString());
                lvi.SubItems.Add(sotienphat.ToString());
                lvi.SubItems.Add(sotienung.ToString());
                lvi.SubItems.Add(thucnhan.ToString());

                lvTinhLuong.Items.Add(lvi);

            }
            reader.Close();
            sqlCon.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            string tenNV = txtTenNV.Text.Trim();

            if (string.IsNullOrEmpty(tenNV))
            {
                // Nếu tên nhân viên rỗng, hiển thị toàn bộ danh sách nhân viên
                HienThiDanhSach();
            }
            else
            {
                // Ngược lại, hiển thị danh sách nhân viên có tên tương ứng
                HienThiThongTinNhanVien(tenNV);
            }
        }

        private void HienThiThongTinNhanVien(string tenNV)
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
            sqlCmd.CommandText = sqlCmd.CommandText = "SELECT " +
                "NV.MaNV, " +
                "NV.TenNV, " +
                "PB.TenPB, " +
                "FORMAT(COALESCE(L.SoTienLuong, 0), 'N0') AS SoTienLuong, " +
                "FORMAT(COALESCE(L.TroCap, 0), 'N0') AS PhuCap, " +
                "FORMAT(COALESCE(NV.Cong, 0), 'N0') AS Cong, " +
                "FORMAT((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)), 'N0') AS TongLuongTT, " +
                "FORMAT(COALESCE(PhucLoi.SoTienThuong, 0), 'N0') AS SoTienThuong, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105), 'N0') AS BaoHiem, " +
                "FORMAT((((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)\r\n, 'N0') AS ThueTNCN,  " +

                "FORMAT(COALESCE(LoiPhat.SoPhat, 0), 'N0') AS SoPhat, " +
                "FORMAT(COALESCE(TU.SoTienUng, 0), 'N0') AS SoTienUng, " +
                "FORMAT(((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105) + COALESCE(PhucLoi.SoTienThuong, 0) - COALESCE(LoiPhat.SoPhat, 0) - COALESCE(TU.SoTienUng, 0)) - (((((COALESCE(L.SoTienLuong, 0) * COALESCE(NV.Cong, 0) + COALESCE(L.TroCap, 0)) - ((COALESCE(L.SoTienLuong, 0) * 22 ) * 0.105))  - COALESCE(L.TroCap, 0))) * 0.05)) , 'N0') AS ThucNhan " +
                "FROM NhanVien NV " +
                "LEFT JOIN PhongBan PB ON NV.MaPB = PB.MaPB " +
                "LEFT JOIN Luong L ON NV.MaLuong = L.MaLuong " +
                "LEFT JOIN KhenThuong KT ON NV.MaNV = KT.MaNV " +
                "LEFT JOIN KyLuat KL ON NV.MaNV = KL.MaNV " +
                "LEFT JOIN TamUng TU ON NV.MaNV = TU.MaNV " +
                "LEFT JOIN PhucLoi ON PhucLoi.MaPhucLoi = KT.MaPhucLoi " +
                "LEFT JOIN LoiPhat ON KL.MaLoiPhat = LoiPhat.MaLoiPhat " +
                "LEFT JOIN NgayLamViec ON NgayLamViec.MaNV = NV.MaNV " +
                "WHERE NV.TenNV LIKE @TenNV ";

            sqlCmd.Parameters.AddWithValue("@TenNV", "%" + tenNV + "%");
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lvTinhLuong.Items.Clear();

            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                string tenpb = reader.GetString(2);
                string sotienluong = reader.GetString(3);
                string phucap = reader.GetString(4);
                string cong = reader.GetString(5);
                string tongluongtt = reader.GetString(6);
                string sotienthuong = reader.GetString(7);
                string baohiem = reader.GetString(8);
                string thuetncn = reader.GetString(9);
                string sotienphat = reader.GetString(10);
                string sotienung = reader.GetString(11);
                string thucnhan = reader.GetString(12);

                ListViewItem lvi = new ListViewItem(manv.ToString());
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(tenpb);
                lvi.SubItems.Add(sotienluong.ToString());
                lvi.SubItems.Add(phucap.ToString());
                lvi.SubItems.Add(cong.ToString());
                lvi.SubItems.Add(tongluongtt.ToString());
                lvi.SubItems.Add(sotienthuong.ToString());
                lvi.SubItems.Add(baohiem.ToString());
                lvi.SubItems.Add(thuetncn.ToString());
                lvi.SubItems.Add(sotienphat.ToString());
                lvi.SubItems.Add(sotienung.ToString());
                lvi.SubItems.Add(thucnhan.ToString());

                lvTinhLuong.Items.Add(lvi);

            }
            reader.Close();
            sqlCon.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            rptTinhLuong rptTinhLuong = new rptTinhLuong();
            rptTinhLuong.Show();

            


        }
    }


}
