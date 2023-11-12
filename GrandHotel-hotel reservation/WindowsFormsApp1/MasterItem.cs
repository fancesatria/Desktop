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
    public partial class MasterItem : Form
    {

        public Modul mo = new Modul();
        public int id;
        public Boolean edit;
        public MasterItem()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void MasterItem_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            edit = false;
            button1.Enabled = true;

            mo.clearform(groupBox1);
            dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n      ,[RequestPrice]\r\n      ,[CompensationFee]\r\n  FROM [GrandHotel].[dbo].[Item]");
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["RequestPrice"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["CompensationFee"].FormattedValue.ToString();

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                groupBox3.Enabled = true;
                groupBox1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            this.button1.Enabled = false;
            groupBox3.Enabled = true;
            groupBox2.Enabled = true;
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
                    if (mo.exc($"UPDATE [dbo].[Item]\r\n   SET [Name] = '{textBox1.Text}'\r\n      ,[RequestPrice] = '{Convert.ToInt32(textBox2.Text)}'\r\n      ,[CompensationFee] = '{Convert.ToInt32(textBox3.Text)}'\r\n WHERE ID = '{id}'"))
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
                    if (mo.exc($"INSERT INTO [dbo].[Item]\r\n           ([Name]\r\n           ,[RequestPrice]\r\n           ,[CompensationFee])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,'{Convert.ToInt32(textBox2.Text)}'\r\n           ,'{Convert.ToInt32(textBox3.Text)}')"))
                    {
                        MessageBox.Show("Data ditambah");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal ditambah");
                    }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlynumber(e);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            edit = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 0)
            {
                if (mo.dialog("Ingin menghapus data ini?"))
                {
                    if (mo.exc($"DELETE FROM [dbo].[Item]\r\n      WHERE ID='{id}'"))
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
