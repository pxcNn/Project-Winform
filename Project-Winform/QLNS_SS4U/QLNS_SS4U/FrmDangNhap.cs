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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNS_SS4U
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.IO.File.ReadAllText("config.txt"));
            try
            {
                conn.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;

                if (tk == null || tk.Equals(""))
                {
                    MessageBox.Show("Chưa nhập Username");
                    return;
                }
                if (mk == null || mk.Equals(""))
                {
                    MessageBox.Show("Chưa nhập Password");
                    return;
                }
                

                string sql = "select * from ThongTinDangNhap where TaiKhoan = '" + tk + "' and MatKhau='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Focus();
                }
                
            }   
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!");
            }
            

        }
        



        private void button2_Click(object sender, EventArgs e)
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

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            
            
        }

        private void phide_Click(object sender, EventArgs e)
        {
            
        }

        private void pview_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void pview_Click_1(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                phide.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void phide_Click_1(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                pview.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }
    }
}
