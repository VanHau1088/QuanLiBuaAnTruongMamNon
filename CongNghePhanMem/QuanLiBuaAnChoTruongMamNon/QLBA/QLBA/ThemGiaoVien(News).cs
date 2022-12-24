using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBA
{
    public partial class ThemGiaoVien_News_ : Form
    {
        public ThemGiaoVien_News_()
        {
            InitializeComponent();
        }


        private bool _vt;
        public bool vt
        {
            get { return _vt; }
            set { _vt = value; }
        }

        SqlConnection con = new SqlConnection(@"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBAMN1905;Integrated Security=True");
        DataSet ds = new DataSet();
        bool save = true;
        bool save1 = true;


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_MaKhoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TenKhoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThemGiaoVien_News__Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda;

            sda = new SqlDataAdapter("SELECT * from GIAOVIEN", con);
            sda.Fill(ds, "GIAOVIEN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["GIAOVIEN"].Columns[0];
            ds.Tables["GIAOVIEN"].PrimaryKey = key;
            Gridview1.DataSource = ds.Tables["GIAOVIEN"];
            Gridview1.Columns[0].HeaderText = "Mã giáo viên";
            Gridview1.Columns[1].HeaderText = "Tên giáo viên";
            Gridview1.Columns[2].HeaderText = "Ngày Sinh";
            Gridview1.Columns[3].HeaderText = "Giới tính ";
            Gridview1.Columns[4].HeaderText = "Địa chỉ ";
            Gridview1.Columns[5].HeaderText = "Số điện thoại";
            Gridview1.Columns[6].HeaderText = "Lương ";
            Gridview1.Columns[7].HeaderText = "Ngày bắt đầu ";
            Gridview1.Columns[8].HeaderText = "Lương CB ";
            Gridview1.Columns[9].HeaderText = "Mã lớp ";
            Gridview1.Columns[10].HeaderText = "CMND ";
            Gridview1.Columns[11].HeaderText = "Trình độ ";



            bt_Sửa.Enabled = false;
            bt_Xóa.Enabled = false;
        }

        private void Gridview1_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Gridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.Gridview1.Rows[e.RowIndex];
                txt_MaGV.Text = row.Cells[0].Value.ToString();
                txt_TenGV.Text = row.Cells[1].Value.ToString();
                txt_NgayThangNam.Text = row.Cells[2].Value.ToString();
                txt_GT.Text = row.Cells[3].Value.ToString();
                txt_DiaChi.Text = row.Cells[4].Value.ToString();
                txt_SDT.Text = row.Cells[5].Value.ToString();
                txt_HSL.Text = row.Cells[6].Value.ToString();
                dtp_NgayVaoLam.Text = row.Cells[7].Value.ToString();
                txt_LuongCB.Text = row.Cells[8].Value.ToString();
                txt_MaLop.Text = row.Cells[9].Value.ToString();
                txt_CMND.Text = row.Cells[10].Value.ToString();
                cbb_TrinhDo.Text = row.Cells[11].Value.ToString();

                Gridview1.Columns[0].HeaderText = "Mã giáo viên";
                Gridview1.Columns[1].HeaderText = "Tên giáo viên";
                Gridview1.Columns[2].HeaderText = "Ngày Sinh";
                Gridview1.Columns[3].HeaderText = "Giới tính";
                Gridview1.Columns[4].HeaderText = "Địa chỉ";
                Gridview1.Columns[5].HeaderText = "Số điện thoại";
                Gridview1.Columns[6].HeaderText = "Hệ số lương";
                Gridview1.Columns[7].HeaderText = "Ngày vào làm";
                Gridview1.Columns[8].HeaderText = "Lương CB";
                Gridview1.Columns[9].HeaderText = "Mã lớp";
                Gridview1.Columns[10].HeaderText = "CMND";
                Gridview1.Columns[11].HeaderText = "Trình độ";


                bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                bt_Xóa.Enabled = true; bt_Xóa.ForeColor = Color.Black;
                bt_Sửa.Enabled = true; bt_Sửa.ForeColor = Color.Black;
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_Xóa_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_Sửa_Click(object sender, EventArgs e)
        {
            
        }

        private void ThemGiaoVien_News__Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbl_HSL_Click(object sender, EventArgs e)
        {

        }

        private void txt_HSL_TextChanged(object sender, EventArgs e)
        {

        }

        private void tSb_Them_Click(object sender, EventArgs e)
        {
            if (bt_Them.Text == "Thêm")
            {
                bt_Xóa.Enabled = false;
                bt_Sửa.Enabled = false;
                txt_MaGV.Enabled = true;
                txt_TenGV.Enabled = true;
                txt_NgayThangNam.Enabled = true;
                txt_GT.Enabled = true;
                txt_DiaChi.Enabled = true;
                txt_SDT.Enabled = true;
                txt_HSL.Enabled = true;
                dtp_NgayVaoLam.Enabled = true;
                txt_LuongCB.Enabled = true;
                txt_MaLop.Enabled = true;
                txt_CMND.Enabled = true;
                cbb_TrinhDo.Enabled = true;


                bt_Them.Text = "Lưu";
                bt_Them.ForeColor = Color.Blue;
                bt_Sửa.Text = "Sửa";
            }
            else if (bt_Them.Text == "Lưu")
            {
                if (txt_MaGV.Text == string.Empty || txt_TenGV.Text == string.Empty)
                {
                    MessageBox.Show("Bạn hãy điền đầy đủ thông tin.");
                    return;
                }
                else
                {
                    try
                    {
                        DataRow dr = ds.Tables["GIAOVIEN"].NewRow();
                        dr[0] = txt_MaGV.Text;
                        dr[1] = txt_TenGV.Text;
                        dr[2] = txt_NgayThangNam.Text;
                        dr[3] = txt_GT.Text;
                        dr[4] = txt_DiaChi.Text;
                        dr[5] = txt_SDT.Text;
                        dr[6] = txt_HSL.Text;
                        dr[7] = dtp_NgayVaoLam.Text;
                        dr[8] = txt_LuongCB.Text;
                        dr[9] = txt_MaLop.Text;
                        dr[10] = txt_CMND.Text;
                        dr[11] = cbb_TrinhDo.Text;

                        ds.Tables["GIAOVIEN"].Rows.Add(dr);
                        save = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mã khối đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txt_MaGV.Enabled = false;
                    txt_MaGV.Text = "";
                    txt_TenGV.Text = "";
                    txt_NgayThangNam.Text = "";
                    txt_GT.Text = "";
                    txt_DiaChi.Text = "";
                    txt_SDT.Text = "";
                    txt_HSL.Text = "";
                    dtp_NgayVaoLam.Text = "";
                    txt_LuongCB.Text = "";
                    txt_MaLop.Text = "";
                    txt_CMND.Text = "";
                    cbb_TrinhDo.Text = "";


                    bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                }
            }
        }

        private void tSb_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string GIAOVIEN = Gridview1.CurrentRow.Cells[0].Value.ToString();

                DataRow dr = ds.Tables["GIAOVIEN"].Rows.Find(GIAOVIEN);

                if (dr != null)
                {
                    dr.Delete();
                }
                txt_MaGV.Enabled = false;
                txt_MaGV.Text = "";
                txt_TenGV.Text = "";
                txt_NgayThangNam.Text = "";
                txt_GT.Text = "";
                txt_DiaChi.Text = "";
                txt_SDT.Text = "";
                txt_HSL.Text = "";
                dtp_NgayVaoLam.Text = "";
                txt_LuongCB.Text = "";
                txt_MaLop.Text = "";
                txt_CMND.Text = "";
                cbb_TrinhDo.Text = "";

                save = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật vào cở sở dữ liệu. Hãy chắc chắc khối học bạn xóa không còn lớp nào tồn tại, hoặc đảm bảo đã điền đầy đủ thông tin khi thêm hoặc chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tSb_Sua_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables["GIAOVIEN"].Rows.Find(txt_MaGV.Text);

            if (dr != null)
            {

                if (bt_Sửa.Text == "Sửa")
                {
                    bt_Xóa.Enabled = false;
                    bt_Them.Enabled = true;
                    txt_MaGV.Enabled = false;
                    txt_MaGV.Text = dr[0].ToString();
                    txt_TenGV.Text = dr[1].ToString();
                    txt_NgayThangNam.Text = dr[2].ToString();
                    txt_GT.Text = dr[3].ToString();
                    txt_DiaChi.Text = dr[4].ToString();
                    txt_SDT.Text = dr[5].ToString();
                    txt_HSL.Text = dr[6].ToString();
                    dtp_NgayVaoLam.Text = dr[7].ToString();
                    txt_LuongCB.Text = dr[8].ToString();
                    txt_MaLop.Text = dr[9].ToString();
                    txt_CMND.Text = dr[10].ToString();
                    cbb_TrinhDo.Text = dr[11].ToString();

                    bt_Sửa.Text = "Lưu";
                    bt_Sửa.ForeColor = Color.Blue;
                }
                else if (bt_Sửa.Text == "Lưu")
                {

                    if (txt_TenGV.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn chưa điền đầy đủ thông tin.");
                        return;
                    }

                    else
                    {
                        try
                        {
                            //string caulenh = "insert into KhoiHoc values('" + txt_MaKhoi.Text + "','" + txt_TenKhoi.Text + "')";
                            dr[1] = txt_TenGV.Text;
                            dr[2] = txt_NgayThangNam.Text;
                            dr[3] = txt_GT.Text;
                            dr[4] = txt_DiaChi.Text;
                            dr[5] = txt_SDT.Text;
                            dr[6] = txt_HSL.Text;
                            dr[7] = dtp_NgayVaoLam.Text;
                            dr[8] = txt_LuongCB.Text;
                            dr[9] = txt_MaLop.Text;
                            dr[10] = txt_CMND.Text;
                            dr[11] = cbb_TrinhDo.Text;

                            save = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hãy điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        bt_Sửa.Text = "Sửa"; bt_Sửa.ForeColor = Color.Black;
                        txt_MaGV.Text = string.Empty;
                        txt_TenGV.Text = string.Empty;
                        txt_NgayThangNam.Text = string.Empty;
                        txt_GT.Text = string.Empty;
                        txt_DiaChi.Text = string.Empty;
                        txt_SDT.Text = string.Empty;
                        txt_HSL.Text = string.Empty;
                        dtp_NgayVaoLam.Text = string.Empty;
                        txt_LuongCB.Text = string.Empty;
                        txt_MaLop.Text = string.Empty;
                        txt_CMND.Text = string.Empty;
                        cbb_TrinhDo.Text = string.Empty;


                        bt_Sửa.Enabled = false;
                        bt_Xóa.Enabled = false;
                        save = false;
                    }
                }
            }
        }

        private void bt_ChonAnh_Click(object sender, EventArgs e)
        {

        }

        private void cbb_TrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.OrangeRed, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }
    }
}
