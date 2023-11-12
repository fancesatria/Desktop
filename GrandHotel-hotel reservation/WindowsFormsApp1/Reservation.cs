using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Reservation : Form
    {
        public Modul mo = new Modul();
        public int totalkamar;
        public int totalitem;
        public int roomprice;
        public int totalsemua;
        public int idcustomer;
        public int idreservasi, idresroom;
        
        public Reservation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[RoomTypeID]\r\n      ,[RoomNumber]\r\n      ,[RoomFloor]\r\n      ,[Description]\r\n      ,[FlagKamar]\r\n      ,[FlagPesan]\r\n  FROM [GrandHotel].[dbo].[Room] WHERE FlagKamar = 0 AND FlagPesan=0 AND RoomTypeID='{comboBox1.SelectedValue}'");
            if(dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["RoomTypeID"].Visible = false;
            }
        }

        public void awal()
        {
            comboBox1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n      ,[Capacity]\r\n      ,[RoomPrice]\r\n  FROM [GrandHotel].[dbo].[RoomType]");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";


            dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[RoomTypeID]\r\n      ,[RoomNumber]\r\n      ,[RoomFloor]\r\n      ,[Description]\r\n      ,[FlagKamar]\r\n      ,[FlagPesan]\r\n  FROM [GrandHotel].[dbo].[Room] WHERE FlagKamar = 0 AND FlagPesan=0");
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["RoomTypeID"].Visible = false;
            }

            dataGridView2.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[RoomTypeID]\r\n      ,[RoomNumber]\r\n      ,[RoomFloor]\r\n      ,[Description]\r\n      ,[FlagKamar]\r\n      ,[FlagPesan]\r\n      ,[Name]\r\n      ,[Capacity]\r\n      ,[RoomPrice]\r\n  FROM [GrandHotel].[dbo].[VFlagPesan]");
            if (dataGridView2.Columns.Count > 0)
            {
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["RoomTypeID"].Visible = false;
            }

            //item();
            //setsubtotalitem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count > 0)
            {
                string sql = $"UPDATE [dbo].[Room] SET [FlagPesan] = 1 WHERE ID='{Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}'";
                if (mo.exc(sql))
                {
                    awal();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddCustomer c = new AddCustomer();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE [dbo].[Room] SET [FlagPesan] = 0 WHERE ID='{Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}'";
            if (mo.exc(sql))
            {
                awal();
            }
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            awal();
            groupBox3.Enabled = false;
        }

        public void item()
        {
            string sql = $"SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n      ,[RequestPrice]\r\n      ,[CompensationFee]\r\n  FROM [GrandHotel].[dbo].[Item]";
            comboBox2.DataSource = mo.getdata(sql);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";

            dataGridView3.DataSource = mo.getdata("SELECT * FROM VRI");
            dataGridView3.Columns["ID"].Visible = false;
            dataGridView3.Columns["RoomID"].Visible = false;
            dataGridView3.Columns["RoomID"].Visible = false;
            dataGridView3.Columns["ReservationRoomID"].Visible = false;
            dataGridView3.Columns["ItemID"].Visible = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = $"SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n      ,[RequestPrice]\r\n      ,[CompensationFee]\r\n  FROM [GrandHotel].[dbo].[Item] WHERE ID='{comboBox2.SelectedValue}'";
            textBox5.Text = Convert.ToString(mo.getvalueint(sql, "RequestPrice"));
            setsubtotalitem();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        public void setsubtotalitem()
        {
            int price = Convert.ToInt32(textBox5.Text);
            textBox6.Text = Convert.ToString(numericUpDown1.Value * price);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            setsubtotalitem();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                string sql = $"SELECT * FROM [GrandHotel].[dbo].[Customer] WHERE PhoneNumber='{textBox3.Text}'";
                if (mo.getcount(sql)>0)
                {
                    textBox4.Text = mo.getvalue(sql, "Name");
                    idcustomer = mo.getvalueint(sql, "ID");
                } else
                {
                    MessageBox.Show("Customer tidak ditemukan, pastikan nomor telepon sudah benar atau tambah customer baru");
                }
            }
        }


        public void settotalhargakamar()
        {
            if(mo.getcount("SELECT * FROM [GrandHotel].[dbo].[VFlagPesan]") == 0)
            {
                label8.Text = "0";
            } else
            {
                label8.Text = Convert.ToString(mo.getvalueint("SELECT SUM(RoomPrice) as hargakamar FROM VFlagPesan", "hargakamar") * Convert.ToInt32(numericUpDown2.Value));
                totalkamar = Convert.ToInt32(label8.Text);
                
            }
        }

        public int settotalitem()
        {
            return mo.getvalueint("SELECT SUM(TotalCharge) as totalitem FROM VRI", "totalitem") * Convert.ToInt32(numericUpDown2.Value);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            settotalhargakamar();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            settotalhargakamar();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            setsubtotalitem();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            settotalhargakamar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox3))
            {
                MessageBox.Show("Harap isi semua");

            } else
            {
                if (dataGridView2.SelectedCells.Count > 0)
                {
                    idreservasi = mo.getvalueint("SELECT * FROM Reservation ORDER BY ID DESC", "ID");
                    idresroom = mo.getvalueint($"SELECT * FROM ReservationRoom WHERE ReservationID='{idreservasi}' AND RoomID='{Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}'", "ID");
                    string sql = $"INSERT INTO [dbo].[ReservationRI]\r\n           ([ReservationRoomID]\r\n           ,[ItemID]\r\n           ,[QTY]\r\n           ,[TotalCharge])\r\n     VALUES\r\n           ('{idresroom}'\r\n           ,'{comboBox2.SelectedValue}'\r\n           ,'{numericUpDown1.Value}'\r\n           ,'{Convert.ToInt32(textBox6.Text)}')";
                    if (mo.exc(sql))
                    {
                        item();
                        label8.Text = Convert.ToString(totalkamar + settotalitem());
                    }
                    else
                    {
                        MessageBox.Show(idresroom.ToString());
                    }
                } else
                {
                    MessageBox.Show("Pilih kamar dulu");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(mo.dialog("Yakin ingin menghapus data ini?"))
            {
                if (mo.exc($"DELETE FROM [dbo].[ReservationRI] WHERE ID='{Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}'"))
                {
                    item();
                    label8.Text = Convert.ToString(totalkamar + settotalitem());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "SELECT TOP (1000) [ID]\r\n      ,[RoomTypeID]\r\n      ,[RoomNumber]\r\n      ,[RoomFloor]\r\n      ,[Description]\r\n      ,[FlagKamar]\r\n      ,[FlagPesan]\r\n  FROM [GrandHotel].[dbo].[Room] WHERE FlagPesan=1 AND FlagKamar=0";

            if (mo.getcount(sql) ==0)
            {
                MessageBox.Show("Pilih kamar terlebih dahulu");
            } else  {

                if (mo.exc($"INSERT INTO [dbo].[Reservation]\r\n           ([EmployeeID]\r\n           ,[CustomerID]\r\n           ,[Code]\r\n           ,[Datetime])\r\n     VALUES\r\n           ('{Form1.idpetugas}'\r\n           ,'{idcustomer}'\r\n           ,'{mo.buatid("RES","SELECT * FROM Reservation")}'\r\n           ,'{dateTimePicker1.Value.ToString("yyyy/MM/dd")}')"))
                {
                    int idreservasi = mo.getvalueint("SELECT * FROM Reservation ORDER BY ID DESC", "ID");
                    
                    for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
                    {
                        Debug.WriteLine($"INSERT INTO [dbo].[ReservationRoom]\r\n           ([ReservationID]\r\n           ,[StartDatetime]\r\n           ,[DurationNights]\r\n           ,[RoomID]\r\n           ,[RoomPrice]\r\n           VALUES\r\n           ('{idreservasi}'\r\n           ,'{dateTimePicker1.Value.ToString("yyyy/MM/dd")}'\r\n           ,'{Convert.ToInt32(numericUpDown2.Value)}'\r\n           ,'{Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}'\r\n           ,'{Convert.ToInt32(dataGridView2.Rows[i].Cells["RoomPrice"].FormattedValue.ToString())}')");
                        if (mo.exc($"INSERT INTO [dbo].[ReservationRoom]\r\n           ([ReservationID]\r\n           ,[StartDatetime]\r\n           ,[DurationNights]\r\n           ,[RoomID]\r\n           ,[RoomPrice])\r\n           VALUES\r\n           ('{idreservasi}'\r\n           ,'{dateTimePicker1.Value.ToString("yyyy/MM/dd")}'\r\n           ,'{Convert.ToInt32(numericUpDown2.Value)}'\r\n           ,'{Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}'\r\n           ,'{Convert.ToInt32(dataGridView2.Rows[i].Cells["RoomPrice"].FormattedValue.ToString())}')"))
                        {
                            mo.exc($"UPDATE [dbo].[Room] SET [FlagKamar] = 1 WHERE ID='{Convert.ToInt32(dataGridView2.Rows[i].Cells["ID"].FormattedValue.ToString())}'");

                            //MessageBox.Show("Reservasi berhasil");
                            //awal();
                            item();
                            setsubtotalitem();
                            groupBox3.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Gagal reservasi room");
                            //MessageBox.Show(Convert.ToString($"INSERT INTO [dbo].[ReservationRoom]\r\n           ([ReservationID]\r\n           ,[StartDatetime]\r\n           ,[DurationNights]\r\n           ,[RoomID]\r\n           ,[RoomPrice]\r\n           VALUES\r\n           ({idreservasi}\r\n           ,'{dateTimePicker1.Value.ToString("yyyy/MM/dd")}'\r\n           ,{Convert.ToInt32(numericUpDown2.Value)}\r\n           ,{Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["ID"].FormattedValue.ToString())}\r\n           ,{Convert.ToInt32(dataGridView2.Rows[i].Cells["RoomPrice"].FormattedValue.ToString())})"));
                        }
                    }
                } else
                {
                    MessageBox.Show("Gagal reservasi");
                }
            }
        }
    }
}
