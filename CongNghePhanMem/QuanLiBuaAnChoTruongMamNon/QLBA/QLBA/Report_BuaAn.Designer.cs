namespace QLBA
{
    partial class Report_BuaAn
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Thoát = new System.Windows.Forms.Button();
            this.Gridview1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1556, 769);
            this.reportViewer1.TabIndex = 0;
            // 
            // Thoát
            // 
            this.Thoát.Location = new System.Drawing.Point(577, 455);
            this.Thoát.Name = "Thoát";
            this.Thoát.Size = new System.Drawing.Size(137, 41);
            this.Thoát.TabIndex = 39;
            this.Thoát.Text = "Thoát";
            this.Thoát.UseVisualStyleBackColor = true;
            this.Thoát.Click += new System.EventHandler(this.button3_Click);
            // 
            // Gridview1
            // 
            this.Gridview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Gridview1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Gridview1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Gridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview1.Location = new System.Drawing.Point(54, 35);
            this.Gridview1.Name = "Gridview1";
            this.Gridview1.RowHeadersWidth = 51;
            this.Gridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Gridview1.Size = new System.Drawing.Size(1192, 395);
            this.Gridview1.TabIndex = 36;
            // 
            // Report_BuaAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 769);
            this.Controls.Add(this.Thoát);
            this.Controls.Add(this.Gridview1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_BuaAn";
            this.Text = "Report_BuaAn";
            this.Load += new System.EventHandler(this.Report_BuaAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gridview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button Thoát;
        private System.Windows.Forms.DataGridView Gridview1;
    }
}