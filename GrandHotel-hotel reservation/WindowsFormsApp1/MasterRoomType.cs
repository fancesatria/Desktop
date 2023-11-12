using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class MasterRoomType : Form
    {
        public Modul mo = new Modul();
        public int id;
        public Boolean edit = false;

        public MasterRoomType()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void MasterRoomType_Load(object sender, EventArgs e)
        {
            load();

        }
        public void load()
        {
            groupBox1.Enabled = false;
            edit = false;
            groupBox3.Enabled = false;
            button1.Enabled = true;

            mo.clearform(groupBox1);
            dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n      ,[Capacity]\r\n      ,[RoomPrice]\r\n  FROM [GrandHotel].[dbo].[RoomType]");
            dataGridView1.Columns["ID"].Visible = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Capacity"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["RoomPrice"].FormattedValue.ToString();
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                
                groupBox1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit = true;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            this.button1.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Pastikan data terisi semua");
            }
            else
            {
                if (edit)
                {
                    if(mo.exc($"UPDATE [dbo].[RoomType]\r\n   SET [Name] = '{textBox1.Text}'\r\n      ,[Capacity] = '{Convert.ToInt32(textBox2.Text)}'\r\n      ,[RoomPrice] ='{Convert.ToInt32(textBox3.Text)}'\r\n WHERE ID = '{id}'"))
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
                    if(mo.exc($"INSERT INTO [dbo].[RoomType]\r\n           ([Name]\r\n           ,[Capacity]\r\n           ,[RoomPrice])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,'{textBox2.Text}'\r\n           ,'{textBox3.Text}')"))
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 0)
            {
                if (mo.dialog("Ingin menghapus data ini?"))
                {
                    if (mo.exc($"DELETE FROM [dbo].[RoomType]\r\n      WHERE ID='{id}'"))
                    {
                        MessageBox.Show("Data dihapus");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal dihapus");
                    }
                }
            }
        }
    }
}
