using OverLoading;

Rumus rumus = new Rumus();
//Console.WriteLine(rumus.persegi(3));
//Console.WriteLine(rumus.persegi(7,5));

Console.Write("Masukkkan panjang sisi persegi : ");
int s = Convert.ToInt32(Console.ReadLine());

Console.Write($"Luas segitiga dg sisi {s} adalah {rumus.persegi(s)}");

Console.WriteLine("\n\n\n");

Console.Write("Masukkkan panjang : ");
int p = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkkan lebar : ");
int l = Convert.ToInt32(Console.ReadLine());

Console.Write($"Luas segitiga dg panjang {p} dan lebar {l} adalah {rumus.persegi(p, l)}");