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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky form2 = new Dangky();
            form2.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from NguoiDung where Username='" + txt_taikhoan.Text + "'and Password='" + txt_matkhau.Text+"'", con);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                MessageBox.Show("Đăng nhập thành công!");
                FrmMain form1 = new FrmMain();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

