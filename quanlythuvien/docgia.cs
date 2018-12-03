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
    public partial class docgia : Form
    {
        SqlConnection cnn;
        string flag;
        int index;
        public docgia()
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

            txtmadocgia.ReadOnly = true;
            txttendocgia.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtdienthoai.ReadOnly = true;

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

            txtmadocgia.ReadOnly = false;
            txttendocgia.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtdienthoai.ReadOnly = false;

            txtmadocgia.Focus();
        }
        //kết nối csql
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
            index = dtgdocgia.CurrentRow.Index;
            txtmadocgia.Text = dtgdocgia.Rows[index].Cells[0].Value.ToString();
            txttendocgia.Text = dtgdocgia.Rows[index].Cells[1].Value.ToString();
            dtpngaysinhdg.Text = dtgdocgia.Rows[index].Cells[2].Value.ToString();
            if (dtgdocgia.Rows[index].Cells[3].Value.ToString().Trim().Equals("Nam"))
            {
                rbtnnam.Checked = true;
            }
            else
            {
                rbtnnu.Checked = true;
            }
            txtdiachi.Text = dtgdocgia.Rows[index].Cells[4].Value.ToString();
            txtdienthoai.Text = dtgdocgia.Rows[index].Cells[5].Value.ToString();
        }
        private void docgia_Load(object sender, EventArgs e)
        {
            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from DOCGIA", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgdocgia.DataSource = tb;
                    }
                }
            }
            loaddl();
        }
        private bool kiemtrama()
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KT_MaDG";
            cmd.Parameters.AddWithValue("@maDG", txtmadocgia.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = dt.Rows.Count;
            return i > 0;
        }

        private void dtgdocgia_Click(object sender, EventArgs e)
        {
            loaddl();
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
            txtmadocgia.Text = " ";
            txttendocgia.Text = " ";
            txtdienthoai.Text = " ";
            txtdiachi.Text = " ";
            rbtnnam.Checked = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            txtmadocgia.Focus();
            flag = "edit";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                connect();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "delete_DG";
                cmd.Parameters.AddWithValue("@maDG", txtmadocgia.Text);
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    docgia_Load(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Độc giả đã tồn tại ở bẳng khác! Không thể xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {

            if (flag == "add")
            {
                if (checkdata())
                {
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Them_DG";
                    cmd.Parameters.AddWithValue("@maDG", txtmadocgia.Text);
                    cmd.Parameters.AddWithValue("@tenDG", txttendocgia.Text);
                    cmd.Parameters.AddWithValue("@NS", Convert.ToDateTime(dtpngaysinhdg.Value.ToString()));
                    if (rbtnnam.Checked)
                        cmd.Parameters.AddWithValue("@GT", "Nam");
                    else
                        cmd.Parameters.AddWithValue("@GT", "Nữ");
                    cmd.Parameters.AddWithValue("@DC", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@DT", txtdienthoai.Text);
                    
                    //cmd.Parameters.AddWithValue("@mapb", comboxmapb.SelectedValue);
                    if (kiemtrama())
                    {
                        MessageBox.Show("Mã độc giả đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmadocgia.Focus();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        docgia_Load(sender, e);
                    }
                }
            }
            else
            {
                try
                {
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "update_DG";
                    cmd.Parameters.AddWithValue("@maDG", txtmadocgia.Text);
                    cmd.Parameters.AddWithValue("@tenDG", txttendocgia.Text);
                    cmd.Parameters.AddWithValue("@NS", Convert.ToDateTime(dtpngaysinhdg.Value.ToString()));
                    if (rbtnnam.Checked)
                        cmd.Parameters.AddWithValue("@GT", "Nam");
                    else
                        cmd.Parameters.AddWithValue("@GT", "Nữ");
                    cmd.Parameters.AddWithValue("@DC", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@DT", txtdienthoai.Text);

                    cmd.ExecuteNonQuery();
                    docgia_Load(sender, e);
                    MessageBox.Show("Sửa thành công độc giả");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Sửa không thành công" + ex);
                }

            }
        }
        public bool checkdata()
        {
            if (string.IsNullOrWhiteSpace(txtmadocgia.Text))
            {
                MessageBox.Show("bạn chưa nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadocgia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txttendocgia.Text))
            {
                MessageBox.Show("bạn chưa nhập tên độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttendocgia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("bạn chưa nhập địa chỉ của độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtdienthoai.Text))
            {
                MessageBox.Show("bạn chưa nhập điện thoại của độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdienthoai.Focus();
                return false;
            }
            
            return true;
        }
    }
}
