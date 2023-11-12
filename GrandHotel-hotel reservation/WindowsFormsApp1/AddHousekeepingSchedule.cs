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
    public partial class AddHousekeepingSchedule : Form
    {
        public Modul mo = new Modul();
        public AddHousekeepingSchedule()
        {
            InitializeComponent();
        }

        public void load()
        {
            tampil();

            comboBox2.DataSource = mo.getdata("SELECT * FROM [GrandHotel].[dbo].[VE] WHERE Role='Housekeeper'");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";

            comboBox1.DataSource = mo.getdata("SELECT TOP (1000) [ID]\r\n      ,[RoomTypeID]\r\n      ,[RoomFloor]\r\n      ,[Description]\r\n      ,[FlagKamar]\r\n      ,[FlagPesan]\r\n      ,[Name]\r\n      ,[Capacity]\r\n      ,[RoomPrice]\r\n      ,[RoomNumber]\r\n  FROM [GrandHotel].[dbo].[VROOM]");
            comboBox1.DisplayMember = "RoomNumber";
            comboBox1.ValueMember = "ID";
        }

        public void tampil()
        {
            //dataGridView3.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[Date]\r\n      ,[EmployeeID]\r\n      ,[Username]\r\n  FROM [GrandHotel].[dbo].[VCRE]");
            dataGridView3.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[Date]\r\n      ,[EmployeeID]\r\n      ,[Username]\r\n  FROM [GrandHotel].[dbo].[VCRE] WHERE EmployeeID='{comboBox2.SelectedValue}' AND Date='{dateTimePicker1.Value.ToString("yyyy/MM/dd")}'");
            if (dataGridView3.Columns.Count > 0)
            {
                dataGridView3.Columns["ID"].Visible = false;
                dataGridView3.Columns["EmployeeID"].Visible = false;
            }
        }

        private void AddHousekeepingSchedule_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            load();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampil();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mo.exc($"INSERT INTO [dbo].[CleaningRoom]\r\n           ([Date]\r\n           ,[EmployeeID])\r\n     VALUES\r\n           ('{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'\r\n           ,'{comboBox2.SelectedValue}')"))
            {
                int idcleaningroom = mo.getvalueint("SELECT [ID]\r\n      ,[Date]\r\n      ,[EmployeeID]\r\n  FROM [dbo].[CleaningRoom] ORDER BY ID DESC", "ID");
                //MessageBox.Show(idcleaningroom.ToString());
                if (mo.exc($"INSERT INTO [dbo].[CleanngRoomDetail]\r\n           ([CleaningRoomID]\r\n           ,[RoomID]\r\n           ,[StartDateTime]\r\n           ,[FinishDateTime]\r\n           ,[Note]\r\n           ,[StatusCleaning])\r\n     VALUES\r\n           ('{idcleaningroom}'\r\n           ,'{comboBox1.SelectedValue}'\r\n           ,'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'\r\n           ,''\r\n           ,''\r\n           ,'WAITING')"))
                {
                    MessageBox.Show("Data disimpan");
                    tampil();
                }
                else
                {
                    MessageBox.Show("Room iD tak dapat diproses");
                }
            } else
            {
                MessageBox.Show("DAta tak dapat diproses");
            }
        }
    }
}
