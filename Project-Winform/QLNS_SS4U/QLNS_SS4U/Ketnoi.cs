using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLNS_SS4U
{
    internal class Ketnoi 
    {
        

        public Ketnoi()
        {
           
        }


        public static SqlConnection MoKetNoi()
        {
            string strCon = @"Data Source=DESKTOP-42GU85A;Initial Catalog=QLNS_SS4U;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            return sqlCon;
        }

        public static void DongKetNoi(SqlConnection sqlCon)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
    }
}

