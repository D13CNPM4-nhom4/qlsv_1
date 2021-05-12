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
using app = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;
using Microsoft.Office.Interop.Excel;

namespace QLSV
{
    public partial class QLDiem : Form
    {
        public QLDiem()
        {
            InitializeComponent();
        }

        private void QLDiem_Load(object sender, EventArgs e)
        {
            getlop();
            getmh();
            
        }
       void Hienthi()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DiemMonHocc", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lop");
            dataGridView1.DataSource = ds.Tables["lop"];
            con.Close();

        }
        void Hienthi2()
        {

            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select SinhViennn.MaSV,SinhViennn.Hoten,SinhViennn.Gioitinh,SinhViennn.Ngaysinh,LopHocPhan.MaMH from LopHocPhan,SinhViennn,KetQuaDangky where LopHocPhan.MalopHP = KetQuaDangKy.MalopHP and SinhViennn.MaSV = KetQuaDangKy.MaSV and LopHocPhan.MalopHP = '" + cbbchonlop.SelectedValue + "'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lop");
            dataGridView1.DataSource = ds.Tables["lop"];     
            con.Close();

        }
        private void getmh()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select MonHoc.TenMH,LopHocPhan.* from LopHocPhan,MonHoc where MonHoc.MaMH=LopHocPhan.MaMH", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbbmonhoc.DataSource = lop.Tables["khoa"];
            cbbmonhoc.DisplayMember = "TenMH";
            cbbmonhoc.ValueMember = "MaMH";
            con.Close();
        }
        private void getlop()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from LopHocPhan", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lop");
            cbbchonlop.DataSource = ds.Tables["lop"];
            cbbchonlop.DisplayMember = "TenlopHP";
            cbbchonlop.ValueMember = "MalopHP";
        }
        private void export2Excel(DataGridView g, string duongdan, string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void btnchon_Click(object sender, EventArgs e)
        {
            export2Excel(dataGridView1, @"D:\", "xuatfileExcelDIEM");
            MessageBox.Show("Xuất file Excel thành công");
        }
        private void getsv()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from SinhViennn", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lop");
            dataGridView1.DataSource = ds.Tables["lop"];
        }
        private DataTable table;
        private void cbbchonlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            Hienthi();
            con.Close();
        }
    
        private void Hienthisv()
        {
           

        }

        private void cbbchonmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select LopHocPhan.* from LopHocPhan where LopHocPhan.MaMH='" + cbbmonhoc.SelectedValue + "'", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "lop");
            cbbchonlop.DataSource = lop.Tables["lop"];
            cbbchonlop.DisplayMember = "TenlopHP";
            cbbchonlop.ValueMember = "MalopHP";
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMain form2 = new FrmMain();
            form2.Show();
            this.Hide();
        }
      
        string diemchu;
        string danhgia ;
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {   
            int numrow;
            numrow = e.RowIndex;
            if (Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diem1"].Value) >= 0 && Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diem1"].Value) <= 10 && Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diem2"].Value) >= 0 && Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diem2"].Value) <= 10 && Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diemthi"].Value) >= 0 && Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diemthi"].Value) <= 10)
            {
                double diem1 = Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diem1"].Value);
                double diem2 = Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diem2"].Value);
                double diemthi = Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diemthi"].Value);
                double diemhe4 = Convert.ToDouble(dataGridView1.Rows[numrow].Cells["Diemhe4"].Value);
                double diemtongket = Convert.ToDouble(dataGridView1.Rows[numrow].Cells["DiemTK"].Value);
                diemtongket = (double)((((diem1 * 3) + (diem2 * 3)) / 2 + (diemthi * 7)) / 10);
                if (diemtongket >= 8.5)
                {
                    diemchu = "A";
                    diemhe4 = 4.0;
                    danhgia = "Đạt";

                }
                else if (diemtongket >= 8.0 && diemtongket < 8.5)
                {
                    diemchu = "B+";
                    diemhe4 = 3.0;
                    danhgia = "Đạt";
                }
                else if (diemtongket >= 7.0 && diemtongket < 8.0)
                {
                    diemchu = "B";
                    diemhe4 = 3.0;
                    danhgia = "Đạt";
                }
                else if (diemtongket >= 6.5 && diemtongket < 7.0)
                {
                    diemchu = "C+";
                    diemhe4 = 2.0;
                    danhgia = "Đạt";
                }
                else if (diemtongket >= 5.5 && diemtongket < 6.5)
                {
                    diemchu = "C";
                    diemhe4 = 2.0;
                    danhgia = "Đạt";
                }
                else if (diemtongket >= 5.0 && diemtongket < 5.5)
                {
                    diemchu = "D+";
                    diemhe4 = 1.0;
                    danhgia = "Đạt";
                }
                else if (diemtongket >= 4.0 && diemtongket < 5.0)
                {
                    diemchu = "D";
                    diemhe4 = 1.0;
                    danhgia = "Đạt";
                }
                else if (diemtongket < 4.0)
                {
                    diemchu = "F";
                    diemhe4 = 0.0;
                    danhgia = "Học lại";
                }

                dataGridView1.Rows[numrow].Cells["DiemTK"].Value = diemtongket.ToString();
                dataGridView1.Rows[numrow].Cells["Diemchu"].Value = diemchu.ToString();
                dataGridView1.Rows[numrow].Cells["Diemhe4"].Value = diemhe4.ToString();
                dataGridView1.Rows[numrow].Cells["Danhgia"].Value = danhgia.ToString();
           

            }
            else
            {
                MessageBox.Show("Nhập điểm không đúng. Yêu cầu nhập lại");
            }




            /*  foreach (DataGridViewRow row in dataGridView1.SelectedRows)
              {
                  float diemtk = Convert.ToInt32(row.Cells["DiemTK"].Value.ToString());
                  float diem1 = Convert.ToInt32(row.Cells["Diem1"].Value.ToString());
                  float diem2 = Convert.ToInt32(row.Cells["Diem2"].Value.ToString());
                  float diemthi = Convert.ToInt32(row.Cells["Diemthi"].Value.ToString());
                  diemtongket = (((diem1 + diem2) / 2) * 3 + diemthi * 7) / 10;
                  //row.Cells["DiemTK"].Value = diemtongket.ToString();
              }*/

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
           //     float diem1 = Convert.ToInt32(dataGridView1.Rows[0].Cells["Diem1"].Value);
            //    float diem2 = Convert.ToInt32(dataGridView1.Rows[0].Cells["Diem2"].Value);
            //    float diemthi = Convert.ToInt32(dataGridView1.Rows[0].Cells["Diemthi"].Value);
              //  diemtongket = ((diem1 * 3)+ (diem2 *3));
               // row.Cells["DiemTK"].Value = diemtongket.ToString();
            //}
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {/*
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO DiemMonHocc VALUES(@MaSV,@Hoten,@Gioitinh,@Ngaysinh,@MaMH,@Diem1,@Diem2,@Diemthi,@DiemTK,@Diemchu,@Diemhe4,@Danhgia)", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            dataGridView1.DataSource = lop.Tables["khoa"];
            MessageBox.Show("Cập nhật thành công");
            con.Close();
            Hienthi();*/
            /* dataGridView1.Rows.Clear();
             string file = "D:\\mygrid.bin";
             using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
             {
                 int n = bw.ReadInt32();
                 int m = bw.ReadInt32();
                 for (int i = 0; i < m; ++i)
                 {
                     dataGridView1.Rows.Add();
                     for (int j = 0; j < n; ++j)
                     {
                         if (bw.ReadBoolean())
                         {
                             dataGridView1.Rows[i].Cells[j].Value = bw.ReadString();
                         }
                         else bw.ReadBoolean();
                     }
                 }
                 MessageBox.Show("Cập nhật thành công");
             }*/
            Hienthi2();
            this.dataGridView1.Columns.Add("Diem1", "Diem1");
            this.dataGridView1.Columns.Add("Diem2", "Diem2");
            this.dataGridView1.Columns.Add("Diemthi", "Diemthi");
            this.dataGridView1.Columns.Add("DiemTK", "DiemTK");
            this.dataGridView1.Columns.Add("Diemchu", "Diemchu");
            this.dataGridView1.Columns.Add("Diemhe4", "Diemhe4");
            this.dataGridView1.Columns.Add("Danhgia", "Danhgia");
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DiemMonHocc where Danhgia=N'Học lại'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lop");
            dataGridView1.DataSource = ds.Tables["lop"];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert DiemMonHocc values  (@MaSV,@Hoten,@Gioitinh,@Ngaysinh,@MaMH,@Diem1,@Diem2,@Diemthi,@DiemTK,@Diemchu,@Diemhe4,@Danhgia)", con);
           // foreach (DataGridViewRow row in dataGridView1.Rows)
          /*  {
                cmd.Parameters.AddWithValue("MaSV", dataGridView1.Rows[0].Cells["MaSV"].Value.ToString()); 
                cmd.Parameters.AddWithValue("Hoten", dataGridView1.Rows[0].Cells["Hoten"].Value.ToString());
                cmd.Parameters.AddWithValue("Gioitinh", dataGridView1.Rows[0].Cells["Gioitinh"].Value.ToString());
                cmd.Parameters.AddWithValue("Ngaysinh", dataGridView1.Rows[0].Cells["Ngaysinh"].Value.ToString());
                cmd.Parameters.AddWithValue("MaMH", dataGridView1.Rows[0].Cells["MaMH"].ToString());
                cmd.Parameters.AddWithValue("Diem1", dataGridView1.Rows[0].Cells["Diem1"].Value.ToString());
                cmd.Parameters.AddWithValue("Diem2", dataGridView1.Rows[0].Cells["Diem2"].Value.ToString());
                cmd.Parameters.AddWithValue("Diemthi", dataGridView1.Rows[0].Cells["Diemthi"].Value.ToString());
                cmd.Parameters.AddWithValue("DiemTK", dataGridView1.Rows[0].Cells["DiemTK"].Value.ToString());
                cmd.Parameters.AddWithValue("Diemchu", dataGridView1.Rows[0].Cells["Diemchu"].Value.ToString());
                cmd.Parameters.AddWithValue("Diemhe4", dataGridView1.Rows[0].Cells["Diemhe4"].Value.ToString());
                cmd.Parameters.AddWithValue("Danhgia", dataGridView1.Rows[0].Cells["Danhgia"].Value.ToString());
            
                cmd.ExecuteNonQuery();
            //}
            MessageBox.Show("Lưu thành công");
            con.Close();
            Hienthi();*/
            /*string file = "D:\\mygrid.bin";
            using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
            {
                bw.Write(dataGridView1.Columns.Count);
                bw.Write(dataGridView1.Rows.Count);
                foreach (DataGridViewRow dgvR in dataGridView1.Rows)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        object val = dgvR.Cells[j].Value;
                        if (val == null)
                        {
                            bw.Write(false);
                            bw.Write(false);
                        }
                        else
                        {
                            bw.Write(true);
                            bw.Write(val.ToString());
                        }
                    }
                }
                MessageBox.Show("Lưu thành công");
            }*/
            /* String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
             SqlConnection con = new SqlConnection(conn);
             con.Open();
             SqlCommand cmd = new SqlCommand("select * from DiemMonHocc", con);
             DataTable dt = new DataTable();
             SqlDataReader dr = cmd.ExecuteReader();
             dt.Load(dr);
             dataGridView1.DataSource = dt;
             con.Close();*/
            try
            {
                them();
            }
            catch
            {
                sua();
            }

        }
        private void them()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            for (int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                string insert = "insert into DiemMonHocc values(N'" + dataGridView1.Rows[i].Cells["MaSV"].Value + "',N'" + dataGridView1.Rows[i].Cells["Hoten"].Value + "',N'" + dataGridView1.Rows[i].Cells["Gioitinh"].Value + "',N'" + dataGridView1.Rows[i].Cells["Ngaysinh"].Value + "',N'" + dataGridView1.Rows[i].Cells["MaMH"].Value + "','" + dataGridView1.Rows[i].Cells["Diem1"].Value + "','" + dataGridView1.Rows[i].Cells["Diem2"].Value + "','" + dataGridView1.Rows[i].Cells["Diemthi"].Value + "','" + dataGridView1.Rows[i].Cells["DiemTK"].Value + "','" + dataGridView1.Rows[i].Cells["Diemchu"].Value + "','" + dataGridView1.Rows[i].Cells["Diemhe4"].Value + "',N'" + dataGridView1.Rows[i].Cells["Danhgia"].Value + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
           
            }
            con.Close();



        }
        private void sua()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string insert = "update DiemMonHocc set Hoten=N'" + dataGridView1.Rows[i].Cells["Hoten"].Value + "',Gioitinh=N'" + dataGridView1.Rows[i].Cells["Gioitinh"].Value + "',Ngaysinh=N'" + dataGridView1.Rows[i].Cells["Ngaysinh"].Value + "',MaMH='" + dataGridView1.Rows[i].Cells["MaMH"].Value + "',Diem1=N'" + dataGridView1.Rows[i].Cells["Diem1"].Value + "',Diem2=N'" + dataGridView1.Rows[i].Cells["Diem2"].Value + "',Diemthi=N'" + dataGridView1.Rows[i].Cells["Diemthi"].Value + "',DiemTK=N'" + dataGridView1.Rows[i].Cells["DiemTK"].Value + "',Diemchu=N'" + dataGridView1.Rows[i].Cells["Diemchu"].Value + "',Diemhe4=N'" + dataGridView1.Rows[i].Cells["Diemhe4"].Value + "',Danhgia=N'" + dataGridView1.Rows[i].Cells["Danhgia"].Value + "' where MaSV=N'" + dataGridView1.Rows[i].Cells["MaSV"].Value + "'";
                SqlCommand cmd = new SqlCommand(insert, con);

                cmd.ExecuteNonQuery();
            

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DiemMonHocc where Danhgia=N'Đạt'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lop");
            dataGridView1.DataSource = ds.Tables["lop"];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            adapter1.Fill(ds1, "ti");
            dataGridView1.DataSource = ds1.Tables["ti"];
            MessageBox.Show("Tìm kiếm thành công");
            con.Close();
        }
    }
}
