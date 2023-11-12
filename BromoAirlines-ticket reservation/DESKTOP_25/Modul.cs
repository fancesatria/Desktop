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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP_25
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
            conn = new SqlConnection(@"Data Source=.;Initial Catalog=BromoAirlines;Integrated Security=True");
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
                return null;
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
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            closeKoneksi();
        }
    }
}
