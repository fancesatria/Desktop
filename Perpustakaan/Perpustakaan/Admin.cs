using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1;

namespace Perpustakaan
{
    public partial class Admin : Form
    {
        Modul mo = new Modul();
        public Admin()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anggota panggil = new Anggota();
            panggil.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterBuku panggil = new MasterBuku();
            panggil.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Petugas panggil = new Petugas();
            panggil.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lokasi panggil = new Lokasi();
            panggil.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Kategori panggil = new Kategori();
            panggil.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ManajemenUser panggil = new ManajemenUser();
            panggil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Peminjaman panggil = new Peminjaman();
            panggil.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pengembalian panggil = new Pengembalian();
            panggil.Show();
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            LoginForm panggil = new LoginForm();
            panggil.Show();
        }
    }
}
