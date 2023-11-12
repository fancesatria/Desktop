// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Console.Write("Bilangan 1 : ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Bilangan 2 : ");
int b = Convert.ToInt32(Console.ReadLine());
Console.Write("Bilangan 3 : ");
int c = Convert.ToInt32(Console.ReadLine());

int tambah = a + b;
Console.WriteLine($"Tambah : {tambah}");

int kurang = a - b;
Console.WriteLine($"Kurang : {kurang}");

int kali = a * b;
Console.WriteLine($"Kali : {kali}");

int bagi = a / b;
Console.WriteLine($"Bagi : {bagi}");

int modulus = a%b;
Console.WriteLine($"Mudulus : {modulus}");

double pecahan = a / c;
Console.WriteLine($"Pecahan : {pecahan}");
