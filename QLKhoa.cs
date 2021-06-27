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
    public partial class QLKhoa : Form
    {
        public QLKhoa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain form1 = new FrmMain();
            form1.Show();
            this.Hide();
        }
        void Hienthi()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Khoa", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dgvkhoa.DataSource = ds.Tables[0];
            con.Close();
        }
        void Hienthi2()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from ChuyenNganh", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"cn");
            dgvcn.DataSource = ds.Tables["cn"];
            con.Close();
        }
        private void QLKhoa_Load(object sender, EventArgs e)
        {
            Hienthi();
            Hienthi2();
            txtmakhoa.Text = Masinhkhoa();
            txtmakhoa.Enabled = false;
            txtmacn.Text = Masinhchuyennganh();
            txtmacn.Enabled = false;
            getkhoa();
        }
        public string Masinhkhoa()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from Khoa";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "Kh001";
            }
            else
            {
                int k;
                ma = "Kh";
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Khoa values(@Makhoa,@Tenkhoa,@Sotien1TC)", con);
                cmd.Parameters.AddWithValue("Makhoa", txtmakhoa.Text);
                if (txttenkhoa.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenkhoa", txttenkhoa.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa");
                    return;
                }
                if (txtsotien.Text != "")
                {
                    cmd.Parameters.AddWithValue("Sotien1TC", txtsotien.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập số tiền cho 1 tín chỉ");
                    return;
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                Hienthi();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmakhoa.Text = Masinhkhoa();
            txtmakhoa.Enabled = false;
            Hienthi();
            txttenkhoa.ResetText();
            txttencn.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Khoa set Tenkhoa=@Tenkhoa,Sotien1TC=@Sotien1TC where Makhoa=@Makhoa", con);
                cmd.Parameters.AddWithValue("Makhoa", txtmakhoa.Text);
                if (txttenkhoa.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenkhoa", txttenkhoa.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa");
                    return;
                }
                if (txtsotien.Text != "")
                {
                    cmd.Parameters.AddWithValue("Sotien1TC", txtsotien.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập số tiền cho 1 tín chỉ");
                    return;
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                Hienthi();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void dgvkhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvkhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtmakhoa.Text = dgvkhoa.Rows[numrow].Cells[0].Value.ToString();
            txttenkhoa.Text = dgvkhoa.Rows[numrow].Cells[1].Value.ToString();
            txtsotien.Text = dgvkhoa.Rows[numrow].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Khoa where Makhoa=@Makhoa", con);
            cmd.Parameters.AddWithValue("Makhoa", txtmakhoa.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoá thành công");
            Hienthi();
            con.Close();
        }
        private void getkhoa()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Khoa", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbbmakhoa.DataSource = lop.Tables["khoa"];
            cbbmakhoa.DisplayMember = "Tenkhoa";
            cbbmakhoa.ValueMember = "Makhoa";
            con.Close();
        }
        public string Masinhchuyennganh()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from ChuyenNganh";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma1 = "";
            if (dt.Rows.Count <= 0)
            {
                ma1 = "CN001";
            }
            else
            {
                int k;
                ma1 = "CN";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    ma1 = ma1 + "00";
                }
                else if (k < 100)
                {
                    ma1 = ma1 + "0";
                }
                ma1 = ma1 + k.ToString();
            }
            return ma1;
        }

        private void btnthemcn_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ChuyenNganh values(@Machuyennganh,@Tenchuyennganh,@Makhoa)", con);
                cmd.Parameters.AddWithValue("Machuyennganh", txtmacn.Text);
                if (txttencn.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenchuyennganh", txttencn.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên chuyên ngành");
                    return;
                }
                cmd.Parameters.AddWithValue("Makhoa", cbbmakhoa.SelectedValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                Hienthi2();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void btnsuacn_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Khoa set @Machuyennganh=Machuyennganh,@Tenchuyennganh=Tenchuyennganh where Makhoa=@Makhoa", con);
                if (txttencn.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenchuyennganh", txttencn.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên chuyên ngành");
                    return;
                }
                cmd.Parameters.AddWithValue("Tenchuyennganh", txttencn.Text);
                cmd.Parameters.AddWithValue("Makhoa", txtmakhoa.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                Hienthi2();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi gì đó");
            }
        }

        private void btnxoacn_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Khoa set @Machuyennganh=Machuyennganh,@Tenchuyennganh=Tenchuyennganh where Makhoa=@Makhoa", con);
            cmd.Parameters.AddWithValue("Machuyennganh", txtmacn.Text);
            cmd.Parameters.AddWithValue("Tenchuyennganh", txttencn.Text);
            cmd.Parameters.AddWithValue("Makhoa", txtmakhoa.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            Hienthi2();
            con.Close();
        }

        private void btnlammoicn_Click(object sender, EventArgs e)
        {
            txtmacn.Text = Masinhchuyennganh();
            txtmacn.Enabled = false;
            Hienthi2();
            txttencn.ResetText();
            txtmakhoa.ResetText();
        }

        private void dgvcn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            cbbmakhoa.Text = dgvcn.Rows[n].Cells["Makhoa"].Value.ToString();
            txttencn.Text = dgvcn.Rows[n].Cells["Tenchuyennganh"].Value.ToString();
            txtmacn.Text = dgvcn.Rows[n].Cells["Machuyennganh"].Value.ToString();
        }
    }
}
