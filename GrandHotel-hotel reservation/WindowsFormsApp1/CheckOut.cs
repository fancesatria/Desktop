using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CheckOut : Form
    {
        public Modul mo = new Modul();
        public int idreservasiroom;
        public int totalitem, subtotalitem;
        public CheckOut()
        {
            InitializeComponent();
        }
        public void load()
        {
            comboBox3.DataSource = mo.getdata("SELECT *  FROM [GrandHotel].[dbo].[Room] WHERE FlagKamar=1 AND FlagPesan=1");
            comboBox3.DisplayMember = "RoomNumber";
            comboBox3.ValueMember = "RoomNumber";

            comboBox2.DataSource = mo.getdata("SELECT * FROM [GrandHotel].[dbo].[Item]");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";

            comboBox1.DataSource = mo.getdata("SELECT * FROM [GrandHotel].[dbo].[ItemStatus]");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            tampil();
            settotal();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
            load();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void tampil()
        {
            dataGridView3.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[ReservationID]\r\n      ,[RoomID]\r\n      ,[ReservationRoomID]\r\n      ,[ItemID]\r\n      ,[QTY]\r\n      ,[Name]\r\n      ,[TotalCharge]\r\n      ,[RoomNumber]\r\n  FROM [GrandHotel].[dbo].[VRI] WHERE RoomNumber='{comboBox3.SelectedValue}'");
            dataGridView3.Columns["ID"].Visible = false;
            dataGridView3.Columns["ReservationID"].Visible = false;
            dataGridView3.Columns["RoomID"].Visible = false;
            dataGridView3.Columns["ReservationRoomID"].Visible = false;
            dataGridView3.Columns["ItemID"].Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO [dbo].[ReservationRI]\r\n           ([ReservationRoomID]\r\n           ,[ItemID]\r\n           ,[QTY]\r\n           ,[TotalCharge])\r\n     VALUES\r\n           ('{idreservasiroom}'\r\n           ,'{comboBox2.SelectedValue}'\r\n           ,'{Convert.ToInt32(numericUpDown1.Value)}'\r\n           ,'{subtotalitem}')";
            if(mo.exc(sql)){
                MessageBox.Show("Item ditambah");
                tampil();
                settotal() ;
            }
            else
            {
                MessageBox.Show("Item gagal ditambah");
            }

        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO [dbo].[ReservationCO]\r\n           ([ReservationRoomID]\r\n           ,[ItemID]\r\n           ,[ItemStatusID]\r\n           ,[QTY]\r\n           ,[TotalCharge])\r\n     VALUES\r\n           ('{idreservasiroom}'\r\n           ,'{comboBox2.SelectedValue}'\r\n           ,'{comboBox1.SelectedValue}'\r\n           ,'{Convert.ToInt32(numericUpDown1.Value)}'\r\n           ,'{Convert.ToInt32(label8.Text)}')";
            if (mo.exc(sql))
            {
                MessageBox.Show("Checkout Berhasil");
            }
            else
            {
                MessageBox.Show("Checkout gagal");
            }
        }

        public void settotal()
        {
            string cek = $"SELECT * FROM [GrandHotel].[dbo].[ReservationRI] WHERE ReservationRoomID='{idreservasiroom}'";
            if(mo.exc(cek))
            {
                totalitem = mo.getvalueint($"SELECT SUM(TotalCharge) AS Totals FROM [GrandHotel].[dbo].[ReservationRI] WHERE ReservationRoomID='{idreservasiroom}'", "totals");
                label8.Text = totalitem.ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int hargaitem = mo.getvalueint($"SELECT * FROM [GrandHotel].[dbo].[Item] WHERE ID={comboBox2.SelectedValue}", "RequestPrice");
            subtotalitem = (int)(numericUpDown1.Value * hargaitem);
            //label8.Text = subtotalitem.ToString();
            settotal();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampil();
            string sql = $"SELECT TOP (1000) [ID]\r\n      ,[ReservationID]\r\n      ,[RoomID]\r\n      ,[ReservationRoomID]\r\n      ,[ItemID]\r\n      ,[QTY]\r\n      ,[Name]\r\n      ,[TotalCharge]\r\n      ,[RoomNumber]\r\n  FROM [GrandHotel].[dbo].[VRI] WHERE RoomNumber='{comboBox3.SelectedValue}'";
            idreservasiroom = mo.getvalueint(sql, "ReservationRoomID");
            settotal();
        }
    }
}
