using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Boolean kiemtraHienMotform(string sFormname)
        {

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name.Equals(sFormname))
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  if (kiemtraHienMotform("NhanVien")) return;
           // else
            {
                NhanVien f1 = new NhanVien();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sach f2 = new Sach();
            f2.MdiParent = this;
            f2.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            docgia f3 = new docgia();
            f3.MdiParent = this;
            f3.Show();
        }

        private void độcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phieumuon f4 = new Phieumuon();
            f4.MdiParent = this;
            f4.Show();
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phieutra f5 = new Phieutra();
            f5.MdiParent = this;
            f5.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nhânViênCóLươngTrên5TriệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmluongnhanvien f6 = new frmluongnhanvien();
            f6.MdiParent = this;
            f6.Show();
        }

        private void nhânViênCóNămSinh1990ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmnhanvien1990 f7 = new frmnhanvien1990();
            f7.MdiParent = this;
            f7.Show();
        }
    }
}
