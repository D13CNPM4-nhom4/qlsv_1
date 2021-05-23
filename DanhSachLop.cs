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
    public partial class DanhSachLop : Form
    {
        public DanhSachLop()
        {
            InitializeComponent();
        }

        private void DanhSachLop_Load(object sender, EventArgs e)
        {
            getkhoa();
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
            cbbkhoa.DataSource = lop.Tables["khoa"];
            cbbkhoa.DisplayMember = "Tenkhoa";
            cbbkhoa.ValueMember = "Makhoa";
            con.Close();
        }
        void Hienthi()
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select SinhViennn.MaSV,SinhViennn.Hoten,SinhViennn.Gioitinh,SinhViennn.Ngaysinh from LopHocPhan,SinhViennn,KetQuaDangky where LopHocPhan.MalopHP = KetQuaDangKy.MalopHP and SinhViennn.MaSV = KetQuaDangKy.MaSV and LopHocPhan.MalopHP = '"+cbblop.SelectedValue+"'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void cbbkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LopHocPhan where Makhoa='"+cbbkhoa.SelectedValue+"'", con);
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet lop = new DataSet();
            add.Fill(lop, "khoa");
            cbblop.DataSource = lop.Tables["khoa"];
            cbblop.DisplayMember = "TenlopHP";
            cbblop.ValueMember = "MalopHP";
            con.Close();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void quayLaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain form2 = new FrmMain();
            form2.Show();
        }
    }
}
