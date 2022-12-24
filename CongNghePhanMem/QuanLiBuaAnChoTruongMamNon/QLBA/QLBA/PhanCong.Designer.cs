namespace QLBA
{
    partial class PhanCong
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
            this.dGV_PhanCong = new System.Windows.Forms.DataGridView();
            this.col_MaGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenLop = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bt_Luu = new System.Windows.Forms.Button();
            this.bt_HienThi = new System.Windows.Forms.Button();
            this.cbb_KhoiHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_PhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV_PhanCong
            // 
            this.dGV_PhanCong.AllowUserToDeleteRows = false;
            this.dGV_PhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_PhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_PhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaGV,
            this.col_TenGV,
            this.col_MaLop,
            this.col_TenLop});
            this.dGV_PhanCong.Location = new System.Drawing.Point(59, 135);
            this.dGV_PhanCong.Margin = new System.Windows.Forms.Padding(4);
            this.dGV_PhanCong.Name = "dGV_PhanCong";
            this.dGV_PhanCong.RowHeadersWidth = 51;
            this.dGV_PhanCong.Size = new System.Drawing.Size(682, 234);
            this.dGV_PhanCong.TabIndex = 5;
            this.dGV_PhanCong.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_PhanCong_CellEndEdit);
            this.dGV_PhanCong.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dGV_PhanCong_ColumnAdded);
            this.dGV_PhanCong.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dGV_PhanCong_DataError);
            this.dGV_PhanCong.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dGV_PhanCong_EditingControlShowing);
            this.dGV_PhanCong.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dGV_PhanCong_RowsAdded);
            // 
            // col_MaGV
            // 
            this.col_MaGV.DataPropertyName = "MaGV";
            this.col_MaGV.HeaderText = "Mã giáo viên";
            this.col_MaGV.MinimumWidth = 6;
            this.col_MaGV.Name = "col_MaGV";
            // 
            // col_TenGV
            // 
            this.col_TenGV.DataPropertyName = "TenGV";
            this.col_TenGV.HeaderText = "Tên giáo viên";
            this.col_TenGV.MinimumWidth = 6;
            this.col_TenGV.Name = "col_TenGV";
            // 
            // col_MaLop
            // 
            this.col_MaLop.DataPropertyName = "MaLop";
            this.col_MaLop.HeaderText = "Mã lớp hiện tại";
            this.col_MaLop.MinimumWidth = 6;
            this.col_MaLop.Name = "col_MaLop";
            // 
            // col_TenLop
            // 
            this.col_TenLop.DataPropertyName = "MaLop";
            this.col_TenLop.HeaderText = "Tên lớp hiện tại";
            this.col_TenLop.MinimumWidth = 6;
            this.col_TenLop.Name = "col_TenLop";
            // 
            // bt_Luu
            // 
            this.bt_Luu.ForeColor = System.Drawing.Color.MediumBlue;
            this.bt_Luu.Location = new System.Drawing.Point(443, 82);
            this.bt_Luu.Name = "bt_Luu";
            this.bt_Luu.Size = new System.Drawing.Size(112, 27);
            this.bt_Luu.TabIndex = 9;
            this.bt_Luu.Text = "Lưu";
            this.bt_Luu.UseVisualStyleBackColor = true;
            this.bt_Luu.Click += new System.EventHandler(this.bt_Luu_Click);
            // 
            // bt_HienThi
            // 
            this.bt_HienThi.ForeColor = System.Drawing.Color.MediumBlue;
            this.bt_HienThi.Location = new System.Drawing.Point(306, 82);
            this.bt_HienThi.Name = "bt_HienThi";
            this.bt_HienThi.Size = new System.Drawing.Size(112, 27);
            this.bt_HienThi.TabIndex = 8;
            this.bt_HienThi.Text = "Hiển thị";
            this.bt_HienThi.UseVisualStyleBackColor = true;
            this.bt_HienThi.Click += new System.EventHandler(this.bt_HienThi_Click);
            // 
            // cbb_KhoiHoc
            // 
            this.cbb_KhoiHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_KhoiHoc.FormattingEnabled = true;
            this.cbb_KhoiHoc.Location = new System.Drawing.Point(142, 82);
            this.cbb_KhoiHoc.Name = "cbb_KhoiHoc";
            this.cbb_KhoiHoc.Size = new System.Drawing.Size(140, 24);
            this.cbb_KhoiHoc.TabIndex = 7;
            this.cbb_KhoiHoc.SelectedIndexChanged += new System.EventHandler(this.cbb_KhoiHoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(59, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khối học : ";
            // 
            // PhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dGV_PhanCong);
            this.Controls.Add(this.bt_Luu);
            this.Controls.Add(this.bt_HienThi);
            this.Controls.Add(this.cbb_KhoiHoc);
            this.Controls.Add(this.label1);
            this.Name = "PhanCong";
            this.Text = "PhanCong: 52000887 + 52000883";
            this.Load += new System.EventHandler(this.PhanCong_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PhanCong_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_PhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_PhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaLop;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_TenLop;
        private System.Windows.Forms.Button bt_Luu;
        private System.Windows.Forms.Button bt_HienThi;
        private System.Windows.Forms.ComboBox cbb_KhoiHoc;
        private System.Windows.Forms.Label label1;
    }
}