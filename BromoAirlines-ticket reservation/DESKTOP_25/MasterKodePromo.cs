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

namespace DESKTOP_25
{
    public partial class MasterKodePromo : Form
    {
        Modul mo = new Modul();
        string idkode;
        bool edit = false;
        public MasterKodePromo()
        {
            InitializeComponent();
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Kode]\r\n      ,[PersentaseDiskon]\r\n      ,[MaksimumDiskon]\r\n      ,[BerlakuSampai]\r\n      ,[Deskripsi]\r\n  FROM [BromoAirlines].[dbo].[KodePromo]");
            dataGridView1.Columns["ID"].Visible = false;

            button3.Enabled = false;
            button4.Enabled = false;

        }

        public void load()
        {
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Kode]\r\n      ,[PersentaseDiskon]\r\n      ,[MaksimumDiskon]\r\n      ,[BerlakuSampai]\r\n      ,[Deskripsi]\r\n  FROM [BromoAirlines].[dbo].[KodePromo] ASC");
            dataGridView1.Columns["ID"].Visible = false;

            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idkode = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            button3.Enabled = true;
            button4.Enabled = true;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Kode"].FormattedValue.ToString();
            //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Kode"].FormattedValue.ToString());
            //numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PersentaseDiskon"].FormattedValue.ToString());
            //numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaksimumDiskon"].FormattedValue.ToString());
            //textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Deskripsi"].FormattedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mo.dialog("Ingin menghapus item ini?"))
            {
                if (mo.exc("DELETE FROM [dbo].[Bandara]\r\n      WHERE ID = '"+idkode+"'"))
                {
                    MessageBox.Show("Data dihapus");
                    load();
                } else
                {
                    MessageBox.Show("Data gagal dihapus");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            edit = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Data harus terisi semua");
            } else {
                if (edit)
                {
                    string sql = $"UPDATE [dbo].[KodePromo]\r\n   SET [Kode] = '{textBox1.Text}'\r\n      ,[PersentaseDiskon] = {Convert.ToDouble(numericUpDown1.Value)}\r\n      ,[MaksimumDiskon] = {Convert.ToDouble(numericUpDown2.Value)}\r\n      ,[BerlakuSampai] = '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'\r\n      ,[Deskripsi] = '{textBox6.Text}'\r\n WHERE ID = '{idkode}'";
                    if (mo.exc(sql))
                    {
                        MessageBox.Show("Perubahan data disimpan");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Perubahan data gagal disimpan");
                    }
                } else {
                    string sql = $"INSERT INTO [dbo].[KodePromo]\r\n           ([Kode]\r\n           ,[PersentaseDiskon]\r\n           ,[MaksimumDiskon]\r\n           ,[BerlakuSampai]\r\n           ,[Deskripsi])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,{Convert.ToDouble(numericUpDown1.Value)}\r\n           ,{Convert.ToDouble(numericUpDown2.Value)}\r\n           ,'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'\r\n           ,'{textBox6.Text}')";
                    if (mo.exc(sql))
                    {
                        MessageBox.Show("Data disimpan");
                        load();
                    } else
                    {
                        MessageBox.Show("Data gagal disimpan");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load();
            mo.ClearForm(groupBox1);
        }
    }
}
