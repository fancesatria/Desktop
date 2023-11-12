// See https://aka.ms/new-console-template for more information
Console.Write("Masukkan batas awal : ");
int awal = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan batas akhir : ");
int akhir = Convert.ToInt32(Console.ReadLine());

int i, bil;

Console.WriteLine("==== Genap ====");
i = awal;
while(i <= akhir)
{
    if (i % 2 == 0)
    {
        Console.Write(i + " ");
    }
    i++;
}

Console.WriteLine("\n");
Console.WriteLine("==== Ganjil ====");
i = awal;
while(i <= akhir)
{
    if (i % 2 == 1) {
        Console.Write(i + " ");
    };
    i++;
}

Console.WriteLine("\n");
Console.WriteLine("==== Prima ====");
i = awal;
while(i <= akhir)
{
    bil = 0;
    int j = 1;
    while(j <= i)
    {
        if(i%j== 0)
        {
            bil = bil + 1;
        }
        j++;
    }
    if(bil==2)
    {
        Console.Write(i+" ");
    }
    i++;
}
