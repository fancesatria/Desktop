using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Object
{
   class Kalkulator
    {
        public void tambah()
        {
            Console.WriteLine("Tambah");
        }

        public void kurang()
        {
            Console.WriteLine("Kurang");
        }
    }


    class Rumus
    {
        public int persegi(int s)
        {
            return s * s;
        }

        public int segitiga(int a, int t )
        {
            return a * t;
        }
    }


}
