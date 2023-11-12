using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Modul mo =  new Modul();
        public static string username;
        public static int idpetugas;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mo.clearform(groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT *  FROM [GrandHotel].[dbo].[VE] WHERE Username='{textBox1.Text}' AND Password='{mo.hash256(textBox2.Text)}'";
            if (mo.getcount(sql)==0)
            {
                MessageBox.Show("Email atau Password salah");
            } else
            {
                username = mo.getvalue(sql, "Username");
                idpetugas = mo.getvalueint(sql, "ID");
                string role = mo.getvalue(sql, "Role");
                if (role == "Front Office")
                {
                    FrontOffice p = new FrontOffice();
                    p.Show();
                    this.Hide();

                }
                else if (role == "Housekeeper Supervisor")
                {
                    HousekeeperSupervisor p = new HousekeeperSupervisor();
                    p.Show();
                    this.Hide();

                }
                else
                {
                    Housekeeper p = new Housekeeper();
                    p.Show();
                    this.Hide();
                }
                //MessageBox.Show(role);
            }
        }
    }
}
