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
    public partial class QuanLiBuaAn : Form
    {
        public QuanLiBuaAn()
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void QuanLiBuaAn_Load(object sender, EventArgs e)
        {

            SqlDataAdapter sda;

            sda = new SqlDataAdapter("SELECT * from BUAAN", con);
            sda.Fill(ds, "BUAAN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["BUAAN"].Columns[0];
            ds.Tables["BUAAN"].PrimaryKey = key;
            Gridview1.DataSource = ds.Tables["BUAAN"];
            Gridview1.Columns[0].HeaderText = "Mã lớp";
            Gridview1.Columns[1].HeaderText = "Ngày tháng năm";
            Gridview1.Columns[2].HeaderText = "Bữa sáng ";
            Gridview1.Columns[3].HeaderText = "Bữa trưa ";
            Gridview1.Columns[4].HeaderText = "Bữa chiều ";
            Gridview1.Columns[5].HeaderText = "CP Bữa sáng ";
            Gridview1.Columns[6].HeaderText = "CP Bữa trưa ";
            Gridview1.Columns[7].HeaderText = "CP Bữa chiều ";
            Gridview1.Columns[8].HeaderText = "Tổng CP";



            bt_Sua.Enabled = false;
            bt_Xoa.Enabled = false;
           
        }

        private void Gridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.Gridview1.Rows[e.RowIndex];
                txt_MaLop.Text = row.Cells[0].Value.ToString();
                dtp_NgayThangNam.Text = row.Cells[1].Value.ToString();
                rtxt_BuaSang.Text = row.Cells[2].Value.ToString();
                rtxt_BuaTrua.Text = row.Cells[3].Value.ToString();
                rtxt_BuaChieu.Text = row.Cells[4].Value.ToString();
                txt_CpSang.Text = row.Cells[5].Value.ToString();
                txt_CpTrua.Text = row.Cells[6].Value.ToString();
                txt_CpChieu.Text = row.Cells[7].Value.ToString();
                txt_TongChiPhi.Text = row.Cells[8].Value.ToString();

                Gridview1.Columns[0].HeaderText = "Mã lớp";
                Gridview1.Columns[1].HeaderText = "Ngày tháng năm";
                Gridview1.Columns[2].HeaderText = "Bữa sáng ";
                Gridview1.Columns[3].HeaderText = "Bữa trưa ";
                Gridview1.Columns[4].HeaderText = "Bữa chiều ";
                Gridview1.Columns[5].HeaderText = "CP Bữa sáng ";
                Gridview1.Columns[6].HeaderText = "CP Bữa trưa ";
                Gridview1.Columns[7].HeaderText = "CP Bữa chiều ";
                Gridview1.Columns[8].HeaderText = "Tổng CP";


                bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                bt_Xoa.Enabled = true; bt_Xoa.ForeColor = Color.Black;
                bt_Sua.Enabled = true; bt_Sua.ForeColor = Color.Black;
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            if (bt_Them.Text == "Thêm")
            {
                bt_Xoa.Enabled = false;
                bt_Sua.Enabled = false;
                txt_MaLop.Enabled = true;
                dtp_NgayThangNam.Enabled = true;
                rtxt_BuaSang.Enabled = true;
                rtxt_BuaTrua.Enabled = true;
                rtxt_BuaChieu.Enabled = true;
                txt_CpSang.Enabled = true;
                txt_CpTrua.Enabled = true;
                txt_CpChieu.Enabled = true;
                txt_TongChiPhi.Enabled = true;


                bt_Them.Text = "Lưu";
                bt_Them.ForeColor = Color.Blue;
                bt_Sua.Text = "Sửa";
            }
            else if (bt_Them.Text == "Lưu")
            {
                if (dtp_NgayThangNam.Text == string.Empty)
                {
                    MessageBox.Show("Bạn hãy điền đầy đủ thông tin.");
                    return;
                }
                else
                {
                    try
                    {
                        DataRow dr = ds.Tables["BUAAN"].NewRow();
                        dr[0] = txt_MaLop.Text;
                        dr[1] = dtp_NgayThangNam.Text;
                        dr[2] = rtxt_BuaSang.Text;
                        dr[3] = rtxt_BuaTrua.Text;
                        dr[4] = rtxt_BuaChieu.Text;
                        dr[5] = txt_CpSang.Text;
                        dr[6] = txt_CpTrua.Text;
                        dr[7] = txt_CpChieu.Text;
                        dr[8] = txt_TongChiPhi.Text;

                        ds.Tables["BUAAN"].Rows.Add(dr);
                        save = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mã khối đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txt_MaLop.Enabled = false;
                    txt_MaLop.Text = "";
                    dtp_NgayThangNam.Text = "";
                    rtxt_BuaSang.Text = "";
                    rtxt_BuaTrua.Text = "";
                    rtxt_BuaChieu.Text = "";
                    txt_CpSang.Text = "";
                    txt_CpTrua.Text = "";
                    txt_CpChieu.Text = "";
                    txt_TongChiPhi.Text = "";


                    bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                }
            }
        }

        private void QuanLiBuaAn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void Gridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string GIAOVIEN = Gridview1.CurrentRow.Cells[0].Value.ToString();

                DataRow dr = ds.Tables["BUAAN"].Rows.Find(GIAOVIEN);

                if (dr != null)
                {
                    dr.Delete();
                }
                txt_MaLop.Enabled = false;
                txt_MaLop.Text = "";
                dtp_NgayThangNam.Text = "";
                rtxt_BuaSang.Text = "";
                rtxt_BuaTrua.Text = "";
                rtxt_BuaChieu.Text = "";
                txt_CpSang.Text = "";
                txt_CpTrua.Text = "";
                txt_CpChieu.Text = "";
                txt_TongChiPhi.Text = "";


                save = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật vào cở sở dữ liệu. Hãy chắc chắc khối học bạn xóa không còn lớp nào tồn tại, hoặc đảm bảo đã điền đầy đủ thông tin khi thêm hoặc chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables["BUAAN"].Rows.Find(txt_MaLop.Text);

            if (dr != null)
            {

                if (bt_Sua.Text == "Sửa")
                {
                    bt_Xoa.Enabled = false;
                    bt_Them.Enabled = true;
                    txt_MaLop.Enabled = false;
                    txt_MaLop.Text = dr[0].ToString();
                    dtp_NgayThangNam.Text = dr[1].ToString();
                    rtxt_BuaSang.Text = dr[2].ToString();
                    rtxt_BuaTrua.Text = dr[3].ToString();
                    rtxt_BuaChieu.Text = dr[4].ToString();
                    txt_CpSang.Text = dr[5].ToString();
                    txt_CpTrua.Text = dr[6].ToString();
                    txt_CpChieu.Text = dr[7].ToString();
                    txt_TongChiPhi.Text = dr[8].ToString();
                    bt_Sua.Text = "Lưu";
                    bt_Sua.ForeColor = Color.Blue;
                }
                else if (bt_Sua.Text == "Lưu")
                {

                    if (txt_MaLop.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn chưa điền đầy đủ thông tin.");
                        return;
                    }

                    else
                    {
                        try
                        {
                            //string caulenh = "insert into KhoiHoc values('" + txt_MaKhoi.Text + "','" + txt_TenKhoi.Text + "')";
                            dr[1] = dtp_NgayThangNam.Text;
                            dr[2] = rtxt_BuaSang.Text;
                            dr[3] = rtxt_BuaTrua.Text;
                            dr[4] = rtxt_BuaChieu.Text;
                            dr[5] = txt_CpSang.Text;
                            dr[6] = txt_CpTrua.Text;
                            dr[7] = txt_CpChieu.Text;
                            dr[8] = txt_TongChiPhi.Text;


                            save = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hãy điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        bt_Sua.Text = "Sửa"; bt_Sua.ForeColor = Color.Black;
                        txt_MaLop.Text = string.Empty;
                        dtp_NgayThangNam.Text = string.Empty;
                        rtxt_BuaSang.Text = string.Empty;
                        rtxt_BuaTrua.Text = string.Empty;
                        rtxt_BuaChieu.Text = string.Empty;
                        txt_CpSang.Text = string.Empty;
                        txt_CpTrua.Text = string.Empty;
                        txt_CpChieu.Text = string.Empty;
                        txt_TongChiPhi.Text = string.Empty;


                        bt_Sua.Enabled = false;
                        bt_Xoa.Enabled = false;
                        save = false;
                    }
                }
            }
        }

        private void txt_CpSang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '-')*/)
            {
                e.Handled = true;
            }
        }

        private void txt_CpTrua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '-')*/)
            {
                e.Handled = true;
            }
        }

        private void txt_CpChieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '-')*/)
            {
                e.Handled = true;
            }
        }

        private void txt_CpSang_TextChanged(object sender, EventArgs e)
        {
            int TongTien = 0;
            if (txt_CpSang.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpSang = int.Parse(txt_CpSang.Text);
                TongTien += CpSang;
            }
            if (txt_CpTrua.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpTrua = int.Parse(txt_CpTrua.Text);
                TongTien += CpTrua;
            }
            if (txt_CpChieu.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpChieu = int.Parse(txt_CpChieu.Text);
                TongTien += CpChieu;
            }
            txt_TongChiPhi.Text = TongTien.ToString();
        }

        private void txt_CpTrua_TextChanged(object sender, EventArgs e)
        {
            int TongTien = 0;
            if (txt_CpSang.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpSang = int.Parse(txt_CpSang.Text);
                TongTien += CpSang;
            }
            if (txt_CpTrua.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpTrua = int.Parse(txt_CpTrua.Text);
                TongTien += CpTrua;
            }
            if (txt_CpChieu.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpChieu = int.Parse(txt_CpChieu.Text);
                TongTien += CpChieu;
            }
            txt_TongChiPhi.Text = TongTien.ToString();
        }

        private void txt_CpChieu_TextChanged(object sender, EventArgs e)
        {
            int TongTien = 0;
            if (txt_CpSang.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpSang = int.Parse(txt_CpSang.Text);
                TongTien += CpSang;
            }
            if (txt_CpTrua.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpTrua = int.Parse(txt_CpTrua.Text);
                TongTien += CpTrua;
            }
            if (txt_CpChieu.Text == string.Empty)
                TongTien += 0;
            else
            {
                int CpChieu = int.Parse(txt_CpChieu.Text);
                TongTien += CpChieu;
            }
            txt_TongChiPhi.Text = TongTien.ToString();
        }

        private void cbb_TenLop_TextChanged(object sender, EventArgs e)
        {
        /*    if (cbb_TenLop.SelectedValue != null)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM BUAAN WHERE MALOP = '" + cbb_TenLop.SelectedValue + "' AND NGAYTHANGNAM = '" + dtp_NgayThangNam.Value.ToString("dd/MM/yyyy") + "'", con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        rtxt_BuaSang.Enabled = false;
                        rtxt_BuaTrua.Enabled = false;
                        rtxt_BuaChieu.Enabled = false;
                        txt_CpSang.Enabled = false;
                        txt_CpTrua.Enabled = false;
                        txt_CpChieu.Enabled = false;
                        txt_TongChiPhi.Enabled = false;
                        rtxt_BuaSang.Text = sdr["BUASANG"].ToString();
                        txt_CpSang.Text = sdr["CPBUASANG"].ToString();
                        rtxt_BuaTrua.Text = sdr["BUATRUA"].ToString();
                        txt_CpTrua.Text = sdr["CPBUATRUA"].ToString();
                        rtxt_BuaChieu.Text = sdr["BUACHIEU"].ToString();
                        txt_CpChieu.Text = sdr["CPBUACHIEU"].ToString();
                        txt_TongChiPhi.Text = sdr["TONGCP"].ToString();
                        bt_Them.Enabled = false;
                        bt_Xoa.Enabled = true;
                        bt_Sua.Enabled = true; bt_Sua.Text = "Sửa";
                    }
                    else
                    {
                        rtxt_BuaSang.Enabled = true; rtxt_BuaSang.Text = string.Empty;
                        rtxt_BuaTrua.Enabled = true; rtxt_BuaTrua.Text = string.Empty;
                        rtxt_BuaChieu.Enabled = true; rtxt_BuaChieu.Text = string.Empty;
                        txt_CpSang.Enabled = true; txt_CpSang.Text = string.Empty;
                        txt_CpTrua.Enabled = true; txt_CpTrua.Text = string.Empty;
                        txt_CpChieu.Enabled = true; txt_CpChieu.Text = string.Empty;
                        bt_Them.Enabled = true;
                        bt_Xoa.Enabled = false;
                        bt_Sua.Enabled = false;
                    }

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                //rtxt_BuaSang.Enabled = false;
                //rtxt_BuaTrua.Enabled = false;
                //rtxt_BuaChieu.Enabled = false;
                //txt_CpSang.Enabled = false;
                //txt_CpTrua.Enabled = false;
                //txt_CpChieu.Enabled = false;
                //bt_Them.Text = "Thêm";
                //bt_Xoa.Enabled = true;
                //bt_Sua.Enabled = true;
            }*/
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report_BuaAn frmBA = new Report_BuaAn();
            frmBA.Show();
        }
    }
}
