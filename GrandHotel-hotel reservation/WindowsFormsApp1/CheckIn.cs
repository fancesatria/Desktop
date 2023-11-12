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
    public partial class CheckIn : Form
    {
        public Modul mo = new Modul();
        public int idreservasi;
        public CheckIn()
        {
            InitializeComponent();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tampil();
                string sql = $"SELECT * FROM [dbo].[Reservation] WHERE Code='{textBox6.Text}'";
                if (mo.getcount(sql) == 0)
                {
                    MessageBox.Show("Kode Booking tidak ada");

                } else
                {
                    string cust = $"SELECT * FROM [dbo].[Customer] WHERE ID='{mo.getvalueint(sql, "CustomerID")}'";
                    idreservasi = mo.getvalueint(sql, "ID");
                    textBox1.Text = mo.getvalue(cust, "PhoneNumber");
                    textBox2.Text = mo.getvalue(cust, "Name");
                    textBox3.Text = mo.getvalue(cust, "Email");
                    textBox4.Text = mo.getvalue(cust, "Age");
                    textBox5.Text = mo.getvalue(cust, "NIK");
                    string gender = mo.getvalue(cust, "Gender");
                    if (gender == "L")
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 1;
                    }
                }
            }
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {

        }

        public void load()
        {

        }

        public void tampil()
        {
            dataGridView1.DataSource = mo.getdata($"SELECT * FROM [dbo].[Reservation] WHERE Code='{textBox6.Text}'");
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["EmployeeID"].Visible = false;
            dataGridView1.Columns["CustomerID"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mo.exc($"UPDATE [dbo].[ReservationRoom] SET [CheckinDatetime] = getdate() WHERE ReservationID='{idreservasi}'"))
            {
                MessageBox.Show("CheckIn Berhasil");
                mo.clearform(groupBox2);
            } else
            {
                MessageBox.Show("CheckIn Gagal");
            }
        }
    }
}
