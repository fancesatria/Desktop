using Abstract;

Rumus rumus = new Rumus();
rumus.tampil();

Console.Write("Masukkan panjang : ");
int p = Convert.ToInt32(Console.ReadLine());

Console.Write("Masukkan lebar : ");
int l = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(rumus.persegipanjang(p,l));