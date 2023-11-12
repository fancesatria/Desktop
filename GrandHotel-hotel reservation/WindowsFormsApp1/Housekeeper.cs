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
    public partial class Housekeeper : Form
    {
        public Housekeeper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CleaningRoom r = new CleaningRoom();
            r.MdiParent = this;
            r.Show();
        }
    }
}
