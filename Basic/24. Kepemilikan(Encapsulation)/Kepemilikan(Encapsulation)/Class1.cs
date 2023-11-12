using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepemilikan_Encapsulation_
{
    class Kalkulator
    {
        // Inti dr enkapsulasi adalah pembatasan akses suatu method/variabel



        // 1. Public bisa dipakai/dipanggil di classnya sendiri, class anak(inheritance), ataupun sbg object
        public int umum = 1;

        // 2. Private hny bisa dipakai/dipanggil di classnya sendiri, tak bisa dipakai di class anak
        private int privasi = 2;

        // 3. Protected hny bsa dipakai class induk dan class anak
        protected int khusus = 3;

        protected int alas=20;
    }

    class Rumus:Kalkulator 
    { 
        public int tampil()
        {
            return this.khusus;
        }

        public int segitiga(int tinggi)
        {
            return this.alas * tinggi;
        }
    }
}
