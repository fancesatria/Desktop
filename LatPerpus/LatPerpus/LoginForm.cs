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


namespace LatPerpus
{
    public partial class LoginForm : Form
    {
        
        SqlConnection conn = new SqlConnection(@"DataSource=DESKTOP-2CLQ26N\SQLEXPRESS;Initial Catalog=DBPerpus;Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            try
            {
                conn.Open();
                MessageBox.Show("Koneksi berhasil");
                conn.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("KOneksi ggal");
            }
        }
    }
}
