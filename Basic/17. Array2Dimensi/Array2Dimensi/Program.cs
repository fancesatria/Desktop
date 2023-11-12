// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//Menampilkan semua data dr array 2 dimensi
//string[,] data = { { "Budi","Sedati"}, {"Andi","Betro"}, {"Dini","Pulungan"} };
//for (int i = 0; i < 3; i++)//loop pertama utk meload key
//{
//    for (int j = 0; j < 2; j++)//loop kedua utk meload value
//    {
//        Console.Write(data[i,j]+" ");
//    }
//    Console.WriteLine();//supaya data tam[il kebawah bukan kesamping
//}


//Memasukkan data array dg input user
string[,] buah = new string[4, 2];//lengthnya
for(int i =0; i < 4; i++)//untk memasukkan key
{
    for(int j =0; j < 2; j++)//memasukkan value
    {
        string tampil = j == 0 ? "Buah : " : "Harga : ";//dicek dulu ini key atau value
        Console.Write(tampil);
        buah[i, j] = Console.ReadLine();
    }
}

Console.WriteLine("");
Console.WriteLine("==== Hasil Menu Buah ====");
for(int i = 0; i < 4; i++)
{
    for (int j = 0;  j < 2; j++)
    {
        Console.Write(buah[i,j]+" ");
    }

    Console.WriteLine();
}
