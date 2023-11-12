using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{
    class Kalkulator
    {
        private double b1, b2;
        // 1. Constructor lgsg berjalan saat membuat object, jadi tanpa dipanggilpun bakal tampil di console(klo pake cw)
        // 2. Tak perlu pakai void, static, atau tipe data
        // 3. Nama constructor hrs sama dg nama class
        public Kalkulator(double a, double b) { 
            b1 = a; 
            b2 = b;
        }

        public double hitung(char opr)
        {
            double hasil;

            switch (opr)
            {
                case '+':
                    hasil = b1 + b2;
                    break;
                case '-':
                    hasil = b1 - b2;
                    break;
                case '*':
                    hasil = b1 * b2;
                    break;
                case '/':
                    hasil = b1 / b2;
                    break;
                case '%':
                    hasil = b1 % b2;
                    break;
                default:
                    hasil = 0;
                    break;

            }
            return hasil;
        }
    }
}
