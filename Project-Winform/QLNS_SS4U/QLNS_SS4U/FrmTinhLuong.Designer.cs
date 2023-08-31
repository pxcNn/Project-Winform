namespace QLNS_SS4U
{
    partial class FrmTinhLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTinhLuong));
            this.lvTinhLuong = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbTenPB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.btnTinh = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvTinhLuong
            // 
            this.lvTinhLuong.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lvTinhLuong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader13,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvTinhLuong.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTinhLuong.FullRowSelect = true;
            this.lvTinhLuong.GridLines = true;
            this.lvTinhLuong.HideSelection = false;
            this.lvTinhLuong.Location = new System.Drawing.Point(12, 182);
            this.lvTinhLuong.Name = "lvTinhLuong";
            this.lvTinhLuong.Size = new System.Drawing.Size(1555, 492);
            this.lvTinhLuong.TabIndex = 0;
            this.lvTinhLuong.UseCompatibleStateImageBehavior = false;
            this.lvTinhLuong.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên nhân viên";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên phòng ban";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số tiền lương";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 118;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Phụ cấp";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 99;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Công";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Lương tháng";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tiền thưởng";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Bảo hiểm";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 110;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Thuế TNCN";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader13.Width = 102;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tiền Phạt";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 110;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Tiền ứng";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 110;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Lương thực nhận";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader12.Width = 159;
            // 
            // cmbTenPB
            // 
            this.cmbTenPB.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenPB.FormattingEnabled = true;
            this.cmbTenPB.Location = new System.Drawing.Point(609, 30);
            this.cmbTenPB.Name = "cmbTenPB";
            this.cmbTenPB.Size = new System.Drawing.Size(395, 27);
            this.cmbTenPB.TabIndex = 1;
            this.cmbTenPB.SelectedIndexChanged += new System.EventHandler(this.cmbTenPB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đơn vị, phòng ban";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tháng";
            // 
            // cmbThang
            // 
            this.cmbThang.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(609, 75);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(213, 27);
            this.cmbThang.TabIndex = 4;
            this.cmbThang.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Họ và tên Nhân viên";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(609, 117);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(213, 26);
            this.txtTenNV.TabIndex = 5;
            // 
            // btnTinh
            // 
            this.btnTinh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTinh.BackgroundImage")));
            this.btnTinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinh.Image = global::QLNS_SS4U.Properties.Resources.icons8_calculator_50;
            this.btnTinh.Location = new System.Drawing.Point(853, 63);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(112, 85);
            this.btnTinh.TabIndex = 6;
            this.btnTinh.Text = "Tính lương";
            this.btnTinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIn.BackgroundImage")));
            this.btnIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = global::QLNS_SS4U.Properties.Resources.icons8_print_52;
            this.btnIn.Location = new System.Drawing.Point(1136, 37);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(120, 107);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "In";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // FrmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLNS_SS4U.Properties.Resources.download1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1575, 686);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTenPB);
            this.Controls.Add(this.lvTinhLuong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTinhLuong";
            this.Text = "Tính Lương";
            this.Load += new System.EventHandler(this.FrmTinhLuong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvTinhLuong;
        private System.Windows.Forms.ComboBox cmbTenPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}