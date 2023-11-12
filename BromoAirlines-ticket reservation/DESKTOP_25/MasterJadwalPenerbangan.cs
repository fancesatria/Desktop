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
    public partial class MasterJadwalPenerbangan : Form
    {
        Modul mo = new Modul();
        string id;
        bool edit = false;
        public MasterJadwalPenerbangan()
        {
            InitializeComponent();
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[KodePenerbangan]\r\n      ,[BandaraKeberangkatanID]\r\n      ,[BandaraTujuanID]\r\n      ,[MaskapaiID]\r\n      ,[TanggalWaktuKeberangkatan]\r\n      ,[DurasiPenerbangan]\r\n      ,[HargaPerTiket]\r\n  FROM [BromoAirlines].[dbo].[JadwalPenerbangan]");
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["BandaraTujuanID"].Visible = false;
            dataGridView1.Columns["BandaraKeberangkatanID"].Visible = false;
            dataGridView1.Columns["BandaraKeberangkatanID"].Visible = false;
            dataGridView1.Columns["BandaraTujuanID"].Visible = false;
            dataGridView1.Columns["MaskapaiID"].Visible = false;

            comboBox1.DataSource = mo.getData("select * from Bandara");
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";

            comboBox2.DataSource = mo.getData("select * from Bandara");
            comboBox2.DisplayMember = "Nama";
            comboBox2.ValueMember = "ID";

            comboBox3.DataSource = mo.getData("select * from Maskapai");
            comboBox3.DisplayMember = "Nama";
            comboBox3.ValueMember = "ID";

            button3.Enabled = false;
            button4.Enabled = false;

        }

        public void load()
        {
            dataGridView1.DataSource = mo.getData("SELECT TOP (1000) [ID]\r\n      ,[KodePenerbangan]\r\n      ,[BandaraKeberangkatanID]\r\n      ,[BandaraTujuanID]\r\n      ,[MaskapaiID]\r\n      ,[TanggalWaktuKeberangkatan]\r\n      ,[DurasiPenerbangan]\r\n      ,[HargaPerTiket]\r\n  FROM [BromoAirlines].[dbo].[JadwalPenerbangan]");
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["BandaraTujuanID"].Visible = false;
            dataGridView1.Columns["BandaraKeberangkatanID"].Visible = false;
            dataGridView1.Columns["BandaraKeberangkatanID"].Visible = false;
            dataGridView1.Columns["BandaraTujuanID"].Visible = false;
            dataGridView1.Columns["MaskapaiID"].Visible = false;

            comboBox1.DataSource = mo.getData("select * from Bandara");
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";

            comboBox2.DataSource = mo.getData("select * from Bandara");
            comboBox2.DisplayMember = "Nama";
            comboBox2.ValueMember = "ID";

            comboBox3.DataSource = mo.getData("select * from Maskapai");
            comboBox3.DisplayMember = "Nama";
            comboBox3.ValueMember = "ID";

            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            button3.Enabled = true;
            button4.Enabled = true;

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["KodePenerbangan"].FormattedValue.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["BandaraKeberangkatanID"].FormattedValue.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["BandaraTujuanID"].FormattedValue.ToString();
            comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["MaskapaiID"].FormattedValue.ToString();
            //textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Alamat"].FormattedValue.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["DurasiPenerbangan"].FormattedValue.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["HargaPerTiket"].FormattedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mo.exc("DELETE FROM [dbo].[JadwalPenerbangan]\r\n      WHERE ID = '" + id + "'"))
            {
                MessageBox.Show("Data dihapus");
                load();
            }
            else
            {
                MessageBox.Show("Data gagal dihapus");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            edit = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load();
            mo.ClearForm(groupBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Data harus terisi semua");
            }
            else
            {
                if (edit)
                {
                    string sql = $"UPDATE [dbo].[JadwalPenerbangan]\r\n   SET [KodePenerbangan] = '{textBox1.Text}'r\n      ,[BandaraKeberangkatanID] = '{comboBox1.SelectedValue}'\r\n      ,[BandaraTujuanID] = '{comboBox2.SelectedValue}\r\n      ,[MaskapaiID] = '{comboBox3.SelectedValue}\r\n      ,[TanggalWaktuKeberangkatan] = '{dateTimePicker1.Value}'\r\n      ,[DurasiPenerbangan] = {Convert.ToInt32(textBox7.Text)} WHERE ID= {id}";
                    if(mo.exc(sql)){
                        MessageBox.Show("Perubahan data disimpan");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Perubahan data gagal disimpan");
                    }
                }
                else
                {
                    string sql = $"INSERT INTO [dbo].[JadwalPenerbangan]\r\n           ([KodePenerbangan]\r\n           ,[BandaraKeberangkatanID]\r\n           ,[BandaraTujuanID]\r\n           ,[MaskapaiID]\r\n           ,[TanggalWaktuKeberangkatan]\r\n           ,[DurasiPenerbangan]\r\n           ,[HargaPerTiket])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,'{comboBox1.SelectedValue}'\r\n           ,'{comboBox2.SelectedValue}'\r\n           ,'{comboBox3.SelectedValue}'\r\n           ,'{dateTimePicker1.Value}'\r\n           ,'{Convert.ToInt32(textBox7.Text)}'\r\n           ,'{Convert.ToDecimal(textBox8.Text)}'";
                    if(mo.exc(sql)){
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlyNumber(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlyNumber(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlyNumber(e);
        }
    }
}
