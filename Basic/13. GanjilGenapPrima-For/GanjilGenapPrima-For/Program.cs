// See https://aka.ms/new-console-template for more information

Console.Write("Masukkan batas awal : ");
int awal = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan batas akhir : ");
int akhir = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("==== BILANGAN GENAP ===="); 
for(int i = awal; i < akhir; i++)
{
    if (i%2 == 0) // genap = habis dibagi 2
    {
        Console.Write(i+" ");
    }
}


Console.WriteLine();
Console.WriteLine("==== BILANGAN GANJIL");
for(int i = awal; i < akhir; i++)
{
    if (i%2 == 1)
    {
        Console.Write(i+" ");
    }
}


Console.WriteLine();
Console.WriteLine("==== BILANGAN PRIMA ====");
int bil;
for(int i = awal; i <= akhir; i++)
{
    bil = 0;
    for (int j = 1; j <= i; j++)
    {
        if (i% j == 0)
        {
            bil = bil + 1;
            
        }
    }

    if (bil == 2)
    {
        Console.Write(i + " ");
    }
}