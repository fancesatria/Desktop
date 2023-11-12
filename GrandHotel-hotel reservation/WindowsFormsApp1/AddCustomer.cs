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
    public partial class AddCustomer : Form
    {
        public Modul mo = new Modul();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox2))
            {
                MessageBox.Show("Pastikan data terisi semua");
            } else
            {
                if (mo.isEmail(textBox1.Text))
                {
                    string s;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        s = "L";
                    }
                    else {
                        s = "P";
                    }

                    string age = mo.getvalue($"SELECT DATEDIFF (YEAR, '{dateTimePicker1.Value.ToString("yyyy/MM/dd")}', GETDATE()) as age", "age");
                    string sql = $"INSERT INTO [dbo].[Customer]\r\n           ([Name]\r\n           ,[NIK]\r\n           ,[Gender]\r\n           ,[PhoneNumber]\r\n           ,[Age],[Email])\r\n     VALUES\r\n           ('{textBox4.Text}'\r\n           ,'{textBox5.Text}'\r\n           ,'{s}'\r\n           ,'{textBox3.Text}'\r\n           ,'{Convert.ToInt32(age)}',\r\n\t\t   '{textBox1.Text}')";

                    if (mo.exc(sql))
                    {
                        MessageBox.Show("Data disimpan");
                    } else
                    {
                        MessageBox.Show("Data gagal disimpan");
                    }
                } else
                {
                    MessageBox.Show("Masukkan email yang valid");
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void AddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reservation r =new Reservation();
            r.Show();
            this.Hide();
        }
    }
}
