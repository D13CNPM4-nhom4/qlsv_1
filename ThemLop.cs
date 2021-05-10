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
    public partial class ThemLop : Form
    {
        public ThemLop()
        {
            InitializeComponent();
        }

        private void ThemLop_Load(object sender, EventArgs e)
        {
            Hienthi();
            txtmalop.Text = Masinh();
            Hienthi2();
            txtmalop.Enabled = false;
            txtmakhoa.Enabled = false;
            txtmakhoa.Text = Masinhkhoahoc();
            getkhoa();
            getcn();
            Refresh();
        }
        void Hienthi()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Lopp", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"lop");
            dgvlop.DataSource = ds.Tables["lop"];
            con.Close();
        }
        void Hienthi2()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from KhoaHocc", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"khoa");
            dgvkhoa.DataSource = ds.Tables["khoa"];
            con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string Masinh()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from Lopp";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "Lop001";
            }
            else
            {
                int k;
                ma = "Lop";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(4));
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
        public string Masinhkhoahoc()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from KhoaHocc";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma1 = "";
            if (dt.Rows.Count <= 0)
            {
                ma1 = "Khoa001";
            }
            else
            {
                int k;
                ma1 = "Khoa";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(5));
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
        private void btnnhap_Click(object sender, EventArgs e)
        {
 
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
   
        }

        private void btnquay_Click(object sender, EventArgs e)
        {
           
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
         
        }

        private void btnthemlop_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Lopp values(@Malop,@Tenlop,@Machuyennganh, @Makhoahoc)", con);
                cmd.Parameters.AddWithValue("Malop", txtmalop.Text);
                if (txttenlop.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenlop", txttenlop.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên lớp");
                    return;
                }    
                cmd.Parameters.AddWithValue("Machuyennganh", cbbmacn.SelectedValue);
                cmd.Parameters.AddWithValue("Makhoahoc", cbbkhoahoc.SelectedValue);
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

        private void btnthemkhoa_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into KhoaHocc values(@Makhoahoc,@Tenkhoahoc,@Trangthai)", con);
                cmd.Parameters.AddWithValue("Makhoahoc", txtmakhoa.Text);
                if (txttenkhoa.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenkhoahoc", txttenlop.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa học");
                    return;
                }
                if (txttinhtrang.Text != "")
                {
                    cmd.Parameters.AddWithValue("Trangthai", txttinhtrang.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập trạng thái");
                    return;
                }
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

        private void btnsualop_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Lop set Tenlop=@Tenlop, Machuyennganh=@Machuyennganh, Khoahoc=@Khoahoc where Malop=@Malop", con);
                cmd.Parameters.AddWithValue("Malop", txtmalop.Text);
                if (txttenlop.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenlop", txttenlop.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên lớp");
                    return;
                }
                cmd.Parameters.AddWithValue("Machuyennganh", cbbmacn.SelectedValue);
                cmd.Parameters.AddWithValue("Khoahoc", cbbkhoahoc.SelectedValue);
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

        private void btnxoalop_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Lop where Malop=@Malop", con);
                cmd.Parameters.AddWithValue("Malop", txtmalop.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công");
                Hienthi();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void btnsuakhoa_Click(object sender, EventArgs e)
        {
            try
            {

                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("update KhoaHocc set Tenkhoahoc=@Tenkhoahoc,Trangthai=@Trangthai where Makhoahoc=@Makhoahoc", con);
                cmd.Parameters.AddWithValue("Makhoahoc", txtmakhoa.Text);
                if (txttenkhoa.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tenkhoahoc", txttenlop.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa học");
                    return;
                }
                if (txttinhtrang.Text != "")
                {
                    cmd.Parameters.AddWithValue("Trangthai", txttinhtrang.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập trạng thái");
                    return;
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                Hienthi2();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void btnxoakhoa_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from KhoaHocc where Makhoahoc=@Makhoahoc", con);
            cmd.Parameters.AddWithValue("Makhoahoc", txtmakhoa.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoá thành công");
            Hienthi2();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain form1 = new FrmMain();
            form1.Show();
            this.Hide();
        }
        private void getkhoa()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from KhoaHocc", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet khoa = new DataSet();
            add.Fill(khoa, "khoa");
            cbbkhoahoc.DataSource = khoa.Tables["khoa"];
            cbbkhoahoc.DisplayMember = "Tenkhoahoc";
            cbbkhoahoc.ValueMember = "Makhoahoc";
            con.Close();
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
            cbbmacn.DataSource = lop.Tables["cn"];
            cbbmacn.DisplayMember = "Tenchuyennganh";
            cbbmacn.ValueMember = "Machuyennganh";
            con.Close();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ThemLop_Load(sender,e);
            txtmalop.Text = Masinh();
            txtmalop.Enabled = false;
            Hienthi();
            txttenlop.ResetText();

        }

        private void btnlammoikhoa_Click(object sender, EventArgs e)
        {
            txtmakhoa.Text = Masinhkhoahoc();
            txtmakhoa.Enabled = false;
            Hienthi2();
            txttinhtrang.ResetText();
            
        }
    }
}
