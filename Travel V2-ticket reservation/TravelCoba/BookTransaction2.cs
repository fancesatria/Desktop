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
    public partial class BookTransaction2 : Form
    {
        Modul mo = new Modul();
        String seat_no;

        public static bool check = false;
        List<string> seat_numbers = new List<string>();//nnti diconvert jadi int
        public BookTransaction2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void BookTransaction2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void BookTransaction2_Load(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string sql = "select * from customer where name='"+textBox1.Text + "'";

            string id_customer = mo.getValue(sql,"id");
            string name = mo.getValue(sql, "name");
            string email = mo.getValue(sql, "email");
            string phone = mo.getValue(sql, "phone");

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Customer not found","Error");
            } else
            {
                groupBox2.Enabled = true;

                Program.custId = id_customer;
                textBox2.Text = phone;
                textBox3.Text = email;
                for (int i = 1; i < 12; i++)
                {
                    if (String.IsNullOrEmpty(mo.getValue("select * from ticket where seat_number=" + i + " and schedule_id=" + Program.schid, "seat_number")))
                    {
                        this.Controls.Find("button" + i, true)[0].BackColor = SystemColors.Control;
                        this.Controls.Find("button" + i, true)[0].Enabled = true;

                    }
                    else
                    {
                        this.Controls.Find("button" + i, true)[0].BackColor = Color.Red;
                        this.Controls.Find("button" + i, true)[0].Enabled = true;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            seat_no = "3";
            if (check)
            {
                seat_numbers.Add("3");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            seat_no = "6";
            if (check)
            {
                seat_numbers.Add("6");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            seat_no = "9";
            if (check)
            {
                seat_numbers.Add("9");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seat_no = "1";
            if (check)
            {
                seat_numbers.Add("1");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            seat_no = "4";
            if (check)
            {
                seat_numbers.Add("4");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            seat_no = "7";
            if (check)
            {
                seat_numbers.Add("7");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            seat_no = "10";
            if (check)
            {
                seat_numbers.Add("10");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            seat_no = "2";
            if (check)
            {
                seat_numbers.Add("2");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            seat_no = "5";
            if (check)
            {
                seat_numbers.Add("5");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (check)
            {
                seat_numbers.Add("8");
            }
            seat_no = "8";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            seat_no = "11";
            if (check)
            {
                seat_numbers.Add("11");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //belum dikasi validasi data udah keisi apa belum
            //isi variabel static
            Program.cust_name = textBox1.Text;
            Program.cust_phone = textBox2.Text;
            Program.cust_email = textBox3.Text;
            Program.cust_seat_number = seat_no;
            Program.cust_seat_numbers = string.Format(string.Join(", ", seat_numbers));
            //MessageBox.Show(string.Format(string.Join(", ", seat_numbers)));

            BookConfirmation bc = new BookConfirmation();
            bc.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                check = true;
                //MessageBox.Show("true");
            }
            else
            {
                check = false;
                //MessageBox.Show("false");
            }
        }
    }
}
