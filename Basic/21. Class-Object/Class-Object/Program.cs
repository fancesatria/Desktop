// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//OBJECT 
using Class_Object;

Kalkulator kalku = new Kalkulator();
kalku.tambah();
kalku.kurang();
Console.WriteLine("\n\n");

Console.Write("Masukkan alas : ");
int alas = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan tinggi : ");
int tinggi = Convert.ToInt32(Console.ReadLine());

Rumus rumus = new Rumus();
Console.WriteLine($"Luas segitiga dengan alas {alas}cm dan tinggi {tinggi}cm adalah {rumus.segitiga(alas,tinggi)}cm");
