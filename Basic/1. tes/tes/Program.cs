// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//string[] arr = { "Kl123", "78hd", "ghgh^&", "kKL09", "fgff" };
//Random ran = new Random();
//Console.WriteLine(arr[ran.Next(0,5)]);

int i = 20;
string txt = "";

if(i <= 10)
{
    txt = "BOOK000" + i;
} else if(i >= 100)
{
    txt = "BOOK0" + i;
} else if(i < 100 || i > 10)
{
    txt = "BOOK00" + i;
} else
{
    txt = "BOOK0" + i;
}

Console.Write(txt);