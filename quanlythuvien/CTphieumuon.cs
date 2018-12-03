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
    public partial class CTphieumuon : Form
    {
        SqlConnection cnn;
        string flag;
        int index;
        public CTphieumuon()
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

            //txtmaphieumuon.ReadOnly = true;
            //txtmasachmuon.ReadOnly = true;
            txtsoluongmuon.ReadOnly = true;
            cbomapm.Enabled = false;
            cbomasach.Enabled = false;

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

            //cbomasach.ReadOnly = false;
            //txtmasachmuon.ReadOnly = false;
            txtsoluongmuon.ReadOnly = false;
            cbomapm.Enabled = true;
            cbomasach.Enabled = true;
            //txtmaphieumuon.Focus();
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
            index = dtgctpmuon.CurrentRow.Index;
            cbomapm.Text = dtgctpmuon.Rows[index].Cells[0].Value.ToString();
            cbomasach.Text = dtgctpmuon.Rows[index].Cells[1].Value.ToString();
            txtsoluongmuon.Text = dtgctpmuon.Rows[index].Cells[2].Value.ToString();
            
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
        private void CTphieumuon_Load(object sender, EventArgs e)
        {
            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from CHITIETPHIEUMUON", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgctpmuon.DataSource = tb;
                        Load_cbo("cbo_phieumuon", cbomapm);
                        Load_cbo("cbo_sach", cbomasach);
                    }
                }
            }
            loaddl();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            connect();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "delete_CTPhieumuon";
            cmd.Parameters.AddWithValue("@maPhieumuon", cbomapm.Text);
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CTphieumuon_Load(sender, e);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            flag = "add";
            cbomapm.Text=" ";
            //txtmanv.Text = " ";
            // txtmadg.Text = " ";
            cbomasach.Text = " ";
            // txtmapmuon.Text = " ";
            txtsoluongmuon.Text = " ";

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            flag = "edit";
            cbomapm.Text = " ";
            //txtmanv.Text = " ";
            // txtmadg.Text = " ";
            cbomasach.Text = " ";
            // txtmapmuon.Text = " ";
            txtsoluongmuon.Text = " ";
         
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                if (String.IsNullOrEmpty(cbomapm.Text) || String.IsNullOrEmpty(cbomasach.Text))
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Them_CtPhieumuon";
                    cmd.Parameters.AddWithValue("@mapm", cbomapm.SelectedValue);
                    cmd.Parameters.AddWithValue("@masach", cbomasach.SelectedValue);
                    cmd.Parameters.AddWithValue("@soluong", txtsoluongmuon.Text);
                    cmd.ExecuteNonQuery();
                    CTphieumuon_Load(sender, e);
                }
            }
            else
            {
                connect();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_CtPhieumuon";
                cmd.Parameters.AddWithValue("@mapm", cbomapm.SelectedValue);
                cmd.Parameters.AddWithValue("@masach", cbomasach.SelectedValue);
                cmd.Parameters.AddWithValue("@soluong", txtsoluongmuon.Text);
                cmd.ExecuteNonQuery();
                CTphieumuon_Load(sender, e);
            }

        }

        private void dtgctpmuon_Click(object sender, EventArgs e)
        {
            loaddl();
        }
    }
}
