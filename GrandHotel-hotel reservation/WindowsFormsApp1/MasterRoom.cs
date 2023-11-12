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
    public partial class MasterRoom : Form
    {
        public Modul mo = new Modul();
        public Boolean edit = false;
        public int id;
        public MasterRoom()
        {
            InitializeComponent();
        }

        private void MasterRoom_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            button1.Enabled = true;
            edit = false;

            mo.clearform(groupBox1);
            dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[RoomTypeID]\r\n      ,[RoomNumber]\r\n      ,[RoomFloor]\r\n      ,[Description]\r\n      ,[FlagKamar]\r\n      ,[FlagPesan]\r\n  FROM [GrandHotel].[dbo].[Room]");
            dataGridView1.Columns["ID"].Visible = false;

            comboBox1.DataSource = mo.getdata("SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n      ,[Capacity]\r\n      ,[RoomPrice]\r\n  FROM [GrandHotel].[dbo].[RoomType]");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["RoomNumber"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["RoomFloor"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].FormattedValue.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["RoomTypeID"].FormattedValue.ToString();

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                groupBox3.Enabled = true;
                groupBox1.Enabled = true;
            }   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            this.button1.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            edit = true;
            groupBox1.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 0)
            {
                if (mo.dialog("Ingin menghapsu data ini?"))
                {
                    if (mo.exc($"DELETE FROM [dbo].[Room]\r\n      WHERE ID = '{id}'"))
                    {
                        MessageBox.Show("Data dihapus");
                        load();
                    }
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Pastikan data terisi semua");
            }
            else
            {
                if (edit)
                {
                    if (mo.exc($"UPDATE [dbo].[Room]\r\n   SET [RoomTypeID] = '{comboBox1.SelectedValue}'\r\n      ,[RoomNumber] = '{textBox1.Text}'\r\n      ,[RoomFloor] = '{textBox3.Text}'\r\n      ,[Decription] = '{textBox4.Text}'\r\n WHERE ID = '{id}'"))
                    {
                        MessageBox.Show("Update berhasil");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Update gagal");
                    }
                }
                else
                {
                    if (mo.exc($"INSERT INTO [dbo].[Room]\r\n           ([RoomTypeID]\r\n           ,[RoomNumber]\r\n           ,[RoomFloor]\r\n           ,[Decription])\r\n     VALUES\r\n           ('{comboBox1.SelectedValue}'\r\n           ,'{textBox1.Text}'\r\n           ,'{textBox3.Text}'\r\n           ,'{textBox4.Text}')"))
                    {
                        MessageBox.Show("Data disimpan");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal disimpan");
                    }
                }
            }
        }
    }
}
