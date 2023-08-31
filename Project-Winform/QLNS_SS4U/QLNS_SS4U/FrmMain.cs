using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_SS4U
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            FrmChucVu frmChucVu = new FrmChucVu();
            frmChucVu.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNhanVien frmNhanVien = new FrmNhanVien();
            frmNhanVien.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmTamUng frmTamUng = new FrmTamUng();
            frmTamUng.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmTinhLuong frmTinhLuong = new FrmTinhLuong();
            frmTinhLuong.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmPhongBan frmPhongBan = new FrmPhongBan();
            frmPhongBan.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmNgayLamViec frmNgayLamViec = new FrmNgayLamViec();
            frmNgayLamViec.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmLuong frmLuong   = new FrmLuong();
            frmLuong.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmLoiPhat Frm = new FrmLoiPhat();
            Frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmKhenThuong frmKhenThuong = new FrmKhenThuong();
            frmKhenThuong.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmKyLuat frmKyLuat = new FrmKyLuat();
            frmKyLuat.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmPhucLoi frmPhucLoi = new FrmPhucLoi();
            frmPhucLoi.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất ra hay không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.Show();
                this.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnChangeDataSource_Click(object sender, EventArgs e)
        {
            string dataSource = "Data Source=DESKTOP-42GU85A;Initial Catalog=QLNS_SS4U;Integrated Security=True";
            string initialCatalog = "QLNS_SS4U";
            bool integratedSecurity = true;

            DatabaseManager.SetConnectionString(dataSource, initialCatalog, integratedSecurity);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }    
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
