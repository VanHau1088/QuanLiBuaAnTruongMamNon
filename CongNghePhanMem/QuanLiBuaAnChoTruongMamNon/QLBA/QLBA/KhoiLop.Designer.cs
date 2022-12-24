namespace QLBA
{
    partial class KhoiLop
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_MaKhoi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.txt_TenLop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MaLop = new System.Windows.Forms.TextBox();
            this.bt_Modify = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GV_LopHoc = new System.Windows.Forms.DataGridView();
            this.grp_KhoiHoc = new System.Windows.Forms.GroupBox();
            this.bt_Update = new System.Windows.Forms.Button();
            this.txt_TenKhoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaKhoi = new System.Windows.Forms.TextBox();
            this.bt_Sửa = new System.Windows.Forms.Button();
            this.bt_Xóa = new System.Windows.Forms.Button();
            this.bt_Them = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Gridview1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_LopHoc)).BeginInit();
            this.grp_KhoiHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbb_MaKhoi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btUpdate);
            this.groupBox1.Controls.Add(this.txt_TenLop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_MaLop);
            this.groupBox1.Controls.Add(this.bt_Modify);
            this.groupBox1.Controls.Add(this.bt_Delete);
            this.groupBox1.Controls.Add(this.bt_Add);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.GV_LopHoc);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(126, 224);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(550, 339);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lớp học";
            // 
            // cbb_MaKhoi
            // 
            this.cbb_MaKhoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_MaKhoi.FormattingEnabled = true;
            this.cbb_MaKhoi.Location = new System.Drawing.Point(146, 276);
            this.cbb_MaKhoi.Name = "cbb_MaKhoi";
            this.cbb_MaKhoi.Size = new System.Drawing.Size(107, 24);
            this.cbb_MaKhoi.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(67, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mã khối";
            // 
            // btUpdate
            // 
            this.btUpdate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.ForeColor = System.Drawing.Color.Red;
            this.btUpdate.Location = new System.Drawing.Point(287, 274);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(245, 46);
            this.btUpdate.TabIndex = 8;
            this.btUpdate.Text = "UPDATE";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // txt_TenLop
            // 
            this.txt_TenLop.Location = new System.Drawing.Point(145, 228);
            this.txt_TenLop.Name = "txt_TenLop";
            this.txt_TenLop.Size = new System.Drawing.Size(107, 22);
            this.txt_TenLop.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(67, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên lớp";
            // 
            // txt_MaLop
            // 
            this.txt_MaLop.Enabled = false;
            this.txt_MaLop.Location = new System.Drawing.Point(146, 182);
            this.txt_MaLop.Name = "txt_MaLop";
            this.txt_MaLop.Size = new System.Drawing.Size(107, 22);
            this.txt_MaLop.TabIndex = 5;
            // 
            // bt_Modify
            // 
            this.bt_Modify.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Modify.Location = new System.Drawing.Point(457, 225);
            this.bt_Modify.Name = "bt_Modify";
            this.bt_Modify.Size = new System.Drawing.Size(75, 30);
            this.bt_Modify.TabIndex = 4;
            this.bt_Modify.Text = "Sửa";
            this.bt_Modify.UseVisualStyleBackColor = true;
            this.bt_Modify.Click += new System.EventHandler(this.bt_Modify_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Delete.Location = new System.Drawing.Point(371, 225);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 30);
            this.bt_Delete.TabIndex = 3;
            this.bt_Delete.Text = "Xóa";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Add.Location = new System.Drawing.Point(287, 225);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 30);
            this.bt_Add.TabIndex = 2;
            this.bt_Add.Text = "Thêm";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(67, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã lớp";
            // 
            // GV_LopHoc
            // 
            this.GV_LopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV_LopHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GV_LopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_LopHoc.Location = new System.Drawing.Point(7, 26);
            this.GV_LopHoc.Name = "GV_LopHoc";
            this.GV_LopHoc.RowHeadersWidth = 51;
            this.GV_LopHoc.Size = new System.Drawing.Size(535, 150);
            this.GV_LopHoc.TabIndex = 0;
            this.GV_LopHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_LopHoc_CellClick);
            // 
            // grp_KhoiHoc
            // 
            this.grp_KhoiHoc.BackColor = System.Drawing.Color.Transparent;
            this.grp_KhoiHoc.Controls.Add(this.bt_Update);
            this.grp_KhoiHoc.Controls.Add(this.txt_TenKhoi);
            this.grp_KhoiHoc.Controls.Add(this.label2);
            this.grp_KhoiHoc.Controls.Add(this.txt_MaKhoi);
            this.grp_KhoiHoc.Controls.Add(this.bt_Sửa);
            this.grp_KhoiHoc.Controls.Add(this.bt_Xóa);
            this.grp_KhoiHoc.Controls.Add(this.bt_Them);
            this.grp_KhoiHoc.Controls.Add(this.label1);
            this.grp_KhoiHoc.Controls.Add(this.Gridview1);
            this.grp_KhoiHoc.ForeColor = System.Drawing.Color.Blue;
            this.grp_KhoiHoc.Location = new System.Drawing.Point(125, 31);
            this.grp_KhoiHoc.Margin = new System.Windows.Forms.Padding(4);
            this.grp_KhoiHoc.Name = "grp_KhoiHoc";
            this.grp_KhoiHoc.Padding = new System.Windows.Forms.Padding(4);
            this.grp_KhoiHoc.Size = new System.Drawing.Size(550, 188);
            this.grp_KhoiHoc.TabIndex = 2;
            this.grp_KhoiHoc.TabStop = false;
            this.grp_KhoiHoc.Text = "Khối học";
            this.grp_KhoiHoc.Paint += new System.Windows.Forms.PaintEventHandler(this.grp_KhoiHoc_Paint);
            // 
            // bt_Update
            // 
            this.bt_Update.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Update.ForeColor = System.Drawing.Color.Red;
            this.bt_Update.Location = new System.Drawing.Point(298, 146);
            this.bt_Update.Name = "bt_Update";
            this.bt_Update.Size = new System.Drawing.Size(245, 42);
            this.bt_Update.TabIndex = 8;
            this.bt_Update.Text = "UPDATE";
            this.bt_Update.UseVisualStyleBackColor = true;
            this.bt_Update.Click += new System.EventHandler(this.bt_Update_Click);
            // 
            // txt_TenKhoi
            // 
            this.txt_TenKhoi.Location = new System.Drawing.Point(372, 70);
            this.txt_TenKhoi.Name = "txt_TenKhoi";
            this.txt_TenKhoi.Size = new System.Drawing.Size(107, 22);
            this.txt_TenKhoi.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(294, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên khối";
            // 
            // txt_MaKhoi
            // 
            this.txt_MaKhoi.Enabled = false;
            this.txt_MaKhoi.Location = new System.Drawing.Point(372, 26);
            this.txt_MaKhoi.Name = "txt_MaKhoi";
            this.txt_MaKhoi.Size = new System.Drawing.Size(107, 22);
            this.txt_MaKhoi.TabIndex = 5;
            // 
            // bt_Sửa
            // 
            this.bt_Sửa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Sửa.Location = new System.Drawing.Point(468, 108);
            this.bt_Sửa.Name = "bt_Sửa";
            this.bt_Sửa.Size = new System.Drawing.Size(75, 30);
            this.bt_Sửa.TabIndex = 4;
            this.bt_Sửa.Text = "Sửa";
            this.bt_Sửa.UseVisualStyleBackColor = true;
            this.bt_Sửa.Click += new System.EventHandler(this.bt_Sửa_Click);
            // 
            // bt_Xóa
            // 
            this.bt_Xóa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Xóa.Location = new System.Drawing.Point(382, 108);
            this.bt_Xóa.Name = "bt_Xóa";
            this.bt_Xóa.Size = new System.Drawing.Size(75, 30);
            this.bt_Xóa.TabIndex = 3;
            this.bt_Xóa.Text = "Xóa";
            this.bt_Xóa.UseVisualStyleBackColor = true;
            this.bt_Xóa.Click += new System.EventHandler(this.bt_Xóa_Click);
            // 
            // bt_Them
            // 
            this.bt_Them.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Them.Location = new System.Drawing.Point(298, 108);
            this.bt_Them.Name = "bt_Them";
            this.bt_Them.Size = new System.Drawing.Size(75, 30);
            this.bt_Them.TabIndex = 2;
            this.bt_Them.Text = "Thêm";
            this.bt_Them.UseVisualStyleBackColor = true;
            this.bt_Them.Click += new System.EventHandler(this.bt_Them_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(294, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã khối";
            // 
            // Gridview1
            // 
            this.Gridview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Gridview1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Gridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview1.Location = new System.Drawing.Point(7, 26);
            this.Gridview1.Name = "Gridview1";
            this.Gridview1.RowHeadersWidth = 51;
            this.Gridview1.Size = new System.Drawing.Size(262, 150);
            this.Gridview1.TabIndex = 0;
            this.Gridview1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridview1_CellClick);
            this.Gridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridview1_CellContentClick);
            // 
            // KhoiLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_KhoiHoc);
            this.Name = "KhoiLop";
            this.Text = "Khối học - Lớp học: 52000887 + 52000883";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XepLop_FormClosing);
            this.Load += new System.EventHandler(this.XepLop_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XepLop_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_LopHoc)).EndInit();
            this.grp_KhoiHoc.ResumeLayout(false);
            this.grp_KhoiHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_MaKhoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.TextBox txt_TenLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MaLop;
        private System.Windows.Forms.Button bt_Modify;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView GV_LopHoc;
        private System.Windows.Forms.GroupBox grp_KhoiHoc;
        private System.Windows.Forms.Button bt_Update;
        private System.Windows.Forms.TextBox txt_TenKhoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaKhoi;
        private System.Windows.Forms.Button bt_Sửa;
        private System.Windows.Forms.Button bt_Xóa;
        private System.Windows.Forms.Button bt_Them;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Gridview1;
    }
}