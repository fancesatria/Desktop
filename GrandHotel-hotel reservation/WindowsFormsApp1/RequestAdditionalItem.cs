using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class RequestAdditionalItem : Form
    {

        public Modul mo = new Modul();
        public int idreservasiroom, totalitem, subtotalitem;
        public RequestAdditionalItem()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public void awal()
        {
            comboBox1.DataSource = mo.getdata("SELECT * FROM [GrandHotel].[dbo].[Room] WHERE FlagKamar=1 AND FlagPesan=1");
            comboBox1.DisplayMember = "RoomNumber";
            comboBox1.ValueMember = "RoomNumber";

            comboBox2.DataSource = mo.getdata("SELECT * FROM [GrandHotel].[dbo].[Item]");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";

            //tampil();

        }

        public void tampil()
        {
            dataGridView3.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[ReservationID]\r\n      ,[RoomID]\r\n      ,[ReservationRoomID]\r\n      ,[ItemID]\r\n      ,[QTY]\r\n      ,[Name]\r\n      ,[TotalCharge]\r\n      ,[RoomNumber]\r\n  FROM [GrandHotel].[dbo].[VRI] WHERE RoomNumber='{comboBox1.SelectedValue}'");
            dataGridView3.Columns["ID"].Visible = false;
            dataGridView3.Columns["ReservationID"].Visible = false;
            dataGridView3.Columns["RoomID"].Visible = false;
            dataGridView3.Columns["ReservationRoomID"].Visible = false;
            dataGridView3.Columns["ItemID"].Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampil();
            string cek = $"SELECT TOP (1000) [ID]\r\n      ,[ReservationID]\r\n      ,[RoomID]\r\n      ,[ReservationRoomID]\r\n      ,[ItemID]\r\n      ,[QTY]\r\n      ,[Name]\r\n      ,[TotalCharge]\r\n      ,[RoomNumber]\r\n  FROM [GrandHotel].[dbo].[VRI] WHERE RoomNumber='{comboBox1.SelectedValue}'";
            idreservasiroom = mo.getvalueint(cek, "ReservationRoomID");
            settotal();

        }

        private void RequestAdditionalItem_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int hargaitem = mo.getvalueint($"SELECT * FROM Item WHERE ID={comboBox2.SelectedValue}", "RequestPrice");
            subtotalitem = (int)(numericUpDown1.Value * hargaitem);
            settotal();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data disimpan");
            awal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mo.exc($"INSERT INTO [dbo].[ReservationRI]\r\n           ([ReservationRoomID]\r\n           ,[ItemID]\r\n           ,[QTY]\r\n           ,[TotalCharge]\r\n )\r\n     VALUES\r\n           ('{idreservasiroom}'\r\n           ,'{comboBox2.SelectedValue}'\r\n           ,'{Convert.ToInt32(numericUpDown1.Value)}'\r\n           ,'{subtotalitem}'\r\n)"))
            {
                MessageBox.Show("Item berhasil ditambah");
                settotal(); //merefresh tampilan total
                tampil();//merefresh dgv
            } else
            {
                MessageBox.Show("Item gagal ditambah");
            }
        }

        public void settotal()
        {
            totalitem = mo.getvalueint($"SELECT SUM(TotalCharge) AS Total FROM [GrandHotel].[dbo].[VRI] WHERE ReservationRoomID={idreservasiroom}", "Total");
            label8.Text = totalitem.ToString();
        }
    }
}
