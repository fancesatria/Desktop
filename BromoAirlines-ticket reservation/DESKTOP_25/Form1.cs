using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP_25
{
    public partial class Form1 : Form
    {
        Modul mo = new Modul();
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pw = textBox2.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pw))
            {
                MessageBox.Show("Data harus diisi semua", "Error");
            } else
            {
                string sql = "select * from Akun where Username='" + name + "' and Password='" + pw + "'";
                if(mo.getCount(sql) == 0)
                {
                    MessageBox.Show("Email atau Passsword salah", "Error");
                } else
                {
                    Program.employee = mo.getValue(sql, "Nama");
                    Program.idemployee = mo.getValue(sql, "ID");

                    string admin = mo.getValue(sql, "MerupakanAdmin");
                    //MessageBox.Show()

                    if (admin == "True")
                    {
                        AdminForm a = new AdminForm();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        Program.namaCustomer = mo.getValue(sql, "Nama");
                        Program.idCustomer = mo.getValue(sql, "ID");
                        MainForm a = new MainForm();
                        a.Show();
                        this.Hide();
                    }


                }

            }

        }
    }
}
