namespace CRUD1
{
    public partial class Form1 : Form
    {
        public Modul mo = new Modul();
        public int id;
        public Boolean edit = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void load()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            label6.Visible = false;
            button3.Enabled = true;
            mo.clearform(groupBox1);
            dataGridView1.DataSource = mo.getdata("SELECT TOP (1000) [id]\r\n      ,[name]\r\n      ,[dateofbirth]\r\n      ,[password]\r\n      ,[email]\r\n      ,[telp]\r\n      ,[photo]\r\n  FROM [dbtes].[dbo].[User]");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lime;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            groupBox1.Enabled = true;
            groupBox3.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ds = openFileDialog1.ShowDialog();
            if (ds == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                label6.Visible = true;
                label6.Text = pictureBox1.ImageLocation;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            mo.onlyNumber(e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                button3.Enabled = false;
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
                //textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["telp"].FormattedValue.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["dateOfBirth"].FormattedValue.ToString());
                pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells["photo"].FormattedValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit = true;
            groupBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mo.adakosong(groupBox1))
            {
                MessageBox.Show("Data harus diisi semua");
            }
            else
            {
                if (edit)
                {
                    string sql = $"UPDATE [dbo].[User]\r\n   SET [name] = '{textBox1.Text}'\r\n      ,[dateofbirth] = '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'\r\n      ,[password] = '{mo.hash256(textBox3.Text)}'\r\n      ,[email] = '{textBox2.Text}'\r\n      ,[telp] = '{textBox4.Text}'\r\n      ,[photo] = '{pictureBox1.ImageLocation}'\r\n WHERE id='{id}'";
                    if (mo.exc(sql))
                    {
                        if (mo.isEmail(textBox2.Text))
                        {
                            MessageBox.Show("Update berhasil");
                            load();
                            mo.clearform(groupBox1);
                        }
                        else
                        {
                            MessageBox.Show("Masukkan email yang valid");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Update gagal");
                        load();
                    }

                }
                else
                {
                    string sql = $"INSERT INTO [dbo].[User]\r\n           ([name]\r\n           ,[dateofbirth]\r\n           ,[password]\r\n           ,[email]\r\n           ,[telp]\r\n           ,[photo])\r\n     VALUES\r\n           ('{textBox1.Text}'\r\n           ,'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'\r\n           ,'{mo.hash256(textBox3.Text)}'\r\n           ,'{textBox2.Text}'\r\n           ,'{textBox4.Text}'\r\n          ,'{pictureBox1.ImageLocation}')";
                    if (mo.exc(sql))
                    {
                        if (mo.isEmail(textBox2.Text))
                        {
                            MessageBox.Show("Insert berhasil");
                            load();
                            mo.clearform(groupBox1);
                        }
                        else
                        {
                            MessageBox.Show("Masukkan email yang valid");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insert gagal");
                        load();
                    }
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count >= 0)
            {
                if (mo.dialog("Ingin menghapus data ini?"))
                {
                    string sql = $"DELETE FROM [dbo].[User]\r\n      WHERE id='{id}'";
                    if (mo.exc(sql))
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