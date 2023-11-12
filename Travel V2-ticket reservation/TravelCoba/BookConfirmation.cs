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
    public partial class BookConfirmation : Form
    {
        Modul mo = new Modul();
        public BookConfirmation()
        {
            InitializeComponent();
        }

        private void BookConfirmation_Load(object sender, EventArgs e)
        {
            string sql = "select * from schedule where id=" + Program.schid;
            string departure_id = mo.getValue(sql, "departure_pool_id");
            string arrival_id = mo.getValue(sql, "arrival_pool_id");


            //departure
            textBox7.Text = mo.getValue("select * from pool where id=" + departure_id, "name");
            textBox4.Text = mo.getValue(sql, "departure_time");
             //arrival
            textBox9.Text = mo.getValue("select * from pool where id="+arrival_id,"name");
            textBox8.Text = mo.getValue(sql, "arrival_time");
            //seat
            if (BookTransaction1.check || BookTransaction2.check)
            {
                textBox6.Text = Program.cust_seat_numbers;
                var total_price = Convert.ToInt32(Program.cust_seat_numbers.Count()) * Convert.ToDecimal(mo.getValue(sql, "price"));
                textBox5.Text = total_price+"";
            }else
            {
                textBox6.Text = Program.cust_seat_number;
                textBox5.Text = mo.getValue(sql, "price");
            }
            //passenger
            textBox1.Text = Program.cust_name;
            textBox2.Text = Program.cust_phone;
            textBox3.Text = Program.cust_email;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BookTransaction1.check || BookTransaction2.check)
            {
                //ubah nomer seat ke int
                List<int> Converted_seat = Program.cust_seat_numbers.Split(',', (char)StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                foreach (var i in Converted_seat)
                {
                    //kalau pake format string, jadiny a 1 0 1 1(10,11), makanya datanya ga muncul
                    string sql = $"insert into ticket (schedule_id, customer_id, seat_number) values ({Program.schid},{Program.custId}, {i+" "})";
                    if (mo.excNonMessage(sql))
                    {
                        MessageBox.Show("Data saved", "Information");
                        //MessageBox.Show(i + "");
                        //MessageBox.Show(Program.cust_seat_numbers);
                        this.Close();
                        if (Program.capacity == "5")
                        {
                            BookTransaction1 ts = new BookTransaction1();
                            ts.Hide();
                        }
                        else
                        {
                            BookTransaction2 ts = new BookTransaction2();
                            ts.Hide();
                        }
                    }
                }

            } else
            {
                string sql = $"insert into ticket (schedule_id, customer_id, seat_number) values ({Program.schid},{Program.custId}, {Program.cust_seat_number})";
                if (mo.exc(sql))
                {
                    MessageBox.Show("Data saved", "Information");
                    this.Close();
                    if (Program.capacity == "5")
                    {
                        BookTransaction1 ts = new BookTransaction1();
                        ts.Hide();
                    }
                    else
                    {
                        BookTransaction2 ts = new BookTransaction2();
                        ts.Hide();
                    }
                }
            }
        }

        private void BookConfirmation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            if (Program.capacity == "5")
            {
                BookTransaction1 ts = new BookTransaction1();
                ts.Close();
            }
            else
            {
                BookTransaction2 ts = new BookTransaction2();
                ts.Close();
            }
        }
    }
}
