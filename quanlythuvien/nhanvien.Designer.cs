namespace quanlythuvien
{
    partial class NhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtmanv = new System.Windows.Forms.TextBox();
			this.txttennv = new System.Windows.Forms.TextBox();
			this.rbtnam = new System.Windows.Forms.RadioButton();
			this.rbtnu = new System.Windows.Forms.RadioButton();
			this.txtdienthoai = new System.Windows.Forms.TextBox();
			this.txtluong = new System.Windows.Forms.TextBox();
			this.dtpngayvaolam = new System.Windows.Forms.DateTimePicker();
			this.btnthem = new System.Windows.Forms.Button();
			this.btnsua = new System.Windows.Forms.Button();
			this.btnxoa = new System.Windows.Forms.Button();
			this.btnthoat = new System.Windows.Forms.Button();
			this.dtgnhanvien = new System.Windows.Forms.DataGridView();
			this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tennv = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ngayvaolam = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnluu = new System.Windows.Forms.Button();
			this.txtdiachi = new System.Windows.Forms.TextBox();
			this.btnhuy = new System.Windows.Forms.Button();
			this.txtchungmt = new System.Windows.Forms.TextBox();
			this.lab = new System.Windows.Forms.Label();
			this.txtTuoi = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dtgnhanvien)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã Nhân viên:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tên Nhân Viên:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tuổi:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 127);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Giới Tính:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(328, 27);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Địa Chỉ:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(328, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Điện Thoại:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(328, 94);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Ngày Vào Làm:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(328, 127);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Lương:";
			// 
			// txtmanv
			// 
			this.txtmanv.Location = new System.Drawing.Point(117, 27);
			this.txtmanv.Name = "txtmanv";
			this.txtmanv.Size = new System.Drawing.Size(128, 20);
			this.txtmanv.TabIndex = 8;
			// 
			// txttennv
			// 
			this.txttennv.Location = new System.Drawing.Point(117, 57);
			this.txttennv.Name = "txttennv";
			this.txttennv.Size = new System.Drawing.Size(128, 20);
			this.txttennv.TabIndex = 9;
			this.txttennv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttennv_KeyPress);
			// 
			// rbtnam
			// 
			this.rbtnam.AutoSize = true;
			this.rbtnam.Location = new System.Drawing.Point(117, 122);
			this.rbtnam.Name = "rbtnam";
			this.rbtnam.Size = new System.Drawing.Size(47, 17);
			this.rbtnam.TabIndex = 11;
			this.rbtnam.TabStop = true;
			this.rbtnam.Text = "Nam";
			this.rbtnam.UseVisualStyleBackColor = true;
			// 
			// rbtnu
			// 
			this.rbtnu.AutoSize = true;
			this.rbtnu.Location = new System.Drawing.Point(184, 122);
			this.rbtnu.Name = "rbtnu";
			this.rbtnu.Size = new System.Drawing.Size(39, 17);
			this.rbtnu.TabIndex = 12;
			this.rbtnu.TabStop = true;
			this.rbtnu.Text = "Nữ";
			this.rbtnu.UseVisualStyleBackColor = true;
			// 
			// txtdienthoai
			// 
			this.txtdienthoai.Location = new System.Drawing.Point(464, 53);
			this.txtdienthoai.Name = "txtdienthoai";
			this.txtdienthoai.Size = new System.Drawing.Size(121, 20);
			this.txtdienthoai.TabIndex = 14;
			this.txtdienthoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdienthoai_KeyPress);
			// 
			// txtluong
			// 
			this.txtluong.Location = new System.Drawing.Point(464, 127);
			this.txtluong.Name = "txtluong";
			this.txtluong.Size = new System.Drawing.Size(121, 20);
			this.txtluong.TabIndex = 15;
			// 
			// dtpngayvaolam
			// 
			this.dtpngayvaolam.CustomFormat = "dd/MM/yyyy";
			this.dtpngayvaolam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpngayvaolam.Location = new System.Drawing.Point(464, 94);
			this.dtpngayvaolam.Name = "dtpngayvaolam";
			this.dtpngayvaolam.Size = new System.Drawing.Size(121, 20);
			this.dtpngayvaolam.TabIndex = 16;
			// 
			// btnthem
			// 
			this.btnthem.Location = new System.Drawing.Point(45, 202);
			this.btnthem.Name = "btnthem";
			this.btnthem.Size = new System.Drawing.Size(75, 23);
			this.btnthem.TabIndex = 17;
			this.btnthem.Text = "Thêm";
			this.btnthem.UseVisualStyleBackColor = true;
			this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
			// 
			// btnsua
			// 
			this.btnsua.Location = new System.Drawing.Point(148, 202);
			this.btnsua.Name = "btnsua";
			this.btnsua.Size = new System.Drawing.Size(75, 23);
			this.btnsua.TabIndex = 18;
			this.btnsua.Text = "Sửa";
			this.btnsua.UseVisualStyleBackColor = true;
			this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
			// 
			// btnxoa
			// 
			this.btnxoa.Location = new System.Drawing.Point(253, 202);
			this.btnxoa.Name = "btnxoa";
			this.btnxoa.Size = new System.Drawing.Size(75, 23);
			this.btnxoa.TabIndex = 19;
			this.btnxoa.Text = "Xóa";
			this.btnxoa.UseVisualStyleBackColor = true;
			this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
			// 
			// btnthoat
			// 
			this.btnthoat.Location = new System.Drawing.Point(475, 202);
			this.btnthoat.Name = "btnthoat";
			this.btnthoat.Size = new System.Drawing.Size(75, 23);
			this.btnthoat.TabIndex = 21;
			this.btnthoat.Text = "Thoát";
			this.btnthoat.UseVisualStyleBackColor = true;
			this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
			// 
			// dtgnhanvien
			// 
			this.dtgnhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgnhanvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.manv,
            this.tennv,
            this.ngaysinh,
            this.gioitinh,
            this.diachi,
            this.dienthoai,
            this.ngayvaolam,
            this.luong});
			this.dtgnhanvien.Location = new System.Drawing.Point(21, 241);
			this.dtgnhanvien.Name = "dtgnhanvien";
			this.dtgnhanvien.Size = new System.Drawing.Size(651, 150);
			this.dtgnhanvien.TabIndex = 22;
			this.dtgnhanvien.Click += new System.EventHandler(this.dtgnhanvien_Click);
			// 
			// manv
			// 
			this.manv.DataPropertyName = "manv";
			this.manv.HeaderText = "Mã nhân viên";
			this.manv.Name = "manv";
			// 
			// tennv
			// 
			this.tennv.DataPropertyName = "tennv";
			this.tennv.HeaderText = "Tên nhân viên";
			this.tennv.Name = "tennv";
			// 
			// ngaysinh
			// 
			this.ngaysinh.DataPropertyName = "ngaysinh";
			this.ngaysinh.HeaderText = "Ngày sinh";
			this.ngaysinh.Name = "ngaysinh";
			// 
			// gioitinh
			// 
			this.gioitinh.DataPropertyName = "gioitinh";
			this.gioitinh.HeaderText = "Giới tính";
			this.gioitinh.Name = "gioitinh";
			// 
			// diachi
			// 
			this.diachi.DataPropertyName = "diachi";
			this.diachi.HeaderText = "Địa chỉ";
			this.diachi.Name = "diachi";
			// 
			// dienthoai
			// 
			this.dienthoai.DataPropertyName = "dienthoai";
			this.dienthoai.HeaderText = "Điện thoại";
			this.dienthoai.Name = "dienthoai";
			// 
			// ngayvaolam
			// 
			this.ngayvaolam.DataPropertyName = "ngayvaolam";
			this.ngayvaolam.HeaderText = "Ngày vào làm";
			this.ngayvaolam.Name = "ngayvaolam";
			// 
			// luong
			// 
			this.luong.DataPropertyName = "luong";
			this.luong.HeaderText = "Lương";
			this.luong.Name = "luong";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnluu
			// 
			this.btnluu.Location = new System.Drawing.Point(364, 202);
			this.btnluu.Name = "btnluu";
			this.btnluu.Size = new System.Drawing.Size(75, 23);
			this.btnluu.TabIndex = 23;
			this.btnluu.Text = "Lưu";
			this.btnluu.UseVisualStyleBackColor = true;
			this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
			// 
			// txtdiachi
			// 
			this.txtdiachi.Location = new System.Drawing.Point(464, 24);
			this.txtdiachi.Name = "txtdiachi";
			this.txtdiachi.Size = new System.Drawing.Size(121, 20);
			this.txtdiachi.TabIndex = 24;
			// 
			// btnhuy
			// 
			this.btnhuy.Location = new System.Drawing.Point(577, 202);
			this.btnhuy.Name = "btnhuy";
			this.btnhuy.Size = new System.Drawing.Size(75, 23);
			this.btnhuy.TabIndex = 25;
			this.btnhuy.Text = "Hủy";
			this.btnhuy.UseVisualStyleBackColor = true;
			this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
			// 
			// txtchungmt
			// 
			this.txtchungmt.Location = new System.Drawing.Point(117, 158);
			this.txtchungmt.Name = "txtchungmt";
			this.txtchungmt.Size = new System.Drawing.Size(100, 20);
			this.txtchungmt.TabIndex = 26;
			// 
			// lab
			// 
			this.lab.AutoSize = true;
			this.lab.Location = new System.Drawing.Point(18, 161);
			this.lab.Name = "lab";
			this.lab.Size = new System.Drawing.Size(33, 13);
			this.lab.TabIndex = 27;
			this.lab.Text = "CMT:";
			// 
			// txtTuoi
			// 
			this.txtTuoi.Location = new System.Drawing.Point(117, 86);
			this.txtTuoi.Name = "txtTuoi";
			this.txtTuoi.Size = new System.Drawing.Size(88, 20);
			this.txtTuoi.TabIndex = 28;
			// 
			// NhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(705, 431);
			this.Controls.Add(this.txtTuoi);
			this.Controls.Add(this.lab);
			this.Controls.Add(this.txtchungmt);
			this.Controls.Add(this.btnhuy);
			this.Controls.Add(this.txtdiachi);
			this.Controls.Add(this.btnluu);
			this.Controls.Add(this.dtgnhanvien);
			this.Controls.Add(this.btnthoat);
			this.Controls.Add(this.btnxoa);
			this.Controls.Add(this.btnsua);
			this.Controls.Add(this.btnthem);
			this.Controls.Add(this.dtpngayvaolam);
			this.Controls.Add(this.txtluong);
			this.Controls.Add(this.txtdienthoai);
			this.Controls.Add(this.rbtnu);
			this.Controls.Add(this.rbtnam);
			this.Controls.Add(this.txttennv);
			this.Controls.Add(this.txtmanv);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "NhanVien";
			this.Text = "Thông Tin nhân viên";
			this.Load += new System.EventHandler(this.NhanVien_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgnhanvien)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.RadioButton rbtnam;
        private System.Windows.Forms.RadioButton rbtnu;
        private System.Windows.Forms.TextBox txtdienthoai;
        private System.Windows.Forms.TextBox txtluong;
        private System.Windows.Forms.DateTimePicker dtpngayvaolam;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.DataGridView dtgnhanvien;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn tennv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dienthoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayvaolam;
        private System.Windows.Forms.DataGridViewTextBoxColumn luong;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.TextBox txtchungmt;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.TextBox txtTuoi;
    }
}