using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class Peminjaman : Form
    {
        public Peminjaman()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TambahPinjam panggil = new TambahPinjam();
            panggil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetailPinjam panggil = new DetailPinjam();
            panggil.Show();
        }
    }
}
