// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


Console.Write("Masukkan bulan : ");
int bulan = Convert.ToInt32(Console.ReadLine());
bool validateB = (bulan > 0)&&(bulan < 13);
Console.WriteLine($"Bulan inputan : {bulan}, VALIDASI : {validateB}");

Console.Write("Masukkan tanggal : ");
int tgl = Convert.ToInt32(Console.ReadLine());
bool validateT = (tgl > 0)&&(tgl < 32);
Console.WriteLine($"Tanggal inputan : {tgl}, VALIDASI : {validateT}");
