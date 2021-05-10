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
    public partial class Dangky : Form
    {
        public Dangky()
        {
            InitializeComponent();
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            String conn = @"Data Source=DUCDZ\SQLEXPRESS01;Initial Catalog=QLSV4;Integrated Security=True";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into CanBo(Username,Password,Hoten) values('" + txt_tk.Text + "','" + txt_mk.Text + "','"+txthoten.Text+"')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đăng ký thành công");
            con.Close();
        }

        private void btnquay_Click(object sender, EventArgs e)
        {
            DangNhap form1 = new DangNhap();
            form1.Show();
            this.Hide();
        }
    }
}
