// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

int kkm = 80;

Console.Write("Masukkan nilai anda : ");
int nilai = Convert.ToInt32(Console.ReadLine());

bool hasil = nilai >= kkm;
Console.WriteLine($"NIlai anda = {nilai},\n Nilai minimum = {kkm},\n LULUS = {hasil}");
