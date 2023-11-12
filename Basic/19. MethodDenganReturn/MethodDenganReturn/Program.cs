// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

int tampil()
{
    Console.Write("Masukkan bil 1 : ");
    int bil1 = Convert.ToInt32(Console.ReadLine());
    
    Console.Write("Masukkan bil 2 : ");
    int bil2 = Convert.ToInt32(Console.ReadLine());

    int hasil = bil1 + bil2;
    return hasil;
}

//tampil(); //kalau lgsg dipanggil gini nnti gk akan ngereturn hasil, jadi harus di cw dulu
Console.WriteLine(tampil());

