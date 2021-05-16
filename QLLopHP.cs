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
    public partial class QLLopHP : Form
    {
        public QLLopHP()
        {
            InitializeComponent();
        }

        private void QLLopHP_Load(object sender, EventArgs e)
        {
            Hienthi();
            txtMaLopHP.Text = Masinhlhp();
            txtMaLopHP.Enabled = false;
            getkhoa();
            getgv();
            getcn();
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
            cbboxKhoa.DataSource = lop.Tables["khoa"];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";
            con.Close();
        }
        private void getgv()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from GiangVien", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbboxGiangVien.DataSource = lop.Tables["khoa"];
            cbboxGiangVien.DisplayMember = "Hoten";
            cbboxGiangVien.ValueMember = "MaGV";
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
            add.Fill(lop, "khoa");
            cbboxCN.DataSource = lop.Tables["khoa"];
            cbboxCN.DisplayMember = "Tenchuyennganh";
            cbboxCN.ValueMember = "Machuyennganh";
            con.Close();
        }
        private void getmonhoc()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from MonHoc", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbboxKhoa.DataSource = lop.Tables["khoa"];
            cbboxKhoa.DisplayMember = "TenMH";
            cbboxKhoa.ValueMember = "MaMH";
            con.Close();
        }
        public string Masinhlhp()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from LopHocPhan";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma1 = "";
            if (dt.Rows.Count <= 0)
            {
                ma1 = "LHP001";
            }
            else
            {
                int k;
                ma1 = "LHP";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(4));
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
        void Hienthi()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LopHocPhan", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        
        }

        private void cbboxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Khoa.*,GiangVien.*,ChuyenNganh.* from Khoa,GiangVien,ChuyenNganh where Khoa.Makhoa=GiangVien.Makhoa and ChuyenNganh.Makhoa=Khoa.Makhoa and Khoa.Makhoa='"+cbboxKhoa.SelectedValue+"'", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbboxGiangVien.DataSource = lop.Tables["lop"];
            cbboxGiangVien.DisplayMember = "Hoten";
            cbboxGiangVien.ValueMember = "MaGV";
            cbboxCN.DataSource = lop.Tables["lop"];
            cbboxCN.DisplayMember = "Tenchuyennganh";
            cbboxCN.ValueMember = "Machuyennganh";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO LopHocPhan VALUES (@MalopHP,@TenlopHP,@MaMH,@Namhoc,@Giangvien,@Thoigian,@Diadiem,@Siso,@Makhoa)", con);
                cmd.Parameters.AddWithValue("MalopHP", txtMaLopHP.Text);
                if (txtTenLopHP.Text != "")
                {
                    cmd.Parameters.AddWithValue("TenlopHP", txtTenLopHP.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên lớp học phần");
                    return;
                }

                cmd.Parameters.AddWithValue("MaMH", cbbMonhoc.SelectedValue);
                if (txtnamhoc.Text != "")
                {
                    cmd.Parameters.AddWithValue("Namhoc", txtnamhoc.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập năm học");
                    return;
                }

                cmd.Parameters.AddWithValue("Giangvien", cbboxGiangVien.SelectedValue);
                if (txtthoigian.Text != "")
                {
                    cmd.Parameters.AddWithValue("Thoigian", txtthoigian.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập thời gian học");
                    return;
                }
                if (txtNoiHoc.Text != "")
                {
                    cmd.Parameters.AddWithValue("Diadiem", txtNoiHoc.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập địa điểm học");
                    return;
                }
                if (txtSiSo.Text != "")
                {
                    cmd.Parameters.AddWithValue("Siso", txtSiSo.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập sĩ số");
                    return;
                }

                cmd.Parameters.AddWithValue("Makhoa", cbboxKhoa.SelectedValue);
                MessageBox.Show("Thêm thành công");
                cmd.ExecuteNonQuery();
                con.Close();
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void cbboxCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select MonHoc.*,ChuyenNganh.* from MonHoc,ChuyenNganh where MonHoc.Machuyennganh=ChuyenNganh.MachuyenNganh and ChuyenNganh.Machuyennganh='" + cbboxCN.SelectedValue + "'", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbbMonhoc.DataSource = lop.Tables["lop"];
            cbbMonhoc.DisplayMember = "TenMH";
            cbbMonhoc.ValueMember = "MaMH";
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMain form1 = new FrmMain();
            form1.Show();
            this.Hide();
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain form2 = new FrmMain();
            form2.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            cbboxKhoa.Text = dataGridView1.Rows[n].Cells["Makhoa"].Value.ToString();
            cbboxGiangVien.Text = dataGridView1.Rows[n].Cells["Giangvien"].Value.ToString();
            cbbMonhoc.Text = dataGridView1.Rows[n].Cells["MaMH"].Value.ToString();
            
            txtMaLopHP.Text = dataGridView1.Rows[n].Cells["MalopHP"].Value.ToString();
            txtTenLopHP.Text = dataGridView1.Rows[n].Cells["TenlopHP"].Value.ToString();
            txtSiSo.Text = dataGridView1.Rows[n].Cells["Siso"].Value.ToString();
            txtthoigian.Text = dataGridView1.Rows[n].Cells["Thoigian"].Value.ToString();
            txtNoiHoc.Text = dataGridView1.Rows[n].Cells["Diadiem"].Value.ToString();
            txtnamhoc.Text = dataGridView1.Rows[n].Cells["Namhoc"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("update LopHocPhan set TenlopHP=@TenlopHP,MaMH=@MaMH,Namhoc=@Namhoc,Giangvien=@Giangvien,Thoigian=@Thoigian,Diadiem=@Diadiem,Siso=@Siso,Makhoa=@Makhoa where MalopHP=@MalopHP", con);
                cmd.Parameters.AddWithValue("MalopHP", txtMaLopHP.Text);
                if (txtTenLopHP.Text != "")
                {
                    cmd.Parameters.AddWithValue("TenlopHP", txtTenLopHP.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên lớp học phần");
                    return;
                }

                cmd.Parameters.AddWithValue("MaMH", cbbMonhoc.SelectedValue);
                if (txtnamhoc.Text != "")
                {
                    cmd.Parameters.AddWithValue("Namhoc", txtnamhoc.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập năm học");
                    return;
                }

                cmd.Parameters.AddWithValue("Giangvien", cbboxGiangVien.SelectedValue);
                if (txtthoigian.Text != "")
                {
                    cmd.Parameters.AddWithValue("Thoigian", txtthoigian.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập thời gian học");
                    return;
                }
                if (txtNoiHoc.Text != "")
                {
                    cmd.Parameters.AddWithValue("Diadiem", txtNoiHoc.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập địa điểm học");
                    return;
                }
                if (txtSiSo.Text != "")
                {
                    cmd.Parameters.AddWithValue("Siso", txtSiSo.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập sĩ số");
                    return;
                }

                cmd.Parameters.AddWithValue("Makhoa", cbboxKhoa.SelectedValue);
                MessageBox.Show("Sửa thành công");
                cmd.ExecuteNonQuery();
                con.Close();
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from LopHocPhan where MalopHP=@MalopHP", con);
                cmd.Parameters.AddWithValue("MalopHP", txtMaLopHP.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Hienthi();
                MessageBox.Show("Xoá thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLLopHP_Load(sender, e);
            txtMaLopHP.Text = Masinhlhp();
            txtnamhoc.ResetText();
            txtNoiHoc.ResetText();
            txtSiSo.ResetText();
            txtTenLopHP.ResetText();
            txtthoigian.ResetText();
            txtMaLopHP.Enabled = false;
        }
    }
}
