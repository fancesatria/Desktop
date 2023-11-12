using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobaPanel
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Form activeForm;
        private bool isCollapse;
        public Form1()
        {
            InitializeComponent();
            //btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            OpenChildFormOnDefault(new MainForm());
            hideTaskbar();
            button6.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new User(), sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideTaskbar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new employee(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
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
                    currentButton.BackColor = System.Drawing.Color.LightSkyBlue;
                    currentButton.ForeColor = System.Drawing.Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = System.Drawing.Color.White;
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
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
                    previousBtn.ForeColor = System.Drawing.Color.Gainsboro;
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
            lblTitle.Text = childForm.Text;
        }

        private void OpenChildFormOnDefault(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitle.BackColor = System.Drawing.Color.White;
            panelLogo.BackColor = System.Drawing.Color.DarkSlateBlue; ;
            currentButton = null;
            //btnCloseChildForm.Visible = false;
        }
        public void hideTaskbar()
        {
            panelMenu.Visible = false;
            //ini button buat item taskbar
            //button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
        }

        public void showTaskbar()
        {
            panelMenu.Visible = true;
            //ini button buat item taskbar
            //button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new food(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MainForm(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Trahnsaction(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Report(),sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showTaskbar();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //bool isCollapse;
            //timer: interval:15, enabled:false, button5_click = timer1.start()
            if (isCollapse)
            {
                panelmaster.Height += 10;
                if (panelmaster.Size == panelmaster.MaximumSize)
                {

                    timer1.Stop();
                    isCollapse = false;
                }
            }
            else
            {
                panelmaster.Height -= 10;
                if (panelmaster.Size == panelmaster.MinimumSize)
                {

                    timer1.Stop();
                    isCollapse = true;
                }
            }
        }
    }
}
