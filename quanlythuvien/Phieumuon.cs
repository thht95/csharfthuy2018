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
    public partial class Phieumuon : Form
    {

        SqlConnection cnn;
        string flag;
        int index;
        public Phieumuon()
        {
            InitializeComponent();
        }
        public static string sp = "";
        private void btnctpmuon_Click(object sender, EventArgs e)
        {
            sp = txtmapm.Text;
            CTphieumuon frm1 = new CTphieumuon();
            frm1.Show();
        }
        public void khoacontrol()
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            //btntimkiem.Enabled = true;
            btnthoat.Enabled = false;
            btnluu.Enabled = false;

            txtmapm.ReadOnly = true;
            //txtmanvpm.ReadOnly = true;
            //txtmadgpm.ReadOnly = true;

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

            txtmapm.ReadOnly = false;
            //cbomanhanvienpm.ReadOnly = false;
            //txtmadgpm.ReadOnly = false;

            txtmapm.Focus();
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
            index = dtgphieumuon.CurrentRow.Index;
            txtmapm.Text = dtgphieumuon.Rows[index].Cells[0].Value.ToString();
            cboNV.Text = dtgphieumuon.Rows[index].Cells[1].Value.ToString();
            cboDG.Text = dtgphieumuon.Rows[index].Cells[2].Value.ToString();
            dtpngaymuon.Text = dtgphieumuon.Rows[index].Cells[3].Value.ToString();
            dtpngayhentra.Text = dtgphieumuon.Rows[index].Cells[4].Value.ToString();
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
        private void Phieumuon_Load(object sender, EventArgs e)
        {
            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select [MaPhieuMuon],[TenNV],[TenDG],[NgayMuon],[NgayHenTra] from ([dbo].[PHIEUMUON] inner join [dbo].[NHANVIEN] on [dbo].[PHIEUMUON].[MaNV]=[dbo].[NHANVIEN].MaNV) inner join[dbo].[DOCGIA] on[dbo].[PHIEUMUON].MaDG = DOCGIA.MaDG", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgphieumuon.DataSource = tb;
                        Load_cbo("cbo_NhanVien", cboNV);
                        Load_cbo("cbo_DocGia", cboDG);
                    }
                }
            }
            loaddl();
        }
        private bool kiemtrama()
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KT_MaPhieuMuon";
            cmd.Parameters.AddWithValue("@maPhieuMuon", txtmapm.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = dt.Rows.Count;
            return i > 0;
        }

        private void dtgphieumuon_Click(object sender, EventArgs e)
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
            txtmapm.Text = " ";

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            txtmapm.Focus();
            flag = "edit";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            connect();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "delete_Phieumuon";
            cmd.Parameters.AddWithValue("@maPhieuMuon", txtmapm.Text);
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Phieumuon_Load(sender, e);
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
                    cmd.CommandText = "Them_PhieuMuon";
                    cmd.Parameters.AddWithValue("@maPhieuMuon", txtmapm.Text);
                    cmd.Parameters.AddWithValue("@maNV ", cboNV.SelectedValue);
                    cmd.Parameters.AddWithValue("@maDG ", cboDG.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngayMuon", Convert.ToDateTime(dtpngaymuon.Value.ToString()));
                    cmd.Parameters.AddWithValue("@ngayHenTra", Convert.ToDateTime(dtpngayhentra.Value.ToString()));

                    if (kiemtrama())
                    {
                        MessageBox.Show("Mã Phiếu mượn đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmapm.Focus();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Phieumuon_Load(sender, e);
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
                    cmd.CommandText = "update_PhieuMuon";
                    cmd.Parameters.AddWithValue("@maPhieuMuon", txtmapm.Text);
                    cmd.Parameters.AddWithValue("@maNV ", cboNV.SelectedValue);
                    cmd.Parameters.AddWithValue("@maDG ", cboDG.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngayMuon", Convert.ToDateTime(dtpngaymuon.Value.ToString()));
                    cmd.Parameters.AddWithValue("@ngayHenTra", Convert.ToDateTime(dtpngayhentra.Value.ToString()));

                    cmd.ExecuteNonQuery();
                    Phieumuon_Load(sender, e);
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
            if (string.IsNullOrWhiteSpace(txtmapm.Text))
            {
                MessageBox.Show("bạn chưa nhập mã Phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmapm.Focus();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(txtmanvpm.Text))
            //{
            //    MessageBox.Show("bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtmanvpm.Focus();
            //    return false;
            //}
            //if (string.IsNullOrWhiteSpace(txtmadgpm.Text))
            //{
            //    MessageBox.Show("bạn chưa nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtmadgpm.Focus();
            //    return false;
            //}
            return true;
        }
        private DataTable Laydanhsach(string sFilter)
        {
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sqlSelect = "select * from PHIEUMUON where" + sFilter;
                using (SqlCommand cmd = new SqlCommand(sqlSelect, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable t = new DataTable("PHIEUMUON");
                        da.Fill(t);
                        cnn.Close();
                        return t;
                    }
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sFilter = " 1>0 ";
            if (!string.IsNullOrEmpty(txtmapm.Text.Trim()))
            {
                sFilter += string.Format("and MaPhieuMuon like N'%{0}%'", txtmapm.Text.Trim().ToString());
                dtgphieumuon.DataSource = Laydanhsach(sFilter);

                //if (!string.IsNullOrEmpty(txt_tennv.Text.Trim()))
                //{
                //    sFilter += string.Format("and tennv like N'%{0}%'", txt_tennv.Text.Trim().ToString());
                //    datagrid_nhanvien.DataSource = Laydanhsach(sFilter);
                //    txt_tennv.Focus();
                //}


                //if (!string.IsNullOrEmpty(txt_diachi.Text.Trim()))
                //{
                //    sFilter += string.Format("and diachi like N'%{0}%'", txt_diachi.Text.Trim().ToString());
                //    datagrid_nhanvien.DataSource = Laydanhsach(sFilter);
                //    txt_diachi.Focus();
                //}
                //if (!string.IsNullOrEmpty(txt_sdt.Text.Trim()))
                //{
                //    sFilter += string.Format("and sdt like N'%{0}%'", txt_sdt.Text.Trim().ToString());
                //    datagrid_nhanvien.DataSource = Laydanhsach(sFilter);
                //    txt_sdt.Focus();
                //}
                //if (!string.IsNullOrEmpty(mtxt_cmnd.Text.Trim()))
                //{
                //    sFilter += string.Format("and cmnd like N'%{0}%'", mtxt_cmnd.Text.Trim().ToString());
                //    datagrid_nhanvien.DataSource = Laydanhsach(sFilter);
                //    mtxt_cmnd.Focus();
                //}
            }
        }
    }
}