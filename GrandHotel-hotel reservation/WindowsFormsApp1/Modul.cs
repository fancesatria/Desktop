using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Modul
    {
        public SqlCommand cmd;
        public SqlConnection conn;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public DataTable dt;

        public void koneksi()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-FML3VRPI\SQLEXPRESS;Initial Catalog=GrandHotel;Integrated Security=True");
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void closekoneksi()
        {
            conn.Close();
        }

        public string hash256(String inputSTring)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputSTring);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i <= hash.Length - 1; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        public DataTable getdata(String sql) {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                da = new SqlDataAdapter()
;               da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            } catch (Exception ex)
            {
                return null;
                MessageBox.Show(ex.Message);
            } finally
            {
                closekoneksi();

            }
        }

        public int getcount(string sql)
        {
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                da = new SqlDataAdapter()
;               da.SelectCommand = cmd;
                da.Fill(dt);
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                return 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closekoneksi();

            }
        }

        public string getvalue(string sql, string col)
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
            catch (Exception ex)
            {
                return "";
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closekoneksi();

            }
        }

        public int getvalueint(string sql, string col)
        {
            int value = 0;
            koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();

                value = Convert.ToInt32(dr.GetValue(dr.GetOrdinal(col)).ToString());
                return value;
            }
            catch (Exception ex)
            {
                return 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closekoneksi();

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
            } catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closekoneksi();
            }
        }

        public bool dialog(string txt)
        {
            DialogResult ds = MessageBox.Show(txt, "KOnfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ds == DialogResult.Yes)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool isEmail(string email)
        {
            try
            {
                var mai = new MailAddress(email);
                return true;
            }  catch { return false; }
        }

        public Boolean adakosong(GroupBox gb)
        {
            bool status = false;
            foreach(Control ct in gb.Controls)
            {
                if (ct is TextBox)
                {
                    TextBox tb = ct as TextBox;
                    if(tb.Text == "")
                    {
                        status = true;
                        break;
                    }
                }

                if (ct is PictureBox)
                {
                    PictureBox tb = ct as PictureBox;
                    if (tb.ImageLocation == null)
                    {
                        status = true;
                        break;
                    }
                }

                if (ct is ComboBox)
                {
                    ComboBox tb = ct as ComboBox;
                    if (tb.SelectedIndex < 0)
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
            }
        }

        public void onlynumber(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public string buatid(string code, string sql)
        {
            int i = getcount(sql);
            string id = "";

            if (i <= 10)
            {
                id = code + "000" + i;
            } else if(i >= 100)
            {
                id = code + "0" + i;
            } else if(1 < 100 || i > 10)
            {
                id = code + "00" + i;
            } else
            {
                id = code + "0" + i;
            }

            return id;
        }

        public void capctha(Label lb)
        {
            string[] arr = {"KL098","OP123", "JH678", "ASU456", "OPU567"};
            Random rand = new Random();
            lb.Text = arr[rand.Next(0, arr.Length)];
        }
    }
}
