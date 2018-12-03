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
    public partial class Phieutra : Form
    {
        SqlConnection cnn;
        string flag;
        int index;
        public Phieutra()
        {
            InitializeComponent();
        }
        public static string sp = "";
        private void btnctptra_Click(object sender, EventArgs e)
        {
            sp = txtmaptra.Text;
            CTphieutra frm = new CTphieutra();
            frm.Show();
        }
        public void khoacontrol()
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            //btntimkiem.Enabled = true;
            btnthoat.Enabled = false;
            btnluu.Enabled = false;

            txtmaptra.ReadOnly = false;
            //txtmanv.ReadOnly = true;
            //txtmadg.ReadOnly = true;
            txttinhtrang.ReadOnly = true;
            //txtmapmuon.ReadOnly = true;

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

            txtmaptra.ReadOnly = true;
            //txtmanv.ReadOnly = false;
            //txtmadg.ReadOnly = false;
            txttinhtrang.ReadOnly = false;
            //txtmapmuon.ReadOnly = false;

            txtmaptra.Focus();
        }
        public void un1lockcontrol()
        {
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            //btntimkiem.Enabled = false;
            btnluu.Enabled = true;
            btnthoat.Enabled = true;

            txtmaptra.ReadOnly = true;
            //txtmanv.ReadOnly = false;
            //txtmadg.ReadOnly = false;
            txttinhtrang.ReadOnly =false;
            //txtmapmuon.ReadOnly = false;

            txtmaptra.Focus();
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
            index = dtgphieutra.CurrentRow.Index;
            txtmaptra.Text = dtgphieutra.Rows[index].Cells[0].Value.ToString();
            cbotenNV.Text = dtgphieutra.Rows[index].Cells[1].Value.ToString();
            cbotenDG.Text = dtgphieutra.Rows[index].Cells[2].Value.ToString();
            dtpngaytra.Text = dtgphieutra.Rows[index].Cells[3].Value.ToString();
            txttinhtrang.Text = dtgphieutra.Rows[index].Cells[4].Value.ToString();
            cboPM.Text = dtgphieutra.Rows[index].Cells[5].Value.ToString();
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
            cbo.DisplayMember = dt.Columns[1].ToString();
            cbo.ValueMember = dt.Columns[0].ToString();
        }

        public void Load_cboPT(string lenh, ComboBox cbo)
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
        private void Phieutra_Load(object sender, EventArgs e)
        {
            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select [MaPhieuTra] ,[TenNV],[TenDG],[NgayTra],[TinhTrang],[dbo].[PHIEUMUON].[MaPhieuMuon]  from ([dbo].[PHIEUMUON] inner join [dbo].[NHANVIEN] on [dbo].[PHIEUMUON].[MaNV]=[dbo].[NHANVIEN].MaNV) inner join[dbo].[DOCGIA] on[dbo].[PHIEUMUON].MaDG = DOCGIA.MaDG inner join[dbo].[PHIEUTRA] on[dbo].[DOCGIA].MaDG =[dbo].[PHIEUTRA].MaDG", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgphieutra.DataSource = tb;
                        Load_cbo("cbo_NhanVien", cbotenNV);
                        Load_cbo("cbo_DocGia", cbotenDG);
                        Load_cboPT("cbo_phieumuon", cboPM);
                    }
                }
            }
            loaddl();
        }

        private void dtgphieutra_Click(object sender, EventArgs e)
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
            txtmaptra.Text = " ";
            //txtmanv.Text = " ";
           // txtmadg.Text = " ";
            txttinhtrang.Text = " ";
           // txtmapmuon.Text = " ";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            un1lockcontrol();
            
            txtmaptra.Focus();
            flag = "edit";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            connect();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "delete_PhieuTra";
            cmd.Parameters.AddWithValue("@maPhieuTra", txtmaptra.Text);
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Phieutra_Load(sender, e);
            }

        }
        private bool kiemtrama()
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KT_MaPhieuTra";
            cmd.Parameters.AddWithValue("@maPhieuTra", txtmaptra.Text);
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
                if (checkdata())
                {
                 
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Them_PhieuTra";
                    cmd.Parameters.AddWithValue("@maPhieuTra", txtmaptra.Text);
                    cmd.Parameters.AddWithValue("@maNV", cbotenNV.SelectedValue);
                    cmd.Parameters.AddWithValue("@maDG ", cbotenDG.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngayTra", Convert.ToDateTime(dtpngaytra.Value.ToString()));
                    cmd.Parameters.AddWithValue("@tinhTrang", txttinhtrang.Text);
                    cmd.Parameters.AddWithValue("@maPhieuMuon", cboPM.SelectedValue);

                    if (kiemtrama())
                    {
                        MessageBox.Show("Mã Phiếu Trả đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmaptra.Focus();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Phieutra_Load(sender, e);
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
                    cmd.CommandText = "update_PhieuTra";
                    cmd.Parameters.AddWithValue("@maPhieuTra", txtmaptra.Text);
                    cmd.Parameters.AddWithValue("@maNV", cbotenNV.SelectedValue);
                    cmd.Parameters.AddWithValue("@maDG ", cbotenDG.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngayTra", Convert.ToDateTime(dtpngaytra.Value.ToString()));
                    cmd.Parameters.AddWithValue("@tinhTrang", txttinhtrang.Text);
                    cmd.Parameters.AddWithValue("@maPhieuMuon", cboPM.SelectedValue);
                    
                    cmd.ExecuteNonQuery();
                    Phieutra_Load(sender, e);
                        MessageBox.Show("Sửa thành công phiếu trả");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Sửa không thành công" + ex);
                }

            }
        }
        public bool checkdata()
        {
            if (string.IsNullOrWhiteSpace(txtmaptra.Text))
            {
                MessageBox.Show("bạn chưa nhập mã Phiếu trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaptra.Focus();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txtmanv.Text))
            //{
            //    MessageBox.Show("bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtmanv.Focus();
            //    return false;
            //}
            //if (string.IsNullOrWhiteSpace(txtmadg.Text))
            //{
            //    MessageBox.Show("bạn chưa nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtmadg.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(txttinhtrang.Text))
            {
                MessageBox.Show("bạn chưa nhập tình trạng trả sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txtmapmuon.Text))
            //{
            //    MessageBox.Show("bạn chưa nhập mã phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtmapmuon.Focus();
            //    return false;
            //}
            
            return true;
        }
    }
}
