using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    abstract class Kalkulator
    {
        // 1. Abstract tak bisa dipanggil sbg object di class lain
        // 2. Kalau mau  dipangggil harus diturunkan ke class lain dulu
        // 3. Tujuannya adalah utk melindungi class tsb spy tak dijadikan objecct scr sembarangan
        // jadi hrs melalui pewarisan tlb dulu

        // Class dibawah ini gk bisa lgsg dipanggil melalui object Kalkulator
        // Tapi pake object Rumus (rumus.tampil)
        public void tampil()
        {
            Console.WriteLine("Hello world");
        }

        public int kali(int a, int b)
        {
            return a * b;
        }
    }

    class Rumus : Kalkulator
    {
        public int persegipanjang(int p, int l)
        {
            return kali(p, l); //method kali didapat dr class Kalkulator
        } 
    }
}
