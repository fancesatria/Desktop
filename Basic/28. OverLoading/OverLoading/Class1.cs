using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverLoading
{
    class Rumus
    {

        // OVERLOADING : misal ada method sama beda parameter nanti bisa saling menggantikan
        // Method tsb dijbedajan oleh parameter
        public int persegi(int s)
        {
            return s * s;
        }

        public int persegi(int a, int b)
        {
            return a * b;
        }
    }
}
