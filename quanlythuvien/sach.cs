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
    public partial class Sach : Form
    {
        SqlConnection cnn;
        string flag;
        int index;
        public Sach()
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

            txtmasach.ReadOnly = true;
            txttensach.ReadOnly = true;
            txtloaisach.ReadOnly = true;
            txtlinhvuc.ReadOnly = true;
            txttacgia.ReadOnly = true;
            txtnxb.ReadOnly = true;

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

            txtmasach.ReadOnly = false;
            txttensach.ReadOnly = false;
            txtloaisach.ReadOnly = false;
            txtlinhvuc.ReadOnly = false;
            txttacgia.ReadOnly = false;
            txtnxb.ReadOnly = false;

            txtmasach.Focus();

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
        private void Sach_Load(object sender, EventArgs e)
        {

            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from SACH", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgsach.DataSource = tb;
                    }
                }
            }
            loaddata();
        }
        //loát dữ liệu lên các ô
        private void loaddata()
        {
            index = dtgsach.CurrentRow.Index;
            txtmasach.Text = dtgsach.Rows[index].Cells[0].Value.ToString();
            txttensach.Text = dtgsach.Rows[index].Cells[1].Value.ToString();
            txtloaisach.Text = dtgsach.Rows[index].Cells[2].Value.ToString();
            txtlinhvuc.Text = dtgsach.Rows[index].Cells[3].Value.ToString();
            txttacgia.Text = dtgsach.Rows[index].Cells[4].Value.ToString();
            txtnxb.Text = dtgsach.Rows[index].Cells[5].Value.ToString();
            dtpnxb.Text = dtgsach.Rows[index].Cells[6].Value.ToString();

        }
        //loát dl lên khi kích vào
        private void dtgsach_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            flag = "add";
            txtmasach.Text = " ";
            txttensach.Text = " ";
            txtloaisach.Text = " ";
            txtlinhvuc.Text = " ";
            txttacgia.Text = " ";
            txtnxb.Text = " ";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            txtmasach.Focus();
            flag = "edit";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            connect();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "delete_Sach";
            cmd.Parameters.AddWithValue("@manv", txtmasach.Text);
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sach_Load(sender, e);
            }
        }
        private bool kiemtrama()
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KT_MaSach";
            cmd.Parameters.AddWithValue("@maSach", txtmasach.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = dt.Rows.Count;
            return i > 0;
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
               // if (checkdata())
                {
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Them_Sach";
                    cmd.Parameters.AddWithValue("@maSach", txtmasach.Text);
                    cmd.Parameters.AddWithValue("@tenSach", txttensach.Text);
                    cmd.Parameters.AddWithValue("@loaiSach", txtloaisach.Text);
                    cmd.Parameters.AddWithValue("@linhVuc", txtlinhvuc.Text);
                    cmd.Parameters.AddWithValue("@tacGia", txttacgia.Text);
                    cmd.Parameters.AddWithValue("@NhaXB", txtnxb.Text);
                    cmd.Parameters.AddWithValue("@ngayXB", Convert.ToDateTime(dtpnxb.Value.ToString()));
                    
                    //cmd.Parameters.AddWithValue("@mapb", comboxmapb.SelectedValue);
                    if (kiemtrama())
                    {
                        MessageBox.Show("Mã sách đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmasach.Focus();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã thêm sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sach_Load(sender, e);
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
                    cmd.CommandText = "update_Sach";
                    cmd.Parameters.AddWithValue("@maSach", txtmasach.Text);
                    cmd.Parameters.AddWithValue("@tenSach", txttensach.Text);
                    cmd.Parameters.AddWithValue("@loaiSach", txtloaisach.Text);
                    cmd.Parameters.AddWithValue("@linhVuc", txtlinhvuc.Text);
                    cmd.Parameters.AddWithValue("@tacGia", txttacgia.Text);
                    cmd.Parameters.AddWithValue("@NhaXB", txtnxb.Text);
                    cmd.Parameters.AddWithValue("@ngayXB", Convert.ToDateTime(dtpnxb.Value.ToString()));

                    cmd.ExecuteNonQuery();
                    Sach_Load(sender, e);
                    MessageBox.Show("Sửa thành công");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Sửa không thành công" + ex);
                }

            }
        }

        public bool checkdata()
        {
            if (string.IsNullOrWhiteSpace(txtmasach.Text))
            {
                MessageBox.Show("bạn chưa nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasach.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txttensach.Text))
            {
                MessageBox.Show("bạn chưa nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttensach.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtloaisach.Text))
            {
                MessageBox.Show("bạn chưa nhập loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtloaisach.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtlinhvuc.Text))
            {
                MessageBox.Show("bạn chưa nhập lĩnh vực cho sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlinhvuc.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txttacgia.Text))
            {
                MessageBox.Show("bạn chưa nhập tác giả của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttacgia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtnxb.Text))
            {
                MessageBox.Show("bạn chưa nhập nhà xuất bản của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnxb.Focus();
                return false;
            }
            return true;
        }
    }
}
