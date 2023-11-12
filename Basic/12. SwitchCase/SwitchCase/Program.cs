// See https://aka.ms/new-console-template for more information
Console.Write("Masukkan bilangan 1 : ");
int bil1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan bilangan 2 : ");
int bil2 = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan Menu < 1 s.d 4 > : ");
int menu = Convert.ToInt32(Console.ReadLine());

switch (menu)
{
    case 1:
        Console.WriteLine(bil1 + bil2);
        break;

    case 2:
        Console.WriteLine(bil1 - bil2);
        break;

    case 3:
        Console.WriteLine(bil1 * bil2);
        break;

    case 4:
        Console.WriteLine(bil1/bil2);
        break;
        
    default:
    Console.WriteLine("Menu tidak ada");
    break;


}

