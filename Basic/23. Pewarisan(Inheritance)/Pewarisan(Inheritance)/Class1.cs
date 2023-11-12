using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pewarisan_Inheritance_
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

    // kita ingin menggunakan isi dr class Kalkulator dalam class Rumus dg cara diwariskan
    class Rumus : Kalkulator //ini cara mewariskannya
    {
        public void lingkaran()
        {
            Console.WriteLine("Lingkaran");
        }

        public int persegi(int s)
        {
            return s * s;
        }
    }
}
