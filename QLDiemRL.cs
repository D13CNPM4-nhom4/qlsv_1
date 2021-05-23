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
    public partial class QLDiemRL : Form
    {
        public QLDiemRL()
        {
            InitializeComponent();
        }
        private void QLDiemRL_Load(object sender, EventArgs e)
        {
            getkhoa();
            getlop();
            txtmarl.Text = Masinhdiemrl();
            Hienthi();
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
            cbboxChonkhoa.DataSource = lop.Tables["khoa"];
            cbboxChonkhoa.DisplayMember = "Tenkhoa";
            cbboxChonkhoa.ValueMember = "Makhoa";
            con.Close();
        }
        private void getlop()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Malop,Tenlop,Khoa.Makhoa from Lopp,Khoa,ChuyenNganh where Lopp.Machuyennganh=ChuyenNganh.Machuyennganh and ChuyenNganh.Makhoa=Khoa.Makhoa and Khoa.Makhoa='"+cbboxChonkhoa.SelectedValue+"'", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbboxchonlop.DataSource = lop.Tables["lop"];
            cbboxchonlop.DisplayMember = "Tenlop";
            cbboxchonlop.ValueMember = "Tenlop";
            con.Close();
        }
        private void getten()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhViennn where Hoten=@Hoten", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbboxchonlop.DataSource = lop.Tables["lop"];
            cbboxchonlop.DisplayMember = "Hoten";
            cbboxchonlop.ValueMember = "Hoten";
            con.Close();
        }
        void Hienthi()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiemRLL", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public DataTable LoadDanhSachLop(string Malop)
        {
            DataTable data = new DataTable();
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
                String sql = "select Malop,Tenlop,Khoa.Makhoa from Lopp,Khoa,ChuyenNganh where Lopp.Machuyennganh=ChuyenNganh.Machuyennganh and ChuyenNganh.Makhoa=Khoa.Makhoa and Khoa.Makhoa=" + Malop;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            return data;
        }
        String xeploai;
        private void button1_Click_1(object sender, EventArgs e)
        {
            int tongdiem = Convert.ToInt32(txtTongDiemRL.Text);
            if (tongdiem >= 90)
            {
                xeploai = "Xuất Sắc";
            }
            else if (tongdiem >= 80 && tongdiem < 90)
            {
                xeploai = "Tốt";
            }
            else if (tongdiem >= 70 && tongdiem < 80)
            {
                xeploai = "Khá";
            }
            else
            {
                xeploai = "Trung Bình";
            }
            txtxeploai.Text = xeploai.ToString();
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DiemRLL VALUES(@MadiemRL,@MaSV,@Hoten,@Lop,@Hocky,@Namhoc,@Tongdiem,@Xeploai)", con);
                cmd.Parameters.AddWithValue("MadiemRL", txtmarl.Text);
                cmd.Parameters.AddWithValue("MaSV", txtmsv.Text);
                cmd.Parameters.AddWithValue("Hoten", txthoten.Text);
                cmd.Parameters.AddWithValue("Lop", cbboxchonlop.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Hocky", cbbhocky.SelectedItem);
                cmd.Parameters.AddWithValue("Namhoc", cbboxNamHoc.SelectedItem);
                if (txtTongDiemRL.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tongdiem", txtTongDiemRL.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập điểm rèn luyện cho sinh viên");
                    return;
                }
                cmd.Parameters.AddWithValue("Xeploai", txtxeploai.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nhập thành công");
                con.Close();
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó -_-");
            }
        }
        public string Masinhdiemrl()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from DiemRLL";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma1 = "";
            if (dt.Rows.Count <= 0)
            {
                ma1 = "RL001";
            }
            else
            {
                int k;
                ma1 = "RL";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3));
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
        private void btnLoadSV_Click(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            int tongdiem = Convert.ToInt32(txtTongDiemRL.Text);
            if (tongdiem >= 90)
            {
                xeploai = "Xuất Sắc";
            }
            else if (tongdiem >= 80 && tongdiem < 90)
            {
                xeploai = "Tốt";
            }
            else if (tongdiem >= 70 && tongdiem < 80)
            {
                xeploai = "Khá";
            }
            else
            {
                xeploai = "Trung Bình";
            }
            txtxeploai.Text = xeploai.ToString();
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE DiemRLL SET  MaSV=@MaSV,Hoten=@Hoten,Lop=@Lop,Hocky=@Hocky,Namhoc=@Namhoc,Tongdiem=@Tongdiem,Xeploai=@Xeploai where MadiemRL=@MadiemRL", con);
                cmd.Parameters.AddWithValue("MadiemRL", txtmarl.Text);
                cmd.Parameters.AddWithValue("MaSV", txtmsv.Text);
                cmd.Parameters.AddWithValue("Hoten", txthoten.Text);
                cmd.Parameters.AddWithValue("Lop", cbboxchonlop.SelectedValue);
                cmd.Parameters.AddWithValue("Hocky", cbbhocky.SelectedItem);

                cmd.Parameters.AddWithValue("Namhoc", cbboxNamHoc.SelectedItem);
                if (txtTongDiemRL.Text != "")
                {
                    cmd.Parameters.AddWithValue("Tongdiem", txtTongDiemRL.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập điểm rèn luyện cho sinh viên");
                    return;
                }
                cmd.Parameters.AddWithValue("Xeploai", txtxeploai.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                con.Close();
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Có lỗi gì đó ko ổn! -_-");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnnhap_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DiemRLL where Lop='" + txttim.Text + "'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "ti");
            dataGridView1.DataSource = ds1.Tables["ti"];
            con.Close();
        }

        private void cbboxChonkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Lopp.*,Khoa.*, ChuyenNganh.Machuyennganh from Lopp,ChuyenNganh,Khoa where Lopp.Machuyennganh=ChuyenNganh.Machuyennganh and ChuyenNganh.Makhoa = Khoa.Makhoa and Khoa.Makhoa='"+cbboxChonkhoa.SelectedValue+"'", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbboxchonlop.DataSource = lop.Tables["lop"];
            cbboxchonlop.DisplayMember = "Tenlop";
            cbboxchonlop.ValueMember = "Malop";
            con.Close();
        }
        private DataTable table;
        private void btnktra_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhViennn where MaSV=@MaSV", con);
            cmd.Parameters.AddWithValue("MaSV", txtmsv.Text);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "l");
            table = lop.Tables["l"];
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên");
                return;
            }

            else

            {
                MessageBox.Show("Tìm thấy sinh viên");
                txthoten.Text = table.Rows[0]["Hoten"].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLDiemRL_Load(sender, e);
            txtmsv.ResetText();
            txthoten.ResetText();
            txtTongDiemRL.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMain form3 = new FrmMain();
            form3.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            txtmarl.Text = dataGridView1.Rows[n].Cells["MadiemRL"].Value.ToString();
            txtmsv.Text = dataGridView1.Rows[n].Cells["MaSV"].Value.ToString();
            txthoten.Text = dataGridView1.Rows[n].Cells["Hoten"].Value.ToString();
            cbboxNamHoc.Text = dataGridView1.Rows[n].Cells["Namhoc"].Value.ToString();
            cbbhocky.Text = dataGridView1.Rows[n].Cells["Hocky"].Value.ToString();
            txtTongDiemRL.Text = dataGridView1.Rows[n].Cells["Tongdiem"].Value.ToString();
            txtxeploai.Text = dataGridView1.Rows[n].Cells["Xeploai"].Value.ToString();
        }
    }
}
