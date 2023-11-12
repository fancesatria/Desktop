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
    public partial class UbahStatus : Form
    {
        Modul mo = new Modul();

        public UbahStatus()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[JadwalPenerbanganID]\r\n      ,[StatusPenerbanganID]\r\n      ,[WaktuPerubahanTerjadi]\r\n      ,[PerkiraanDurasiDelay]\r\n  FROM [BromoAirlines].[dbo].[PerubahanStatusJadwalPenerbangan]");
            dataGridView1.Columns["ID"].Visible = false;

            comboBox3.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Nama]\r\n  FROM [BromoAirlines].[dbo].[StatusPenerbangan]");
            comboBox3.DisplayMember = "Nama";
            comboBox3.ValueMember = "ID";

            label2.Visible = false;
            dateTimePicker1.Visible = false;



        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 2)
            {
                label2.Visible = true;
                dateTimePicker1.Visible = true;
            } else
            {
                label2.Visible = false;
                dateTimePicker1.Visible = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
