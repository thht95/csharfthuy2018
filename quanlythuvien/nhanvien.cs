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
    public partial class NhanVien : Form
    {
        SqlConnection cnn;
        string flag;
        int index;
        public NhanVien()
        {
            InitializeComponent();
        }
        public void khoacontrol()
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            //btntimkiem.Enabled = true;
            btnthoat.Enabled = true;
            btnluu.Enabled = true;

            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            txtluong.ReadOnly = true;
            txtdienthoai.ReadOnly = true;
            txtdiachi.ReadOnly = true;

            btnthem.Focus();

        }
        public void unlockcontrol()
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            //btntimkiem.Enabled = false;
            btnluu.Enabled = true;
            btnthoat.Enabled = true;

            txtmanv.ReadOnly = false;
            txttennv.ReadOnly = false;
            txtluong.ReadOnly = false;
            txtdienthoai.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtchungmt.ReadOnly = false;

            txtmanv.Focus();
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
        //loát dữ liệu lên datagridview
        private void NhanVien_Load(object sender, EventArgs e)
        {
           
            khoacontrol();
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select [MaNV],[TenNV],(2018-year([NgaySinh])) as'NgaySinh',[GioiTinh],[DiaChi], [DienThoai],[NgayVaoLam],[Luong],[CMT] from NHANVIEN", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgnhanvien.DataSource = tb;
                    }
                }
            }
            loaddl();

        }
        //hiện dữ liệu lên combox
        private void laydsnv()
        {
            
        }
   
        //kiểm tra mã
        private bool kiemtrama()
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "kientra_ma";
            cmd.Parameters.AddWithValue("@ma", txtmanv.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = dt.Rows.Count;
            return i > 0;
        }


        private bool kiemtraCMT()
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KT_CMT";
            cmd.Parameters.AddWithValue("@cmt", txtchungmt.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = dt.Rows.Count;
            return i > 0;
        }
        //loát dữ liệu lên các ô
        private void loaddl()
        {
            index = dtgnhanvien.CurrentRow.Index;
            txtmanv.Text = dtgnhanvien.Rows[index].Cells[0].Value.ToString();
            txttennv.Text = dtgnhanvien.Rows[index].Cells[1].Value.ToString();
            txtTuoi.Text = dtgnhanvien.Rows[index].Cells[2].Value.ToString();
            if (dtgnhanvien.Rows[index].Cells[3].Value.ToString().Trim().Equals("Nam"))
            {
                rbtnam.Checked = true;
            }
            else
            {
                rbtnu.Checked = true;
            }
            txtdiachi.Text = dtgnhanvien.Rows[index].Cells[4].Value.ToString();
            txtdienthoai.Text = dtgnhanvien.Rows[index].Cells[5].Value.ToString();
            dtpngayvaolam.Text = dtgnhanvien.Rows[index].Cells[6].Value.ToString();
            txtluong.Text = dtgnhanvien.Rows[index].Cells[7].Value.ToString();
            txtchungmt.Text = dtgnhanvien.Rows[index].Cells[8].Value.ToString();
        }
        //loát dl lên khi kích vào
        private void dtgnhanvien_Click(object sender, EventArgs e)
        {
            loaddl();
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        //thêm thữ liệu
        private void btnthem_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            flag = "add";
            txtmanv.Text = " ";
            txttennv.Text = " ";
            txtluong.Text = " ";
            txtdienthoai.Text = " ";
            txtdiachi.Text = " ";
            txtchungmt.Text = "";
            rbtnam.Checked = true;
        }
        //sửa dữ liệu
        private void btnsua_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            txtmanv.Focus();
            flag = "edit";  
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                connect();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "delete_NV";
                cmd.Parameters.AddWithValue("@manv", txtmanv.Text);
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa thông tin này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanVien_Load(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Nhân viên đã tồn tại ở bẳng khác !!! Không thể xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
                
        }

        // lưu dữ liệu
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                //if (checkdata())
                {
                    connect();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "them_NV";
                    cmd.Parameters.AddWithValue("@MaNV", txtmanv.Text);
                    cmd.Parameters.AddWithValue("@TenNV", txttennv.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", txtTuoi.Text);
                    if (rbtnam.Checked)
                        cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                    else
                        cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");
                    cmd.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@DienThoai", txtdienthoai.Text);
                    cmd.Parameters.AddWithValue("@NgayVaoLam", Convert.ToDateTime(dtpngayvaolam.Value.ToString()));
                    cmd.Parameters.AddWithValue("@Luong", txtluong.Text);
                    cmd.Parameters.AddWithValue("@cmt", txtchungmt.Text);
                    
                    //cmd.Parameters.AddWithValue("@mapb", comboxmapb.SelectedValue);
                    if (kiemtrama())
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmanv.Focus();
                    }
                    
                    cmd.Parameters.AddWithValue("@cmt", txtchungmt.Text);
                    if (kiemtraCMT())
                    {
                        MessageBox.Show("Chứng minh thư của nhân viên đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtchungmt.Focus();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NhanVien_Load(sender, e);
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
                    cmd.CommandText = "update_NV";
                    cmd.Parameters.AddWithValue("@manv", txtmanv.Text);
                    cmd.Parameters.AddWithValue("@ten", txttennv.Text);
                    cmd.Parameters.AddWithValue("@ns", txtTuoi.Text);
                    if (rbtnam.Checked)
                        cmd.Parameters.AddWithValue("@gt", "Nam");
                    else
                        cmd.Parameters.AddWithValue("@gt", "Nữ");
                    cmd.Parameters.AddWithValue("@dc", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@dt", txtdienthoai.Text);
                    cmd.Parameters.AddWithValue("@nvl", Convert.ToDateTime(dtpngayvaolam.Value.ToString()));
                    cmd.Parameters.AddWithValue("@luong", Convert.ToDouble(txtluong.Text));

                    cmd.ExecuteNonQuery();
                    NhanVien_Load(sender, e);
                    MessageBox.Show("Sửa thành công");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Sửa không thành công"+ex);
                }
            
           }
        }
        //public bool checkdata()
        //{
        //    if(string.IsNullOrWhiteSpace(txtmanv.Text))
        //    {
        //        MessageBox.Show("bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtmanv.Focus();
        //        return false;
        //    }
        //    if(string.IsNullOrWhiteSpace(txttennv.Text))
        //    {
        //        MessageBox.Show("bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txttennv.Focus();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtdiachi.Text))
        //    {
        //        MessageBox.Show("bạn chưa nhập địa chỉ của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtdiachi.Focus();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtdienthoai.Text))
        //    {
        //        MessageBox.Show("bạn chưa nhập điện thoại của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtdienthoai.Focus();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtluong.Text))
        //    {
        //        MessageBox.Show("bạn chưa nhập lương của nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtluong.Focus();
        //        return false;
        //    }
        //    return true;
        //}



        


            //tìm kiếm
        private DataTable Laydanhsach(string sFilter)
        {
            string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sqlSelect = "select * from NHANVIEN where" + sFilter;
                using (SqlCommand cmd = new SqlCommand(sqlSelect, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable t = new DataTable("NHANVIEN");
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
            if (!string.IsNullOrEmpty(txtmanv.Text.Trim()))
            {
                sFilter += string.Format("and MaNV like N'%{0}%'", txtmanv.Text.Trim().ToString());
                dtgnhanvien.DataSource = Laydanhsach(sFilter);

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

        private void btnhuy_Click(object sender, EventArgs e)
        {
            unlockcontrol();
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            flag = "add";
            txtmanv.Text = " ";
            txttennv.Text = " ";
            txtluong.Text = " ";
            txtdienthoai.Text = " ";
            txtdiachi.Text = " ";
            rbtnam.Checked = true;
        }

        //chỉ cho nhập số
        private void txtdienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string st = "0123456789" + (char)8;
            //if (st.IndexOf(e.KeyChar) == -1)
            //{
            //    MessageBox.Show("Bạn phải nhập số");
            //    e.Handled = true;
            //}
        }

        //chỉ cho nhập chữ
        private void txttennv_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar)) //&& !Char.IsControl(e.KeyChar))
            //{

            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }
    }
}
