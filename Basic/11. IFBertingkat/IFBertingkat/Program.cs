// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

int kkm = 80;
Console.Write("Masukkan nilai : ");
int nilai = Convert.ToInt32(Console.ReadLine());

if (nilai >= 0 && nilai <= 100)
{
    if (nilai >= kkm)
    {
        Console.WriteLine("Anda Lulus");
    } else
    {
        Console.WriteLine("Anda Tidak Lulus");
    }
} else
{
    Console.WriteLine("Nili tidak valid");
}
