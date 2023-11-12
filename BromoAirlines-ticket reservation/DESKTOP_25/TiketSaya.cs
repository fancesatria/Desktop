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
    public partial class TiketSaya : Form
    {
        Modul mo = new Modul();
        public TiketSaya()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void TiketSaya_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mo.getData("SELECT dbo.TransaksiHeader.ID, dbo.TransaksiHeader.AkunID, dbo.TransaksiHeader.TanggalTransaksi, dbo.TransaksiHeader.JadwalPenerbanganID, dbo.TransaksiDetail.TransaksiHeaderID, dbo.TransaksiDetail.TitelPenumpang, dbo.TransaksiDetail.NamaLengkapPenumpang, \r\n             dbo.Akun.Username, dbo.Akun.Nama\r\nFROM   dbo.TransaksiDetail INNER JOIN\r\n             dbo.TransaksiHeader ON dbo.TransaksiDetail.TransaksiHeaderID = dbo.TransaksiHeader.ID INNER JOIN\r\n             dbo.Akun ON dbo.TransaksiHeader.AkunID = dbo.Akun.ID WHERE AkunID="+Program.idCustomer);
            dataGridView1.Columns["ID"].Visible = false ;
            dataGridView1.Columns["AkunID"].Visible = false ;
        }
    }
}
