// See https://aka.ms/new-console-template for more information
using Constructor;

Console.Write("Masukkan bil 1 : ");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan bil 2 : ");
int b = Convert.ToInt32(Console.ReadLine());

Kalkulator kalkulator = new Kalkulator(a, b);

Console.Write("Masukkan operasi < +, -, *, /, % > : ");
char opr = Convert.ToChar(Console.ReadLine());

Console.WriteLine(kalkulator.hitung(opr));

