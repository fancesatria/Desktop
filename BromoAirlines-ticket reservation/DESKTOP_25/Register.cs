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
    public partial class Register : Form
    {
        Modul mo = new Modul();
        bool admin = false;
        public Register()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 f  = new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                if (textBox2.TextLength < 8)
                {
                    MessageBox.Show("Pasword terdiri dari minimal 8 digit");
                } else
                {
                    if (textBox5.TextLength < 10 || textBox5.TextLength > 15)
                    {
                        MessageBox.Show("Nomor telepon minim 10 digit dan maksimal 15 digit");
                    }
                    else
                    {
                        if (mo.exc($"insert into Akun values('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', '{textBox5.Text}', '{1}') "))
                        {
                            MessageBox.Show("Akun berhasil dibuat");
                            AdminForm m = new AdminForm();
                            m.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Gagal membuat akun");
                        }
                    }
                }
            } else
            {
                if (textBox2.TextLength < 8)
                {
                    MessageBox.Show("Password terdir dari minimal 8 digit ");
                } else
                {
                    if (textBox5.TextLength < 10 || textBox5.TextLength > 15)
                    {
                        MessageBox.Show("Nomor telepon minim 10 digit dan maksimal 15 digit");
                    }
                    else
                    {
                        if (mo.exc($"insert into Akun values('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', '{textBox5.Text}', '{0}') "))
                        {
                            MessageBox.Show("Akun berhasil dibuat");
                            MainForm m = new MainForm();
                            m.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Gagal membuat akun");
                        }
                    }
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlyNumber(e);
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                admin = true;
            } else
            {
                admin = false;
            }
        }
    }
}
