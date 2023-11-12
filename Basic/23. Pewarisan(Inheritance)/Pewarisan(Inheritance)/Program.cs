// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Pewarisan_Inheritance_;

Rumus rumus = new Rumus();
//rumus.tambah();//menggunakan method dr class Kalkulator, tapi dr class Rumus
//rumus.kurang();

Console.Write("Masukkan panjang sisi : ");
int sisi = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(rumus.persegi(sisi)); ;//menggunakan methodnya sendiri, byukan dr class lain