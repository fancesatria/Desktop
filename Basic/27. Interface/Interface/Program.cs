using Interface;

Kalkulator kalkulator = new Kalkulator();
kalkulator.judul("Ini interface");

Console.WriteLine(kalkulator.kali(4, 5));
Console.WriteLine(kalkulator.bagi(64, 8));

Console.Write("Masukkan bil 1 : ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Masukkan bil 2 : ");
int b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(kalkulator.kali(a,b));