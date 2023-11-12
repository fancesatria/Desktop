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
    public partial class MainForm : Form
    {
        Modul mo = new Modul();
        public MainForm()
        {
            InitializeComponent();
            label3.Text = Program.namaCustomer;
            mo.autoCompleteTextBox(textBox1, "select * from Bandara", "Nama");
            mo.autoCompleteTextBox(textBox3, "select * from Bandara", "Nama");

            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TiketSaya t = new TiketSaya();
            t.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (mo.dialog("Anda ingin keluar?"))
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.idBerangkat = mo.getValue("select * from Bandara where Nama='" + textBox1.Text + "'", "ID");
            Program.idTujuan = mo.getValue("select * from Bandara where Nama='" + textBox3.Text + "'", "ID");
            Program.jumlahPenumpang = numericUpDown1.Value+"";
            Program.tgl = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            Program.be = textBox1.Text;
            Program.tu = textBox3.Text;

            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("ISi data dulu");
            }
            else
            {
                ListPenerbangan form = new ListPenerbangan();
                form.Show();
                this.Hide();
            }
        }
    }
}
