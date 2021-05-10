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
using System.IO;
using System.Globalization;

namespace QLSV
{
    public partial class QLGiangVien : Form
    {
        public QLGiangVien()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void QLGiangVien_Load(object sender, EventArgs e)
        {
            Hienthi();
            txtMaGV.Text = Masinh();
            getkhoa();
            txtMaGV.Enabled = false;
            
        }

        private void btnchonhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            dlg.Title = "Select Student Picture";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picsGV.ImageLocation = dlg.FileName;
                txthinh.Text = dlg.FileName;
            }
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
        void Hienthi()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from GiangVien", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public string Masinh()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from GiangVien";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "GV001";
            }
            else
            {
                int k;
                ma = "GV";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3));
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

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO GiangVien VALUES (@MaGV,@Anhhoso,@Hoten,@Gioitinh,@Ngaysinh,@SDT,@CMND,@Email,@Chuyenmon,@Makhoa)", con);
                cmd.Parameters.AddWithValue("MaGV", txtMaGV.Text);
                if (picsGV.Image != null)
                {
                    cmd.Parameters.AddWithValue("Anhhoso", convertImageToBytes());
                }
                else
                {
                    MessageBox.Show("Vui lòng cập nhật ảnh giảng viên");
                    return;
                }
                if (txtHoten.Text != "")
                {
                    cmd.Parameters.AddWithValue("Hoten", txtHoten.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên giảng viên");
                    return;
                }
                cmd.Parameters.AddWithValue("Gioitinh", cbboxGioitinh.SelectedItem);
                cmd.Parameters.AddWithValue("Ngaysinh", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                if (txtChuyenMon.Text != "")
                {
                    cmd.Parameters.AddWithValue("Chuyenmon", txtChuyenMon.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập chuyên môn");
                    return;
                }
                cmd.Parameters.AddWithValue("Makhoa", cbboxKhoa.SelectedValue);
                MessageBox.Show("Thêm thành công");
                cmd.ExecuteNonQuery();
                con.Close();
                txthinh.Text = txtHoten.Text = "";
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Vui lòng cập nhật lại ảnh giảng viên!");
            }
        }
        private byte[] convertImageToBytes()
        {
            FileStream fs;
            fs = new FileStream(txthinh.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("update GiangVien set Anhhoso=@Anhhoso,Hoten=@Hoten,Gioitinh=@Gioitinh,Ngaysinh=@Ngaysinh,SDT=@SDT,CMND=@CMND,Email=@Email,Chuyenmon=@Chuyenmon,Makhoa=@Makhoa where MaGV=@MaGV", con);
                cmd.Parameters.AddWithValue("MaGV", txtMaGV.Text);
                if (picsGV.Image != null)
                {
                    cmd.Parameters.AddWithValue("Anhhoso", convertImageToBytes());
                }
                else
                {
                    MessageBox.Show("Vui lòng cập nhật ảnh giảng viên");
                    return;
                }
                if (txtHoten.Text != "")
                {
                    cmd.Parameters.AddWithValue("Hoten", txtHoten.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên giảng viên");
                    return;
                }
                cmd.Parameters.AddWithValue("Gioitinh", cbboxGioitinh.SelectedItem);
                cmd.Parameters.AddWithValue("Ngaysinh", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                if (txtChuyenMon.Text != "")
                {
                    cmd.Parameters.AddWithValue("Chuyenmon", txtChuyenMon.Text);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập chuyên môn");
                    return;
                }
                cmd.Parameters.AddWithValue("Makhoa", cbboxKhoa.SelectedValue);
                MessageBox.Show("Sửa thành công");
                cmd.ExecuteNonQuery();
                con.Close();
                txthinh.Text = txtHoten.Text = "";
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Vui lòng cập nhật lại ảnh giảng viên!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from GiangVien where MaGV=@MaGV", con);
            cmd.Parameters.AddWithValue("MaGV", txtMaGV.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoá thành công");
            con.Close();
            Hienthi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            txthinh.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            byte[] b = (byte[])dataGridView1.Rows[r].Cells[1].Value;
            picsGV.Image = ByteArrayToImage(b);
            int numrow;
            numrow = e.RowIndex;
            txtMaGV.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtHoten.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            txtCMND.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[numrow].Cells[7].Value.ToString();
            txtChuyenMon.Text = dataGridView1.Rows[numrow].Cells[8].Value.ToString();
        /*    String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select GiangVien.*,Khoa.* from GiangVien,Khoa where GiangVien.Makhoa = Khoa.Makhoa and MaGV='"+txtMaGV.Text+"'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";
            cbboxKhoa.DataSource = dt;
            con.Close();*/
        }
            Image ByteArrayToImage(byte[] b)
            {
                MemoryStream m = new MemoryStream(b);
                return Image.FromStream(m);
            }

        private void cbboxGioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLGiangVien_Load(sender, e);
            Hienthi();
            txtMaGV.Text = Masinh();
            txtChuyenMon.ResetText();
            txtEmail.ResetText();
            txtCMND.ResetText();
            txtSDT.ResetText();
            picsGV.Image = null;
            txthinh.ResetText();
            txtHoten.ResetText();

           
        }

        private void btnTimGV_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM GiangVien WHERE  MaGV= @MaGV or Hoten=@Hoten", con);
            if (txtTimKiem.Text != "")
            {
                cmd.Parameters.AddWithValue("MaGV", txtTimKiem.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu cần tìm");
                return;
            }
            cmd.Parameters.AddWithValue("Hoten", txtTimKiem.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "ti");
            dataGridView1.DataSource = ds1.Tables["ti"];
            MessageBox.Show("Tìm kiếm thành công");
            con.Close();
        }

        private void cbboxKhoa_Click(object sender, EventArgs e)
        {
            getkhoa();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int VT = dataGridView1.CurrentCell.RowIndex;
            load(VT);
        }
        private void load(int VT)
        {
            try
            {

                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[VT].Cells[4].Value.ToString());
                cbboxGioitinh.Text = dataGridView1.Rows[VT].Cells[3].Value.ToString();
                cbboxKhoa.Text = dataGridView1.Rows[VT].Cells[9].Value.ToString();

            }
            catch (Exception e) { }
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain form2 = new FrmMain();
            form2.Show();
            this.Hide();
        }
    }
}
