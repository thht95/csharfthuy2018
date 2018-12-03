using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace quanlythuvien
{
    class conect
    {

        //public SqlConnection cnn;
        //public void connect()
        //{
        //    try
        //    {
        //        string constr = ConfigurationManager.ConnectionStrings["quanlythuvien"].ConnectionString;
        //        cnn = new SqlConnection(constr);
        //        cnn.Open();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Kết nối không thành công", "THÔNG BÁO", MessageBoxButtons.OK);
        //    }

        //}

        //public void data(string lenh, DataGridView dtg)
        //{
        //    try
        //    {
        //        connect();
        //        SqlCommand cmd = cnn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = lenh;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        dtg.DataSource = dt;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Không thể kết nối tới cơ sở dữ liệu!" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        //public void data1(string lenh, DataGridView dtg, string an)
        //{
        //    try
        //    {
        //        connect();
        //        SqlCommand cmd = cnn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = lenh;
        //        cmd.Parameters.AddWithValue("@ma", an);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        dtg.DataSource = dt;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Không thể kết nối tới cơ sở dữ liệu!" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        //public void Load_cbo(string lenh, ComboBox cbo)
        //{
        //    connect();
        //    SqlCommand cmd = cnn.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = lenh;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    cbo.DataSource = dt;
        //    cbo.DisplayMember = dt.Columns[1].ToString();
        //    cbo.ValueMember = dt.Columns[0].ToString();
        //}


        //public bool kiemtra(string lenh, string text)
        //{

        //    SqlCommand cmd = cnn.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = lenh;
        //    cmd.Parameters.AddWithValue("@ma", text);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    int i = dt.Rows.Count;
        //    return i > 0;
        //}
        //    //public bool kiemtra2(string lenh, string text1, string text2)
        //    //{

        //    //    SqlCommand cmd = cnn.CreateCommand();
        //    //    cmd.CommandType = CommandType.StoredProcedure;
        //    //    cmd.CommandText = lenh;
        //    //    cmd.Parameters.AddWithValue("@ma1", text1);
        //    //    cmd.Parameters.AddWithValue("@ma2", text2);
        //    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    //    DataTable dt = new DataTable();
        //    //    da.Fill(dt);
        //    //    int i = dt.Rows.Count;
        //    //    return i > 0;
        //    //}


        //    //public string Parametr(string lenh, string text, string t)
        //    //{
        //    //    SqlCommand cmd = cnn.CreateCommand();
        //    //    cmd.CommandType = CommandType.StoredProcedure;
        //    //    cmd.CommandText = lenh;
        //    //    cmd.Parameters.AddWithValue("@ma", text);
        //    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    //    DataTable dt = new DataTable();
        //    //    da.Fill(dt);
        //    //    t = cmd.ExecuteScalar().ToString();
        //    //    return t;

        //    //}

        }
}