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
    public partial class PhanCong : Form
    {
        public PhanCong()
        {
            InitializeComponent();
            dGV_PhanCong.ColumnAdded += dGV_PhanCong_ColumnAdded;
        }

        private bool _vt;
        bool save = true;
        public bool vt
        {
            get { return _vt; }
            set { _vt = value; }
        }
        SqlConnection con = new SqlConnection(@"Data Source=Oscar\SQLEXPRESS;Initial Catalog=QLCBAMN1905;Integrated Security=True");
        DataTable dt_combobox = new DataTable();
        DataTable dt = new DataTable();

        private void disable_cell(bool f)
        {
            dGV_PhanCong.Columns[0].ReadOnly = f;
            dGV_PhanCong.Columns[1].ReadOnly = f;
            dGV_PhanCong.Columns[2].ReadOnly = f;
        }

        private void PhanCong_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT MAGV, TENGV, GIAOVIEN.MALOP FROM GIAOVIEN, LOPHOC GROUP BY MAGV, TENGV, GIAOVIEN.MALOP", con);
            //DataTable dt = new DataTable();
            sda.Fill(dt);
            dGV_PhanCong.DataSource = dt;

            //DataTable dt_combobox = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter("SELECT * FROM LOPHOC", con);
            sd.Fill(dt_combobox);
            DataGridViewComboBoxColumn col_combobox = (DataGridViewComboBoxColumn)dGV_PhanCong.Columns["col_TenLop"];
            col_combobox.Items.Add(string.Empty);
            col_combobox.DataSource = dt_combobox;
            col_combobox.ValueMember = "MALOP";
            col_combobox.DisplayMember = "TENLOP";

            cbb_KhoiHoc.Items.Add("Tất cả");
            foreach (DataRow row in dt_combobox.Rows)
            {
                cbb_KhoiHoc.Items.Add(row[1].ToString());
            }

            //disable_cell(true);
            dGV_PhanCong.CellEndEdit += new DataGridViewCellEventHandler(dGV_PhanCong_CellEndEdit);
            dGV_PhanCong.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dGV_PhanCong_EditingControlShowing);
        }

        private void dGV_PhanCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (cb != null)
                cb.SelectedIndexChanged -= new EventHandler(cbb_KhoiHoc_SelectedIndexChanged);
        }
        DataGridViewCell cell;

        ComboBox cb = new ComboBox();
        private void dGV_PhanCong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            cell = this.dGV_PhanCong.CurrentCell;
            cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.SelectedIndexChanged -= new EventHandler(cbb_KhoiHoc_SelectedIndexChanged);
                cb.SelectedIndexChanged += new EventHandler(cbb_KhoiHoc_SelectedIndexChanged);
            }
        }

        private void cbb_KhoiHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb != null)
           {
                DataRowView drv = cb.SelectedItem as DataRowView;
                if (drv != null)
                {
                    disable_cell(false);
                    this.dGV_PhanCong[2, cell.RowIndex].Value = MALOP(cbb_KhoiHoc);
                    disable_cell(true);
                    save = false;
               }
            }
        }

        private string MALOP(ComboBox cbb)
        {
            string s = null;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MALOP FROM LOPHOC where TENLOP = N'" + cbb.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s = dr["MALOP"].ToString();
            }
            con.Close();
            return s;
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;
                foreach (DataGridViewRow row in dGV_PhanCong.Rows)
                {
                    //DataRow row = drv.Row;
                    cmd = new SqlCommand("UPDATE GIAOVIEN SET MALOP ='" + row.Cells[2].Value.ToString() + "' WHERE MAGV = '" + row.Cells[0].Value.ToString() + "'", con);
                    //cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void bt_HienThi_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda;
            DataTable table = new DataTable();
            if (cbb_KhoiHoc.Text == "Tất cả")
                sda = new SqlDataAdapter("SELECT MAGV, TENGV, GIAOVIEN.MALOP FROM GIAOVIEN, LOPHOC GROUP BY MAGV, TENGV, GIAOVIEN.MALOP", con);
            else
                sda = new SqlDataAdapter("SELECT MAGV, TENGV, GIAOVIEN.MALOP FROM GIAOVIEN, LOPHOC WHERE GIAOVIEN.MALOP = '" + MALOP(cbb_KhoiHoc) + "' GROUP BY MAGV, TENGV, GIAOVIEN.MALOP", con);
            sda.Fill(table);
            dGV_PhanCong.DataSource = table;
        }

        private void PhanCong_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush, rect);
            brush.Dispose();
        }


        //FIX LỖI DATAGRIDVIEW
        private void dGV_PhanCong_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
          /*  if (e.Column.CellType == typeof(DataGridViewImageCell))
                dGV_PhanCong.Columns.Remove(e.Column);*/
        }

        private void dGV_PhanCong_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
          /*  for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                foreach (DataGridViewCell cell in dGV_PhanCong.Rows[i].Cells)
                {
                    if (cell.GetType() == typeof(DataGridViewImageCell))
                    {
                        cell.Value = DBNull.Value;
                    }
                }
            }*/
        }

        private void dGV_PhanCong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
