using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSV
{
    public partial class QLMonHoc : Form
    {
        public QLMonHoc()
        {
            InitializeComponent();
        }

        void Hienthi()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from MonHoc", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public string Masinhmh()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from MonHoc";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "MH001";
            }
            else
            {
                int k;
                ma = "MH";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
        private void getcn()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ChuyenNganh", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "cn");
            cbbcn.DataSource = lop.Tables["cn"];
            cbbcn.DisplayMember = "Tenchuyennganh";
            cbbcn.ValueMember = "Machuyennganh";
        }
            private void btThemMH_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into MonHoc values(@MaMH,@TenMH,@SoTC,@Hocky,@Machuyennganh)", con);
            cmd.Parameters.AddWithValue("MaMH", txtMaMonHocThemMoi.Text);
            if (txtTenMH.Text != "")
            {
                cmd.Parameters.AddWithValue("TenMH", txtTenMH.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên môn học");
                return;
            }
            cmd.Parameters.AddWithValue("SoTC", numericUpSoTC.Value);
            cmd.Parameters.AddWithValue("Hocky", numericUpDownHocKyThu.Value);
            cmd.Parameters.AddWithValue("Machuyennganh", cbbcn.SelectedValue);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thành công");
            Hienthi();
            con.Close();
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            Hienthi();
            txtMaMonHocThemMoi.Text = Masinhmh();
            txtMaMonHocThemMoi.Enabled = false;
            getcn();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("update  MonHoc set TenMH=@TenMH,SoTC=@SoTC,Hocky=@Hocky, Machuyennganh=@Machuyennganh where MaMH=@MaMH", con);
            cmd.Parameters.AddWithValue("MaMH", txtMaMonHocThemMoi.Text);
            if (txtTenMH.Text != "")
            {
                cmd.Parameters.AddWithValue("TenMH", txtTenMH.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên môn học");
                return;
            }
            cmd.Parameters.AddWithValue("SoTC", numericUpSoTC.Value);
            cmd.Parameters.AddWithValue("Hocky", numericUpDownHocKyThu.Value);
            cmd.Parameters.AddWithValue("Machuyennganh", cbbcn.SelectedValue);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            Hienthi();
            con.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from MonHoc where MaMH=@MaMH", con);
            cmd.Parameters.AddWithValue("MaMH", txtMaMonHocThemMoi.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoá thành công");
            Hienthi();
            con.Close();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            QLMonHoc_Load(sender, e);
            Hienthi();
            txtMaMonHocThemMoi.Text = Masinhmh();
            txtTenMH.ResetText();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMaMonHocThemMoi.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenMH.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            numericUpSoTC.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            numericUpDownHocKyThu.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select MonHoc.*,ChuyenNganh.* from MonHoc,ChuyenNganh where ChuyenNganh.Machuyennganh=MonHoc.Machuyennganh and MaMH='" + txtMaMonHocThemMoi.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            cbbcn.DisplayMember = "Tenchuyennganh";
            cbbcn.ValueMember = "Machuyennganh";
            cbbcn.DataSource = dt;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain form2 = new FrmMain();
            form2.Show();
            this.Hide();a
        }
    }
}
