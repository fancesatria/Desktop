// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//string[] menu = {"Sop","Bakso","Es Buah", "Kue","Rujak"};
////Menampilkan semua array
//for(int i = 0; i < menu.Length; i++)
//{
//    Console.WriteLine(menu[i]);
//}

//Mengubah isi salah satu array
//menu[0] = "Jajan";
//Console.WriteLine(menu[0]);
//for (int i = 0; i < menu.Length; i++)
//{
//    Console.WriteLine(menu[i]);
//}


//Menambahkan data array dengan input user
string[] teman = new string[4];
for (int i = 0;i <= 3; i++)
{
    Console.Write($"Teman {i} : ");
    teman[i] = Console.ReadLine();
}


//Menampilkan data array yang sudah dimasukan 
Console.WriteLine($"Nama nyang dimasukkan : ");
for (int i =0; i <= 3; i++)
{
    Console.WriteLine(teman[i]);
}
