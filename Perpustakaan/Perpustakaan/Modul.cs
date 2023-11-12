'using System;
using System.Collections.Generic; //ini buat list
using System.Data;
using System.Data.SqlClient; //data provider utk sql server
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Modul
    {
        public SqlConnection conn; //ini buat koneksinya
        public SqlCommand cmd; //ini buat command sql
        public SqlDataAdapter da; //ambil data buat disimpen ke data set(penyimpanan cache)
        public SqlDataReader dr; //ini ambil data tapi cuma read only
        public DataTable dt;

        public void Koneksi()
        {
            conn = new SqlConnection(@"SERVER=DESKTOP-2CLQ26N\SQLEXPRESS;database=DBPerpus;Integrated Security=True;");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void CloseKoneksi()
        {
            conn.Close();
            ///cmd.Dispose();
        }

        public DataTable getdata(string sql)
        {
            Koneksi();
            try
            {
                da = new SqlDataAdapter();
                dt = new DataTable();
                cmd = new SqlCommand(sql, conn);
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                CloseKoneksi();
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

        public int getCount(string sql)
        {
            Koneksi();
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
                return 0;
            }
            finally
            {
                CloseKoneksi();
            }
        }

        public string getValue(string sql, string col)
        {
            String value = "";
            Koneksi();
            try
            {
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();

                value = dr.GetValue(dr.GetOrdinal(col)).ToString();
                //if (IsDBNull(dr.Item(col)))
                //    return "";
                //else
                //    return dr.Item(col);
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
            finally
            {
                CloseKoneksi();
            }
        }

        public bool exc(string sql)
        {
            Koneksi();

            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message)
                return false;
            }
            finally
            {
                CloseKoneksi();
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

        public bool dialog(string txt)
        {
            DialogResult ds = MessageBox.Show(txt, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                return true;
            }
            else
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

        public bool isEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable importExcelFromURL(string url, string sheetname = "Sheet1")
        {
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;


            try
            {
                // If True Then
                // MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & url & "';Mode=Read;" & "Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""")
                // Else
                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + url + "';Mode=Read;" + "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;\"");
                // End If


                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetname + "$]", MyConnection);

                DtSet = new System.Data.DataSet();
                DataTable dt = new DataTable();
                MyCommand.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable();
            }
            finally
            {
                //MyConnection.Close();
                //MyConnection.Close();
            }
            MyConnection.Close();
        }

        public void exportExcel(SaveFileDialog sfd, DataGridView dgv)
        {
            int colIndex = 0;
            int rowIndex = 0;
            sfd.Filter = "Excel Files(*.xlsx)|*.xlsx";
            sfd.FileName = "Dhana_" + DateTime.Now.ToString("ddMMyyyy");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application ExcelApp;
                    Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                    object misValue = System.Reflection.Missing.Value;


                    ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelWorkBook = ExcelApp.Workbooks.Add(misValue);
                    //ExcelWorkSheet = ExcelWorkBook.Sheets("sheet1");
                    ExcelWorkSheet = ExcelWorkBook.Sheets["sheet1"];

                    foreach (DataGridViewColumn dc in dgv.Columns)
                    {
                        colIndex = colIndex + 1;
                        ExcelWorkSheet.Cells[1, colIndex] = dc.Name;
                    }

                    foreach (DataGridViewRow dr in dgv.Rows)
                    {
                        rowIndex = rowIndex + 1;
                        colIndex = 0;
                        foreach (DataGridViewColumn dc in dgv.Columns)
                        {
                            colIndex = colIndex + 1;
                            ExcelWorkSheet.Cells[rowIndex + 1, colIndex] = dgv.Rows[dr.Index].Cells[dc.Name].Value;
                        }
                    }


                    ExcelWorkSheet.SaveAs(sfd.FileName);
                    ExcelWorkBook.Close();
                    ExcelApp.Quit();

                    releaseObject(ExcelApp);
                    releaseObject(ExcelWorkBook);
                    releaseObject(ExcelWorkSheet);

                    MessageBox.Show("Berhasil");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
