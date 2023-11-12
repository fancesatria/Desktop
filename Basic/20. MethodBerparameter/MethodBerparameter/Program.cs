// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

bool tgl(int tgl)
{
    if(tgl > 0 && tgl< 32)
    {
        return true;
    } else
    {
        return false;
    }
}

Console.WriteLine(tgl(5)) ;
