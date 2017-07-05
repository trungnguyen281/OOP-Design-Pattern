namespace DemoSCO
{
    partial class DemoSCO
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQLHS = new System.Windows.Forms.TabPage();
            this.cbGVCN = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMSHS = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridHocSinh = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabQLGV = new System.Windows.Forms.TabPage();
            this.gridGiaoVien = new System.Windows.Forms.DataGridView();
            this.MSGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.MSHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabQLHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHocSinh)).BeginInit();
            this.tabQLGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGiaoVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabQLHS);
            this.tabControl1.Controls.Add(this.tabQLGV);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 332);
            this.tabControl1.TabIndex = 0;
            // 
            // tabQLHS
            // 
            this.tabQLHS.Controls.Add(this.btnClear);
            this.tabQLHS.Controls.Add(this.cbGVCN);
            this.tabQLHS.Controls.Add(this.btnThem);
            this.tabQLHS.Controls.Add(this.btnXoa);
            this.tabQLHS.Controls.Add(this.btnSua);
            this.tabQLHS.Controls.Add(this.btnTimKiem);
            this.tabQLHS.Controls.Add(this.label4);
            this.tabQLHS.Controls.Add(this.txtHoten);
            this.tabQLHS.Controls.Add(this.label3);
            this.tabQLHS.Controls.Add(this.txtMSHS);
            this.tabQLHS.Controls.Add(this.txtTimKiem);
            this.tabQLHS.Controls.Add(this.label2);
            this.tabQLHS.Controls.Add(this.gridHocSinh);
            this.tabQLHS.Controls.Add(this.label1);
            this.tabQLHS.Location = new System.Drawing.Point(4, 22);
            this.tabQLHS.Name = "tabQLHS";
            this.tabQLHS.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLHS.Size = new System.Drawing.Size(646, 306);
            this.tabQLHS.TabIndex = 0;
            this.tabQLHS.Text = "QLHS";
            this.tabQLHS.UseVisualStyleBackColor = true;
            // 
            // cbGVCN
            // 
            this.cbGVCN.FormattingEnabled = true;
            this.cbGVCN.Location = new System.Drawing.Point(413, 68);
            this.cbGVCN.Name = "cbGVCN";
            this.cbGVCN.Size = new System.Drawing.Size(146, 21);
            this.cbGVCN.TabIndex = 13;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(565, 104);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(565, 178);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(565, 141);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(565, 30);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "GVCN:";
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(232, 68);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(124, 20);
            this.txtHoten.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Họ tên:";
            // 
            // txtMSHS
            // 
            this.txtMSHS.Location = new System.Drawing.Point(47, 68);
            this.txtMSHS.Name = "txtMSHS";
            this.txtMSHS.Size = new System.Drawing.Size(124, 20);
            this.txtMSHS.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(413, 32);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(146, 20);
            this.txtTimKiem.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MSHS:";
            // 
            // gridHocSinh
            // 
            this.gridHocSinh.AllowUserToAddRows = false;
            this.gridHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHocSinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSHS,
            this.HoTen,
            this.SoLuongMonHoc,
            this.DTB,
            this.GVCN});
            this.gridHocSinh.Location = new System.Drawing.Point(7, 104);
            this.gridHocSinh.Name = "gridHocSinh";
            this.gridHocSinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHocSinh.Size = new System.Drawing.Size(552, 196);
            this.gridHocSinh.TabIndex = 1;
            this.gridHocSinh.SelectionChanged += new System.EventHandler(this.gridHocSinh_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ HỌC SINH";
            // 
            // tabQLGV
            // 
            this.tabQLGV.Controls.Add(this.gridGiaoVien);
            this.tabQLGV.Controls.Add(this.label5);
            this.tabQLGV.Location = new System.Drawing.Point(4, 22);
            this.tabQLGV.Name = "tabQLGV";
            this.tabQLGV.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLGV.Size = new System.Drawing.Size(646, 306);
            this.tabQLGV.TabIndex = 1;
            this.tabQLGV.Text = "QLGV";
            this.tabQLGV.UseVisualStyleBackColor = true;
            // 
            // gridGiaoVien
            // 
            this.gridGiaoVien.AllowUserToAddRows = false;
            this.gridGiaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGiaoVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSGV,
            this.HoTenGV,
            this.SoLuongHS});
            this.gridGiaoVien.Location = new System.Drawing.Point(6, 48);
            this.gridGiaoVien.Name = "gridGiaoVien";
            this.gridGiaoVien.Size = new System.Drawing.Size(634, 252);
            this.gridGiaoVien.TabIndex = 2;
            // 
            // MSGV
            // 
            this.MSGV.HeaderText = "MSGV";
            this.MSGV.Name = "MSGV";
            this.MSGV.Width = 150;
            // 
            // HoTenGV
            // 
            this.HoTenGV.FillWeight = 200F;
            this.HoTenGV.HeaderText = "Họ tên";
            this.HoTenGV.Name = "HoTenGV";
            this.HoTenGV.Width = 300;
            // 
            // SoLuongHS
            // 
            this.SoLuongHS.HeaderText = "Số học sinh quản lý";
            this.SoLuongHS.Name = "SoLuongHS";
            this.SoLuongHS.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(240, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "QUẢN LÝ GIÁO VIÊN";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(565, 67);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "<--";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // MSHS
            // 
            this.MSHS.HeaderText = "MSHS";
            this.MSHS.Name = "MSHS";
            this.MSHS.Width = 50;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 170;
            // 
            // SoLuongMonHoc
            // 
            this.SoLuongMonHoc.HeaderText = "Số môn học";
            this.SoLuongMonHoc.Name = "SoLuongMonHoc";
            // 
            // DTB
            // 
            this.DTB.HeaderText = "ĐTB";
            this.DTB.Name = "DTB";
            this.DTB.Width = 50;
            // 
            // GVCN
            // 
            this.GVCN.HeaderText = "Giáo viên chủ nhiệm";
            this.GVCN.Name = "GVCN";
            this.GVCN.Width = 140;
            // 
            // DemoSCO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 356);
            this.Controls.Add(this.tabControl1);
            this.Name = "DemoSCO";
            this.Text = "DemoSCO";
            this.Load += new System.EventHandler(this.DemoSCO_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabQLHS.ResumeLayout(false);
            this.tabQLHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHocSinh)).EndInit();
            this.tabQLGV.ResumeLayout(false);
            this.tabQLGV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGiaoVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQLHS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMSHS;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridHocSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabQLGV;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView gridGiaoVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGVCN;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongHS;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVCN;
    }
}

