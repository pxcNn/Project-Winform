namespace QLNS_SS4U
{
    partial class FrmPhucLoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhucLoi));
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.ckbTinhTrang = new System.Windows.Forms.CheckBox();
            this.dateTimePickerNgaySua = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayTao = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMucThuong = new System.Windows.Forms.TextBox();
            this.txtTenMucThuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvKhenThuong = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDau = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnKe = new System.Windows.Forms.Button();
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.txtMauHienHanh = new System.Windows.Forms.TextBox();
            this.txtTongMau = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
            this.btnThem.Image = global::QLNS_SS4U.Properties.Resources.icons8_add_52;
            this.btnThem.Location = new System.Drawing.Point(875, 18);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 86);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSua.BackgroundImage")));
            this.btnSua.Image = global::QLNS_SS4U.Properties.Resources.icons8_fix_52;
            this.btnSua.Location = new System.Drawing.Point(1000, 17);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 86);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
            this.btnXoa.Image = global::QLNS_SS4U.Properties.Resources.icons8_delete_52;
            this.btnXoa.Location = new System.Drawing.Point(1125, 13);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 86);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.BackgroundImage")));
            this.btnLuu.Image = global::QLNS_SS4U.Properties.Resources.icons8_save_52;
            this.btnLuu.Location = new System.Drawing.Point(875, 124);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 86);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIn.BackgroundImage")));
            this.btnIn.Image = global::QLNS_SS4U.Properties.Resources.icons8_print_52;
            this.btnIn.Location = new System.Drawing.Point(1000, 124);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 86);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "In";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDong.BackgroundImage")));
            this.btnDong.Image = global::QLNS_SS4U.Properties.Resources.icons8_exit_52ư;
            this.btnDong.Location = new System.Drawing.Point(1125, 126);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 86);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // ckbTinhTrang
            // 
            this.ckbTinhTrang.AutoSize = true;
            this.ckbTinhTrang.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTinhTrang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckbTinhTrang.Location = new System.Drawing.Point(543, 130);
            this.ckbTinhTrang.Name = "ckbTinhTrang";
            this.ckbTinhTrang.Size = new System.Drawing.Size(136, 25);
            this.ckbTinhTrang.TabIndex = 8;
            this.ckbTinhTrang.Text = "Có hiệu lực";
            this.ckbTinhTrang.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNgaySua
            // 
            this.dateTimePickerNgaySua.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgaySua.Location = new System.Drawing.Point(581, 78);
            this.dateTimePickerNgaySua.Name = "dateTimePickerNgaySua";
            this.dateTimePickerNgaySua.Size = new System.Drawing.Size(243, 26);
            this.dateTimePickerNgaySua.TabIndex = 7;
            // 
            // dateTimePickerNgayTao
            // 
            this.dateTimePickerNgayTao.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgayTao.Location = new System.Drawing.Point(581, 23);
            this.dateTimePickerNgayTao.Name = "dateTimePickerNgayTao";
            this.dateTimePickerNgayTao.Size = new System.Drawing.Size(243, 26);
            this.dateTimePickerNgayTao.TabIndex = 6;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(181, 20);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(226, 26);
            this.txtID.TabIndex = 2;
            // 
            // txtMucThuong
            // 
            this.txtMucThuong.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMucThuong.Location = new System.Drawing.Point(181, 139);
            this.txtMucThuong.Name = "txtMucThuong";
            this.txtMucThuong.Size = new System.Drawing.Size(226, 26);
            this.txtMucThuong.TabIndex = 1;
            // 
            // txtTenMucThuong
            // 
            this.txtTenMucThuong.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMucThuong.Location = new System.Drawing.Point(181, 78);
            this.txtTenMucThuong.Name = "txtTenMucThuong";
            this.txtTenMucThuong.Size = new System.Drawing.Size(226, 26);
            this.txtTenMucThuong.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(18, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mức Thưởng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(470, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày sửa";
            this.label5.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(470, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày tạo";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(18, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên mức thưởng";
            // 
            // lvKhenThuong
            // 
            this.lvKhenThuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.lvKhenThuong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvKhenThuong.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvKhenThuong.FullRowSelect = true;
            this.lvKhenThuong.GridLines = true;
            this.lvKhenThuong.HideSelection = false;
            this.lvKhenThuong.Location = new System.Drawing.Point(22, 349);
            this.lvKhenThuong.Name = "lvKhenThuong";
            this.lvKhenThuong.Size = new System.Drawing.Size(1178, 231);
            this.lvKhenThuong.TabIndex = 0;
            this.lvKhenThuong.UseCompatibleStateImageBehavior = false;
            this.lvKhenThuong.View = System.Windows.Forms.View.Details;
            this.lvKhenThuong.SelectedIndexChanged += new System.EventHandler(this.lvKhenThuong_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên mức thưởng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 367;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mức thưởng";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 178;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày Tạo";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày sửa";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 134;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Hiệu lực";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 122;
            // 
            // btnDau
            // 
            this.btnDau.Image = global::QLNS_SS4U.Properties.Resources.icons8_previous_501;
            this.btnDau.Location = new System.Drawing.Point(357, 294);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(50, 39);
            this.btnDau.TabIndex = 2;
            this.btnDau.UseVisualStyleBackColor = true;
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.Image = global::QLNS_SS4U.Properties.Resources.icons8_previous_50;
            this.btnTruoc.Location = new System.Drawing.Point(445, 294);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(50, 39);
            this.btnTruoc.TabIndex = 3;
            this.btnTruoc.UseVisualStyleBackColor = true;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // btnKe
            // 
            this.btnKe.Image = global::QLNS_SS4U.Properties.Resources.icons8_next_50;
            this.btnKe.Location = new System.Drawing.Point(536, 294);
            this.btnKe.Name = "btnKe";
            this.btnKe.Size = new System.Drawing.Size(50, 39);
            this.btnKe.TabIndex = 4;
            this.btnKe.UseVisualStyleBackColor = true;
            this.btnKe.Click += new System.EventHandler(this.btnKe_Click);
            // 
            // btnCuoi
            // 
            this.btnCuoi.Image = global::QLNS_SS4U.Properties.Resources.icons8_last_50;
            this.btnCuoi.Location = new System.Drawing.Point(629, 294);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(50, 39);
            this.btnCuoi.TabIndex = 5;
            this.btnCuoi.UseVisualStyleBackColor = true;
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTim.BackgroundImage")));
            this.btnTim.Image = global::QLNS_SS4U.Properties.Resources.icons8_search_52;
            this.btnTim.Location = new System.Drawing.Point(1125, 237);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 86);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(975, 267);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(100, 26);
            this.txtTimKiem.TabIndex = 7;
            // 
            // txtMauHienHanh
            // 
            this.txtMauHienHanh.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMauHienHanh.Location = new System.Drawing.Point(296, 226);
            this.txtMauHienHanh.Name = "txtMauHienHanh";
            this.txtMauHienHanh.Size = new System.Drawing.Size(100, 26);
            this.txtMauHienHanh.TabIndex = 8;
            // 
            // txtTongMau
            // 
            this.txtTongMau.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongMau.Location = new System.Drawing.Point(633, 226);
            this.txtTongMau.Name = "txtTongMau";
            this.txtTongMau.Size = new System.Drawing.Size(100, 26);
            this.txtTongMau.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(489, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 47;
            this.label6.Text = "Tổng mẫu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(99, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "Mẫu tin hiện hành";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(872, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 21);
            this.label8.TabIndex = 48;
            this.label8.Text = "Nhập ID";
            // 
            // FrmPhucLoi
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::QLNS_SS4U.Properties.Resources.download1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1212, 593);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvKhenThuong);
            this.Controls.Add(this.ckbTinhTrang);
            this.Controls.Add(this.txtTongMau);
            this.Controls.Add(this.dateTimePickerNgaySua);
            this.Controls.Add(this.dateTimePickerNgayTao);
            this.Controls.Add(this.txtMauHienHanh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMucThuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtTenMucThuong);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnCuoi);
            this.Controls.Add(this.btnKe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTruoc);
            this.Controls.Add(this.btnDau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPhucLoi";
            this.Text = "Phúc Lợi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtMucThuong;
        private System.Windows.Forms.TextBox txtTenMucThuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvKhenThuong;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnDau;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnKe;
        private System.Windows.Forms.Button btnCuoi;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TextBox txtMauHienHanh;
        private System.Windows.Forms.TextBox txtTongMau;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaySua;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayTao;
        private System.Windows.Forms.CheckBox ckbTinhTrang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

