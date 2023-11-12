using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP_25
{
    public partial class AdminForm : Form
    {
        Modul mo = new Modul();
        private Button currentButton;
        private Form activeForm;
        private bool isCollapse;
        public AdminForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //hideTaskbar();
        }



        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    //Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    //currentButton.BackColor = System.Drawing.Color.LightSkyBlue;
                    currentButton.ForeColor = Color.Blue;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                }

            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = System.Drawing.Color.DarkSlateBlue;
                    previousBtn.ForeColor = System.Drawing.Color.DarkGray;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void hideTaskbar()
        {
            panelMenu.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
        }

        public void showTaskbar()
        {
            panelMenu.Visible = true;
            //ini button buat item taskbar
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showTaskbar();
        }

        private void label7_Click(object sender, EventArgs e)
        {
           


        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showTaskbar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MasterMaskapai(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MasterBandara(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MasterJadwalPenerbangan(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MasterKodePromo(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UbahStatus(), sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (mo.dialog("Anda inginn keluar?"))
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }

        private void panelDesktop_DoubleClick(object sender, EventArgs e)
        {
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
