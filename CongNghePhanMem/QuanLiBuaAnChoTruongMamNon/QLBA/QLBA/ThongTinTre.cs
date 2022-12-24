using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QLBA
{
    public partial class ThongTinTre : Form
    {
        public ThongTinTre()
        {
            InitializeComponent();
            setDataGridView_EditTable(false);
        }
        SqlConnection con = new SqlConnection(@"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBAMN1905;Integrated Security=True");
        SqlCommand cmd;
        DataSet ds = new DataSet();
        bool save = true;
        bool save1 = true;
        private bool _vt;
        public bool vt
        {
            get { return _vt; }
            set { _vt = value; }
        }

        private void ThongTinTre_Load(object sender, EventArgs e)
        {
            /*  CapNhat();
              LopHoc();
              LoadDataInto_ComboBox_KhoiHoc();
              LoadDataInto_ComboBox_LopHoc();
              LoadDataInto_ComboBox_Thang_Nam();*/

            SqlDataAdapter sda;

            sda = new SqlDataAdapter("SELECT * from HOCSINH", con);
            sda.Fill(ds, "HOCSINH");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["HOCSINH"].Columns[0];
            ds.Tables["HOCSINH"].PrimaryKey = key;
            Gridview1.DataSource = ds.Tables["HOCSINH"];
            Gridview1.Columns[0].HeaderText = "Mã trẻ";
            Gridview1.Columns[1].HeaderText = "Tên trẻ";
            Gridview1.Columns[2].HeaderText = "Ngày Sinh";
            Gridview1.Columns[3].HeaderText = "Giới tính ";
            Gridview1.Columns[4].HeaderText = "Địa chỉ ";
            Gridview1.Columns[5].HeaderText = "Ngày nhập học";
            Gridview1.Columns[6].HeaderText = "Lớp hiện tại";



            bt_CapNhat.Enabled = false;
            bt_Xoa.Enabled = false;
        }


        private void Gridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.Gridview1.Rows[e.RowIndex];
                txt_Ma.Text = row.Cells[0].Value.ToString();
                txt_HoTen.Text = row.Cells[1].Value.ToString();
                txt_NgayThangNam.Text = row.Cells[2].Value.ToString();
                txt_GT.Text = row.Cells[3].Value.ToString();
                txt_DiaChi.Text = row.Cells[4].Value.ToString();
                txt_NgayNhapHoc.Text = row.Cells[5].Value.ToString();
                txt_LopHienTai.Text = row.Cells[6].Value.ToString();


                Gridview1.Columns[0].HeaderText = "Mã trẻ";
                Gridview1.Columns[1].HeaderText = "Tên trẻ";
                Gridview1.Columns[2].HeaderText = "Ngày Sinh";
                Gridview1.Columns[3].HeaderText = "Giới tính ";
                Gridview1.Columns[4].HeaderText = "Địa chỉ ";
                Gridview1.Columns[5].HeaderText = "Lớp hiện tại";
                Gridview1.Columns[6].HeaderText = "Ngày nhập học";
          


                bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                bt_Xoa.Enabled = true; bt_Xoa.ForeColor = Color.Black;
                bt_CapNhat.Enabled = true; bt_CapNhat.ForeColor = Color.Black;
            }
        }


        private void bt_Them_Click_1(object sender, EventArgs e)
        {
            if (bt_Them.Text == "Thêm")
            {
                bt_Xoa.Enabled = false;
                bt_CapNhat.Enabled = false;
                txt_Ma.Enabled = true;
                txt_HoTen.Enabled = true;
                txt_NgayThangNam.Enabled = true;
                txt_GT.Enabled = true;
                txt_DiaChi.Enabled = true;
                txt_LopHienTai.Enabled = true;
                txt_NgayNhapHoc.Enabled = true;
      


                bt_Them.Text = "Lưu";
                bt_Them.ForeColor = Color.Blue;
                bt_CapNhat.Text = "Sửa";
            }
            else if (bt_Them.Text == "Lưu")
            {
                if (txt_Ma.Text == string.Empty || txt_HoTen.Text == string.Empty)
                {
                    MessageBox.Show("Bạn hãy điền đầy đủ thông tin.");
                    return;
                }
                else
                {
                    try
                    {
                        DataRow dr = ds.Tables["HOCSINH"].NewRow();
                        dr[0] = txt_Ma.Text;
                        dr[1] = txt_HoTen.Text;
                        dr[2] = txt_NgayThangNam.Text;
                        dr[3] = txt_GT.Text;
                        dr[4] = txt_DiaChi.Text;
                        dr[5] = txt_LopHienTai.Text;
                        dr[6] = txt_NgayNhapHoc.Text;
                   

                        ds.Tables["HOCSINH"].Rows.Add(dr);
                        save = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mã khối đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txt_Ma.Enabled = false;
                    txt_Ma.Text = "";
                    txt_HoTen.Text = "";
                    txt_NgayThangNam.Text = "";
                    txt_GT.Text = "";
                    txt_DiaChi.Text = "";
                    txt_LopHienTai.Text = "";
                    txt_NgayNhapHoc.Text = "";
                  

                    bt_Them.Text = "Thêm"; bt_Them.ForeColor = Color.Black;
                }
            }
        }




        private void paint_ListView(ListView lst_TTTK)
        {
            for (int i = 0; i < lst_TTTK.Items.Count; i++)
            {
                if (lst_TTTK.Items[i].Index % 2 == 0)
                {
                    lst_TTTK.Items[i].BackColor = Color.LightGreen;
                }
            }
        }
        private void clearGroupbox(GroupBox grp)
        {
            foreach (Control ctr in grp.Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox t = (TextBox)ctr;
                    t.Clear();
                }
                else if (ctr.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker t = (DateTimePicker)ctr;
                    t.Value = DateTime.Today;
                }
            }
        }
        private void clear(GroupBox grp)
        {
            foreach (Control ctr in grp.Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox t = (TextBox)ctr;
                    t.Clear();
                }
                else if (ctr.GetType() == typeof(MaskedTextBox))
                {
                    MaskedTextBox t = (MaskedTextBox)ctr;
                    t.Clear();
                }
                else if (ctr.GetType() == typeof(RadioButton))
                {
                    RadioButton t = (RadioButton)ctr;
                    t.Checked = false;
                }
            }
        }

        //Tab thong tin tre
        
        byte[] img;
        string imgLoc = "";

        private void bt_Them_Click(object sender, EventArgs e)
        {
         /*   ThemTre form = new ThemTre();
            form.vt = _vt;
            form.Show();
            Refresh();*/

        }

        private void bt_CapNhat_Click(object sender, EventArgs e)
        {

            DataRow dr = ds.Tables["HOCSINH"].Rows.Find(txt_Ma.Text);

            if (dr != null)
            {

                if (bt_CapNhat.Text == "Sửa")
                {
                    bt_Xoa.Enabled = false;
                    bt_Them.Enabled = true;
                    txt_HoTen.Enabled = false;
                    txt_HoTen.Text = dr[0].ToString();
                    txt_HoTen.Text = dr[1].ToString();
                    txt_NgayThangNam.Text = dr[2].ToString();
                    txt_GT.Text = dr[3].ToString();
                    txt_DiaChi.Text = dr[4].ToString();
                    txt_LopHienTai.Text = dr[5].ToString();
                    txt_NgayNhapHoc.Text = dr[6].ToString();

             


                    bt_CapNhat.Text = "Lưu";
                    bt_CapNhat.ForeColor = Color.Blue;
                }
                else if (bt_CapNhat.Text == "Lưu")
                {

                    if (txt_HoTen.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn chưa điền đầy đủ thông tin.");
                        return;
                    }

                    else
                    {
                        try
                        {
                            //string caulenh = "insert into KhoiHoc values('" + txt_MaKhoi.Text + "','" + txt_TenKhoi.Text + "')";
                            dr[1] = txt_HoTen.Text;
                            dr[2] = txt_NgayThangNam.Text;
                            dr[3] = txt_GT.Text;
                            dr[4] = txt_DiaChi.Text;
                            dr[5] = txt_LopHienTai.Text;
                            dr[6] = txt_NgayNhapHoc.Text;
                            save = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hãy điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        bt_CapNhat.Text = "Sửa"; bt_CapNhat.ForeColor = Color.Black;
                        txt_Ma.Text = string.Empty;
                        txt_HoTen.Text = string.Empty;
                        txt_NgayThangNam.Text = string.Empty;
                        txt_GT.Text = string.Empty;
                        txt_DiaChi.Text = string.Empty;
                        txt_LopHienTai.Text = string.Empty;
                        txt_NgayNhapHoc.Text = string.Empty;

                        bt_CapNhat.Enabled = false;
                        bt_Xoa.Enabled = false;
                        save = false;
                    }
                }
            }
        }

            private void bt_Xoa_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa trẻ này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                      MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                try
                {
                    string HOCSINH = Gridview1.CurrentRow.Cells[0].Value.ToString();

                    DataRow dr = ds.Tables["HOCSINH"].Rows.Find(HOCSINH);

                    if (dr != null)
                    {
                        dr.Delete();
                    }
                    txt_Ma.Enabled = false;
                    txt_Ma.Text = "";
                    txt_HoTen.Text = "";
                    txt_NgayThangNam.Text = "";
                    txt_GT.Text = "";
                    txt_DiaChi.Text = "";
                    txt_LopHienTai.Text = "";
                    txt_NgayNhapHoc.Text = "";

                    save = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể cập nhật vào cở sở dữ liệu. Hãy chắc chắc khối học bạn xóa không còn lớp nào tồn tại, hoặc đảm bảo đã điền đầy đủ thông tin khi thêm hoặc chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            }

        //Tab xep lop - len lop
        private void LopHoc()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT TENLOP FROM LOPHOC", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbb_LopHienTai.Items.Add(dr[0]);
                    cbb_LopMoi.Items.Add(dr[0]);
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
        }
        private string MaLop(ComboBox cbb)
        {
            string s = null;
            con.Open();
            cmd = new SqlCommand("SELECT MALOP FROM LOPHOC where TENLOP = N'" + cbb.Text + "'", con);
            //cmd.Parameters.AddWithValue("@TenLop", cbb_LopMoi.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s = dr["MALOP"].ToString();
            }
            con.Close();
            return s;
        }

        private void cbb_LopHienTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lst_LopHienTai.Items.Clear();
            grp_LopHienTai.Text = "Danh sách lớp " + cbb_LopHienTai.Text;
            grp_LopHienTai.ForeColor = Color.Blue;
            con.Open();
            cmd = new SqlCommand("SELECT MATRE, TENTRE, NGAYSINH, GIOITINH, NGAYNHAPHOC, HOCSINH.MALOP FROM HOCSINH, LOPHOC WHERE HOCSINH.MALOP = LOPHOC.MALOP AND TENLOP=N'" + cbb_LopHienTai.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                //DateTime ngsinh = DateTime.ParseExact(dr[2].ToString(), "dd/MM/yyyy", null);
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                lst_LopHienTai.Items.Add(item);
            }
            con.Close();
            paint_ListView(lst_LopHienTai);
        }

        private void cbb_LopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lst_LopMoi.Items.Clear();
            grp_LopMoi.Text = "Danh sách lớp " + cbb_LopMoi.Text;
            grp_LopMoi.ForeColor = Color.Blue;
            con.Open();
            cmd = new SqlCommand("SELECT MATRE, TENTRE, NGAYSINH, GIOITINH, NGAYNHAPHOC, HOCSINH.MALOP FROM HOCSINH, LOPHOC WHERE HOCSINH.MALOP = LOPHOC.MALOP AND TENLOP=N'" + cbb_LopMoi.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                //DateTime ngsinh = DateTime.ParseExact(dr[2].ToString(), "dd/MM/yyyy", null);
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(dr[5].ToString());
                lst_LopMoi.Items.Add(item);
            }
            con.Close();
            paint_ListView(lst_LopMoi);
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
           /* if (lst_LopMoi.Items.Count > 0)
            {
                try
                {
                    string malop1 = MaLop(cbb_LopHienTai);
                    string malop2 = MaLop(cbb_LopMoi);
                    con.Open();
                    foreach (ListViewItem item in lst_LopMoi.Items)
                    {
                        if (item.SubItems[5].Text == malop1)
                        {
                            cmd = new SqlCommand("UPDATE HOCSINH SET MALOP = '" + malop2 + "' WHERE MATRE='" + int.Parse(item.SubItems[0].Text) + "'", con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }

            if (lst_LopHienTai.Items.Count > 0)
            {
                try
                {
                    string malop1 = MaLop(cbb_LopHienTai);
                    string malop2 = MaLop(cbb_LopMoi);
                    con.Open();
                    foreach (ListViewItem item in lst_LopHienTai.Items)
                    {
                        if (item.SubItems[5].Text == malop2)
                        {
                            cmd = new SqlCommand("UPDATE HOCSINH SET MALOP = '" + malop1 + "' WHERE MATRE='" + int.Parse(item.SubItems[0].Text) + "'", con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            MessageBox.Show("Hoàn tất việc xếp lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
        }
        

        private void bt_Down_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_LopHienTai.SelectedItems)
            {
                lst_LopHienTai.Items.Remove(item);
                lst_LopMoi.Items.Add(item);
            }
            paint_ListView(lst_LopHienTai);
            paint_ListView(lst_LopMoi);
        }

        private void bt_Up_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_LopMoi.SelectedItems)
            {
                lst_LopMoi.Items.Remove(item);
                lst_LopHienTai.Items.Add(item);
            }
            paint_ListView(lst_LopHienTai);
            paint_ListView(lst_LopMoi);
        }

        private void bt_UpAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_LopMoi.SelectedItems)
            {
                lst_LopMoi.Items.Remove(item);
                lst_LopHienTai.Items.Add(item);
            }
            paint_ListView(lst_LopHienTai);
            paint_ListView(lst_LopMoi);
        }

        private void bt_DownAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_LopHienTai.Items)
            {
                lst_LopHienTai.Items.Remove(item);
                lst_LopMoi.Items.Add(item);
            }
            paint_ListView(lst_LopHienTai);
            paint_ListView(lst_LopMoi);
        }

        private void tab_ThongTinTre_TabIndexChanged(object sender, EventArgs e)
        {
            if (tab_ThongTinTre.SelectedIndex == 0)
            {
               /* CapNhat();*/
            }
            else
                LopHoc();
        }

        private void tab_ThongTinTre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_ThongTinTre.SelectedIndex == 0)
            {
               /* CapNhat();*/
            }
            else
            {
                lst_LopHienTai.Items.Clear();
                lst_LopMoi.Items.Clear();
                cbb_LopHienTai.Items.Clear();
                cbb_LopMoi.Items.Clear();
                LopHoc();
            }
        }

        private void lst_LopHienTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_LopHienTai.SelectedItems.Count > 0)
                bt_Down.Enabled = true;
            else
                bt_Down.Enabled = false;
        }

        private void lst_LopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_LopMoi.SelectedItems.Count > 0)
                bt_Up.Enabled = true;
            else
                bt_Up.Enabled = false;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.OrangeRed, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void ThongTinTre_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Blue, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  CapNhat();*/
            clear(grp_DSLH);
            clear(grp_TTHS);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }

        private void txt_SDTCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '-')*/)
            {
                e.Handled = true;
            }
        }

        private void txt_SDTMe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '-')*/)
            {
                e.Handled = true;
            }
        }


        //Tab học phi
        private void LoadDataInto_ComboBox_KhoiHoc()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM KHOIHOC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
         /*   cbb_KhoiHoc.DataSource = dt;
            cbb_KhoiHoc.DisplayMember = "TenKhoi";
            cbb_KhoiHoc.ValueMember = "MaKhoi";
            cbb_KhoiHoc.SelectedValue = -1;*/
        }

        private void LoadDataInto_ComboBox_LopHoc()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM LOPHOC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cbb_LopHoc.DataSource = dt;
            cbb_LopHoc.DisplayMember = "TENLOP";
            cbb_LopHoc.ValueMember = "MALOP";
            cbb_LopHoc.SelectedValue = -1;
        }

        private void LoadDataInto_ComboBox_Thang_Nam()
        {
            for (int i = 1; i < 13; i++)
                cbb_Thang.Items.Add(i.ToString());
            int currentyear = DateTime.Today.Year;
            for (int i = currentyear - 10; i <= currentyear + 10; i++)
                cbb_Nam.Items.Add(i.ToString());
        }
        private void LoadDataInto_DataGridView_HocPhi()
        {
            string s = "SELECT HOCSINH.MATRE, TENTRE, TENLOP, NGAYTHANGNAM, SOTIEN, TINHTRANG, NGAYTHU FROM HOCSINH, LOPHOC, HOCPHI WHERE HOCSINH.MATRE = HOCPHI.MATRE AND HOCSINH.MALOP = LOPHOC.MALOP AND LOPHOC.MALOP = '" + cbb_LopHoc.SelectedValue + "' AND NGAYTHANGNAM = '" + cbb_Thang.Text + "/" + cbb_Nam.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(s, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgV_HocPhi.DataSource = dt;
            if (dgV_HocPhi.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgV_HocPhi.Rows)
                {
                    if (row.Cells["col_TINHTRANG"].Value.ToString() == "Chưa đóng")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                foreach (DataGridViewRow row in dgV_HocPhi.Rows)
                {
                    if (row.Cells["col_TINHTRANG"].Value.ToString() != "Chưa đóng")
                    {
                        DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["col_CHECKHP"];
                        cell.Value = 1;
                    }
                }
            }
        }

        private void bt_HienThi_Click(object sender, EventArgs e)
        {
            if (cbb_LopHoc.Text == string.Empty || cbb_Thang.Text == string.Empty || cbb_Nam.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn đầy đủ thông tin");
            }
            else
            {
                string ThangNam = cbb_Thang.Text + "/" + cbb_Nam.Text;
                try
                {
                    bool k = false;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT NGAYTHANGNAM FROM HOCPHI WHERE NGAYTHANGNAM = '" + ThangNam + "'", con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        k = true;
                    }
                    DataTable dt = new DataTable();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    if (k == false)
                    {
                        if (MessageBox.Show("Danh sách học phí tháng " + ThangNam + " chưa được khởi tạo. Bạn có muốn khởi tạo ngay?", "Thông báo"
                            , MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            SqlDataAdapter sda = new SqlDataAdapter("SELECT MATRE FROM HOCSINH", con);
                            sda.Fill(dt);

                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            SqlCommand cmd1;
                            foreach (DataRow row in dt.Rows)
                            {
                                cmd1 = new SqlCommand("INSERT INTO HOCPHI(MATRE, NGAYTHANGNAM, TINHTRANG) VALUES('" + int.Parse(row["MATRE"].ToString()) + "', '" + ThangNam + "', N'Chưa đóng')", con);
                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("Khởi tạo danh sách học phí thành công.");
                                k = true;
                            }
                            if (con.State == ConnectionState.Open)
                                con.Close();
                        }
                    }
                    else if (k == true)
                    {
                        LoadDataInto_DataGridView_HocPhi();
                        if (dgV_HocPhi.Rows.Count > 0)
                        {
                            txt_SoTien.Enabled = true;
                            bt_SetHP.Enabled = true;
                            ck_CapNhat.Enabled = true;
                        }
                        //dgV_HocPhi.Columns["HocPhi"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bt_SetHP_Click(object sender, EventArgs e)
        {
            if (dgV_HocPhi.Rows.Count > 0)
            {
                int row = dgV_HocPhi.Rows.Count;
                decimal hocphi = decimal.Parse(txt_SoTien.Text);
                for (int i = 0; i < row; i++)
                    dgV_HocPhi[5, i].Value = hocphi;
            }
        }

        private void setDataGridView_EditTable(bool k)
        {
            dgV_HocPhi.ReadOnly = !k;
            dgV_HocPhi.Columns["col_CHECKHP"].Visible = k;
            dgV_HocPhi.Columns["col_TINHTRANG"].Visible = !k;

        }

        private void ck_CapNhat_CheckedChanged(object sender, EventArgs e)
        {
            setDataGridView_EditTable(ck_CapNhat.Checked);
        }

        private void dgV_HocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgV_HocPhi.Columns[e.ColumnIndex].Name == "col_CHECKHP" && dgV_HocPhi.CurrentCell is DataGridViewCheckBoxCell)
            {
                bool isChecked = (bool)dgV_HocPhi[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
                if (isChecked == true)
                {
                    dgV_HocPhi.Rows[e.RowIndex].Cells["col_TINHTRANG"].Value = "Đã thu";
                    dgV_HocPhi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    foreach (DataGridViewColumn col in dgV_HocPhi.Columns)
                    {
                        if (col.Name != "col_CHECKHP")
                            col.ReadOnly = true;
                    }
                    dgV_HocPhi.Rows[e.RowIndex].Cells["col_TINHTRANG"].Value = "Chưa đóng";
                    dgV_HocPhi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    //dtp.Visible = false;
                    dgV_HocPhi.Rows[e.RowIndex].Cells["col_NGAYTHU"].Value = string.Empty;

                }
                dgV_HocPhi.EndEdit();
            }
        }

        private void dgV_HocPhi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgV_HocPhi.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgV_HocPhi_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgV_HocPhi.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgV_HocPhi.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        DateTimePicker dtp;

        private void dgV_HocPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                dtp = new DateTimePicker();
                if (dgV_HocPhi.CurrentRow.Cells["col_TINHTRANG"].Value.ToString() != "Chưa đóng")
                {

                    dgV_HocPhi.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgV_HocPhi.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);
                    dtp.Visible = true;
                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                    dtp.DropDown += new EventHandler(dtp_DropDown);
                    dtp.ValueChanged += new EventHandler(dtp_ValueChanged);

                }
                else
                {
                    dgV_HocPhi.CurrentRow.Cells["col_NGAYTHU"].Value = "";
                    dtp.Visible = false;
                }
            }
        }



        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            var timepicker = sender as DateTimePicker;
            timepicker.Value = new DateTime(timepicker.Value.Year, timepicker.Value.Month, timepicker.Value.Day);
        }
        int oldday;

        private void dtp_DropDown(object sender, EventArgs e)
        {
            oldday = ((DateTimePicker)(sender)).Value.Day;
        }
        // private void dtp_DropDown(object sender )

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            //dgV_HocPhi.CurrentCell.Value = dtp.Text.ToString();
            dtp.Visible = false;
        }

        private void dtp_CloseUp(object sender, EventArgs e)
        {
          /*  dtp.Value.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);*/
            dtp.Value.GetDateTimeFormats();
            dgV_HocPhi.CurrentCell.Value = dtp.Value.Date;

        }

        private void bt_Update_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_Update_Click_1(object sender, EventArgs e)
        {
            string NgayThu = cbb_Thang.Text + "/" + cbb_Nam.Text;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;
                foreach (DataGridViewRow row in dgV_HocPhi.Rows)
                {
                    cmd = new SqlCommand("UPDATE HOCPHI SET SOTIEN = '" + decimal.Parse(row.Cells["col_HOCPHI"].Value.ToString()) + "', TINHTRANG = N'" + row.Cells["col_TINHTRANG"].Value + "', NGAYTHU = '" + row.Cells["col_NGAYTHU"].Value.ToString() + "' WHERE MATRE = '" + int.Parse(row.Cells["col_MATRE"].Value.ToString()) + "' AND THANGNAM = '" + NgayThu + "'", con);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cập nhật thành công vào cơ sở dữ liệu.");
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            open.Title = "Chọn ảnh đại diện";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imgLoc = open.FileName.ToString();
                imgBox.ImageLocation = imgLoc;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Report_HocPhi frm = new Report_HocPhi();
            frm.Show();
        }



        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void grp_TTHS_Enter(object sender, EventArgs e)
        {

        }



        /*   private void TreeView_DSLH_AfterSelect_1(object sender, TreeViewEventArgs e)
           {
               bool kt = true;
               string indexLop = null;
               int indexTre = -1;
               for (int i = 0; i < TreeView_DSLH.Nodes.Count && kt; i++)
               {
                   for (int j = 0; j < TreeView_DSLH.Nodes[i].Nodes.Count && kt; j++)
                   {
                       for (int k = 0; k < TreeView_DSLH.Nodes[i].Nodes[j].Nodes.Count && kt; k++)
                       {
                           if (TreeView_DSLH.Nodes[i].Nodes[j].Nodes[k].Text == e.Node.Text)
                           {
                               indexLop = TreeView_DSLH.Nodes[i].Nodes[j].Text;
                               indexTre = e.Node.Index;
                               kt = false;
                               break;
                           }
                       }
                   }
               }
               if (indexLop != null)
               {
                   con.Open();
                   cmd = new SqlCommand("SELECT * FROM HOCSINH, LOPHOC WHERE HOCSINH.MALOP=LOPHOC.MALOP AND TENLOP = @TENLOP", con);
                   cmd.Parameters.AddWithValue("@TENLOP", indexLop);
                   //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM HocSinh, LopHoc WHERE HocSinh.MaLop=LopHoc.MaLop AND TenLop='" + indexLop + "'", con);
                   SqlDataReader dr = cmd.ExecuteReader();
                   DataTable tb = new DataTable();
                   //sda.Fill(tb);
                   tb.Load(dr);
                   txt_HoTen.Text = tb.Rows[indexTre]["TENTRE"].ToString();
                   txt_Ma.Text = tb.Rows[indexTre]["MATRE"].ToString();
                   txt_NgayThangNam.Value = DateTime.ParseExact(tb.Rows[indexTre]["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                   txt_NgayNhapHoc.Text = tb.Rows[indexTre]["NGAYNHAPHOC"].ToString();
                   txt_DiaChi.Text = tb.Rows[indexTre]["DIACHI"].ToString();
                   txt_LopHienTai.Text = tb.Rows[indexTre]["TENLOP"].ToString();
                   txt_MaLop.Text = tb.Rows[indexTre]["MALOP"].ToString();
                   if (tb.Rows[indexTre]["GIOITINH"].ToString().Contains("Nam"))
                   {
                       rdb_Nam.Checked = true;
                       rdb_Nu.Checked = false;
                   }
                   else
                   {
                       rdb_Nu.Checked = true;
                       rdb_Nam.Checked = false;
                   }

                   img = (byte[])(tb.Rows[indexTre]["HINH"]);
                   if (img == null)
                   {
                       imgBox = null;
                   }
                   else
                   {
                       MemoryStream ms = new MemoryStream(img);
                       imgBox.Image = Image.FromStream(ms);
                   }

                   con.Close();
                   SqlCommand cmd1 = new SqlCommand("SELECT * FROM PHUHUYNH WHERE MATRE = '" + int.Parse(txt_Ma.Text) + "'", con);
                   con.Open();
                   SqlDataReader dre = cmd1.ExecuteReader();
                   if (dre.Read())
                   {
                       txt_HoTenCha.Text = dre["HOTENCHA"].ToString();
                       txt_NgheNghiepCha.Text = dre["NGHENGHIEPCHA"].ToString();
                       txt_SDTCha.Text = dre["SDTCHA"].ToString();
                       txt_HoTenMe.Text = dre["HOTENME"].ToString();
                       txt_NgheNghiepMe.Text = dre["NGHENGHIEPME"].ToString();
                       txt_SDTMe.Text = dre["SDTME"].ToString();
                   }
                   con.Close();
                   bt_Xoa.Enabled = true;
                   bt_CapNhat.Enabled = true;
               }
           }*/
    }
}
