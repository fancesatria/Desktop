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
    public partial class MasterEmployee : Form
    {
        public Modul mo =new Modul();
        public int id;
        public Boolean edit = false;
        public MasterEmployee()
        {
            InitializeComponent();
        }

        private void MasterEmployee_Load(object sender, EventArgs e)
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

            dataGridView1.DataSource = mo.getdata($"SELECT TOP (1000) [ID]\r\n      ,[Username]\r\n      ,[Email]\r\n      ,[Password]\r\n      ,[Name]\r\n      ,[Address]\r\n      ,[DateOfBirth]\r\n      ,[JobID]\r\n      ,[Role]\r\n  FROM [GrandHotel].[dbo].[VE]");
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["JobID"].Visible = false;

            comboBox1.DataSource = mo.getdata("SELECT TOP (1000) [ID]\r\n      ,[Name]\r\n  FROM [GrandHotel].[dbo].[Job]");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

           //ngisi dibatasi pas hari kerja aja:
           //DateTime hariino= DateTime.Now;
           // if(hariino.DayOfWeek == DayOfWeek.Sunday)
           // {
           //     hariino = DateTime.Now;
           // }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["JobID"].FormattedValue.ToString();


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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            this.button1.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            edit = true;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true; groupBox3.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (mo.dialog("Ingin menghapus ddata ini"))
                {
                    if (mo.exc($"DELETE FROM [dbo].[Employee]\r\n      WHERE ID='{id}'"))
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            load();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Pastikan data terisi semua");
            }
            else
            {
                if (mo.isEmail(textBox4.Text))
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Password tak sama");
                    }
                    else
                    {
                        if (edit)
                        {
                            if (mo.exc($"UPDATE [dbo].[Employee]\r\n   SET [Username] ='{textBox1.Text}' \r\n      ,[Email] ='{textBox4.Text}' \r\n      ,[Password] ='{mo.hash256(textBox2.Text)}' \r\n      ,[Name] ='{textBox5.Text}' \r\n      ,[Address] ='{textBox8.Text}' \r\n      ,[DateOfBirth] ='{dateTimePicker1.Value.ToString("yyyy/MM/dd")}' \r\n      ,[JobID] ='{comboBox1.SelectedValue}' \r\n WHERE ID = '{id}'"))
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
                            if (mo.exc($"INSERT INTO [dbo].[Employee]\r\n           ([Username]\r\n           ,[Email]\r\n           ,[Password]\r\n           ,[Name]\r\n           ,[Address]\r\n           ,[DateOfBirth]\r\n           ,[JobID])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,'{textBox4.Text}'\r\n           ,'{mo.hash256(textBox2.Text)}'\r\n           ,'{textBox5.Text}'\r\n           ,'{textBox8.Text}'\r\n           ,'{dateTimePicker1.Value.ToString("yyyy/MM/dd")}'\r\n           ,'{comboBox1.SelectedValue}')"))
                            {
                                MessageBox.Show("Data disimpan");
                                load();
                            }
                            else
                            {
                                MessageBox.Show("data gagal disimpan");
                            }
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Masukkan email yang valid");
                }
            }
        }
    }
}   
