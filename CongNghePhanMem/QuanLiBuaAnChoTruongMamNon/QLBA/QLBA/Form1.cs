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
    public partial class Form1 : Form
    {
        public object ConfigurationManager { get; private set; }

        // Tạo 2 biến cục bộ
        string strCon = @"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBA;Integrated Security=True";
        // ĐỐi tượng kết nối
        SqlConnection sqlCon = null;
        private object reportViewer1;

        public Form1()
        {
            this.BackgroundImage = Properties.Resources.a640dedb1cfe686afc38e52e74bfa4bf__children_reading_books_girl_reading;
            InitializeComponent();
        }



        //   private void btnMoKetNoi_Click(object sender, EventArgs e)
        //  {

        //   try
        //  {
        //        if (sqlCon == null) {
        //            sqlCon = new SqlConnection(strCon); // Rổng thì tạo mới 
        //       }
        // Mở kết nối
        //      if (sqlCon.State == ConnectionState.Closed)
        //       {
        // Đóng thì mở
        //           sqlCon.Open();
        //           MessageBox.Show("Kết nối thành công");
        //        }
        //     }
        //      catch(Exception ex)
        //      {
        //          MessageBox.Show(ex.Message);
        //       }
        //   }

        //private void btnDongketnoi_Click(object sender, EventArgs e)
        // {
        //       if (sqlCon != null && sqlCon.State == ConnectionState.Open)
        //   {
        // Đóng thì mở
        //       sqlCon.Close();
        //       MessageBox.Show("Đóng kết nối thành công");
        //      }
        //      else
        //     {
        //        MessageBox.Show("Chưa tạo kết nối!");
        //    }
        // }





        private void kHỐIToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tHỰCĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

     
        private void xếpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            KhoiLop xepLop = new KhoiLop();

            xepLop.ShowDialog();
        }
      
      

       

     
     
        private void tHỰCĐƠNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLiBuaAn quanLiBuaAn = new QuanLiBuaAn();
            quanLiBuaAn.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            dangnhap.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoan dangnhap = new TaiKhoan();
            dangnhap.ShowDialog();
        }

        class Functions
        {
            public static SqlConnection Con;  //Khai báo đối tượng kết nối        

            public static void Connect()
            {
                Con = new SqlConnection();   //Khởi tạo đối tượng
                Con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + @"\Quanlybanhang.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                Con.Open();                  //Mở kết nối
                                             //Kiểm tra kết nối
                if (Con.State == ConnectionState.Open)
                    MessageBox.Show("Kết nối thành công");
                else MessageBox.Show("Không thể kết nối với dữ liệu");

            }
            public static void Disconnect()
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();    //Đóng kết nối
                    Con.Dispose();  //Giải phóng tài nguyên
                    Con = null;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

   
    

     

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PhanCong phanCong = new PhanCong();
            phanCong.ShowDialog();
        }

        private void thôngTinTrẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTre thongtintre = new ThongTinTre();
            thongtintre.ShowDialog();
        }

        private void kHỐIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinGiáoViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ThemGiaoVien_News_ themgiaovien = new ThemGiaoVien_News_();
            themgiaovien.ShowDialog();
        }

        private void thôngTinPhụHuynhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinPhuHuynh thongTinPhuHuynh = new ThongTinPhuHuynh();
            thongTinPhuHuynh.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
