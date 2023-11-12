using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TravelCoba
{
    internal static class Program
    {
        public static string GlobaLString ="This is global string";
        public static string EmpName;
        public static string role;
        public static string custId;
        public static string schid;
        public static string capacity;
        public static string price;
        public static string cust_name;
        public static string cust_email;
        public static string cust_phone;
        public static string cust_seat_number;
        public static string cust_seat_numbers;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
