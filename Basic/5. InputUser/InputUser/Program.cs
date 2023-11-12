// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Console.Write("Masukkan nama anda : ");
string nama = Console.ReadLine();

Console.Write("Masukkan usia anda : ");
int umur = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan berat badan anda : \n\n");
double berat = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Data inputan");
Console.WriteLine(nama);
Console.WriteLine(umur);
Console.WriteLine(berat);