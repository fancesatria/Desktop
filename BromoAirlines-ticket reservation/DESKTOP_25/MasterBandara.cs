using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP_25
{
    public partial class MasterBandara : Form
    {
        Modul mo = new Modul();
        string id;
        bool edit = false;
        public MasterBandara()
        {
            InitializeComponent();
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Nama]\r\n      ,[KodeIATA]\r\n      ,[Kota]\r\n      ,[NegaraID]\r\n      ,[JumlahTerminal]\r\n      ,[Alamat]\r\n  FROM [BromoAirlines].[dbo].[Bandara]");
            dataGridView1.Columns["ID"].Visible = false;
            comboBox1.DataSource = mo.getData("select * from Negara");
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";

            button3.Enabled = false;
            button4.Enabled = false;
        }

        public void load()
        {
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[Nama]\r\n      ,[KodeIATA]\r\n      ,[Kota]\r\n      ,[NegaraID]\r\n      ,[JumlahTerminal]\r\n      ,[Alamat]\r\n  FROM [BromoAirlines].[dbo].[Bandara] ORDER BY Nama ASC");
            dataGridView1.Columns["ID"].Visible = false;
            comboBox1.DataSource = mo.getData("select * from Negara");
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";

            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void MasterBandara_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mo.dialog("Ingin menghapus item ini?"))
            {
                if (mo.exc("DELETE FROM [dbo].[Bandara]\r\n      WHERE ID = '" + id + "'"))
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
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["KodeIATA"].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Kota"].FormattedValue.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["NegaraID"].FormattedValue.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["JumlahTerminal"].FormattedValue.ToString());
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Alamat"].FormattedValue.ToString();
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
            } else
            {
                if(edit)
                {
                    string sql = $"UPDATE [dbo].[Bandara]\r\n   SET [Nama] ='{textBox1.Text}'\r\n      ,[KodeIATA] = '{textBox3.Text}'\r\n      ,[Kota] = '{textBox4.Text}'\r\n      ,[NegaraID] = {comboBox1.SelectedValue}\r\n      ,[JumlahTerminal] = '{Convert.ToInt32(numericUpDown1.Value)}'\r\n      ,[Alamat] ='{textBox6.Text}'\r\n WHERE ID = {id}";
                    if (mo.exc(sql))
                    {
                        MessageBox.Show("Update disimpan");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Update gagal disimpan");
                    }
                } else
                {
                    string sql = $"INSERT INTO [dbo].[Bandara]\r\n           ([Nama]\r\n           ,[KodeIATA]\r\n           ,[Kota]\r\n           ,[NegaraID]\r\n           ,[JumlahTerminal]\r\n           ,[Alamat])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           , '{textBox3.Text}'\r\n           ,'{textBox4.Text}'\r\n           ,{comboBox1.SelectedValue}\r\n           ,'{Convert.ToInt32(numericUpDown1.Value)}'\r\n           ,'{textBox6.Text}')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            mo.ClearForm(groupBox1);
            load();
        }
    }
}
