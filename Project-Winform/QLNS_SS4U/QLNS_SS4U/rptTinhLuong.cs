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
using Microsoft.Reporting.WinForms;


namespace QLNS_SS4U
{
    public partial class rptTinhLuong : Form
    {

        string strCon = System.IO.File.ReadAllText("config.txt");

        SqlConnection sqlCon = null;
        public rptTinhLuong()
        {
            InitializeComponent();
        }

        private void rptTinhLuong_Load(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            
            string sql = "SELECT " +
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
            SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Luong");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNS_SS4U.rptTinhLuong.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables["Luong"];
            this.reportViewer1.LocalReport.DataSources.Add(rds);





            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
