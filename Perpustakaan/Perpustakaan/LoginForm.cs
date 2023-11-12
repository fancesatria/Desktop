using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1;


namespace Perpustakaan
{
    public partial class LoginForm : Form
    {
        int salah = 0;
        string jam;
        bool status = true;


        Modul mod = new Modul();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Captcha();
        }

        private void Captcha()
        {
            //int length = 6;
            //const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            Random random = new Random();
            //var RandomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            int num = random.Next(6, 8);
            string captcha = "";
            int totl = 0;

            do
            {
                int chr = random.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha += (char)chr;
                    totl++;
                    if (totl == num)
                        break;
                    {

                    }

                }
            } while (true);
            boxcaptcha.Text = captcha;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //try
            //{
            //mod.Koneksi();
            //MessageBox.Show("berhasil yeayy");
            //mod.CloseKoneksi();
            //}
            //catch (Exception ex)
            //{
            //MessageBox.Show("gagal");
            //}

            if (boxcaptcha.Text == txtcaptcha.Text)
            {
                SqlConnection conn = new SqlConnection(@"SERVER=DESKTOP-2CLQ26N\SQLEXPRESS;Initial Catalog=DBPerpus;Integrated Security=True");
                //var sql = $"select * from [DBPerpus].[dbo].[tbluser] where username='{txtuser.Text}' and password='{txtpw.Text}'";
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("select count (*) from tbluser where username='" + txtuser.Text + "' and password='" + txtpw.Text + "'", conn);
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    var level = mod.getValue("select * from tbluser where level='level'");

                    ///ini nti ditambah ifelse kalau yg loin itu admin / pengunjung
                    //if (level.ToString() == "admin")
                    //{
                    //    this.Hide();
                    //    Admin panggil = new Admin();
                    //    panggil.Show();
                    //}
                    //else
                    //{
                    //    this.Hide();
                    //    MenuAnggota panggil = new MenuAnggota();
                    //    panggil.Show();

                    //}

                    MessageBox.Show(level);

                    this.Hide();
                    Admin panggil = new Admin();
                    panggil.Show();


                    // mod.getdata("select * from tbluser");


                }
                else
                {
                    MessageBox.Show("Mohon isi username dan password dengan benar!", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Masukkan captcha dengan benar!", "Perhatian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnLoad(e);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtcaptcha_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbcaptcha_Click(object sender, EventArgs e)
        {
            
        }

        private void btncaptcha_Click(object sender, EventArgs e)
        {
            Captcha();
        }

        private void boxcaptcha_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {//tunggu 2 menit
            if (1 < 5)
            {
                label5.Text = "Tunggu 2 menit";
            } else
            {
                label5.Text = "";
            }
        }
    }
}
