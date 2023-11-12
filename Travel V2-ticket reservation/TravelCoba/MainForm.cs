using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCoba
{
    public partial class MainForm : Form
    {
        Modul mo = new Modul();
        public MainForm()
        {
            InitializeComponent();
            label3.Text = Program.EmpName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ViewSchedule vs  = new ViewSchedule();
            vs.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewSchedule vs = new ViewSchedule();
            vs.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Form2.showTaskbar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mo.dialog("Wanna Logout?"))
            {
                Form2 f2 = new Form2();
                f2.Hide();
                this.Close();

                Form1 f = new Form1();
                f.Show();
            }
        }
    }
}
