using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBA
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }


        bool _vt = true;



        private void timer5_Tick(object sender, EventArgs e)
        {
            if (panel5.Width < 385)
            {
                panel5.Width += 10;
                if (panel5.Width >= 385)
                    timer5.Stop();
            }
        }

        private void mS_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_DangNhap frm = new frm_DangNhap();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "DangNhap")
                    Application.OpenForms[i].Close();
            }
            timer6.Start();
            txt_TaiKhoan.Text = string.Empty;
            txt_MatKhau.Text = string.Empty;
            txt_TaiKhoan.Focus();
            lbl_ThongBao.Text = "";
            mS.Visible = false;
        }

        private void đốiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer11.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Width < 385)
            {
                panel1.Width += 10;
                if (panel1.Width == 50)
                    timer2.Start();
                if (panel1.Width >= 385)
                    timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Width < 385)
            {
                panel2.Width += 10;
                if (panel2.Width == 50)
                    timer3.Start();
                if (panel2.Width >= 385)
                    timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (panel3.Width < 385)
            {
                panel3.Width += 10;
                if (panel3.Width == 50)
                    timer4.Start();
                if (panel3.Width >= 385)
                    timer3.Stop();
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (panel4.Width < 385)
            {
                panel4.Width += 10;
                if (panel4.Width == 50)
                    timer5.Start();
                if (panel4.Width >= 385)
                    timer4.Stop();
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (panel1.Width > 0)
            {
                panel1.Width -= 10;
                if (panel1.Width <= 335)
                    timer7.Start();
                if (panel1.Width <= 0)
                    timer6.Stop();
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (panel2.Width > 0)
            {
                panel2.Width -= 10;
                if (panel2.Width <= 335)
                    timer8.Start();
                if (panel2.Width <= 0)
                    timer7.Stop();
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (panel3.Width > 0)
            {
                panel3.Width -= 10;
                if (panel3.Width <= 335)
                    timer9.Start();
                if (panel3.Width <= 0)
                    timer8.Stop();
            }

        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (panel4.Width > 0)
            {
                panel4.Width -= 10;
                if (panel4.Width <= 335)
                    timer10.Start();
                if (panel4.Width <= 0)
                    timer9.Stop();
            }

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            if (panel5.Width > 0)
            {
                panel5.Width -= 10;
                if (panel5.Width <= 0)
                    timer10.Stop();
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            if (panel6.Width < 385)
            {
                panel6.Width += 10;
                if (panel6.Width >= 385)
                    timer11.Stop();
            }
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            if (panel6.Width > 0)
            {
                panel6.Width -= 10;
                if (panel6.Width <= 0)
                    timer12.Stop();
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            lbl_ThongBao.BackColor = System.Drawing.Color.Transparent;
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBA;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM TAIKHOAN WHERE TAIKHOAN='" + txt_TaiKhoan.Text + "' AND ,MATKHAU='" + txt_MatKhau.Text + "'", con);
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    mS.Visible = true;
                    if (panel1.Width == 0)
                        timer1.Start();
                    if (sdr["VAITRO"].ToString() == "CLIENT")
                        _vt = false;
                    else
                        _vt = true;
                }
                else
                    lbl_ThongBao.Text = "Tài khoản hoặc mật khẩu không chính xác.";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối tới cơ sở dữ liệu thất bại. Vui lòng thủ lại sau.");
                Application.Exit();
            }

        }
    }
}
