// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
Console.Write("Masukkan Bulan : ");
int bulan = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan Tanggal : ");
int tgl = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("");
String hasil = ((tgl>0)&&(tgl<32) && (bulan>0)&&(bulan<13) ) ? "Benar" : "Salah";

Console.WriteLine($"Bulan anda = {bulan}\n Tanggal anda = {tgl}\n Hasil : {hasil}");
