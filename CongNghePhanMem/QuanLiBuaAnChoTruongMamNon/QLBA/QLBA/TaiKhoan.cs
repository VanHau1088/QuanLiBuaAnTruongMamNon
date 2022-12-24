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
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBAMN1905;Integrated Security=True");
        DataSet ds = new DataSet();
        private void CapNhat()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TAIKHOAN", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ListViewItem item = new ListViewItem(sdr["MAGV"].ToString());
                    item.SubItems.Add(sdr["TAIKHOAN"].ToString());
                    item.SubItems.Add(sdr["MATKHAU"].ToString());
                    item.SubItems.Add(sdr["VAITRO"].ToString());
                    lst_TTTK.Items.Add(item);
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
            paint_ListView();
        }

        private void paint_ListView()
        {
            for (int i = 0; i < lst_TTTK.Items.Count; i++)
            {
                if (lst_TTTK.Items[i].Index % 2 == 0)
                {
                    lst_TTTK.Items[i].BackColor = Color.LightGreen;
                }
            }
        }

        private void CapNhat_Cbb()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT MAGV FROM GIAOVIEN", con);
                sda.Fill(dt);
                cbb_MaGV.DataSource = dt;
                cbb_MaGV.DisplayMember = "MAGV";
                cbb_MaGV.ValueMember = "MAGV";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            CapNhat();
            CapNhat_Cbb();
            cbb_MaGV.SelectedValue = -1;
            cbb_VT.Items.AddRange(new object[] { "Admin", "Client" });
            bt_Xoa.Enabled = false;
            bt_Sua.Enabled = false;
            cbb_MaGV.Enabled = false;
            txt_TK.Enabled = false;
            txt_MK.Enabled = false;
            cbb_VT.Enabled = false;
        }

        private void lst_TTTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_TTTK.SelectedItems.Count == 0)
                return;
            ListViewItem item = lst_TTTK.SelectedItems[0];
            if (item.SubItems[0].Text == string.Empty)
                cbb_MaGV.SelectedValue = -1;
            else
                cbb_MaGV.Text = item.SubItems[0].Text;
            txt_TK.Text = item.SubItems[1].Text;
            txt_MK.Text = item.SubItems[2].Text;
            cbb_VT.Text = item.SubItems[3].Text;

            cbb_MaGV.Enabled = false;
            txt_TK.Enabled = false;
            txt_MK.Enabled = false;
            cbb_VT.Enabled = false;
            bt_Xoa.Enabled = true;
            bt_Sua.Enabled = true;
            bt_Them.Text = "Thêm";
            bt_Sua.Text = "Sửa";
            bt_Xoa.Text = "Xoá";
        }

        private void cbb_MaGV_TextChanged(object sender, EventArgs e)
        {
            if (cbb_MaGV.SelectedItem != null)
                txt_TK.Text = cbb_MaGV.SelectedValue.ToString();
            else
                txt_TK.Text = string.Empty;
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            if (bt_Them.Text == "Thêm")
            {
                cbb_MaGV.SelectedValue = -1;
                txt_TK.Text = string.Empty;
                txt_MK.Text = string.Empty;
                cbb_VT.Text = "Client";
                bt_Xoa.Enabled = false;
                bt_Sua.Enabled = false;
                bt_Them.Text = "Lưu";
                cbb_MaGV.Enabled = true;
                txt_TK.Enabled = true;
                txt_MK.Enabled = true;
                cbb_VT.Enabled = true;
                bt_Sua.Text = "Sửa";
            }
            else if (bt_Them.Text == "Lưu")
            {
                if (cbb_MaGV.Text == string.Empty || txt_TK.Text == string.Empty || txt_MK.Text == string.Empty)
                    MessageBox.Show("Bạn chưa điền đầy đủ thông tin.");
                else
                {
                    bool k = true;
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT MAGV FROM TAIKHOAN WHERE TAIKHOAN = '" + cbb_MaGV.Text + "'", con);
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    if (sdr.Read())
                    {
                        MessageBox.Show("Giáo viên này đã có tài khoản.", " Thông báo");
                        k = false;
                    }
                    con.Close();
                    if (k)
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO TAIKHOAN VALUES('" + txt_TK.Text + "', '" + txt_MK.Text + "', '" + cbb_VT.Text + "','" + cbb_MaGV.Text + "')", con);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Thành công.");
                        }
                        if (con.State == ConnectionState.Open)
                            con.Close();

                        ListViewItem item = new ListViewItem(cbb_MaGV.Text);
                        item.SubItems.Add(txt_TK.Text);
                        item.SubItems.Add(txt_MK.Text);
                        item.SubItems.Add(cbb_VT.Text);
                        lst_TTTK.Items.Add(item);

                        cbb_MaGV.SelectedValue = -1;
                        txt_TK.Text = string.Empty;
                        txt_MK.Text = string.Empty;
                        cbb_VT.Text = "Client";

                        cbb_MaGV.Enabled = false;
                        txt_TK.Enabled = false;
                        txt_MK.Enabled = false;
                        cbb_VT.Enabled = false;
                        bt_Them.Text = "Thêm";
                    }
                }
            }
        }

        private void bt_Xoa_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM TAIKHOAN WHERE TAIKHOAN = '" + txt_TK.Text + "'", con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thành công.");
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
                lst_TTTK.Items.Clear();
                CapNhat();
                cbb_MaGV.SelectedValue = -1;
                txt_TK.Text = string.Empty;
                txt_MK.Text = string.Empty;
                cbb_VT.Text = "Client";
            }

        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            if (bt_Sua.Text == "Sửa")
            {
                cbb_MaGV.Enabled = true;
                txt_TK.Enabled = true;
                txt_MK.Enabled = true;
                cbb_VT.Enabled = true;
                //bt_Them.Enabled = false;
                bt_Xoa.Enabled = false;
                bt_Sua.Text = "Lưu";
            }
            else if (bt_Sua.Text == "Lưu")
            {
                if (con.State == ConnectionState.Closed)
                
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE TAIKHOAN SET TAIKHOAN ='" + txt_TK.Text + "', MATKHAU ='" + txt_MK.Text + "', VAITRO = '" + cbb_VT.Text + "', MAGV = '" + cbb_MaGV.Text + "' WHERE TAIKHOAN = '" + txt_TK.Text + "'", con);
                
         
                 if (cmd.ExecuteNonQuery() > 0)
                {

                    MessageBox.Show("Thay đổi thành công.");
                }
                 if (con.State == ConnectionState.Open)
                    con.Close();



                cbb_MaGV.SelectedValue = -1;
                txt_TK.Text = string.Empty;
                txt_MK.Text = string.Empty;
                cbb_VT.Text = "Client";

                cbb_MaGV.Enabled = false;
                txt_TK.Enabled = false;
                txt_MK.Enabled = false;
                cbb_VT.Enabled = false;
                bt_Sua.Text = "Sửa";
                bt_Sua.Enabled = false;
                lst_TTTK.Items.Clear();
                CapNhat();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.OrangeRed, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void TaiKhoan_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void txt_TK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
