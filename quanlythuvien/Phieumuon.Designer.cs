namespace quanlythuvien
{
    partial class Phieumuon
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.txtmapm = new System.Windows.Forms.TextBox();
            this.dtpngaymuon = new System.Windows.Forms.DateTimePicker();
            this.dtgphieumuon = new System.Windows.Forms.DataGridView();
            this.dtpngayhentra = new System.Windows.Forms.DateTimePicker();
            this.btnctpmuon = new System.Windows.Forms.Button();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.cboDG = new System.Windows.Forms.ComboBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgphieumuon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiếu Mượn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên độc giả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày Mượn Sách:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày Hẹn Trả Sách:";
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(69, 306);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(75, 23);
            this.btnthem.TabIndex = 5;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(200, 306);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 23);
            this.btnsua.TabIndex = 6;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(333, 306);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 23);
            this.btnxoa.TabIndex = 7;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(462, 306);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 23);
            this.btnluu.TabIndex = 8;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(591, 306);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 23);
            this.btnthoat.TabIndex = 9;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // txtmapm
            // 
            this.txtmapm.Location = new System.Drawing.Point(179, 35);
            this.txtmapm.Name = "txtmapm";
            this.txtmapm.Size = new System.Drawing.Size(127, 20);
            this.txtmapm.TabIndex = 10;
            // 
            // dtpngaymuon
            // 
            this.dtpngaymuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaymuon.Location = new System.Drawing.Point(179, 164);
            this.dtpngaymuon.Name = "dtpngaymuon";
            this.dtpngaymuon.Size = new System.Drawing.Size(127, 20);
            this.dtpngaymuon.TabIndex = 13;
            // 
            // dtgphieumuon
            // 
            this.dtgphieumuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgphieumuon.Location = new System.Drawing.Point(379, 35);
            this.dtgphieumuon.Name = "dtgphieumuon";
            this.dtgphieumuon.Size = new System.Drawing.Size(496, 197);
            this.dtgphieumuon.TabIndex = 14;
            this.dtgphieumuon.Click += new System.EventHandler(this.dtgphieumuon_Click);
            // 
            // dtpngayhentra
            // 
            this.dtpngayhentra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayhentra.Location = new System.Drawing.Point(179, 211);
            this.dtpngayhentra.Name = "dtpngayhentra";
            this.dtpngayhentra.Size = new System.Drawing.Size(127, 20);
            this.dtpngayhentra.TabIndex = 15;
            // 
            // btnctpmuon
            // 
            this.btnctpmuon.Location = new System.Drawing.Point(743, 268);
            this.btnctpmuon.Name = "btnctpmuon";
            this.btnctpmuon.Size = new System.Drawing.Size(98, 98);
            this.btnctpmuon.TabIndex = 16;
            this.btnctpmuon.Text = "Chi Tiết Phiếu Mượn";
            this.btnctpmuon.UseVisualStyleBackColor = true;
            this.btnctpmuon.Click += new System.EventHandler(this.btnctpmuon_Click);
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(179, 80);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(127, 21);
            this.cboNV.TabIndex = 17;
            // 
            // cboDG
            // 
            this.cboDG.FormattingEnabled = true;
            this.cboDG.Location = new System.Drawing.Point(179, 121);
            this.cboDG.Name = "cboDG";
            this.cboDG.Size = new System.Drawing.Size(127, 21);
            this.cboDG.TabIndex = 18;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(591, 362);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 23);
            this.btntimkiem.TabIndex = 19;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // Phieumuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 412);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.cboDG);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.btnctpmuon);
            this.Controls.Add(this.dtpngayhentra);
            this.Controls.Add(this.dtgphieumuon);
            this.Controls.Add(this.dtpngaymuon);
            this.Controls.Add(this.txtmapm);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Phieumuon";
            this.Text = "Phieumuon";
            this.Load += new System.EventHandler(this.Phieumuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgphieumuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.TextBox txtmapm;
        private System.Windows.Forms.DateTimePicker dtpngaymuon;
        private System.Windows.Forms.DataGridView dtgphieumuon;
        private System.Windows.Forms.DateTimePicker dtpngayhentra;
        private System.Windows.Forms.Button btnctpmuon;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.ComboBox cboDG;
        private System.Windows.Forms.Button btntimkiem;
    }
}