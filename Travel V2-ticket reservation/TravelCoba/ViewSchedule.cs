using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCoba
{
    public partial class ViewSchedule : Form
    {
        Modul mo = new Modul();
        string viewSchedule = "SELECT dbo.schedule.*, dbo.pool.city, dbo.pool.name\r\nFROM     dbo.schedule LEFT JOIN\r\n                  dbo.pool ON dbo.schedule.departure_pool_id = dbo.pool.id AND dbo.schedule.arrival_pool_id = dbo.pool.id";
        public ViewSchedule()
        {
            InitializeComponent();
        }

        private void ViewSchedule_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            comboBox1.DataSource = mo.getData("SELECT TOP (1000) [id]\r\n      ,[city]\r\n      ,[name]\r\n      ,[created_at]\r\n      ,[updated_at]\r\n      ,[deleted_at]\r\n  FROM [ESEMKATravel].[dbo].[pool]");
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";

            comboBox2.DataSource = mo.getData("SELECT TOP (1000) [id]\r\n      ,[city]\r\n      ,[name]\r\n      ,[created_at]\r\n      ,[updated_at]\r\n      ,[deleted_at]\r\n  FROM [ESEMKATravel].[dbo].[pool]");
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";

            cari(0,0);
        }

        public void cari(int a, int b)
        {
            //select departure masukin alias, select arrival masukin alias, terus gabungin
            string departure = "SELECT dbo.schedule.id, dbo.schedule.car_id, dbo.schedule.departure_time, dbo.schedule.departure_pool_id, dbo.schedule.capacity, dbo.schedule.price, dbo.pool.city, dbo.pool.name FROM     dbo.schedule LEFT JOIN                  dbo.pool ON dbo.schedule.departure_pool_id = dbo.pool.id";
            string arrival = "SELECT dbo.schedule.id, dbo.schedule.car_id, dbo.schedule.capacity, dbo.schedule.price, dbo.pool.city, dbo.pool.name, dbo.schedule.arrival_pool_id, dbo.schedule.arrival_time FROM     dbo.schedule LEFT JOIN                  dbo.pool ON dbo.schedule.arrival_pool_id = dbo.pool.id";

            if (a==0 || b ==0)
            {
                string sql = "SELECT a.id, a.departure_pool_id, a.departure_time,a.name as departurePool,b.arrival_pool_id, b.arrival_time, b.name as arrivalPool, a.capacity,a.price FROM ("+departure+")a LEFT JOIN ("+arrival+")b ON a.car_id=b.car_id WHERE a.name<>b.name";
                dataGridView1.DataSource = mo.getData(sql);

            } else
            {
                string sql = $"SELECT a.id, a.departure_pool_id, a.departure_time,a.name as departurePool,b.arrival_pool_id, b.arrival_time, b.name as arrivalPool, a.capacity, a.price FROM ("+departure+")a LEFT JOIN (" +arrival+")b ON a.car_id=b.car_id WHERE a.departure_pool_id="+a+" AND b.arrival_pool_id="+b+" AND a.name<>b.name";
                dataGridView1.DataSource = mo.getData(sql);
            }

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["departure_pool_id"].Visible = false;
            dataGridView1.Columns["arrival_pool_id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cari(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.schid = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].FormattedValue.ToString();
            Program.capacity = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["capacity"].FormattedValue.ToString();
            Program.price = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["price"].FormattedValue.ToString();

            if (Program.capacity == "5")
            {
                ViewScheduleDetail1 s = new ViewScheduleDetail1();
                s.Show();
                this.Hide();
            }
            else
            {
                ViewScheduleDetail2 s = new ViewScheduleDetail2();
                s.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.schid = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["id"].FormattedValue.ToString();
            Program.capacity = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["capacity"].FormattedValue.ToString();
            Program.price = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["price"].FormattedValue.ToString();

            if (Program.capacity == "5")
            {
                BookTransaction1 s = new BookTransaction1();
                s.Show();
                this.Hide();
            } else
            {
                BookTransaction2 s = new BookTransaction2();
                s.Show();
                this.Hide();
            }
        }
    }
}
