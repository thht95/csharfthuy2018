using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace quanlythuvien
{
    public partial class frmnhanvien1990 : Form
    {
        public frmnhanvien1990()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pr_NhanVien1990";
                //cmd.Parameters.AddWithValue("@nam", Convert.ToInt32(mtxt_nam.Text.ToString()));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptnhanvien1990 rp = new rptnhanvien1990();
                rp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rp;
            }
        }
    }
}
