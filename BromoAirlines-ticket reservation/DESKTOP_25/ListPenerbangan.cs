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
    public partial class ListPenerbangan : Form
    {
        Modul mo = new Modul();
        string brkt = $"SELECT dbo.JadwalPenerbangan.ID, dbo.JadwalPenerbangan.KodePenerbangan, dbo.JadwalPenerbangan.BandaraKeberangkatanID, dbo.JadwalPenerbangan.BandaraTujuanID, dbo.JadwalPenerbangan.MaskapaiID, dbo.JadwalPenerbangan.TanggalWaktuKeberangkatan, \r\n             dbo.JadwalPenerbangan.DurasiPenerbangan, dbo.JadwalPenerbangan.HargaPerTiket, dbo.Maskapai.Nama, dbo.Bandara.Nama AS Berangkat\r\nFROM   dbo.JadwalPenerbangan LEFT JOIN\r\n             dbo.Maskapai ON dbo.JadwalPenerbangan.MaskapaiID = dbo.Maskapai.ID LEFT JOIN\r\n             dbo.Bandara ON dbo.JadwalPenerbangan.BandaraKeberangkatanID = dbo.Bandara.ID AND dbo.JadwalPenerbangan.BandaraKeberangkatanID = dbo.Bandara.ID";
        string tj = $"SELECT dbo.JadwalPenerbangan.ID, dbo.JadwalPenerbangan.KodePenerbangan, dbo.JadwalPenerbangan.BandaraKeberangkatanID, dbo.JadwalPenerbangan.BandaraTujuanID, dbo.JadwalPenerbangan.MaskapaiID, dbo.JadwalPenerbangan.TanggalWaktuKeberangkatan, \r\n             dbo.JadwalPenerbangan.DurasiPenerbangan, dbo.JadwalPenerbangan.HargaPerTiket, dbo.Maskapai.Nama, dbo.Bandara.Nama AS Tujuan\r\nFROM   dbo.JadwalPenerbangan LEFT JOIN\r\n             dbo.Maskapai ON dbo.JadwalPenerbangan.MaskapaiID = dbo.Maskapai.ID LEFT JOIN\r\n             dbo.Bandara ON dbo.JadwalPenerbangan.BandaraTujuanID = dbo.Bandara.ID AND dbo.JadwalPenerbangan.BandaraTujuanID = dbo.Bandara.ID";
        public ListPenerbangan()
        {
            InitializeComponent();
            cari();
            label5.Text = Program.be;
            label12.Text = Program.tu;
            label13.Text = Program.tgl;
            label14.Text = Program.jumlahPenumpang;
            button1.Enabled = false;

        }

        public void cari()
        {

            dataGridView1.DataSource = mo.getData($"select a.ID, a.KodePenerbangan, a.TanggalWaktuKeberangkatan, a.Berangkat ,b.Tujuan, a.HargaPerTiket from ({brkt})a left join ({tj})b on a.MaskapaiID=b.MaskapaiID where a.Berangkat='"+Program.be+"' and b.Tujuan='"+Program.tu+"' order by a.HargaPerTiket asc");
            dataGridView1.Columns["ID"].Visible = false;

            List<string> filter = new List<string>();
            filter.Add("Harga Terendah");
            filter.Add("Harga Teringgi");

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(filter.ToArray());

            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = mo.getData($"select a.ID, a.KodePenerbangan, a.TanggalWaktuKeberangkatan, a.Berangkat ,b.Tujuan, a.HargaPerTiket from ({brkt})a left join ({tj})b on a.MaskapaiID=b.MaskapaiID where a.Berangkat='" + Program.be + "' and b.Tujuan='" + Program.tu + "' order by a.HargaPerTiket asc");
                dataGridView1.Columns["ID"].Visible = false;
            } else {

                dataGridView1.DataSource = mo.getData($"select a.ID, a.KodePenerbangan, a.TanggalWaktuKeberangkatan, a.Berangkat ,b.Tujuan, a.HargaPerTiket from ({brkt})a left join ({tj})b on a.MaskapaiID=b.MaskapaiID where a.Berangkat='" + Program.be + "' and b.Tujuan='" + Program.tu + "' order by a.HargaPerTiket desc");
                dataGridView1.Columns["ID"].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BeliTiket b = new BeliTiket();
            b.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                button1.Enabled = true;
                Program.maskapai = dataGridView1.Rows[e.RowIndex].Cells["HargaPerTiket"].FormattedValue.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = mo.getData($"select a.ID, a.KodePenerbangan, a.TanggalWaktuKeberangkatan, a.Berangkat ,b.Tujuan, a.HargaPerTiket from ({brkt})a left join ({tj})b on a.MaskapaiID=b.MaskapaiID where a.Berangkat='" + Program.be + "' and b.Tujuan='" + Program.tu + "' order by a.HargaPerTiket asc");
                dataGridView1.Columns["ID"].Visible = false;
            }
            else
            {

                dataGridView1.DataSource = mo.getData($"select a.ID, a.KodePenerbangan, a.TanggalWaktuKeberangkatan, a.Berangkat ,b.Tujuan, a.HargaPerTiket from ({brkt})a left join ({tj})b on a.MaskapaiID=b.MaskapaiID where a.Berangkat='" + Program.be + "' and b.Tujuan='" + Program.tu + "' order by a.HargaPerTiket desc");
                dataGridView1.Columns["ID"].Visible = false;
            }
        }
    }
}
