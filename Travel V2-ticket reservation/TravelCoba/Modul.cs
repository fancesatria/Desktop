using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCoba
{
    internal class Modul
    {
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataTable dt;
        public SqlCommand cmd;

        //PANEL SIDEBAR
        private Button currentButton;
        private Form activeForm;

        public void koneksi()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-FML3VRPI\SQLEXPRESS;Initial Catalog=ESEMKATravel;Integrated Security=True");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeKoneksi()
        {
            conn.Close();
            conn.Dispose();
        }

        public DataTable getData(string sql)
        {
            koneksi();
            try
            {
                da = new SqlDataAdapter();
                dt = new DataTable();
                cmd = new SqlCommand(sql, conn);
                da.SelectCommand = cmd;
                da.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                closeKoneksi();
            }
        }

        public String getValue(string sql, string col)
        {
            string value = "";
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();

                value = dr.GetValue(dr.GetOrdinal(col)).ToString();
                return value;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return "";
            }
            finally
            {
                closeKoneksi();
            }
        }
        public int getValueInt(string sql, string col)
        {
            int value = 0;
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();

                value = Convert.ToInt32(dr.GetValue(dr.GetOrdinal(col)));
                return value;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally
            {
                closeKoneksi();
            }
        }
        public int getCount(string sql)
        {
            int value = 0;
            koneksi();
            try
            {
                da = new SqlDataAdapter();
                dt = new DataTable();
                cmd = new SqlCommand(sql, conn);
                da.SelectCommand = cmd;
                da.Fill(dt);

                return dt.Rows.Count;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally
            {
                closeKoneksi();
            }
        }

        public bool exc(string sql)
        {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); return false;
            }
            finally
            {
                closeKoneksi();
            }
        }
        public bool excNonMessage(string sql)
        {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                closeKoneksi();
            }
        }


        public bool isEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public double numberFor(string te)
        {
            double uang;
            try
            {
                uang = double.Parse(te);
            }
            catch (Exception ex)
            {
                uang = 0;
            }
            return uang;
        }

        public void onlyNumber(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public string hash256(String inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= hash.Length - 1; i++)
                stringBuilder.Append(hash[i].ToString("X2"));
            return stringBuilder.ToString().ToLower();
        }

        public bool dialog(string txt)
        {
            DialogResult dr = MessageBox.Show(txt, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearForm(GroupBox gb)
        {
            foreach (Control ct in gb.Controls)
            {
                if (ct is TextBox)
                {
                    TextBox tb = ct as TextBox;
                    tb.Text = "";
                }

                if (ct is PictureBox)
                {
                    PictureBox pc = ct as PictureBox;
                    pc.ImageLocation = null;
                }

                if (ct is NumericUpDown)
                {
                    NumericUpDown nu = ct as NumericUpDown;
                    nu.Value = 0;
                }
            }

        }

        public Boolean adakosong(GroupBox gb)
        {
            bool status = false;
            foreach (Control ct in gb.Controls)
            {
                if (ct is TextBox)
                {
                    TextBox tb = ct as TextBox;
                    if (tb.Text == "")
                    {
                        status = true;
                        break;
                    }
                }

                if (ct is PictureBox)
                {
                    PictureBox pc = ct as PictureBox;
                    if (pc.ImageLocation == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        status = true;
                        break;
                    }
                }

                if (ct is ComboBox)
                {
                    ComboBox cb = ct as ComboBox;
                    if (cb.SelectedIndex < 0)
                    {
                        status = true;
                        break;
                    }
                }

                if (ct is NumericUpDown)
                {
                    NumericUpDown nu = ct as NumericUpDown;
                    if (nu.Value == 0)
                    {
                        status = true;
                        break;
                    }
                }
            }
            return status;
        }

        public void autoCompleteTextBox(TextBox tb, string sql, string col)
        {
            //use this method in load/constructor
            koneksi();
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                MyCollection.Add(dr[col].ToString());
            }
            tb.AutoCompleteCustomSource = MyCollection;
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            closeKoneksi();
        }


        //PANEL SIDEBAR

        //buat constructor,masukinini ke constructor
	//private Button currentButton;
        //private Form activeForm;
        //private bool isCollapse;
        //public Form2()
        //{
        //    InitializeComponent();
        //    //btnCloseChildForm.Visible = false;
        //    this.Text = string.Empty;
        //    this.ControlBox = false;
        //    this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        //    OpenChildFormOnDefault(new MainForm());
        //    hideTaskbar();

        //}

        //private void ActivateButton(object btnSender)
        //{
        //    if (btnSender != null)
        //    {
        //        if (currentButton != (Button)btnSender)
        //        {
        //            DisableButton();
        //            //Color color = SelectThemeColor();
        //            currentButton = (Button)btnSender;
        //            currentButton.BackColor = System.Drawing.Color.LightSkyBlue;
        //            currentButton.ForeColor = System.Drawing.Color.White;
        //            currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            panelTitle.BackColor = System.Drawing.Color.White;
        //            //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
        //            //ThemeColor.PrimaryColor = color;
        //            //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
        //            //btnCloseChildForm.Visible = true;
        //        }

        //    }
        //}

        //private void DisableButton()
        //{
        //    foreach (Control previousBtn in panelMenu.Controls)
        //    {
        //        if (previousBtn.GetType() == typeof(Button))
        //        {
        //            previousBtn.BackColor = System.Drawing.Color.DarkSlateBlue;
        //            previousBtn.ForeColor = System.Drawing.Color.Gainsboro;
        //            previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        }
        //    }
        //}

        //private void OpenChildForm(Form childForm, object btnSender)
        //{
        //    if (activeForm != null)
        //        activeForm.Close();
        //    ActivateButton(btnSender);
        //    activeForm = childForm;
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    this.panelDesktop.Controls.Add(childForm);
        //    this.panelDesktop.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //    lblTitle.Text = childForm.Text;
        //}

        //private void OpenChildFormOnDefault(Form childForm)
        //{
        //    if (activeForm != null)
        //        activeForm.Close();
        //    activeForm = childForm;
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    this.panelDesktop.Controls.Add(childForm);
        //    this.panelDesktop.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //    lblTitle.Text = childForm.Text;
        //}

        //private void Reset()
        //{
        //    DisableButton();
        //    lblTitle.Text = "HOME";
        //    panelTitle.BackColor = System.Drawing.Color.White;
        //    panelLogo.BackColor = System.Drawing.Color.DarkSlateBlue; ;
        //    currentButton = null;
        //    //btnCloseChildForm.Visible = false;
        //}
        //public void hideTaskbar()
        //{
        //    panelMenu.Visible = false;
        ////ini button buat item taskbar
        //    button1.Visible = false;
        //    button2.Visible = false;
        //    button3.Visible = false;
        //    button4.Visible = false;
        //    button5.Visible = false;
        //    button6.Visible = true;
        //}

        //public void showTaskbar()
        //{
        //    panelMenu.Visible = true;
        ////ini button buat item taskbar
        //    button1.Visible = true;
        //    button2.Visible = true;
        //    button3.Visible = true;
        //    button4.Visible = true;
        //    button5.Visible = true;
        //    button6.Visible = false;
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //bool isCollapse;
        //    //timer: interval:15, enabled:false, button5_click = timer1.start()
        //    if (isCollapse)
        //    {
        //        panel2.Height += 10;
        //        if (panel2.Size == panel2.MaximumSize)
        //        {

        //            timer1.Stop();
        //            isCollapse = false;
        //        }
        //    } else {
        //        panel2.Height -= 10;
        //        if (panel2.Size == panel2.MinimumSize)
        //        {

        //            timer1.Stop();
        //            isCollapse = true;
        //        }
        //    }
        //}

    }
}
