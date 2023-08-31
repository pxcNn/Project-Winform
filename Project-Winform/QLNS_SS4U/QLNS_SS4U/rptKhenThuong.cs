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
    public partial class rptKhenThuong : Form
    {
        string strCon = System.IO.File.ReadAllText("config.txt");
        SqlConnection sqlCon = null;
        public rptKhenThuong()
        {
            InitializeComponent();
        }

        private void rptKhenThuong_Load(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }

            string sql = "SELECT MaPhucLoi, TenPhucLoi, FORMAT(SoTienThuong,'N0') AS SoTienThuong, FORMAT(NgayTao,'dd/MM/yyyy') AS NgayTao, FORMAT(NgaySuaDoi,'dd/MM/yyyy') AS NgaySuaDoi, BiXoa FROM PhucLoi;";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, strCon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "PhucLoi");

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNS_SS4U.prtKhenThuong.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables["PhucLoi"];
            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
