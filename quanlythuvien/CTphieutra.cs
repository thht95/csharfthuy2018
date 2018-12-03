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
    public partial class CTphieutra : Form
    {
        SqlConnection cnn;
        string flag;
        int index;
        public CTphieutra()
        {
            InitializeComponent();
        }
        public void khoacontrol()
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            //btntimkiem.Enabled = true;
            btnthoat.Enabled = false;
            btnluu.Enabled = false;

            //txtmactptra.ReadOnly = true;
            //txtmasach.ReadOnly = true;
            txtsoluong.ReadOnly = true;

            btnthem.Focus();

        }
        public void unlockcontrol()
        {
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            //btntimkiem.Enabled = false;
            btnluu.Enabled = true;
            btnthoat.Enabled = true;

            //txtmactptra.ReadOnly = false;
            //txtmasach.ReadOnly = false;
            txtsoluong.ReadOnly = false;

            //txtmactptra.Focus();
        }

        private void connect()
        {
            try
            {
                String constr = @"Data Source=DESKTOP-7Q4SCJC\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True";
                cnn = new SqlConnection(constr);
                cnn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối không thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void loaddl()
        {
            index = dtgctptra.CurrentRow.Index;
            cbomapt.Text = dtgctptra.Rows[index].Cells[0].Value.ToString();
            cbomasach.Text = dtgctptra.Rows[index].Cells[1].Value.ToString();
            txtsoluong.Text = dtgctptra.Rows[index].Cells[2].Value.ToString();

        }
        private void CTphieutra_Load(object sender, EventArgs e)
        {

            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from CHITIETPHIEUTRA", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgctptra.DataSource = tb;
                        Load_cbo("cbo_phieutra", cbomapt);
                        Load_cbo("cbo_sach", cbomasach);
                    }
                }
            }
            loaddl();
        }
        public void Load_cbo(string lenh, ComboBox cbo)
        {
            connect();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = lenh;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = dt.Columns[0].ToString();
            cbo.ValueMember = dt.Columns[0].ToString();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void dtgctptra_Click(object sender, EventArgs e)
        {
            loaddl();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            connect();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "delete_PhieuTra";
            cmd.Parameters.AddWithValue("@maPhieuTra", cbomapt.Text);
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CTphieutra_Load(sender, e);
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            flag = "add";
            cbomapt.Text = " ";
            //txtmanv.Text = " ";
            // txtmadg.Text = " ";
            cbomasach.Text = " ";
            // txtmapmuon.Text = " ";
            txtsoluong.Text = " ";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            flag = "edit";
            cbomapt.Text = " ";
            //txtmanv.Text = " ";
            // txtmadg.Text = " ";
            cbomasach.Text = " ";
            // txtmapmuon.Text = " ";
            txtsoluong.Text = " ";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                if (String.IsNullOrEmpty(cbomapt.Text) || String.IsNullOrEmpty(cbomasach.Text))
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Them_CtPhieutra";
                    cmd.Parameters.AddWithValue("@mapt", cbomapt.SelectedValue);
                    cmd.Parameters.AddWithValue("@masach", cbomasach.SelectedValue);
                    cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                    cmd.ExecuteNonQuery();
                    CTphieutra_Load(sender, e);
                }
            }
            else
            {
                connect();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_CtPhieutra";
                cmd.Parameters.AddWithValue("@mapt", cbomapt.SelectedValue);
                cmd.Parameters.AddWithValue("@masach", cbomasach.SelectedValue);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.ExecuteNonQuery();
                CTphieutra_Load(sender, e);
            }
        }
    }
}
