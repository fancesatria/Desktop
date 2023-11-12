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
    public partial class CleaningRoom : Form
    {
        public Modul mo = new Modul();
        public int idcleaningroom;
        public CleaningRoom()
        {
            InitializeComponent();
        }

        public void awal()
        {
            dataGridView3.DataSource = mo.getdata($"SELECT TOP(1000) [ID]\r\n      ,[Date]\r\n      ,[EmployeeID]\r\n      ,[Username]\r\n      ,[Email]\r\n      ,[Password]\r\n            FROM[GrandHotel].[dbo].[VCRE] WHERE EmployeeID='{Form1.idpetugas}'");
            dataGridView3.Columns["EmployeeID"].Visible = false;
            dataGridView3.Columns["ID"].Visible = false;
            dataGridView3.Columns["Password"].Visible = false;
        }

        private void CleaningRoom_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idcleaningroom = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                MessageBox.Show(idcleaningroom+"");

                dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [Date]\r\n      ,[EmployeeID]\r\n      ,[CleaningRoomID]\r\n      ,[RoomID]\r\n      ,[Username]\r\n      ,[StartDateTime]\r\n      ,[RoomNumber]\r\n      ,[RoomFloor]\r\n  FROM [GrandHotel].[dbo].[VCR] WHERE CleaningRoomID='{idcleaningroom}'");
                dataGridView1.Columns["EmployeeID"].Visible = false;
                dataGridView1.Columns["CleaningRoomID"].Visible = false;
                dataGridView1.Columns["RoomID"].Visible = false;
            }
        }
    }
}
