using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKTOP_25
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string employee;
        public static string idemployee;

        public static string namaCustomer;
        public static string idCustomer;
        public static string idTujuan;
        public static string idBerangkat;
        public static string jumlahPenumpang;
        public static string tgl;
        public static string tu;
        public static string be;
        public static string maskapai = "1";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
