using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrontOffice : Form
    {
        public FrontOffice()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reservation r = new Reservation();
            r.MdiParent = this;
            r.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckIn r = new CheckIn();
            r.MdiParent = this;
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestAdditionalItem r = new RequestAdditionalItem();
            r.MdiParent = this;
            r.Show();
        }

        private void FrontOffice_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.username;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckOut r = new CheckOut();
            r.MdiParent = this;
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MasterRoomType r = new MasterRoomType();
            r.MdiParent = this;
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MasterRoom r = new MasterRoom();
            r.MdiParent = this;
            r.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MasterItem r = new MasterItem();
            r.MdiParent = this;
            r.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MasterEmployee r = new MasterEmployee();
            r.MdiParent = this;
            r.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            MessageBox.Show(Form1.username);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("ddd MMM yyyy HH:mm:ss");
        }
    }
}
