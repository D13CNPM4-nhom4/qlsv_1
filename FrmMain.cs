using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoSoSinhVien form1 = new HoSoSinhVien();
            form1.Show();
            this.Hide();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            QLDiemRL form2 = new QLDiemRL();
            form2.Show();
            this.Hide();
        }

        private void btntroll_Click(object sender, EventArgs e)
        {
            DanhSachLop form1000 = new DanhSachLop();
            form1000.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnxemchitiet_Click(object sender, EventArgs e)
        {
            XemChiTiet form3 = new XemChiTiet();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThemLop form4 = new ThemLop();
            form4.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            QLMonHoc form5 = new QLMonHoc();
            form5.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QLKhoa form6 = new QLKhoa();
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLGiangVien form7 = new QLGiangVien();
            form7.Show();
        }

        private void btnqldiem_Click(object sender, EventArgs e)
        {
            QLDiem form8 = new QLDiem();
            form8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QLLopHP form9 = new QLLopHP();
            form9.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KetQuaDangKy form10 = new KetQuaDangKy();
            form10.Show();
        }
    }
}
