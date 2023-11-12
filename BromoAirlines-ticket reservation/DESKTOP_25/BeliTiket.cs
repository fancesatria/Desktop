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
    public partial class BeliTiket : Form
    {
        Modul mo = new Modul();
        public BeliTiket()
        {
            InitializeComponent();

            List<string> filter = new List<string>();
            filter.Add("Tuan");
            filter.Add("Nyonya");

            label5.Text = Program.be;
            label12.Text = Program.tu;
            label13.Text = Program.jumlahPenumpang + " Penumpang";
            label3.Text = mo.getValue("select * from Maskapai where ID="+Program.maskapai, "Nama");
            label9.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label10.Text = DateTime.Now.ToString("HH:mm");
            label16.Text = Convert.ToString(Convert.ToInt32(Program.maskapai)+ Convert.ToInt32(Program.jumlahPenumpang));

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(filter.ToArray());

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(filter.ToArray());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }
    }
}
