using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace CRUD1
{
    public class Modul
    {
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public SqlConnection conn;
        public DataTable dt;

        public void koneksi()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-FML3VRPI\SQLEXPRESS;Initial Catalog=dbtes;Integrated Security=True");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closekoneksi()
        {
            conn.Close();
        }

        public DataTable getdata(string sql)
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

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

            }
            finally
            {
                conn.Close();
            }
        }

        public int getcount(string sql)
        {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;

            }
            finally
            {
                conn.Close();
            }
        }

        public string getvalue(string sql, string col)
        {
            string val = "";
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();

                val = dr.GetValue(dr.GetOrdinal(col)).ToString();
                return val;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";

            }
            finally
            {
                conn.Close();
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

            } catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                return false;

            }
            finally
            {
                closekoneksi();
            }
        }

        public Boolean adakosong(GroupBox gb)
        {
            bool status = false;
            foreach(Control ct in gb.Controls)
            {
                if (ct is TextBox)
                {
                    TextBox tb = ct as TextBox;
                    if (tb.Text == "")
                    {
                        status = true;
                        MessageBox.Show(tb.GetPositionFromCharIndex+"Textbox kososng");
                        break;
                    }
                }

                if (ct is PictureBox)
                {
                    PictureBox tb = ct as PictureBox;
                    if (tb.ImageLocation == null)
                    {
                        status =  true;
                        break;
                    }
                }

                if (ct is NumericUpDown)
                {
                    NumericUpDown tb = ct as NumericUpDown;
                    if (tb.Value == 0)
                    {
                        status = true;
                        break;
                    }
                }

                if (ct is ComboBox)
                {
                    ComboBox tb = ct as ComboBox;
                    if (tb.SelectedIndex == 0)
                    {
                        status = true;
                        break;
                    }
                }

                
            }

            return status;
        }


        public void clearform(GroupBox gb)
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
                    PictureBox tb = ct as PictureBox;
                    tb.ImageLocation = null;
                }

                if (ct is NumericUpDown)
                {
                    NumericUpDown tb = ct as NumericUpDown;
                    tb.Value = 0;
                }


            }
        }



        public void onlyNumber(KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)){
                e.Handled = true;
            }
        }

        public Boolean isEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean dialog(string txt)
        {
            DialogResult ds = MessageBox.Show(txt, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string hash256(String inputString)
        {
            SHA256 sha = SHA256.Create();//buat object dari SHA
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);//
            byte[] hash = sha.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for(int i  = 0; i <= hash.Length-1; i++) {
                sb.Append(hash[i].ToString("X2")); }
            return sb.ToString().ToLower();
        }
    }
}
