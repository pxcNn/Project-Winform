namespace QLNS_SS4U
{
    partial class FrmLoiPhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoiPhat));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnKe = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMucPhat = new System.Windows.Forms.TextBox();
            this.txtTenLoiPhat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongMau = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnDau = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lvLoiPhat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMauHienHanh = new System.Windows.Forms.TextBox();
            this.ckbTinhTrang = new System.Windows.Forms.CheckBox();
            this.dateTimePickerNgaySua = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayTao = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên lỗi phạt";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 365;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày Tạo";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 197;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày sửa";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 175;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số phạt";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 170;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Hiệu lực";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 122;
            // 
            // btnCuoi
            // 
            this.btnCuoi.Image = global::QLNS_SS4U.Properties.Resources.icons8_last_50;
            this.btnCuoi.Location = new System.Drawing.Point(578, 286);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(50, 39);
            this.btnCuoi.TabIndex = 21;
            this.btnCuoi.UseVisualStyleBackColor = true;
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            // 
            // btnKe
            // 
            this.btnKe.Image = global::QLNS_SS4U.Properties.Resources.icons8_next_50;
            this.btnKe.Location = new System.Drawing.Point(508, 286);
            this.btnKe.Name = "btnKe";
            this.btnKe.Size = new System.Drawing.Size(50, 39);
            this.btnKe.TabIndex = 20;
            this.btnKe.UseVisualStyleBackColor = true;
            this.btnKe.Click += new System.EventHandler(this.btnKe_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.Image = global::QLNS_SS4U.Properties.Resources.icons8_previous_50;
            this.btnTruoc.Location = new System.Drawing.Point(426, 286);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(50, 39);
            this.btnTruoc.TabIndex = 19;
            this.btnTruoc.UseVisualStyleBackColor = true;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Window;
            this.txtID.Location = new System.Drawing.Point(148, 19);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(250, 26);
            this.txtID.TabIndex = 2;
            // 
            // txtMucPhat
            // 
            this.txtMucPhat.BackColor = System.Drawing.SystemColors.Window;
            this.txtMucPhat.Location = new System.Drawing.Point(148, 129);
            this.txtMucPhat.Name = "txtMucPhat";
            this.txtMucPhat.Size = new System.Drawing.Size(251, 26);
            this.txtMucPhat.TabIndex = 1;
            // 
            // txtTenLoiPhat
            // 
            this.txtTenLoiPhat.BackColor = System.Drawing.SystemColors.Window;
            this.txtTenLoiPhat.Location = new System.Drawing.Point(148, 73);
            this.txtTenLoiPhat.Name = "txtTenLoiPhat";
            this.txtTenLoiPhat.Size = new System.Drawing.Size(251, 26);
            this.txtTenLoiPhat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mức Phạt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(475, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày sửa";
            // 
            // txtTongMau
            // 
            this.txtTongMau.BackColor = System.Drawing.SystemColors.Window;
            this.txtTongMau.Location = new System.Drawing.Point(647, 219);
            this.txtTongMau.Name = "txtTongMau";
            this.txtTongMau.Size = new System.Drawing.Size(111, 26);
            this.txtTongMau.TabIndex = 25;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimKiem.Location = new System.Drawing.Point(982, 268);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(111, 26);
            this.txtTimKiem.TabIndex = 23;
            // 
            // btnDau
            // 
            this.btnDau.Image = global::QLNS_SS4U.Properties.Resources.icons8_previous_501;
            this.btnDau.Location = new System.Drawing.Point(342, 286);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(50, 39);
            this.btnDau.TabIndex = 18;
            this.btnDau.UseVisualStyleBackColor = true;
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(473, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày tạo";
            // 
            // lvLoiPhat
            // 
            this.lvLoiPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.lvLoiPhat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvLoiPhat.FullRowSelect = true;
            this.lvLoiPhat.GridLines = true;
            this.lvLoiPhat.HideSelection = false;
            this.lvLoiPhat.Location = new System.Drawing.Point(8, 342);
            this.lvLoiPhat.Name = "lvLoiPhat";
            this.lvLoiPhat.Size = new System.Drawing.Size(1205, 215);
            this.lvLoiPhat.TabIndex = 0;
            this.lvLoiPhat.UseCompatibleStateImageBehavior = false;
            this.lvLoiPhat.View = System.Windows.Forms.View.Details;
            this.lvLoiPhat.SelectedIndexChanged += new System.EventHandler(this.lvLoiPhat_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên lỗi phạt";
            // 
            // txtMauHienHanh
            // 
            this.txtMauHienHanh.BackColor = System.Drawing.SystemColors.Window;
            this.txtMauHienHanh.Location = new System.Drawing.Point(356, 219);
            this.txtMauHienHanh.Name = "txtMauHienHanh";
            this.txtMauHienHanh.Size = new System.Drawing.Size(111, 26);
            this.txtMauHienHanh.TabIndex = 24;
            // 
            // ckbTinhTrang
            // 
            this.ckbTinhTrang.AutoSize = true;
            this.ckbTinhTrang.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTinhTrang.Location = new System.Drawing.Point(524, 118);
            this.ckbTinhTrang.Name = "ckbTinhTrang";
            this.ckbTinhTrang.Size = new System.Drawing.Size(136, 25);
            this.ckbTinhTrang.TabIndex = 8;
            this.ckbTinhTrang.Text = "Có hiệu lực";
            this.ckbTinhTrang.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNgaySua
            // 
            this.dateTimePickerNgaySua.Location = new System.Drawing.Point(578, 74);
            this.dateTimePickerNgaySua.Name = "dateTimePickerNgaySua";
            this.dateTimePickerNgaySua.Size = new System.Drawing.Size(257, 26);
            this.dateTimePickerNgaySua.TabIndex = 7;
            // 
            // dateTimePickerNgayTao
            // 
            this.dateTimePickerNgayTao.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dateTimePickerNgayTao.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dateTimePickerNgayTao.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dateTimePickerNgayTao.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dateTimePickerNgayTao.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dateTimePickerNgayTao.Location = new System.Drawing.Point(578, 21);
            this.dateTimePickerNgayTao.Name = "dateTimePickerNgayTao";
            this.dateTimePickerNgayTao.Size = new System.Drawing.Size(257, 26);
            this.dateTimePickerNgayTao.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(532, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 45;
            this.label6.Text = "Tổng mẫu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(142, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Mẫu tin hiện hành";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(887, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 21);
            this.label8.TabIndex = 45;
            this.label8.Text = "Nhập ID";
            // 
            // btnTim
            // 
            this.btnTim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTim.BackgroundImage")));
            this.btnTim.Image = global::QLNS_SS4U.Properties.Resources.icons8_search_52;
            this.btnTim.Location = new System.Drawing.Point(1122, 237);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 86);
            this.btnTim.TabIndex = 22;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDong.BackgroundImage")));
            this.btnDong.Image = global::QLNS_SS4U.Properties.Resources.icons8_exit_52ư;
            this.btnDong.Location = new System.Drawing.Point(1122, 129);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 86);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIn.BackgroundImage")));
            this.btnIn.Image = global::QLNS_SS4U.Properties.Resources.icons8_print_52;
            this.btnIn.Location = new System.Drawing.Point(1000, 129);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 86);
            this.btnIn.TabIndex = 11;
            this.btnIn.Text = "In";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.BackgroundImage")));
            this.btnLuu.Image = global::QLNS_SS4U.Properties.Resources.icons8_save_52;
            this.btnLuu.Location = new System.Drawing.Point(882, 129);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 86);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
            this.btnXoa.Image = global::QLNS_SS4U.Properties.Resources.icons8_delete_52;
            this.btnXoa.Location = new System.Drawing.Point(1122, 22);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 86);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSua.BackgroundImage")));
            this.btnSua.Image = global::QLNS_SS4U.Properties.Resources.icons8_fix_52;
            this.btnSua.Location = new System.Drawing.Point(1000, 22);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 86);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
            this.btnThem.Image = global::QLNS_SS4U.Properties.Resources.icons8_add_52;
            this.btnThem.Location = new System.Drawing.Point(882, 22);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 86);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FrmLoiPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(192)))), ((int)(((byte)(238)))));
            this.BackgroundImage = global::QLNS_SS4U.Properties.Resources.download1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1214, 589);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvLoiPhat);
            this.Controls.Add(this.ckbTinhTrang);
            this.Controls.Add(this.btnCuoi);
            this.Controls.Add(this.dateTimePickerNgaySua);
            this.Controls.Add(this.btnKe);
            this.Controls.Add(this.txtMucPhat);
            this.Controls.Add(this.dateTimePickerNgayTao);
            this.Controls.Add(this.txtTenLoiPhat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTruoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTongMau);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnDau);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMauHienHanh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLoiPhat";
            this.Text = "Quản lý mức phạt";
            this.Load += new System.EventHandler(this.FrmLoiPhat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnCuoi;
        private System.Windows.Forms.Button btnKe;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMucPhat;
        private System.Windows.Forms.TextBox txtTenLoiPhat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongMau;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnDau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvLoiPhat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMauHienHanh;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaySua;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayTao;
        private System.Windows.Forms.CheckBox ckbTinhTrang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}