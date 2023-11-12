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
    public partial class MasterMaskapai : Form
    {
        Modul mo = new Modul();
        string id;
        bool edit = false;
        public MasterMaskapai()
        {
            InitializeComponent();
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Nama]\r\n      ,[Perusahaan]\r\n      ,[JumlahKru]\r\n      ,[Deskripsi]\r\n  FROM [BromoAirlines].[dbo].[Maskapai]");
            dataGridView1.Columns["ID"].Visible = false ;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            edit = true;
        }

        public void load()
        {
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Nama]\r\n      ,[Perusahaan]\r\n      ,[JumlahKru]\r\n      ,[Deskripsi]\r\n  FROM [BromoAirlines].[dbo].[Maskapai] ORDER BY Nama ASC");
            dataGridView1.Columns["ID"].Visible = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mo.dialog("Ingin menghapus item ini?"))
            {
                if (mo.exc("DELETE FROM [dbo].[Maskapai]\r\n      WHERE ID = '" + id + "'"))
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            button3.Enabled = true;
            button4.Enabled = true;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Nama"].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Perusahaan"].FormattedValue.ToString();
            
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["JumlahKru"].FormattedValue.ToString());
            
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Deskripsi"].FormattedValue.ToString();
        }

        private void MasterMaskapai_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mo.ClearForm(groupBox1);
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Data harus terisi semua");
            } else
            {
                if (edit)
                {
                    string sql = $"UPDATE [dbo].[Maskapai]\r\n   SET [Nama] = '{textBox1.Text}'\r\n      ,[Perusahaan] = '{textBox3.Text}'\r\n      ,[JumlahKru] ={Convert.ToInt32(numericUpDown1.Value)}\r\n      ,[Deskripsi] = '{textBox6.Text}'\r\n WHERE ID = '{id}'";
                    if (mo.exc(sql))
                    {
                        MessageBox.Show("Update disimpan");
                        load();
                    } else
                    {
                        MessageBox.Show("Update gagal disimpan");
                    }
                } else
                {
                    string sql = $"INSERT INTO [dbo].[Maskapai]\r\n           ([Nama]\r\n           ,[Perusahaan]\r\n           ,[JumlahKru]\r\n           ,[Deskripsi])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,'{textBox3.Text}'\r\n           ,{Convert.ToInt32(numericUpDown1.Value)}\r\n           ,'{textBox6.Text}')";
                    if (mo.exc(sql))
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
