using System;
using System.Collections;
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
    public partial class BookTransaction1 : Form
    {
        Modul mo = new Modul();
        String seat_no;

        List<string> seat_numbers = new List<string>();
        public static bool check = false;
        public BookTransaction1()
        {
            InitializeComponent();
        }

        private void BookTransaction1_Load(object sender, EventArgs e)
        {
        }

        private void BookTransaction1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //belum ada validasi kalau data udh keisi apa elum
            //perbarui value variabel
            Program.cust_name = textBox1.Text;
            Program.cust_phone = textBox2.Text;
            Program.cust_email = textBox3.Text;
            Program.cust_seat_number = seat_no;
            
            //foreach (var i in seat_numbers)
            //{
            //    MessageBox.Show(i);
            //}

            Program.cust_seat_numbers = string.Format(string.Join(", ", seat_numbers));
            //MessageBox.Show(string.Format(string.Join(", ",seat_numbers)));

            BookConfirmation bk = new BookConfirmation();
            bk.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //select user
            string sql = "select * from customer where name ='" + textBox1.Text + "'";
            string id_customer = mo.getValue(sql, "id");
            string nama = mo.getValue(sql, "name");
            string phone = mo.getValue(sql, "phone");
            string email = mo.getValue(sql, "email");

            if (string.IsNullOrEmpty(nama))
            {
                MessageBox.Show("Customer not found", "Error");
            }
            else
            {
                Program.custId = id_customer;
                groupBox2.Enabled = true;
                textBox2.Text = phone;
                textBox3.Text = email;

                //select tiket
                for (int i = 1; i < 6; i++)
                {
                    if (string.IsNullOrEmpty(mo.getValue("select * from ticket where seat_number=" + i + " and schedule_id=" + Program.schid, "seat_number")))
                    {
                        this.Controls.Find("button" + i, true)[0].BackColor = SystemColors.Control;
                        this.Controls.Find("button" + i, true)[0].Enabled = true;
                    }
                    else
                    {
                        this.Controls.Find("button" + i, true)[0].BackColor = Color.Red;
                        this.Controls.Find("button" + i, true)[0].Enabled = false;
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            seat_no = "1";
            if (check)
            {
                seat_numbers.Add("1");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            seat_no = "3";
            if (check)
            {
                seat_numbers.Add("3");
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            seat_no = "4";
            if (check)
            {
                seat_numbers.Add("4");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            seat_no = "2";
            if (check)
            {
                seat_numbers.Add("2");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked = true)
            {
                check = true;
            } else
            {
                check = false;
            }
        }
    }
}
