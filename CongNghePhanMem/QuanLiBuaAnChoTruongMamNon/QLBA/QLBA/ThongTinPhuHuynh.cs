using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBA
{
    public partial class ThongTinPhuHuynh : Form
    {
        public ThongTinPhuHuynh()
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


        private void ThongTinPhuHuynh_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda;

            sda = new SqlDataAdapter("SELECT * from PHUHUYNH", con);
            sda.Fill(ds, "PHUHUYNH");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["PHUHUYNH"].Columns[0];
            ds.Tables["PHUHUYNH"].PrimaryKey = key;
            Gridview1.DataSource = ds.Tables["PHUHUYNH"];

            Gridview1.Columns[0].HeaderText = "Mã trẻ";
            Gridview1.Columns[1].HeaderText = "Họ tên cha";
            Gridview1.Columns[2].HeaderText = "Họ tên mẹ ";
            Gridview1.Columns[3].HeaderText = "Nghề nghiệp cha";
            Gridview1.Columns[4].HeaderText = "Nghề nghiệp mẹ";
            Gridview1.Columns[5].HeaderText = "SĐT cha";
            Gridview1.Columns[6].HeaderText = "SĐT mẹ";

            bt_Sửa.Enabled = false;
            bt_Xóa.Enabled = false;
        }

        private void Gridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.Gridview1.Rows[e.RowIndex];
                txt_Ma.Text = row.Cells[0].Value.ToString();
                txt_HoTenCha.Text = row.Cells[1].Value.ToString();
                txt_HoTenMe.Text = row.Cells[2].Value.ToString();
                txt_NgheNghiepCha.Text = row.Cells[3].Value.ToString();
                txt_NgheNghiepMe.Text = row.Cells[4].Value.ToString();
                txt_SDTCha.Text = row.Cells[4].Value.ToString();
                txt_SDTMe.Text = row.Cells[6].Value.ToString();

                Gridview1.Columns[0].HeaderText = "Mã trẻ";
                Gridview1.Columns[1].HeaderText = "Họ tên cha";
                Gridview1.Columns[2].HeaderText = "Họ tên mẹ ";
                Gridview1.Columns[3].HeaderText = "Nghề nghiệp cha";
                Gridview1.Columns[4].HeaderText = "Nghề nghiệp mẹ";
                Gridview1.Columns[5].HeaderText = "SĐT cha";
                Gridview1.Columns[6].HeaderText = "SĐT mẹ";


                bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                bt_Xóa.Enabled = true; bt_Xóa.ForeColor = Color.Black;
                bt_Sửa.Enabled = true; bt_Sửa.ForeColor = Color.Black;
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            if (bt_Them.Text == "Thêm")
            {
                bt_Xóa.Enabled = false;
                bt_Sửa.Enabled = false;
                txt_Ma.Enabled = true;
                txt_HoTenCha.Enabled = true;
                txt_HoTenMe.Enabled = true;
                txt_NgheNghiepCha.Enabled = true;
                txt_NgheNghiepMe.Enabled = true;
                txt_SDTCha.Enabled = true;
                txt_SDTMe.Enabled = true;


                bt_Them.Text = "Lưu";
                bt_Them.ForeColor = Color.Blue;
                bt_Sửa.Text = "Sửa";
            }
            else if (bt_Them.Text == "Lưu")
            {
                if (txt_HoTenCha.Text == string.Empty || txt_HoTenMe.Text == string.Empty)
                {
                    MessageBox.Show("Bạn hãy điền đầy đủ thông tin.");
                    return;
                }
                else
                {
                    try
                    {
                        DataRow dr = ds.Tables["PHUHUYNH"].NewRow();
                        dr[0] = txt_Ma.Text;
                        dr[1] = txt_HoTenCha.Text;
                        dr[2] = txt_HoTenMe.Text;
                        dr[3] = txt_NgheNghiepCha.Text;
                        dr[4] = txt_NgheNghiepMe.Text;
                        dr[5] = txt_SDTCha.Text;
                        dr[6] = txt_SDTMe.Text;

                        ds.Tables["PHUHUYNH"].Rows.Add(dr);
                        save = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mã khối đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txt_Ma.Enabled = false;
                    txt_HoTenCha.Text = "";
                    txt_HoTenMe.Text = "";
                    txt_NgheNghiepCha.Text = "";
                    txt_NgheNghiepMe.Text = "";
                    txt_SDTCha.Text = "";
                    txt_SDTMe.Text = "";

                    bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                }
            }
        }

        private void bt_Xóa_Click(object sender, EventArgs e)
        {
            try
            {
                string GIAOVIEN = Gridview1.CurrentRow.Cells[0].Value.ToString();

                DataRow dr = ds.Tables["PHUHUYNH"].Rows.Find(GIAOVIEN);

                if (dr != null)
                {
                    dr.Delete();
                }
                txt_Ma.Enabled = false;
                txt_HoTenCha.Text = "";
                txt_HoTenMe.Text = "";
                txt_NgheNghiepCha.Text = "";
                txt_NgheNghiepMe.Text = "";
                txt_SDTCha.Text = "";
                txt_SDTMe.Text = "";

                save = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật vào cở sở dữ liệu. Hãy chắc chắc khối học bạn xóa không còn lớp nào tồn tại, hoặc đảm bảo đã điền đầy đủ thông tin khi thêm hoặc chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_Sửa_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables["PHUHUYNH"].Rows.Find(txt_Ma.Text);

            if (dr != null)
            {

                if (bt_Sửa.Text == "Sửa")
                {
                    bt_Xóa.Enabled = false;
                    bt_Them.Enabled = true;
                    txt_Ma.Enabled = false;
                    txt_Ma.Text = dr[0].ToString();
                    txt_HoTenCha.Text = dr[1].ToString();
                    txt_HoTenMe.Text = dr[2].ToString();
                    txt_NgheNghiepCha.Text = dr[3].ToString();
                    txt_NgheNghiepMe.Text = dr[4].ToString();
                    txt_SDTCha.Text = dr[5].ToString();
                    txt_SDTMe.Text = dr[6].ToString();
                    bt_Sửa.Text = "Lưu";
                    bt_Sửa.ForeColor = Color.Blue;
                }
                else if (bt_Sửa.Text == "Lưu")
                {

                    if (txt_HoTenCha.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn chưa điền đầy đủ thông tin.");
                        return;
                    }

                    else
                    {
                        try
                        {
                            //string caulenh = "insert into KhoiHoc values('" + txt_MaKhoi.Text + "','" + txt_TenKhoi.Text + "')";
                            dr[1] = txt_HoTenCha.Text;
                            dr[2] = txt_HoTenMe.Text;
                            dr[3] = txt_NgheNghiepCha.Text;
                            dr[4] = txt_NgheNghiepMe.Text;
                            dr[5] = txt_SDTCha.Text;
                            dr[6] = txt_SDTMe.Text;

                            save = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hãy điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        bt_Sửa.Text = "Sửa"; bt_Sửa.ForeColor = Color.Black;
                        txt_Ma.Text = string.Empty;
                        txt_HoTenCha.Text = string.Empty;
                        txt_HoTenMe.Text = string.Empty;
                        txt_NgheNghiepCha.Text = string.Empty;
                        txt_NgheNghiepMe.Text = string.Empty;
                        txt_SDTCha.Text = string.Empty;
                        txt_SDTMe.Text = string.Empty;

                        bt_Sửa.Enabled = false;
                        bt_Xóa.Enabled = false;
                        save = false;
                    }
                }
            }
        }

        private void ThongTinPhuHuynh_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void grp_TTPH_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }
    }





}
