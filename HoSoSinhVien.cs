using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;


namespace QLSV
{
    public partial class HoSoSinhVien : Form
    {

       
        public HoSoSinhVien()
        {
            InitializeComponent();
         
        }

        private void HoSoSinhVien_Load(object sender, EventArgs e)
        {
            getlop();
            getkhoa();
            Hienthi();
            txtMSV1.Text = Masinh();
            txtMSV1.Enabled = false;
        }
    
        private void getlop()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Lopp", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbboxLop1.DataSource = lop.Tables["lop"];
            cbboxLop1.DisplayMember = "Tenlop";
            cbboxLop1.ValueMember = "Malop";
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
            cbboxKhoa1.DataSource = lop.Tables["khoa"];
            cbboxKhoa1.DisplayMember = "Tenkhoa";
            cbboxKhoa1.ValueMember = "Makhoa";
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            dlg.Title = "Select Student Picture";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picstudent.ImageLocation = dlg.FileName;
                txtImage.Text = dlg.FileName;
            }
        }
        void Hienthi()
        {
           
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SinhViennn", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        public string Masinh()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            string sql = @"select * from SinhViennn";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conn;
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            string ma = "";
            if(dt.Rows.Count<=0)
            {
                ma = "MSV001";
            }
            else
            {
                int k;
                ma = "MSV";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(4));
                k = k + 1;
                if (k<10)
                {
                    ma = ma + "00";
                }
                else if (k<100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;

        }
        private void btThemSV_Click(object sender, EventArgs e)
        {
            try
            {
                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SinhViennn VALUES (@MaSV,@Hoten,@Anhhoso,@Ngaysinh,@Gioitinh,@Dantoc,@SDT,@CMND,@Email,@Hedaotao,@Hotenbo,@Nghebo,@Hotenme,@Ngheme,@Tentinh,@Malop,@Makhoa,@Tinhtrang,@NamNhapHoc)", con);
                cmd.Parameters.AddWithValue("MaSV", txtMSV1.Text);
                if (txtHoten1.Text != "")
                {
                    cmd.Parameters.AddWithValue("Hoten", txtHoten1.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập họ tên");
                    return;
                }
                if (picstudent.Image != null)
                {
                    cmd.Parameters.AddWithValue("Anhhoso", convertImageToBytes());
                }
                else
                {
                    MessageBox.Show("Vui lòng cập nhật ảnh");
                    return;
                }
                cmd.Parameters.AddWithValue("Ngaysinh", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("Gioitinh", cbboxGioitinh1.SelectedItem);
                cmd.Parameters.AddWithValue("Dantoc", cbboxDanToc1.SelectedItem);
                cmd.Parameters.AddWithValue("SDT", txtSDT1.Text);
                cmd.Parameters.AddWithValue("CMND", txtCMND1.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail1.Text);
                cmd.Parameters.AddWithValue("Hedaotao", cbboxHeDT1.SelectedItem);
                cmd.Parameters.AddWithValue("Hotenbo", txtHotenBo1.Text);
                cmd.Parameters.AddWithValue("Hotenme", txtHotenme.Text);
                cmd.Parameters.AddWithValue("Nghebo", txtNghebo.Text);
                cmd.Parameters.AddWithValue("Ngheme", txtNgheme.Text);
                cmd.Parameters.AddWithValue("Tentinh", cbboxTinhThanhPho1.SelectedItem);
                cmd.Parameters.AddWithValue("Malop", cbboxLop1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Makhoa", cbboxKhoa1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Tinhtrang", cbboxTinhtrang1.SelectedItem);
                cmd.Parameters.AddWithValue("NamNhapHoc", txtNamNhapHoc1.Text);
                MessageBox.Show("Thêm thành công");
                cmd.ExecuteNonQuery();
                con.Close();
                txtImage.Text = txtHoten1.Text = "";
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Vui lòng cập nhật lại ảnh! Mất đường dẫn rồi :(");
            }
        }
        private byte[] convertImageToBytes()
        {
            FileStream fs;
            fs = new FileStream(txtImage.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private void btSuaSV_Click(object sender, EventArgs e)
        {
            try
            {

                String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE SinhViennn SET Hoten=@Hoten,Anhhoso=@Anhhoso,Ngaysinh=@Ngaysinh,Gioitinh=@Gioitinh,Dantoc=@Dantoc,SDT=@SDT,CMND=@CMND,Email=@Email,Hedaotao=@Hedaotao,Hotenbo=@Hotenbo,Nghebo=@Nghebo,Hotenme=@Hotenme,Ngheme=@Ngheme,Tentinh=@Tentinh,Makhoa=@Makhoa,Malop=@Malop,Tinhtrang=@Tinhtrang,NamNhapHoc=@NamNhapHoc where MaSV=@MaSV", con);
                cmd.Parameters.AddWithValue("MaSV", txtMSV1.Text);
                if (txtHoten1.Text != "")
                {
                    cmd.Parameters.AddWithValue("Hoten", txtHoten1.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập họ tên");
                    return;
                }
                if (picstudent.Image != null)
                {
                    cmd.Parameters.AddWithValue("Anhhoso", convertImageToBytes());
                }
                else
                {
                    MessageBox.Show("Vui lòng cập nhật ảnh");
                    return;
                }
                cmd.Parameters.AddWithValue("Ngaysinh", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("Gioitinh", cbboxGioitinh1.SelectedItem);
                cmd.Parameters.AddWithValue("Dantoc", cbboxDanToc1.SelectedItem);
                cmd.Parameters.AddWithValue("SDT", txtSDT1.Text);
                cmd.Parameters.AddWithValue("CMND", txtCMND1.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail1.Text);
                cmd.Parameters.AddWithValue("Hedaotao", cbboxHeDT1.SelectedItem);
                cmd.Parameters.AddWithValue("Hotenbo", txtHotenBo1.Text);
                cmd.Parameters.AddWithValue("Hotenme", txtHotenme.Text);
                cmd.Parameters.AddWithValue("Nghebo", txtNghebo.Text);
                cmd.Parameters.AddWithValue("Ngheme", txtNgheme.Text);
                cmd.Parameters.AddWithValue("Tentinh", cbboxTinhThanhPho1.SelectedItem);
                cmd.Parameters.AddWithValue("Malop", cbboxLop1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Makhoa", cbboxKhoa1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("Tinhtrang", cbboxTinhtrang1.SelectedItem);
                cmd.Parameters.AddWithValue("NamNhapHoc", txtNamNhapHoc1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công");
                con.Close();
                txtImage.Text = txtHoten1.Text = "";
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Vui lòng cập nhật lại ảnh! Mất đường dẫn rồi :(");
            }
        }

        private void btXoaSV_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM SinhViennn where MaSV=@MaSV", con);
            cmd.Parameters.AddWithValue("MaSV", txtMSV1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoá thành công");
            con.Close();
            Hienthi();
        }

        private void btTimSV_Click(object sender, EventArgs e)
        {
            //txtTimKiem.Text = "";
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SinhViennn WHERE  MaSV=@MaSV ", con);
            if (txtMSV1.Text != "")
            {
                cmd.Parameters.AddWithValue("MaSV", txtTimKiem.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên cần tìm");
                return;
            }
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1,"ti");
            dataGridView1.DataSource = ds1.Tables["ti"];
            MessageBox.Show("Tìm kiếm thành công");
            con.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SinhViennn", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }
        private void export2Excel(DataGridView g, string duongdan, string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for ( int i =1; i<g.Columns.Count+1;i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i=0; i<g.Rows.Count;i++)
            {
                for( int j=0;j<g.Columns.Count;j++)
                {
                    if(g.Rows[i].Cells[j].Value!=null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }    
                }    
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void btnxem_Click(object sender, EventArgs e)
        {
            export2Excel(dataGridView1, @"D:\", "xuatfileExcel");
            MessageBox.Show("Xuất file Excel thành công");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain form2 = new FrmMain();
            form2.Show();
            this.Hide();
        }

        private void cbboxDanToc1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnthemtiep_Click(object sender, EventArgs e)
        {
            HoSoSinhVien_Load(sender, e);
            txtSDT1.ResetText();
            txtCMND1.ResetText();
            txtEmail1.ResetText();
            txtHoten1.ResetText();
            txtHotenBo1.ResetText();
            txtHotenme.ResetText();
            txtNghebo.ResetText();
            txtNgheme.ResetText();
            txtTimKiem.ResetText();
            txtImage.ResetText();
            txtNamNhapHoc1.ResetText();
            picstudent.Image = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtMSV1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtHoten1.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
         //   picstudent.Image = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
          //  dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
           // cbboxGioitinh1.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
           // cbboxDanToc1.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            txtSDT1.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
            txtCMND1.Text = dataGridView1.Rows[numrow].Cells[7].Value.ToString();
            txtEmail1.Text = dataGridView1.Rows[numrow].Cells[8].Value.ToString();
            txtHotenBo1.Text = dataGridView1.Rows[numrow].Cells[10].Value.ToString();
            txtNghebo.Text = dataGridView1.Rows[numrow].Cells[12].Value.ToString();
            txtHotenme.Text = dataGridView1.Rows[numrow].Cells[11].Value.ToString();
            txtNgheme.Text = dataGridView1.Rows[numrow].Cells[13].Value.ToString();
         //   cbboxLop1.Text = dataGridView1.Rows[numrow].Cells[15].Value.ToString();
         //   cbboxKhoa1.Text = dataGridView1.Rows[numrow].Cells[16].Value.ToString();
            txtNamNhapHoc1.Text = dataGridView1.Rows[numrow].Cells[18].Value.ToString();
            int r = dataGridView1.CurrentCell.RowIndex;
            txtImage.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            byte[] b = (byte[])dataGridView1.Rows[r].Cells[2].Value;
            picstudent.Image = ByteArrayToImage(b);
         /*   String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select SinhViennn.*,Khoa.*,Lopp.* from SinhViennn,Khoa,Lopp,ChuyenNganh where SinhViennn.Malop=Lopp.Malop and Lopp.Machuyennganh=ChuyenNganh.Machuyennganh and ChuyenNganh.Makhoa=Khoa.Makhoa and MaSV='" + txtMSV1.Text + "'", con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            cbboxDanToc1.DisplayMember = "Dantoc";
            cbboxDanToc1.DataSource = dt;
            cbboxGioitinh1.DisplayMember = "Gioitinh";
            cbboxGioitinh1.DataSource = dt;
            cbboxKhoa1.DisplayMember = "Tenkhoa";
            cbboxKhoa1.ValueMember = "Makhoa";
            cbboxKhoa1.DataSource = dt;
            cbboxLop1.DisplayMember = "Tenlop";
            cbboxLop1.ValueMember = "Malop";
            cbboxLop1.DataSource = dt;
         
            cbboxGioitinh1.DataSource = dt;
            cbboxHeDT1.DisplayMember = "Hedaotao";
            cbboxHeDT1.DataSource = dt;
            cbboxTinhtrang1.DisplayMember = "Tinhtrang";
            cbboxTinhtrang1.DataSource = dt;
            cbboxTinhThanhPho1.DisplayMember = "Tentinh";
            cbboxTinhThanhPho1.DataSource = dt;
            con.Close();*/
        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        private void btnthemlop_Click(object sender, EventArgs e)
        {

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

                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[VT].Cells[3].Value.ToString());
                cbboxDanToc1.Text = dataGridView1.Rows[VT].Cells[5].Value.ToString();
                cbboxGioitinh1.Text = dataGridView1.Rows[VT].Cells[4].Value.ToString();
                cbboxHeDT1.Text = dataGridView1.Rows[VT].Cells[9].Value.ToString();
                cbboxKhoa1.Text = dataGridView1.Rows[VT].Cells[16].Value.ToString();
                cbboxLop1.Text = dataGridView1.Rows[VT].Cells[15].Value.ToString();
                cbboxTinhThanhPho1.Text = dataGridView1.Rows[VT].Cells[14].Value.ToString();
                cbboxTinhtrang1.Text = dataGridView1.Rows[VT].Cells[17].Value.ToString();
                
               
            }
            catch (Exception e) { }
        }
    }
}
