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
    public partial class Form1 : Form
    {
        Modul mo = new Modul();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            string sql = $"select * from employee where email='{email}' and password='{password}'";

            if (string.IsNullOrEmpty("email") || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email and Password can't be empty", "Error");
;           } else
            {
                if (mo.isEmail(email))
                {
                    //set name and role,a nd check if name is empty or no
                    string name = mo.getValue(sql, "name");
                    string role = mo.getValue(sql, "role");
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Email or Password wrong", "Error");
                    }
                    else
                    {
                        Program.EmpName = name;
                        Program.role = role;

                        Form2 f = new Form2();
                        f.Show();
                        this.Hide();
                    }
                } else
                {
                    MessageBox.Show("Email invalid", "Error");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mo.autoCompleteTextBox(textBox1, "select * from employee","email");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //mo.autoCompleteTextBox(textBox1, "select * from employee", "email");
        }
    }
}
