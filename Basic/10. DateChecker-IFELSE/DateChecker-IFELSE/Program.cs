// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string hasil;

Console.Write("Masukkan bulan : ");
int bulan = Convert.ToInt32(Console.ReadLine());
Console.Write("MAsukkkan tanggal : ");
int tgl = Convert.ToInt32(Console.ReadLine());

if (tgl > 0 && tgl < 32 && bulan > 0 && bulan < 13)
{
    hasil = "Data valid";
} else
{
    hasil = "Dat atidak valid";
}

Console.WriteLine("=== Hasil ====");
Console.WriteLine($"Bulan = {bulan}\n Tanggal = {tgl} \n Hasil = {hasil}");
