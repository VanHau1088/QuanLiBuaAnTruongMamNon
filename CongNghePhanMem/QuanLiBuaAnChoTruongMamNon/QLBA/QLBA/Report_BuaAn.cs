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
    public partial class Report_BuaAn : Form
    {
        public Report_BuaAn()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBAMN1905;Integrated Security=True");
        DataSet ds = new DataSet();
        bool save = true;
        bool save1 = true;

        private void Report_BuaAn_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
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



      

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "thông báo");
            if(dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
