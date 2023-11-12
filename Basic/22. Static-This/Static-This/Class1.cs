using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_This
{
    class Simpanan
    {

        public int hasil;

        public static void tampil()
        {
            //static bisa dipanggi ntanpa buat object terlebih dahulu
            //jadi tinggal pangil nama class diikuti dg methos yg mau dipanggil
            Console.WriteLine("Tampil static");
        }

        public int set(int a)
        {
            //1. this mendefinisikan kalau kita mau menggunakan variabel yang diinisiasi dengan this
            //2. method yg mengandung this gaboleh menggunakan static, krn akan error
            return this.hasil = a;
        }

        public void get()
        {
            Console.WriteLine(this.hasil);
        }
    }
}
