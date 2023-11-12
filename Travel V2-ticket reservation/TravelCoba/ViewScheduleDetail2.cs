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
    public partial class ViewScheduleDetail2 : Form
    {
        Modul mo = new Modul();
        public ViewScheduleDetail2()
        {
            InitializeComponent();
        }

        private void ViewScheduleDetail2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void ViewScheduleDetail2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 12;i++)
            {
                if (String.IsNullOrEmpty(mo.getValue("select * from ticket where seat_number=" + i + " and schedule_id = " + Program.schid, "seat_number")))
                {
                    this.Controls.Find("button" + i, true)[0].BackColor = SystemColors.Control;
                }
                else
                {
                    this.Controls.Find("button" + i, true)[0].BackColor = Color.Red;
                }
            }
        }

        public void setInfoPassenger(int seat_number)
        {
            string cid = mo.getValue("select * from ticket where seat_number=" + seat_number + " and schedule_id=" + Program.schid,"customer_id");
            string sql = "select * from customer where id=" + cid;
            textBox1.Text = mo.getValue(sql, "name");
            textBox2.Text = mo.getValue(sql, "phone");
            textBox3.Text = mo.getValue(sql, "email");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setInfoPassenger(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setInfoPassenger(4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setInfoPassenger(7);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            setInfoPassenger(10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setInfoPassenger(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setInfoPassenger(6);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setInfoPassenger(9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setInfoPassenger(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setInfoPassenger(5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setInfoPassenger(8);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            setInfoPassenger(11);
        }
    }
}
