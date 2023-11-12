using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace cobalist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ls = new List<string>() { "10","11","12"};
            

            string seat_numbs = string.Format(string.Join(", ", ls));
            //Console.WriteLine(seat_numbs);
            //Console.WriteLine("\n\n");
            List<int> converted_seat = seat_numbs.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            foreach (var i in converted_seat)
            {
                //Console.Write(i+" ");
            }
            Class1 c = new Class1();
            Console.WriteLine(c.isValidPassword("String8+"));

        }
        
    }
}
