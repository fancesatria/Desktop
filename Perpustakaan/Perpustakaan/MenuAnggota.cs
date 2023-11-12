using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class MenuAnggota : Form
    {
        public MenuAnggota()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CariBuku panggil = new CariBuku();
            panggil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HistoryPinjam panggil = new HistoryPinjam();
            panggil.Show();
        }
    }
}
