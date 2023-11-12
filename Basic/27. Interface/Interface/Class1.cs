using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface IHitung
    {
        // 1. Interface itu spt daftar isi dlm buku, jadi mau ada isi apa aja
        // 2. Misal hanya berisi nama2 method yg mau dipakai, tanpa menggunakan isinya

        void judul(string j);

        int kali(int a, int b);

        int bagi(int a, int b);
    }

    // Mengisi method dari interface
    class Kalkulator : IHitung
    {
        public void judul(string j) {
            Console.WriteLine(j);
        }

        public int kali(int a, int b)
        {
            return a * b;
        }

        public int bagi(int a, int b)
        {
            return a / b;
        }
    }
}
